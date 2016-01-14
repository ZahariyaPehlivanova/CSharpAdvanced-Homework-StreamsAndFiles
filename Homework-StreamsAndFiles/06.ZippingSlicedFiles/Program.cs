using System;
using System.IO;
using System.IO.Compression;

class ZippingSlicingFile
{
    const string filePath = "../../text.txt";
    const string result = "../../result.txt";

    private static void Main()
    {
        Console.Write("Write how many parts: ");
        int parts = int.Parse(Console.ReadLine());
        SliceFile(parts);
        for (int i = 0; i < parts; i++)
        {
            ZippingFiles(i);
        }
    }

    private static void ZippingFiles(int i)
    {
        using (var source = new FileStream(string.Format("../../Part-{0}.txt", i), FileMode.Open))
        {
            using (var zip = new GZipStream(source, CompressionMode.Decompress))
            {
                using (var destination = new FileStream(result, i == 0 ? FileMode.Create : FileMode.Append))
                {
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        int readBytes = zip.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        destination.Write(buffer, 0, readBytes);
                    }
                }
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
                    using (var zip = new GZipStream(destination, CompressionMode.Compress, false))
                    {
                        if (i < parts - 1)
                        {
                            sliceSize += leftOver;
                        }
                        var buffer = new byte[sliceSize];
                        source.Read(buffer, 0, buffer.Length);
                        zip.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}