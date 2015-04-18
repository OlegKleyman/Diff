namespace Omego.Diff
{
    public class DiffLine
    {
        public DiffLineStatus Status { get; private set; }
        public int Number { get; private set; }
        public string Content { get; private set; }
    }
}