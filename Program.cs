using System;
using System.Collections;
using System.Drawing;

namespace TicTacToe
{
    class Program
    {

        static void Main(string[] args)
        {

            // var hashtable = new Hashtable();
            //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/multidimensional-arrays
            //var multiDimArray = new Array<Point, Point>();

            var theGame = Game.Instance;
            theGame.Start();
        }
    }
}
