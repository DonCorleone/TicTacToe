using System;

namespace TicTacToe
{
    internal static class Randomizer
    {
        private static readonly Random getrandom = new Random();

        // https://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-int-number-in-c

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }
    }
}


