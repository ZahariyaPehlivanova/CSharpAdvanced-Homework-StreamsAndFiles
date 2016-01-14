using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string resultPath = "../../result.txt";
            StreamWriter result = new StreamWriter(resultPath, false);

            string pathCurrent = Directory.GetCurrentDirectory();
            string[] filePaths = Directory.GetFiles(pathCurrent);

            List<FileInfo> files = filePaths.Select(path => new FileInfo(path)).ToList();
            var sorted =
           files.OrderBy(file => file.Length).
           GroupBy(file => file.Extension).
           OrderByDescending(group => group.Count()).
           ThenBy(group => group.Key);

            using (result) 
            {
                foreach (var group in sorted)
                {
                    result.WriteLine(group.Key);

                    foreach (var info in group)
                    {
                        result.WriteLine("--{0} - {1:F3}kb", info.Name, info.Length / 1024.0);
                    }
                }
            }
        }
    }
}
