namespace TicTacToe
{    
    internal class Player
    {
        // ctor
        public Player(Mark mark){

            Mark = mark;
            if (mark == Mark.Empty)
                throw new TicTacToeException("Wrong Mark defined");
        }
        private Player(){
            
            // Avoid creating players without Marks
        }

        public Mark Mark { get; private set; }
    }
}