using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task3
{
    public static class WordFrequencyCounter
    {

        public static Dictionary<string, int> Counter(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"{nameof(path)} does not exist.");

            using (FileStream fs = File.OpenRead(path))
            {
                using (TextReader reader = new StreamReader(fs))
                {
                    const string pattern = @"[А-яЁёA-z]{1,}";
                    var text = reader.ReadToEnd();
                    MatchCollection matches = Regex.Matches(text, pattern);

                    return Counter(matches);
                }
            }
        }

        public static Dictionary<string, int> Counter(MatchCollection matches)
        {
            if (ReferenceEquals(matches, null))
                throw new ArgumentNullException($"{nameof(matches)}");

            var dictionaryCounter = new Dictionary<string, int>();

            foreach (Match match in matches)
            {
                string word = match.Value.ToLowerInvariant();
                if (dictionaryCounter.ContainsKey(word))
                    dictionaryCounter[word]++;
                else
                    dictionaryCounter.Add(word, 1);
            }

            return dictionaryCounter;
        }
    }
}
