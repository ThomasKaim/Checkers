using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Checkers.Tests
{
    [TestClass]
    public class BoardTests
    {
        public void AssertBoards(string expected, Board actual)
        {
            string[] expectedRows = expected.Split('\n').Select(item => item.Trim()).ToArray();
            string[] actualRows = actual.ToString().Split('\n').Select(item => item.Trim()).ToArray();

            for (int row = 0; row < expectedRows.Length; row++)
            {
                string expectedRow = expectedRows[row];
                string actualRow = actualRows[row];

                if (expectedRow.Length != actualRow.Length)
                {
                    Assert.Fail($"Row {row - 1} did not match");
                }

                for (int column = 0; column < expectedRow.Length; column++)
                {
                    if (expectedRow[column] != actualRow[column])
                    {
                        Assert.Fail($"Expected {expectedRow[column]} at {row - 1}, {column - 1} but got {actualRow[column]}");
                    }
                }
            }
        }

        [TestMethod]
        public void TestCreate()
        {
            Board board = new Board();

            this.AssertBoards(
@" 01234567
0 X X X X
1X X X X
2 X X X X
3
4
5O O O O 
6 O O O O
7O O O O", board);
        }

        [TestMethod]
        public void TestMove()
        {
            Board board = new Board();
            board.Move(2, 1, 3, 0);
            
            this.AssertBoards(
@" 01234567
0 X X X X
1X X X X
2   X X X
3X   
4    
5O O O O 
6 O O O O
7O O O O", board);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestBadMove()
        {
            Board board = new Board();
            board.Move(1, 1, 2, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMoveOffBoard()
        {
            Board board = new Board();
            board.Move(2, 7, 3, 8);
        }

    }
}
