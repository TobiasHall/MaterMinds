using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace MaterMinds
{
    public class GameEngine
    {
        private static readonly Random random = new Random();

        #region Properties
        private Dictionary<int, int> correctAnswer  = new Dictionary<int, int>();
        private Brush[] hintToAnswer;
        private int[] checkForDoubles;
        private int[] sortedPlayersPegsInArray;
        #endregion

        public GameEngine()
        {
            RandomizeAnswer();
        }

        #region GameLogic

        private void SortPlayersPlacedPegs(Dictionary<int, int> keyAndColorIndex)
        {
            for (int i = 0; i < keyAndColorIndex.Count; i++)
            {
                switch (keyAndColorIndex.ElementAt(i).Key)
                {
                    case 1:
                        sortedPlayersPegsInArray[0] = keyAndColorIndex.ElementAt(i).Value;
                        break;
                    case 2:
                        sortedPlayersPegsInArray[1] = keyAndColorIndex.ElementAt(i).Value;
                        break;
                    case 3:
                        sortedPlayersPegsInArray[2] = keyAndColorIndex.ElementAt(i).Value;
                        break;
                    case 4:
                        sortedPlayersPegsInArray[3] = keyAndColorIndex.ElementAt(i).Value;
                        break;
                }
            }
        }

        private void SortHintArray()
        {
            Array.Sort(hintToAnswer);
            Array.Reverse(hintToAnswer);
        }

        private void CopyAnswerArray()
        {
            for (int i = 0; i < 4; i++)
            {
                checkForDoubles[i] = correctAnswer.ElementAt(i).Value;
            }
        }

        private void SetWhitePegs()
        {
            for (int i = 0; i < sortedPlayersPegsInArray.Length; i++)
            {
                for (int j = 0; j < correctAnswer.Count; j++)
                {
                    if (sortedPlayersPegsInArray[i] == checkForDoubles[j] )
                    {
                        hintToAnswer[i] = Brushes.White;
                        //Set the value to 10 so it never hits again. 
                        checkForDoubles[j] = 10;
                        break;
                    }
                }
            }
        }

        private void SetBlackPegs()
        {
            int counter = 0;
            for (int i = 0; i < correctAnswer.Count; i++)
            {
                if (sortedPlayersPegsInArray[i] == correctAnswer.ElementAt(i).Value)
                {
                    hintToAnswer[counter] = Brushes.Black;
                    counter++;
                }
            }
        }

        private void ClearAllProps()
        {
            hintToAnswer = new Brush[4];
            checkForDoubles = new int[4];
            sortedPlayersPegsInArray = new int[4];
        }

        public Brush[] CheckPegPosition(Dictionary<int, int> playersPlacedPegs)
        {
            ClearAllProps();
            CopyAnswerArray();
            SortPlayersPlacedPegs(playersPlacedPegs);
            SetWhitePegs();
            SortHintArray();
            SetBlackPegs();
            return hintToAnswer;
        }

        public bool CheckIfWin(Dictionary<int, int> playersPlacedPegs)
        {
            int counter = 0; 
            foreach (var playerKeyAndValue in playersPlacedPegs)
            {
                foreach (var answerKeyAndValue in correctAnswer)
                {
                    if (playerKeyAndValue.Key == answerKeyAndValue.Key && playerKeyAndValue.Value == answerKeyAndValue.Value)
                    {
                        counter++; 
                    }
                }
            }
            if (counter == correctAnswer.Count)
            {
                return true; 
            }
            return false;
        }

        public Dictionary<int, int> GetCorrectAnswer()
        {
            return correctAnswer;
        }
        public int CalculateScore(int tries, int timer)
        {
            int score = 10000;
            score -= (tries * 1489) + timer*3;
            if (score <= 0)
            {
                score = 0;
            }
            return score;
        }
        #endregion

        public void RandomizeAnswer()
        {
            for (int i = 1; i <= 4; i++)
            {
                correctAnswer.Add(i, random.Next(1, 7));
            }
        }
    }
}
