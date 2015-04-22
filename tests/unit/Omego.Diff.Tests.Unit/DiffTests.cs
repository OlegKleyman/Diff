using System;
using System.Collections;
using System.Collections.Generic;

namespace Omego.Diff.Tests.Unit
{
    using System.Linq;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class DiffTests
    {
        private readonly Mock<DiffReader> mockDiffReader = new Mock<DiffReader>();

        [TestFixtureSetUp]
        public void Setup()
        {
            var records = new List<DiffRecord>()
            {
                new DiffRecord(1, new Dictionary<DiffProperties, object>
                {
                    {DiffProperties.FileName, "README.md"}
                }),
                new DiffRecord(1, GetLineStatus("### Well hello there!", 1, DiffLineStatus.Unchanged)),
                new DiffRecord(1, GetLineStatus("THIS IS YB's 1ST CHANGE", 2, DiffLineStatus.Addition)),
                new DiffRecord(1, GetLineStatus(string.Empty, 3, DiffLineStatus.Unchanged)),
                new DiffRecord(1, GetLineStatus("This repository is meant to provide an example for *forking* a repository on GitHub.",
                    4,
                    DiffLineStatus.Unchanged)),
                new DiffRecord(1, GetLineStatus(string.Empty, 5, DiffLineStatus.Unchanged)),
                new DiffRecord(1, GetLineStatus("After forking this repository, you can make some changes to the project, and submit ["
                    + "a Pull Request](https://github.com/octocat/Spoon-Knife/pulls) as practice.",
                    8,
                    DiffLineStatus.Unchanged)),
                new DiffRecord(1, GetLineStatus(string.Empty, 9, DiffLineStatus.Unchanged)),
                new DiffRecord(1, GetLineStatus("For some more information on how to fork a repository, [check out our guide,"
                    + " \"Forking Projects\"\"](http://guides.github.com/overviews/forking/). Thanks! :sparkling_heart:", 
                    10,
                    DiffLineStatus.Unchanged)),
                new DiffRecord(1, GetLineStatus(string.Empty, 11, DiffLineStatus.Addition)),
                new DiffRecord(1, GetLineStatus("2ND CHANGE IS HERE...", 12, DiffLineStatus.Addition)),
                
                new DiffRecord(2, new Dictionary<DiffProperties, object>
                {
                    {DiffProperties.FileName, "index.html"}
                }),
                new DiffRecord(2, GetLineStatus("<html>", 3, DiffLineStatus.Unchanged)),
                new DiffRecord(2, GetLineStatus("<head>", 4, DiffLineStatus.Unchanged)),
                new DiffRecord(2, GetLineStatus("  <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"/>",
                    5,
                    DiffLineStatus.Unchanged)),
                new DiffRecord(2, GetLineStatus("  <title>Spoon-Knife</title>", 6, DiffLineStatus.Removed)),
                new DiffRecord(2, GetLineStatus("  <title>Spoon-Knife(YB here)</title>", 6, DiffLineStatus.Addition)),
                new DiffRecord(2, GetLineStatus("  <LINK href=\"styles.css\" rel=\"stylesheet\" type=\"text/css\">",
                    7,
                    DiffLineStatus.Unchanged)),
                new DiffRecord(2, GetLineStatus("</head>", 8, DiffLineStatus.Unchanged)),
                new DiffRecord(2, GetLineStatus(string.Empty, 9, DiffLineStatus.Unchanged)),
                new DiffRecord(2, GetLineStatus(string.Empty, 11, DiffLineStatus.Unchanged)),
                new DiffRecord(2, GetLineStatus("<img src=\"forkit.gif\" id=\"octocat\" alt=\"\" />", 12, DiffLineStatus.Unchanged)),
                new DiffRecord(2, GetLineStatus(string.Empty, 13, DiffLineStatus.Unchanged)),
                new DiffRecord(2, GetLineStatus("<!-- Feel free to change this text here -->", 14, DiffLineStatus.Removed)),
                new DiffRecord(2, GetLineStatus("<!-- Feel free to change this text here", 14, DiffLineStatus.Addition)),
                new DiffRecord(2, GetLineStatus("3RD CHANGE APPEARS -->", 15, DiffLineStatus.Addition)),
                new DiffRecord(2, GetLineStatus("<p>", 16, DiffLineStatus.Unchanged)),
                new DiffRecord(2, GetLineStatus("  Fork me? Fork you, @octocat!", 17, DiffLineStatus.Unchanged)),
                new DiffRecord(2, GetLineStatus("</p>", 18, DiffLineStatus.Unchanged))
            };
            mockDiffReader.Setup(reader => reader.ReadAll()).Returns(records);
        }

        private static Dictionary<DiffProperties, object> GetLineStatus(string content, int number, DiffLineStatus status)
        {
            return new Dictionary<DiffProperties, object>
            {
                {DiffProperties.LineContent, content},
                {DiffProperties.LineNumber, number},
                {DiffProperties.LineStatus, status}
            };
        }

        [Test]
        public void FromReaderShouldReturnGitDiff()
        {
            var diff = DiffResult.FromReader(mockDiffReader.Object).ToArray();

            Assert.That(diff, Is.Not.Null);
            Assert.That(diff.Length, Is.EqualTo(2));

            Assert.That(diff[0].FileName, Is.EqualTo("README.md"));
            Assert.That(diff[0].Lines.Length, Is.EqualTo(10));

            Assert.That(diff[0].Lines[0].Status, Is.EqualTo(DiffLineStatus.Unchanged));
            Assert.That(diff[0].Lines[0].Number, Is.EqualTo(1));
            Assert.That(diff[0].Lines[0].Content, Is.EqualTo("### Well hello there!"));

            Assert.That(diff[0].Lines[1].Status, Is.EqualTo(DiffLineStatus.Addition));
            Assert.That(diff[0].Lines[1].Number, Is.EqualTo(2));
            Assert.That(diff[0].Lines[1].Content, Is.EqualTo("THIS IS YB's 1ST CHANGE"));

            Assert.That(diff[0].Lines[2].Status, Is.EqualTo(DiffLineStatus.Unchanged));
            Assert.That(diff[0].Lines[2].Number, Is.EqualTo(3));
            Assert.That(diff[0].Lines[2].Content, Is.EqualTo(string.Empty));

            Assert.That(diff[0].Lines[3].Status, Is.EqualTo(DiffLineStatus.Unchanged));
            Assert.That(diff[0].Lines[3].Number, Is.EqualTo(4));
            Assert.That(diff[0].Lines[3].Content, Is.EqualTo("This repository is meant to provide an example for *forking* a repository on GitHub."));

            Assert.That(diff[0].Lines[4].Status, Is.EqualTo(DiffLineStatus.Unchanged));
            Assert.That(diff[0].Lines[4].Number, Is.EqualTo(5));
            Assert.That(diff[0].Lines[4].Content, Is.EqualTo(string.Empty));

            Assert.That(diff[0].Lines[5].Status, Is.EqualTo(DiffLineStatus.Unchanged));
            Assert.That(diff[0].Lines[5].Number, Is.EqualTo(8));
            Assert.That(diff[0].Lines[5].Content, Is.EqualTo("After forking this repository, you can make some changes to the project, and submit [a Pull Request](https://github.com/octocat/Spoon-Knife/pulls) as practice."));

            Assert.That(diff[0].Lines[6].Status, Is.EqualTo(DiffLineStatus.Unchanged));
            Assert.That(diff[0].Lines[6].Number, Is.EqualTo(9));
            Assert.That(diff[0].Lines[6].Content, Is.EqualTo(string.Empty));

            Assert.That(diff[0].Lines[7].Status, Is.EqualTo(DiffLineStatus.Unchanged));
            Assert.That(diff[0].Lines[7].Number, Is.EqualTo(10));
            Assert.That(diff[0].Lines[7].Content, Is.EqualTo("For some more information on how to fork a repository, [check out our guide, \"Forking Projects\"\"](http://guides.github.com/overviews/forking/). Thanks! :sparkling_heart:"));

            Assert.That(diff[0].Lines[8].Status, Is.EqualTo(DiffLineStatus.Addition));
            Assert.That(diff[0].Lines[8].Number, Is.EqualTo(11));
            Assert.That(diff[0].Lines[8].Content, Is.EqualTo(string.Empty));

            Assert.That(diff[0].Lines[9].Status, Is.EqualTo(DiffLineStatus.Addition));
            Assert.That(diff[0].Lines[9].Number, Is.EqualTo(12));
            Assert.That(diff[0].Lines[9].Content, Is.EqualTo("2ND CHANGE IS HERE..."));

            Assert.That(diff[1].FileName, Is.EqualTo("index.html"));
            Assert.That(diff[1].Lines.Length, Is.EqualTo(17));

            Assert.That(diff[1].Lines[0].Status, Is.EqualTo(DiffLineStatus.Unchanged));
            Assert.That(diff[1].Lines[0].Number, Is.EqualTo(3));
            Assert.That(diff[1].Lines[0].Content, Is.EqualTo("<html>"));

            Assert.That(diff[1].Lines[1].Status, Is.EqualTo(DiffLineStatus.Unchanged));
            Assert.That(diff[1].Lines[1].Number, Is.EqualTo(4));
            Assert.That(diff[1].Lines[1].Content, Is.EqualTo("<head>"));

            Assert.That(diff[1].Lines[2].Status, Is.EqualTo(DiffLineStatus.Unchanged));
            Assert.That(diff[1].Lines[2].Number, Is.EqualTo(5));
            Assert.That(diff[1].Lines[2].Content, Is.EqualTo("  <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"/>"));

            Assert.That(diff[1].Lines[3].Status, Is.EqualTo(DiffLineStatus.Removed));
            Assert.That(diff[1].Lines[3].Number, Is.EqualTo(6));
            Assert.That(diff[1].Lines[3].Content, Is.EqualTo("  <title>Spoon-Knife</title>"));

            Assert.That(diff[1].Lines[4].Status, Is.EqualTo(DiffLineStatus.Addition));
            Assert.That(diff[1].Lines[4].Number, Is.EqualTo(6));
            Assert.That(diff[1].Lines[4].Content, Is.EqualTo("  <title>Spoon-Knife(YB here)</title>"));

            Assert.That(diff[1].Lines[5].Status, Is.EqualTo(DiffLineStatus.Unchanged));
            Assert.That(diff[1].Lines[5].Number, Is.EqualTo(7));
            Assert.That(diff[1].Lines[5].Content, Is.EqualTo("  <LINK href=\"styles.css\" rel=\"stylesheet\" type=\"text/css\">"));

            Assert.That(diff[1].Lines[6].Status, Is.EqualTo(DiffLineStatus.Unchanged));
            Assert.That(diff[1].Lines[6].Number, Is.EqualTo(8));
            Assert.That(diff[1].Lines[6].Content, Is.EqualTo("</head>"));

            Assert.That(diff[1].Lines[7].Status, Is.EqualTo(DiffLineStatus.Unchanged));
            Assert.That(diff[1].Lines[7].Number, Is.EqualTo(9));
            Assert.That(diff[1].Lines[7].Content, Is.EqualTo(string.Empty));

            Assert.That(diff[1].Lines[8].Status, Is.EqualTo(DiffLineStatus.Unchanged));
            Assert.That(diff[1].Lines[8].Number, Is.EqualTo(11));
            Assert.That(diff[1].Lines[8].Content, Is.EqualTo(string.Empty));

            Assert.That(diff[1].Lines[9].Status, Is.EqualTo(DiffLineStatus.Unchanged));
            Assert.That(diff[1].Lines[9].Number, Is.EqualTo(12));
            Assert.That(diff[1].Lines[9].Content, Is.EqualTo("<img src=\"forkit.gif\" id=\"octocat\" alt=\"\" />"));

            Assert.That(diff[1].Lines[10].Status, Is.EqualTo(DiffLineStatus.Unchanged));
            Assert.That(diff[1].Lines[10].Number, Is.EqualTo(13));
            Assert.That(diff[1].Lines[10].Content, Is.EqualTo(string.Empty));

            Assert.That(diff[1].Lines[11].Status, Is.EqualTo(DiffLineStatus.Removed));
            Assert.That(diff[1].Lines[11].Number, Is.EqualTo(14));
            Assert.That(diff[1].Lines[11].Content, Is.EqualTo("<!-- Feel free to change this text here -->"));

            Assert.That(diff[1].Lines[12].Status, Is.EqualTo(DiffLineStatus.Addition));
            Assert.That(diff[1].Lines[12].Number, Is.EqualTo(14));
            Assert.That(diff[1].Lines[12].Content, Is.EqualTo("<!-- Feel free to change this text here"));

            Assert.That(diff[1].Lines[13].Status, Is.EqualTo(DiffLineStatus.Addition));
            Assert.That(diff[1].Lines[13].Number, Is.EqualTo(15));
            Assert.That(diff[1].Lines[13].Content, Is.EqualTo("3RD CHANGE APPEARS -->"));

            Assert.That(diff[1].Lines[14].Status, Is.EqualTo(DiffLineStatus.Unchanged));
            Assert.That(diff[1].Lines[14].Number, Is.EqualTo(16));
            Assert.That(diff[1].Lines[14].Content, Is.EqualTo("<p>"));

            Assert.That(diff[1].Lines[15].Status, Is.EqualTo(DiffLineStatus.Unchanged));
            Assert.That(diff[1].Lines[15].Number, Is.EqualTo(17));
            Assert.That(diff[1].Lines[15].Content, Is.EqualTo("  Fork me? Fork you, @octocat!"));

            Assert.That(diff[1].Lines[16].Status, Is.EqualTo(DiffLineStatus.Unchanged));
            Assert.That(diff[1].Lines[16].Number, Is.EqualTo(18));
            Assert.That(diff[1].Lines[16].Content, Is.EqualTo("</p>"));
        }
    }
}
