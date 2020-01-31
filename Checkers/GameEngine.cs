using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class GameEngine
    {
        public readonly Board Board;
        char _lastTeam = 'O';

        public GameEngine()
        {
            this.Board = new Board();


        }

        public bool CanJump(int row1, int column1, int row2, int column2, char team)
        {
            if (!this.Board.IsOnBoard(row1, column1)) { return false; }
            if (!this.Board.IsOnBoard(row2, column2)) { return false; }
            if (!this.Board.IsSquareSetTo(row2, column2, ' ')) { return false; }
            if (team == 'O')
            {
                if (row1 == row2 + 2)
                {
                    if (column1 == column2 + 2)
                    {
                        switch (this.Board.GetAt(row1 - 1, column1 - 1))
                        {
                            case 'X':
                            case 'W':
                                return true;
                        }

                    }
                    if (column1 == column2 - 2)
                    {
                        switch (this.Board.GetAt(row1 - 1, column1 + 1))
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
                        switch (this.Board.GetAt(row1 - 1, column1 - 1))
                        {
                            case 'X':
                            case 'W':
                                return true;
                        }

                    }
                    if (column1 == column2 - 2)
                    {
                        switch (this.Board.GetAt(row1 - 1, column1 + 1))
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
                        switch (this.Board.GetAt(row1 + 1, column1 - 1))
                        {
                            case 'X':
                            case 'W':
                                return true;
                        }

                    }
                    if (column1 == column2 - 2)
                    {
                        switch (this.Board.GetAt(row1 + 1, column1 + 1))
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
                        switch (this.Board.GetAt(row1 + 1, column1 - 1))
                        {
                            case 'O':
                            case 'U':
                                return true;
                        }

                    }
                    if (column1 == column2 - 2)
                    {
                        switch (this.Board.GetAt(row1 + 1, column1 + 1))
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
                        switch (this.Board.GetAt(row1 + 1, column1 - 1))
                        {
                            case 'O':
                            case 'U':
                                return true;
                        }

                    }
                    if (column1 == column2 - 2)
                    {
                        switch (this.Board.GetAt(row1 + 1, column1 + 1))
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
                        switch (this.Board.GetAt(row1 - 1, column1 - 1))
                        {
                            case 'O':
                            case 'U':
                                return true;
                        }

                    }
                    if (column1 == column2 - 2)
                    {
                        switch (this.Board.GetAt(row1 - 1, column1 + 1))
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
        public bool MustJump(char team)
        {


            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    char piece = this.Board.GetAt(row, column);
                    switch (team)
                    {
                        case 'X':
                        case 'W':
                            if (piece != 'X' && piece != 'W') { continue; }
                            break;
                        case 'O':
                        case 'U':
                            if (piece != 'O' && piece != 'U') { continue; }
                            break;

                    }

                    int upRow = row - 2;
                    int downRow = row + 2;
                    int leftColumn = column - 2;
                    int rightColumn = column + 2;

                    if (team != 'X')
                    {
                        if (this.Board.IsOnBoard(upRow, leftColumn) && this.CanJump(row, column, upRow, leftColumn, team))
                        {
                            return true;
                        }

                        if (this.Board.IsOnBoard(upRow, rightColumn) && this.CanJump(row, column, upRow, rightColumn, team))
                        {
                            return true;
                        }
                    }

                    if (team != 'O')
                    {
                        if (this.Board.IsOnBoard(downRow, leftColumn) && this.CanJump(row, column, downRow, leftColumn, team))
                        {
                            return true;
                        }

                        if (this.Board.IsOnBoard(downRow, rightColumn) && this.CanJump(row, column, downRow, rightColumn, team))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool IsMoveValid(int row1, int column1, int row2, int column2, char team)
        {
            if (!this.Board.IsOnBoard(row1, column1)) { return false; }
            if (!this.Board.IsOnBoard(row2, column2)) { return false; }

            if (this.Board.GetAt(row2, column2) != ' ') { throw new Exception("There is a piece already there"); }
            char piece = this.Board.GetAt(row1, column1);
            if (piece == ' ') { throw new Exception("There is no piece at the square you selected"); }

            if (this.CanJump(row1, column1, row2, column2, team)) { return true; }
            if (this.Board.IsOnBoard(row1, column1))
            {
                if (MustJump(team))
                {
                    if (!CanJump(row1, column1, row2, column2, team)) { throw new Exception("You must capture a piece"); }

                }
            }
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
            if (team == 'W')
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

        public void Move(int startRow, int startColumn, int row2, int column2)
        {

            char team = this.Board.GetAt(startRow, startColumn);
            if (team == ' ') { throw new Exception($"There is no piece at {startRow}, {startColumn}"); }

            if (_lastTeam == 'O' || _lastTeam == 'U') { if (team == 'O' || team == 'U') { throw new Exception("You can not move twice in a row"); } }
            if (_lastTeam == 'X' || _lastTeam == 'W') { if (team == 'X' || team == 'W') { throw new Exception("You can not move twice in a row"); } }
            if (!IsMoveValid(startRow, startColumn, row2, column2, team))
            {
                throw new Exception("That is not a valid move");
            }

            this.Board.SetAt(startRow, startColumn, ' ');
            this.Board.SetAt(row2, column2, team);

            if (CanJump(startRow, startColumn, row2, column2, team))
            {
                int jumpedColumn = (startColumn + column2) / 2;
                int jumpedRow = (startRow + row2) / 2;
                this.Board.SetAt(jumpedRow, jumpedColumn, ' ');
            }
            _lastTeam = team;
            if (row2 == 0 || row2 == 7)
            {
                if (team == 'X') { this.Board.SetAt(row2, column2, 'W'); }
                if (team == 'O') { this.Board.SetAt(row2, column2, 'U'); }

            }
        }


        public void Print()
        {
            this.Board.Print();
        }
    }
}
