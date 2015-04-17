using System.IO;

namespace Omego.Diff.Stats
{
    /// <summary>
    /// Entry class for application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Driver method for the application.
        /// </summary>
        /// <param name="args">Console arguments.</param>
        public static void Main(string[] args)
        {
            var diff = DiffResult.FromReader(new GitDiffReader(new StreamReader(args[0]).ReadToEnd()));
        }
    }
}
