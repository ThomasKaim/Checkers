using System;
using System.Text;

namespace Checkers
{
    public class Board
    {
        char[][] _squares;
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

        public bool CanJump(int row1, int column1, int row2, int column2, char team)
        {
            if (team == 'O' )
            {
                if (row1 == row2 + 2)
                {
                    if (column1 == column2 + 2)
                    {
                        switch (this._squares[row1 - 1][column1 - 1])
                        {
                            case 'X':
                            case 'W':
                                return true;
                        }

                    }
                    if (column1 == column2 - 2)
                    {
                        switch (this._squares[row1 - 1][column1 + 1])
                        {
                            case 'X':
                            case 'W':
                                return true;
                        }
                    }
                }
            }
            if (team == 'U')
            {
                if (row1 == row2 + 2)
                {
                    if (column1 == column2 + 2)
                    {
                        switch (this._squares[row1 - 1][column1 - 1])
                        {
                            case 'X':
                            case 'W':
                                return true;
                        }

                    }
                    if (column1 == column2 - 2)
                    {
                        switch (this._squares[row1 - 1][column1 + 1])
                        {
                            case 'X':
                            case 'W':
                                return true;
                        }
                    }
                }
                if (row1 == row2 - 2)
                {
                    if (column1 == column2 + 2)
                    {
                        switch (this._squares[row1 + 1][column1 - 1])
                        {
                            case 'X':
                            case 'W':
                                return true;
                        }

                    }
                    if (column1 == column2 - 2)
                    {
                        switch (this._squares[row1 + 1][column1 + 1])
                        {
                            case 'X':
                            case 'W':
                                return true;
                        }
                    }
                }
            }
            if (team == 'X')
            {
                if (row1 == row2 - 2)
                {
                    if (column1 == column2 + 2)
                    {
                        switch (this._squares[row1 + 1][column1 - 1])
                        {
                            case 'O':
                            case 'U':
                                return true;
                        }

                    }
                    if (column1 == column2 - 2)
                    {
                        switch (this._squares[row1 + 1][column1 + 1])
                        {
                            case 'O':
                            case 'U':
                                return true;
                        }
                    }
                }
            }
            if (team == 'W')
            {
                if (row1 == row2 - 2)
                {
                    if (column1 == column2 + 2)
                    {
                        switch (this._squares[row1 + 1][column1 - 1])
                        {
                            case 'O':
                            case 'U':
                                return true;
                        }

                    }
                    if (column1 == column2 - 2)
                    {
                        switch (this._squares[row1 + 1][column1 + 1])
                        {
                            case 'O':
                            case 'U':
                                return true;
                        }
                    }
                }
                if (row1 == row2 + 2)
                {
                    if (column1 == column2 + 2)
                    {
                        switch (this._squares[row1 - 1][column1 - 1])
                        {
                            case 'O':
                            case 'U':
                                return true;
                        }

                    }
                    if (column1 == column2 - 2)
                    {
                        switch (this._squares[row1 - 1][column1 + 1])
                        {
                            case 'O':
                            case 'U':
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool IsValid(int row1, int column1, int row2, int column2, char team)
        {
            if ((row1 < 0) || (row1 >= 8)) { throw new Exception("row1 is off the board"); }
            if ((row2 < 0) || (row2 >= 8)) { throw new Exception("row2 is off the board"); }
            if ((column1 < 0) || (column1 >= 8)) { throw new Exception("column1 is off the board"); }
            if ((column2 < 0) || (column2 >= 8)) { throw new Exception("column2 is off the board"); }

            if (this._squares[row2][column2] != ' ') { throw new Exception("There is a piece already there"); }
            char piece = this._squares[row1][column1];
            if (piece == ' ') { throw new Exception("There is no piece at the square you selected"); }

            if (CanJump(row1, column1, row2, column2, team)) { return true; }


            if (team == 'O')
            {
                if (row1 == row2 + 1)
                {
                    if (column1 == column2 + 1 || column1 == column2 - 1)
                    {


                        return true;
                    }
                }
                if (CanJump(row1, column1, row2, column2, team)) { return true; }
                throw new Exception("You can not move that piece there");

            }
            if (team == 'U')
            {
                if (row1 == row2 + 1 || row1 == row2 - 1)
                {
                    if (column1 == column2 + 1 || column1 == column2 - 1)
                    {


                        return true;
                    }
                }
                if (CanJump(row1, column1, row2, column2, team)) { return true; }
                throw new Exception("You can not move that piece there");

            }
            if (team == 'W' )
            {
                if (row1 == row2 - 1 || row1 == row2 + 1)
                {
                    if (column1 == column2 + 1 || column1 == column2 - 1)
                    {


                        return true;
                    }
                }
                if (CanJump(row1, column1, row2, column2, team)) { return true; }
                throw new Exception("You can not move that piece there");
            }
            if (team == 'X')
            {
                if (row1 == row2 - 1)
                {
                    if (column1 == column2 + 1 || column1 == column2 - 1)
                    {


                        return true;
                    }
                }
                if (CanJump(row1, column1, row2, column2, team)) { return true; }
                throw new Exception("You can not move that piece there");
            }

            throw new Exception("There is no piece at the square you selected");

        }
        char lastTeam = 'O';
        public void Move(int startRow, int startColumn, int row2, int column2)
        {

            char team = this._squares[startRow][startColumn];
            if (team == ' ') { throw new Exception($"There is no piece at {startRow}, {startColumn}"); }

            if (lastTeam == 'O' || lastTeam == 'U') { if (team == 'O' || team == 'U') { throw new Exception("You can not move twice in a row"); } }
            if (lastTeam == 'X' || lastTeam == 'W') { if (team == 'X' || team == 'W') { throw new Exception("You can not move twice in a row"); } }
            if (IsValid(startRow, startColumn, row2, column2, team))
            {
                this._squares[startRow][startColumn] = ' ';
                this._squares[row2][column2] = team;
            }
            if (CanJump(startRow, startColumn, row2, column2, team))
            {
                int jumpedColumn = (startColumn + column2) / 2;
                int jumpedRow = (startRow + row2) / 2;
                this._squares[jumpedRow][jumpedColumn] = ' ';
            }
            lastTeam = team;
        }
        public void Kinger()
        {
            for (int column = 0; column <= 8; column++)
            {
                if (this._squares[7][column] == 'X') { this._squares[7][column] = 'W'; }
                if (this._squares[0][column] == 'O') { this._squares[0][column] = 'U'; }
            }
        }

    }
}


