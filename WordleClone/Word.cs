using System;
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
    }
}
