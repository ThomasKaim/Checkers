using System;
using System.Text;

namespace Checkers
{
    public class Board
    {
        readonly char[][] _squares;
        public Board()
        {
            this._squares = new char[8][];

            for (int row = 0; row < 8; row++)
            {
                this._squares[row] = new char[8];
                for (int column = 0; column < 8; column++)
                {
                    this._squares[row][column] = ' ';
                }
            }

            RowSetter(0, 'X');
            RowSetter(1, 'X');
            RowSetter(2, 'X');
            RowSetter(5, 'O');
            RowSetter(6, 'O');
            RowSetter(7, 'O');
        }
        public void RowSetter(int row, char team)
        {

            bool even = false;
            if (row % 2 == 0)
            {
                even = true;

            }
            if (even == true)
            {
                for (int column = 1; column <= 7; column += 2)
                {

                    this._squares[row][column] = team;
                }

            }
            if (even == false)
            {
                for (int column = 0; column <= 6; column += 2)
                {

                    this._squares[row][column] = team;
                }

            }



        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" 01234567");

            for (int row = 0; row < 8; row++)
            {
                sb.Append(row);
                for (int column = 0; column < 8; column++)
                {
                    sb.Append(this._squares[row][column]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public void Print()
        {
            Console.Write(this.ToString());
        }


        public bool IsOnBoard(int row, int column)
        {
            if (row >= 8) { return false; }
            if (row < 0) { return false; }
            if (column >= 8) { return false; }
            if (column < 0) { return false; }
            return true;
        }

        public void VerifyIsOnBoard(int row, int column)
        {
            if (!this.IsOnBoard(row, column))
            {
                throw new Exception($"The square {row}, {column} is not on the board");
            }
        }

        public bool IsSquareSetTo(int row, int column, char wantedTeam)
        {
            this.VerifyIsOnBoard(row, column);

            return (_squares[row][column] == wantedTeam);
        }

        public void SetAt(int row, int column, char team)
        {
            this.VerifyIsOnBoard(row, column);
            this._squares[row][column] = team;
               
        }
        public char GetAt(int row, int column)
        {
            this.VerifyIsOnBoard(row, column);
            return this._squares[row][column];
        }
    }
}


