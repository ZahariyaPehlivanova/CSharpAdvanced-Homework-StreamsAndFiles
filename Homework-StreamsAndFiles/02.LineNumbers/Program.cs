using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class Program
{
    static void Main()
    {
        StreamReader stream = new StreamReader("../../text.txt");
        StreamWriter writer = new StreamWriter("../../result.txt");

        using (stream)
        {
            using (writer)
            {
                int lineCount = 0;
                string line = stream.ReadLine();
                while (line != null)
                {
                    lineCount++;
                    writer.WriteLine(string.Format("Line {0}: {1}", lineCount, line));
                    line = stream.ReadLine();
                }
            }
        }
    }
}
