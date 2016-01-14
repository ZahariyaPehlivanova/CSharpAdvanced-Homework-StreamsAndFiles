using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "../../dog.jpg";
        string copyPath = "../../copy.txt";
        FileStream file = new FileStream(filePath, FileMode.Open);
        FileStream copy = new FileStream(copyPath, FileMode.Open);

        using (file)
        {
            using (copy)
            {
                byte[] buffer = new byte[4096];
                while (true)
                {
                    int readBytes = file.Read(buffer, 0, buffer.Length);
                    if (readBytes == 0)
                    {
                        break;
                    }
                    else
                    {
                        copy.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}