using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Xbehave;
using FluentAssertions;

namespace Omego.Diff.Tests.Integration.Features
{
    public class DiffExampleFeature
    {
        [Scenario()]
        public void GenerateDiffStats()
        {
            var gitDiff = default(string);

            "Given I have git diff file".f(() => gitDiff = Path.GetFullPath(@"Resources\Test.diff"));

            var startInfo = new ProcessStartInfo("Omego.Diff.Stats.exe", gitDiff)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false
            };

            var process = new Process()
            {
                StartInfo = startInfo
            };

            "When I run Omego.Diff".f(() => process.Start());

            var lines = new List<string>();
            while (!process.StandardOutput.EndOfStream)
            {
                lines.Add(process.StandardOutput.ReadLine());
            }

            "Then I should se the git diff stats".f(() => lines.Should().HaveCount(3)).Skip("Production code not yet implemented");
        }
    }
}
