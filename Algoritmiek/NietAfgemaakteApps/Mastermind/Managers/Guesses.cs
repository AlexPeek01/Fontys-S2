using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers
{
    public class Guesses
    {
        private int prevCount;
        public List<string> InitialGuess(int count)
        {
            Random random = new Random();
            List<string> guess = new List<string>();
            for (int i = 0; i < count; i++)
            {
                guess.Add(random.Next(0, 2).ToString());
            }
            return guess;
        }
        public List<string> MakeGuess(List<string> guess, List<Position> positions, int correctPositions)
        {
            if (correctPositions == 0 || correctPositions <= positions.Count - correctPositions)
            {
                for (int i = 0; i < guess.Count; i++)
                {
                    if (guess[i] == "1")
                    {
                        guess[i] = "0";
                        continue;
                    }
                    guess[i] = "1";
                }
                return guess;
            }
            return null;
        }
        public int GetCorrectPositionCount(List<Position> positions, List<string> guess)
        {
            int correctCount = 0;
            for(int i = 0; i < positions.Count; i++)
            {
                if(positions[i].character == guess[i])
                {
                    correctCount++;
                }
            }
            return correctCount;
        }
    }
}
