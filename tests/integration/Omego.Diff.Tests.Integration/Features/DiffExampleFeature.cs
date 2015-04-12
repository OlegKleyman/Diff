using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using Xbehave;

namespace Omego.Diff.Tests.Integration.Features
{
    public class DiffExampleFeature
    {
        [Scenario()]
        public void GenerateDiffStats()
        {
            var gitDiff = default(string);

            "Given I have git diff file".f(() => gitDiff = Path.GetFullPath(@"Resources\Test.diff"));
            "When I run Omego.Diff".f(() => Process.Start("Omego.Diff.Stats.exe", gitDiff));
            "Then I should se the git diff stats".f(() => { }).Skip("Step to be implemented");
        }
    }
}
