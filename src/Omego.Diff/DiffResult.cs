using System;
using System.Collections.Generic;
using System.Linq;

namespace Omego.Diff
{
    public class DiffResult
    {
        public string FileName { get; private set; }
        public DiffLine[] Lines { get; private set; }

        private DiffResult(string fileName, IEnumerable<DiffLine> lines)
        {
            FileName = fileName;
            Lines = lines.ToArray();
        }

        public static IEnumerable<DiffResult> FromReader(DiffReader reader)
        {
            var records = reader.ReadAll().ToList();
            var diffs = new List<DiffResult>();

            var files = records.GroupBy(record => record.Id);
            foreach (var file in files)
            {
                var fileName = file.Single(record => 
                    record.ContainsKey(DiffProperties.FileName)).Property<string>(DiffProperties.FileName);

                var lines =
                    file.Where(record => record.ContainsKey(DiffProperties.LineStatus))
                        .Select(record => new DiffLine(record.Property<DiffLineStatus>(DiffProperties.LineStatus),
                            record.Property<int>(DiffProperties.LineNumber),
                            record.Property<string>(DiffProperties.LineContent)));

                diffs.Add(new DiffResult(fileName, lines));
            }

            return diffs;
        }
    }
}