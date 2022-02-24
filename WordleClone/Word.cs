using System;
using System.Collections;
using System.Collections.Generic;
namespace WordleClone
{
    public class Word
    {
        public string word;
        private int wordLength;

        public Word()
        {
            word = "";
            wordLength = 0;
        }

        public Word(int wordLength)
        {
            word = "";
            this.wordLength = wordLength;
        }

        public Word(string word)
        {
            this.word = word;
            this.wordLength = word.Length;
        }

        public void AddLetter(string letter)
        {
            if (word.Length >= wordLength) return;

            word += letter;
        }

        public void RemoveLetter()
        {
            if (word.Length == 0) return;

            word = word.Remove(word.Length - 1);
        }

        public bool IsFull()
        {
            return word.Length == wordLength;
        }

        public bool Matches(String newWord)
        {
            return word == newWord;
        }

        public List<char> MissingLetters(String opposingWord)
        {
            List<char> chars = new List<char>();
            for (int i = 0; i < word.Length; i++)
            {
                chars.Add(word[i]);
            }

            for (int i = 0; i < opposingWord.Length; i++)
            {
                chars.Remove(opposingWord[i]);
            }
            return chars;
        }

        public List<char> MissingLetters(String opposingWord, int index)
        {
            List<char> chars = new List<char>();
            for (int i = 0; i < word.Length; i++)
            {
                chars.Add(word[i]);
            }

            for (int i = 0; i < opposingWord.Length; i++)
            {
                if (i != index)
                {
                    chars.Remove(opposingWord[i]);
                }
            }
            return chars;
        }
    }
}
