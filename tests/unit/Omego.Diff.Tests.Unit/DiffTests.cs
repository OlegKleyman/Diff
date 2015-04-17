using NUnit.Framework;

namespace Omego.Diff.Tests.Unit
{
    [TestFixture]
    public class DiffTests
    {
        [Test]
        public void FromReaderShouldReturnGitDiff()
        {
            var diff = DiffResult.FromReader(new GitDiffReader(""));
        }
    }
}
