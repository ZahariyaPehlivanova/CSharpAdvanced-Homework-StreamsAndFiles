using System;
using System.IO;

class SlicingFile
{
    const string filePath = "../../text.txt";
    const string assemblePath = "../../result.txt";

    private static void Main()
    {
        Console.Write("Write how many parts:");
        int parts = int.Parse(Console.ReadLine());

        SliceFile(parts);
        for (int i = 0; i < parts; i++)
        {
            Files(i);
        }
    }

    private static void Files(int i)
    {
        using (var source = new FileStream(string.Format("../../Part-{0}.txt", i), FileMode.Open))
        {
            using (var destination = new FileStream(assemblePath, i == 0 ? FileMode.Create : FileMode.Append))
            {
                var buffer = new byte[source.Length];
                source.Read(buffer, 0, buffer.Length);
                destination.Write(buffer, 0, buffer.Length);
            }
        }
    }

    private static void SliceFile(int parts)
    {
        using (var source = new FileStream(filePath, FileMode.Open))
        {
            long sliceSize = source.Length / parts;
            long leftOver = source.Length - sliceSize * parts;
            for (int i = 0; i < parts; i++)
            {
                using (var destination = new FileStream(string.Format("../../Part-{0}.txt", i), FileMode.Create))
                {
                    if (i < parts - 1) 
                    {
                        sliceSize += leftOver;
                    }
                    var buffer = new byte[sliceSize];
                    source.Read(buffer, 0, buffer.Length);
                    destination.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}