using System;
using System.IO;

class Program
{
    static void Main()
    {
        StreamReader stream = new StreamReader("../../text.txt");
        using (stream)
        {
            int lineNumber = 0;
            string line;
           // string line = stream.ReadLine();
            while ((line = stream.ReadLine()) != null)
             {
                lineNumber++;
                if ( lineNumber % 2 == 1)
                {
                    Console.WriteLine("Line:{0} Text: {1}", lineNumber, line);
                    Console.WriteLine("--------");
                    
                }
            }
        }

    }
}
