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

        public DiffLineStatus Status
        {
            get; private set;
        }

        public int Number
        {
            get; private set;
        }

        public string Content
        {
            get; private set;
        }
    }
}