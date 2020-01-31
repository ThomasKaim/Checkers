using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Checkers.Tests
{
    [TestClass]
    public class GameEngineTests
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
        public void TestMove()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.Move(2, 1, 3, 0);

            this.AssertBoards(
@" 01234567
0 X X X X
1X X X X
2   X X X
3X   
4    
5O O O O 
6 O O O O
7O O O O", gameEngine.Board);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestBadMove()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.Move(1, 1, 2, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMoveOffBoard()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.Move(2, 7, 3, 8);

        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMustJump()
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.Move(2, 1, 3, 0);
            gameEngine.Move(5, 2, 4, 1);
            gameEngine.Move(2, 3, 3, 2);

        }

    }
}
