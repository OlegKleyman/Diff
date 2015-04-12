using Xbehave;

namespace Omego.Diff.Tests.Integration.Features
{
    public class DiffExampleFeature
    {
        [Scenario()]
        public void GenerateDiffStats()
        {
            "Given I have git diff file".f(() => { }).Skip("Step to be implemented");
            "When I run Omego.Diff".f(() => { }).Skip("Step to be implemented");
            "Then I should se the git diff stats".f(() => { }).Skip("Step to be implemented");
        }
    }
}
