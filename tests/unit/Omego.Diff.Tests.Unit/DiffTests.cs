namespace Omego.Diff.Tests.Unit
{
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class DiffTests
    {
        private readonly Mock<DiffReader> mockDiffReader = new Mock<DiffReader>();

        [Test]
        public void FromReaderShouldReturnGitDiff()
        {
            var diff = DiffResult.FromReader(mockDiffReader.Object);
            Assert.That(diff, Is.Not.Null);
            Assert.That(diff.Length, Is.EqualTo(2));
            
            Assert.That(diff[0].FileName, Is.EqualTo("README.md"));
            Assert.That(diff[0].Lines.Length, Is.EqualTo(3));

            Assert.That(diff[0].Lines[0].Status, Is.EqualTo(DiffLineStatus.Addition));
            Assert.That(diff[0].Lines[0].Number, Is.EqualTo(2));
            Assert.That(diff[0].Lines[0].Content, Is.EqualTo("THIS IS YB's 1ST CHANGE"));

            Assert.That(diff[0].Lines[1].Status, Is.EqualTo(DiffLineStatus.Addition));
            Assert.That(diff[0].Lines[1].Number, Is.EqualTo(11));
            Assert.That(diff[0].Lines[1].Content, Is.EqualTo(string.Empty));

            Assert.That(diff[0].Lines[1].Status, Is.EqualTo(DiffLineStatus.Addition));
            Assert.That(diff[0].Lines[1].Number, Is.EqualTo(12));
            Assert.That(diff[0].Lines[1].Content, Is.EqualTo("2ND CHANGE IS HERE..."));

            Assert.That(diff[1].FileName, Is.EqualTo("index.html"));
            Assert.That(diff[1].Lines.Length, Is.EqualTo(5));

            Assert.That(diff[1].Lines[0].Status, Is.EqualTo(DiffLineStatus.Removed));
            Assert.That(diff[1].Lines[0].Number, Is.EqualTo(6));
            Assert.That(diff[1].Lines[0].Content, Is.EqualTo("  <title>Spoon-Knife</title>"));

            Assert.That(diff[1].Lines[1].Status, Is.EqualTo(DiffLineStatus.Addition));
            Assert.That(diff[1].Lines[1].Number, Is.EqualTo(6));
            Assert.That(diff[1].Lines[1].Content, Is.EqualTo("  <title>Spoon-Knife(YB here)</title>"));

            Assert.That(diff[1].Lines[2].Status, Is.EqualTo(DiffLineStatus.Removed));
            Assert.That(diff[1].Lines[2].Number, Is.EqualTo(4));
            Assert.That(diff[1].Lines[2].Content, Is.EqualTo("<!-- Feel free to change this text here -->"));

            Assert.That(diff[1].Lines[3].Status, Is.EqualTo(DiffLineStatus.Addition));
            Assert.That(diff[1].Lines[3].Number, Is.EqualTo(4));
            Assert.That(diff[1].Lines[3].Content, Is.EqualTo("<!-- Feel free to change this text here"));

            Assert.That(diff[1].Lines[4].Status, Is.EqualTo(DiffLineStatus.Addition));
            Assert.That(diff[1].Lines[4].Number, Is.EqualTo(5));
            Assert.That(diff[1].Lines[4].Content, Is.EqualTo("3RD CHANGE APPEARS -->"));
        }
    }
}
