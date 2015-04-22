using System;

namespace Omego.Diff
{
    public class DiffLine
    {
        public DiffLine(DiffLineStatus status, int number, string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }
            
            Status = status;
            Number = number;
            Content = content;
        }

        public DiffLineStatus Status { get; private set; }
        public int Number { get; private set; }
        public string Content { get; private set; }
    }
}
/*
 * Assert.That(diff[0].Lines[1].Status, Is.EqualTo(DiffLineStatus.Addition));
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
            Assert.That(diff[1].Lines.Length, Is.EqualTo(5));

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
            Assert.That(diff[1].Lines[3].Content, Is.EqualTo(" <title>Spoon-Knife</title>"));

            Assert.That(diff[1].Lines[4].Status, Is.EqualTo(DiffLineStatus.Addition));
            Assert.That(diff[1].Lines[4].Number, Is.EqualTo(6));
            Assert.That(diff[1].Lines[4].Content, Is.EqualTo(" <title>Spoon-Knife(YB here)</title>"));

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

*/