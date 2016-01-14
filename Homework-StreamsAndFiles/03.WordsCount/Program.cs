using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        StreamReader words = new StreamReader("../../words.txt");
        StreamReader textReader = new StreamReader("../../text.txt");
        StreamWriter resultWriter = new StreamWriter("../../result.txt");

        using (words)
        {
            using (textReader)
            {
                using (resultWriter)
                {
                    var text = textReader.ReadToEnd().ToLower();
                    var result = new SortedDictionary<int, string>();
                    string word = words.ReadLine();
                    while (word != null)
                    {
                        var pattern = string.Format(@"\b{0}\b", word.ToLower());
                        var match = Regex.Matches(text, pattern);
                        result.Add(match.Count, word);

                        word = words.ReadLine();
                    }
                    foreach (var match in result.Reverse())
                    {
                        resultWriter.WriteLine("word: {0}-> count: {1}", match.Value, match.Key);
                    }
                }
            }
        }
    }
}
