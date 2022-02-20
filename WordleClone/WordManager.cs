using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace WordleClone
{
    public class WordManager
    {
        private List<string> words;
        private List<string> answers;

        public WordManager()
        {
            words = GetAllWordsFromFile();
            answers = GetRandomizedCorrectAnswersFromFile();
        }


        public bool IsValidWord(string word)
        {
            if (words.Contains(word.ToLower()))
                return true;

            return false;
        }

        public string GetAnswer(int day)
        {
            return answers[day];
        }

        private void PrintAllWordsFromFile()
        {
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }

        private List<string> GetAllWordsFromFile()
        { 
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(WordManager)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("WordleClone.KnownWords5.wordle-allowed-guesses.txt");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }

            var wordList = text.Split('\n');

            return new List<string>(wordList);
        }

        private List<string> GetRandomizedCorrectAnswersFromFile()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(WordManager)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("WordleClone.KnownWords5.wordle-answers-randomized.txt");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }

            var wordList = text.Split('\n');

            return new List<string>(wordList);
        }
    }
}
