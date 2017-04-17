using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Task3
{
    /// <summary>
    /// Provides methods to count the frequency usage of each word.
    /// </summary>
    public static class WordFrequencyCounter
    {

        #region Public Methods

        /// <summary>
        /// Counts the frequency usage of each word.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>Dictionary of words frequencies occurence in the file.</returns>
        /// <exception cref="System.IO.FileNotFoundException">path</exception>
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

        /// <summary>
        /// Counts the frequency usage of each word.
        /// </summary>
        /// <param name="matches">Represents the set of successful matches.</param>
        /// <returns>Dictionary of frequencies of words occurence in the file.</returns>
        /// <exception cref="System.ArgumentNullException">matches</exception>
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

        #endregion

    }
}
