using System;
using System.Text;

namespace TicTacToe
{
    // Multidimensional Arrays are not inheritable
    internal class Grid
    {
        private static Grid _instance;
        // Singleton
        public static Grid Instance(int size)
        {
            if (_instance == null)
                _instance = new Grid(size);

            return _instance;
        }

        private int _size;

        // Singleton ctor
        private Grid()
        {
        }
        private Grid(int size)
        {
            _size = size;
            GridProperty = new Cell[_size, _size];
            for (int rowIx = 0; rowIx < _size; rowIx++)
            {
                for (int columnIx = 0; columnIx < _size; columnIx++)
                {
                    GridProperty[rowIx, columnIx] = new Cell();
                }
            }
        }

        public int Size { get { return _size; } }
        public Cell[,] GridProperty { get; private set; }

        internal void TakeToken(Mark mark, int columnIx)
        {
            // loop through the column
            for (int rowIx = 0; rowIx < _size; rowIx++)
            {
                // if current row == empty
                if (GridProperty[rowIx, columnIx].Mark == Mark.Empty)
                {
                    GridProperty[rowIx, columnIx].Mark = mark;
                    return;
                }
            }
        }

        internal int? FindFreeColumn()
        {
            // Filled? > search for epmty spaces

            // Loop through the columns
            for (int columnIx = 0; columnIx < _size; columnIx++)
            {
                // Loop through the rows  
                for (int rowIx = 0; rowIx < _size; rowIx++)
                {
                    // if any empty cell found > exit through the gift shop
                    if (GridProperty[rowIx, columnIx].Mark == Mark.Empty)
                        return columnIx;
                }
            }

            return null; // dirty but running
        }

        internal int? checkIfColumnIsFree(int v)
        {
            // Loop through the rows  
            for (int rowIx = 0; rowIx < _size; rowIx++)
            {
                // if any empty cell found > exit through the gift shop
                if (GridProperty[rowIx, v].Mark == Mark.Empty)
                    return v;
            }

            return null;
        }

        internal Mark FindWinnerMark()
        {
            Print();
            // find winner in rows
            Mark winnerMark = findWinnerInRows();
            if (winnerMark == Mark.Empty)
                // ..or in columns
                winnerMark = findWinnerInColumns();
            if (winnerMark == Mark.Empty)
                // .. or diagonal
                winnerMark = findWinnerDiagonal();
            return winnerMark;
        }

        internal void Print()
        {

            var outPut = new StringBuilder();

            // Loop through the columns
            for (int rowIx = 0; rowIx < _size; rowIx++)
            {
                Console.WriteLine("----------------");
                // Loop through the rows  
                for (int columnIx = 0; columnIx < _size; columnIx++)
                {
                    // if any empty cell found > exit through the gift shop
                    string value = GridProperty[rowIx, columnIx].Mark == Mark.Empty ? " " : GridProperty[rowIx, columnIx].Mark.ToString();
                    outPut.AppendFormat($" | {value}");
                }
                outPut.AppendFormat($" | ");
                Console.WriteLine(outPut.ToString());
                outPut.Clear();
            }
            Console.WriteLine("---------------");
            System.Threading.Thread.Sleep(1000);
        }

        private Mark findWinnerDiagonal()
        {
            // ToDo
            return Mark.Empty;
        }

        private Mark findWinnerInRows()
        {

            // find for equal Rows
            for (int rowIx = 0; rowIx < _size; rowIx++)
            {
                Mark lastMark = Mark.Undefined;
                for (int columnIx = 0; columnIx < _size; columnIx++)
                {
                    // if empty >> no winner in this row >> exit (fall down as far as possible)
                    if (GridProperty[rowIx, columnIx].Mark == Mark.Empty)
                        return Mark.Empty;

                    // not same mark >> next row
                    if (GridProperty[rowIx, columnIx].Mark != lastMark){
                        if (lastMark != Mark.Undefined)
                        {
                            break;
                        }else{
                            lastMark = GridProperty[rowIx, columnIx].Mark;
                            continue;
                        }
                    }

                    // else : if row with same marks finnised :: WINNER FOUND !!
                    if (lastMark != Mark.Undefined && lastMark == GridProperty[rowIx, columnIx].Mark && columnIx == _size - 1)
                        return GridProperty[rowIx, columnIx].Mark;
                }
            }

            // no winner found : the show must go on...
            return Mark.Empty;
        }
        private Mark findWinnerInColumns()
        {
            // find for equal colums
            for (int columnIx = 0; columnIx < _size; columnIx++)
            {
                Mark lastMark = Mark.Undefined;

                for (int rowIx = 0; rowIx < _size; rowIx++)
                {
                    // if empty >> no winner in this column >> next column
                    if (GridProperty[rowIx, columnIx].Mark == Mark.Empty)
                        break;

                    // not same mark >> next column
                    if (lastMark != Mark.Undefined && GridProperty[rowIx, columnIx].Mark != lastMark)
                        break;

                    // else : if row with same marks finnised :: WINNER FOUND !!
                    if (lastMark != Mark.Undefined && lastMark == GridProperty[rowIx, columnIx].Mark && rowIx == _size - 1)
                        return GridProperty[rowIx, columnIx].Mark;


                    lastMark = GridProperty[rowIx, columnIx].Mark;
                }

                // reset cursor
                lastMark = Mark.Empty;
            }

            // no winner found : the show must go on...
            return Mark.Empty;
        }
    }
}