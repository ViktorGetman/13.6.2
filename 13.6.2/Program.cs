using System;
using System.Collections.Generic;
using System.IO;

namespace PopularWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Укажите ссылку на ваш текстовый файл");
            var fileLink = Console.ReadLine();
            if (!File.Exists(fileLink))
            {
                Console.WriteLine("Файл не найден");
                return;
            }

            string text = File.ReadAllText(fileLink);
            string[] words = text.Split(new char[] { ' ', '\n', '\r', '.', ',', '!', '?', ';', ':', '-', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;
                }
                else
                {
                    wordCounts.Add(word, 1);
                }
            }

            List<KeyValuePair<string, int>> sortedWords = new List<KeyValuePair<string, int>>(wordCounts);
            sortedWords.Sort((x, y) => y.Value.CompareTo(x.Value));

            Console.WriteLine("10 самых популярных слов:");
            for (int i = 0; i < 10 && i < sortedWords.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedWords[i].Key} - {sortedWords[i].Value} раз");
            }
        }
    }
}

