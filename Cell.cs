using System.ComponentModel;
using System.Drawing;

namespace TicTacToe
{

    internal class Cell
    {
        [DefaultValue(Mark.Empty)]
        public Mark Mark { get; set; }
    }
}