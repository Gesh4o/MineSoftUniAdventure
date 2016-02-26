namespace _03.WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WordCountMain
    {
        public static void Main(string[] args)
        {
            string wordsToSearchPath = "words.txt";
            string[] wordsToSearch = { "quick", "is", "fault" };
            SetWordsToSearch(wordsToSearchPath, wordsToSearch);

            string textToSearchInPath = "text.txt";
            string textToSearchIn = @"-I was quick to judge him, but it wasn't his fault.
- Is this some kind of joke?!Is it ?
-Quick, hide here…It is safer.";
            SetTextToSearchIn(textToSearchInPath, textToSearchIn);

            string[] words = GetWordsToSearch(wordsToSearchPath);
            string text = GetTextToSearchIn(textToSearchInPath);

            Dictionary<string, int> wordsByCount = new Dictionary<string, int>();

            GetWordsAndCounts(words, text, wordsByCount);

            wordsByCount = wordsByCount.OrderByDescending(w => w.Value).ThenBy(w => w.Key).ToDictionary(w => w.Key, w => w.Value);

            SetResult(wordsByCount);
        }

        private static void SetWordsToSearch(string wordsToSearchPath, string[] wordsToSearch)
        {
            using (StreamWriter streamWriter = new StreamWriter(wordsToSearchPath, false))
            {
                foreach (string word in wordsToSearch)
                {
                    streamWriter.WriteLine(word);
                }
            }
        }

        private static void SetTextToSearchIn(string textToSearchInPath, string textToSearchIn)
        {
            using (StreamWriter streamWriter = new StreamWriter(textToSearchInPath, false))
            {
                streamWriter.WriteLine(textToSearchIn);
            }
        }

        private static string[] GetWordsToSearch(string wordsToSearchPath)
        {
            string[] words;
            using (StreamReader streamReader = new StreamReader(wordsToSearchPath))
            {
                words = streamReader.ReadToEnd().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            return words;
        }

        private static string GetTextToSearchIn(string textToSearchInPath)
        {
            string text = string.Empty;
            using (StreamReader textStreamReader = new StreamReader(textToSearchInPath))
            {
                text = textStreamReader.ReadToEnd();
            }

            return text;
        }

        private static void GetWordsAndCounts(string[] words, string text, Dictionary<string, int> wordsByCount)
        {
            foreach (string word in words)
            {
                Regex regex = new Regex("[\\W+]" + word + "[\\W+]", RegexOptions.IgnoreCase);
                int matchesCount = regex.Matches(text).Count;

                wordsByCount.Add(word, matchesCount);
            }
        }

        private static void SetResult(Dictionary<string, int> wordsByCount)
        {
            string resultPath = "result.txt";
            using (StreamWriter streamWriter = new StreamWriter(resultPath))
            {
                foreach (KeyValuePair<string, int> wordPair in wordsByCount)
                {
                    streamWriter.WriteLine("{0}-{1}", wordPair.Key, wordPair.Value);
                }
            }
        }
    }
}
