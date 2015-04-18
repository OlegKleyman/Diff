namespace Omego.Diff
{
    public class DiffResult
    {
        public static DiffResult[] FromReader(DiffReader reader)
        {
            throw new System.NotImplementedException();
        }

        public string FileName { get; private set; }
        public DiffLine[] Lines { get; private set; }
    }
}