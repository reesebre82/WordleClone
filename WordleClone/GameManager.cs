using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace WordleClone
{
    public class GameManager
    {
        public DateTime STARTING_DATE = new DateTime(2022, 2, 16, 0, 0, 0);
        private WordManager wordManager;
        private Word currentWord;
        private List<string> guesses;
        private Word correctWord;
        MainPage mp;

        private bool canType;

        public GameManager()
        {
            wordManager = new WordManager();
            currentWord = new Word(wordLength: 5);
            guesses = new List<string>();
            correctWord = GetCorrectWord();
            canType = true;
            mp = UIGlobal.MainPage;
        }

        public Word GetCorrectWord()
        {
            int currentDay = (int)(DateTime.Now - STARTING_DATE).TotalDays;
            return new Word(wordManager.GetAnswer(day: currentDay));
        }

        public void AttemptSetLetter(string letter)
        {
            if (!canType) return;
            if (currentWord.IsFull()) return;

            currentWord.AddLetter(letter);
            KeyboardLetterVibrate();
            mp.SetLetter(letter, mp.Labels[guesses.Count, currentWord.word.Length - 1].Item1, mp.Labels[guesses.Count, currentWord.word.Length - 1].Item2);
        }

        public void RemoveLetter()
        {
            if (!canType) return;
            if (currentWord.word.Length == 0) return;

            mp.Labels[guesses.Count, currentWord.word.Length - 1].Item1.BorderColor = ColorManager.IsLightMode() ? Color.LightGray : Color.Gray;
            mp.Labels[guesses.Count, currentWord.word.Length - 1].Item2.Text = null;

            currentWord.RemoveLetter();
        }


        async public void EnterWord()
        {
            if (!canType) return;
            if (currentWord.word.Length != 5) return; 

            // Check if word is a real word, if not return
            if(!wordManager.IsValidWord(currentWord.word)) {
                mp.ShakeLane(guesses.Count);
                Console.WriteLine("Guess not real");
                return;
            }

            // Check Matches to the real word, if so update colors, if not, set to gray
            // TODO: Make sure if a char is in right place, it doesnt show yellow unless a second is there
            string lowercaseWord = currentWord.word.ToLower();
            int correctCount = 0;
            Color[] colorValues = new Color[5];
            for (int i = 0; i < 5; i++)
            {
                await mp.Labels[guesses.Count, i].Item1.RotateXTo(-89, 150);
                if (lowercaseWord[i] == correctWord.word[i])
                {
                    mp.Labels[guesses.Count, i].Item1.BackgroundColor = ColorManager.FrameBackgroundColor(selection: 3);
                    mp.Labels[guesses.Count, i].Item1.BorderColor = Color.Transparent;
                    colorValues[i] = ColorManager.FrameBackgroundColor(selection: 3);
                    correctCount++;
                }
                else if (correctWord.word.Contains(lowercaseWord[i]))
                {
                    if (correctWord.MissingLetters(lowercaseWord, i).Contains(lowercaseWord[i]))
                    {
                        mp.Labels[guesses.Count, i].Item1.BackgroundColor = ColorManager.FrameBackgroundColor(selection: 2);
                        mp.Labels[guesses.Count, i].Item1.BorderColor = Color.Transparent;
                        colorValues[i] = ColorManager.FrameBackgroundColor(selection: 2);
                    }
                    else
                    {
                        mp.Labels[guesses.Count, i].Item1.BackgroundColor = ColorManager.FrameBackgroundColor(selection: 1);
                        mp.Labels[guesses.Count, i].Item1.BorderColor = Color.Transparent;
                        colorValues[i] = ColorManager.FrameBackgroundColor(selection: 1);
                    }
                }
                else
                {
                    mp.Labels[guesses.Count, i].Item1.BackgroundColor = ColorManager.FrameBackgroundColor(selection: 1);
                    mp.Labels[guesses.Count, i].Item1.BorderColor = Color.Transparent;
                    colorValues[i] = ColorManager.FrameBackgroundColor(selection: 1);
                }
                mp.Labels[guesses.Count, i].Item2.TextColor = Color.White;
                await mp.Labels[guesses.Count, i].Item1.RotateXTo(0, 150);
            }

            mp.UpdateKeyboard(lowercaseWord, colorValues, Color.White);

            if (correctCount == 5)
            {
                Console.WriteLine("SOLVED");
                canType = false;

                DisplaySolvedState();
            }
            else
            {
                // Move to a new row of letters
                guesses.Add(currentWord.word);
                currentWord = new Word(wordLength: 5);
            }
        }

        private void KeyboardLetterVibrate()
        {
            try
            {
                // Use default vibration length
                HapticFeedback.Perform(HapticFeedbackType.Click);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Feature not supported on device
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                // Other error has occurred.
                Console.WriteLine(ex.Message);
            }
        }

        async private void DisplaySolvedState()
        {
            // First Complete Animation
            mp.SolveDance(guesses.Count);
            await Task.Delay(1000);

            // Second Overlay Popup
            mp.showAnimationEndingScreen();
        }
    }
}
