using System.Collections.Generic;

namespace Omego.Diff
{
    public abstract class DiffReader
    {
        public abstract IEnumerable<DiffRecord> ReadAll();
    }
}