using System;

namespace TicTacToe
{
    internal class Game
    {
        private static Game _instance = null;

        Grid _grid; // dirty but quick ..
        private Game(){

            var size = 3;
            _grid = Grid.Instance(size);
            
            Console.WriteLine($"Tic Tac Toe Grid initialized with size of {size} x {size}.");
        }

        public static Game Instance { 
            get{
                if (_instance == null)
                        _instance = new Game();
                return _instance;
            }
        }

        public void StartOneCell(){
            
            _grid.Print();
        }
        public void Start(){

            // Determine startig player
            var players = new Player[2];

            players[0] = new Player(Mark.O);
            players[1] = new Player(Mark.X);

            Console.WriteLine($"Two players crated with Marks {players[0].Mark} and {players[1].Mark}.");
            
            // Get random Index of starting Player
            int playerIx = new Random().Next(0,1);

            Console.WriteLine($"Player with Mark {players[playerIx].Mark} starts.");

            var gameFinnished = false;

            while(!gameFinnished){

                int columnIxInput;
                if (!int.TryParse(Console.Read().ToString(), out columnIxInput))
                {
                    Console.WriteLine("So nicht!");
                }
                int? freeColumnIx = null;
                while (!freeColumnIx.HasValue)
                {
                    freeColumnIx = _grid.checkIfColumnIsFree(columnIxInput);
                }
                
                // player in term makes the move on the free column
                Console.WriteLine($"Player {players[playerIx].Mark} adds a Mark to Column {freeColumnIx.Value}");
                doTheMove(players[playerIx], freeColumnIx.Value);
                
                // check if finnished 'cause of roules
                var winnerMark = _grid.FindWinnerMark();

                gameFinnished = winnerMark != Mark.Empty;
                // double check if no cheating happens
                if (gameFinnished && winnerMark != players[playerIx].Mark)
                    throw new TicTacToeException("Cheating happens!!");

                if (gameFinnished){
                    Console.WriteLine($"Player {players[playerIx].Mark} won!!!!");
                    break;
                }

                var freeColumn = _grid.FindFreeColumn();

                // check if game finnished 'cause its filled
                gameFinnished = !freeColumn.HasValue;
                if (gameFinnished){
                    Console.WriteLine($"Game finnished without a winner.");
                    break;
                }

                playerIx = playerIx == 0 ? 1 : 0; // Superquick, superdirty
            }           

            _grid.Print();
        }

        private void doTheMove(Player player, int chosenColumn){
            _grid.TakeToken(player.Mark, chosenColumn);
        }
    }
}