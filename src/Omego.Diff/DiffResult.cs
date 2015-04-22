using System;
using System.Collections.Generic;
using System.Linq;

namespace Omego.Diff
{
    public class DiffResult
    {
        public string FileName { get; private set; }
        public IList<DiffLine> Lines { get; private set; }

        private DiffResult(string fileName, IList<DiffLine> lines)
        {
            FileName = fileName;
            Lines = lines;
        }

        public static IEnumerable<DiffResult> FromReader(DiffReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            var records = reader.ReadAll().ToList();
            var diffs = new List<DiffResult>();

            var files = records.GroupBy(record => record.Id);
            foreach (var file in files)
            {
                var fileName = file.Single(record => 
                    record.ContainsKey(DiffProperty.FileName)).Property<string>(DiffProperty.FileName);

                var lines =
                    file.Where(record => record.ContainsKey(DiffProperty.LineStatus))
                        .Select(record => new DiffLine(record.Property<DiffLineStatus>(DiffProperty.LineStatus),
                            record.Property<int>(DiffProperty.LineNumber),
                            record.Property<string>(DiffProperty.LineContent)));

                diffs.Add(new DiffResult(fileName, lines.ToArray()));
            }

            return diffs;
        }
    }
}