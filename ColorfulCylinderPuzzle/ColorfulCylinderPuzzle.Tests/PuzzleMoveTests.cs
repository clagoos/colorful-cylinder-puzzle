using System.Collections.Generic;
using ColorfulCylinderPuzzle.Logic;
using NUnit.Framework;

namespace ColorfulCylinderPuzzle.Tests
{
    [TestFixture]
    public class PuzzleMoveTests
    {
        private Puzzle puzzle;
        private Puzzle expected;
        private byte[,] solvedUpperPosition;
        private byte[,] solvedLowerPosition;

        [OneTimeSetUp]
        public void InitOnceBeforeAnyTest()
        {
            puzzle = new Puzzle(6, 5, new List<byte> {0, 1, 3}, new List<byte> {1, 2}, new List<byte> {3, 4}, true);
            expected = new Puzzle(6, 5, new List<byte> {0, 1, 3}, new List<byte> {1, 2}, new List<byte> {3, 4}, true);
            solvedUpperPosition = new byte[,] {{6, 6, 7, 6, 7}, {1, 2, 3, 4, 5}, {1, 2, 3, 4, 5}, {1, 2, 3, 4, 5}, {1, 2, 3, 4, 5}, {0, 0, 7, 0, 7}};
            solvedLowerPosition = new byte[,] {{0, 0, 7, 0, 7}, {1, 2, 3, 4, 5}, {1, 2, 3, 4, 5}, {1, 2, 3, 4, 5}, {1, 2, 3, 4, 5}, {6, 6, 7, 6, 7}};
        }

        [SetUp]
        public void InitBeforeEachTest()
        {
            puzzle.SetUpPuzzleInUpperSolvedPosition();
            expected.SetUpPuzzleInUpperSolvedPosition();
        }

        [Test]
        public void TestSolvedPositions()
        {
            Assert.IsTrue(puzzle.IsInIdenticalPosition(solvedUpperPosition));
            puzzle.SetUpPuzzleInLowerSolvedPosition();
            Assert.IsTrue(puzzle.IsInIdenticalPosition(solvedLowerPosition));
        }

        [Test]
        public void TestMoveDownAndUp()
        {
            var positionAfterMoveDown = new byte[,]
            {
                {0, 0, 7, 0, 7},
                {6, 6, 3, 6, 5},
                {1, 2, 3, 4, 5},
                {1, 2, 3, 4, 5},
                {1, 2, 3, 4, 5},
                {1, 2, 7, 4, 7}
            };
            expected.SetUpPuzzlePosition(positionAfterMoveDown);
            puzzle.MakeMoveDown();
            Assert.IsTrue(puzzle.IsInIdenticalPosition(expected), $"After move down puzzle is not in the expected position. Instead is {puzzle}");
            puzzle.MakeMoveUp();
            Assert.IsTrue(puzzle.IsInIdenticalPosition(solvedUpperPosition), $"After move down and up puzzle is not in the starting solved upper position. Instead is {puzzle}");
        }

        [Test]
        public void TestMoveUpperLeftAndRight()
        {
            var positionAfterMoveUpperLeft = new byte[,]
            {
                {6, 6, 7, 6, 7},
                {2, 3, 4, 5, 1},
                {2, 3, 4, 5, 1},
                {1, 2, 3, 4, 5},
                {1, 2, 3, 4, 5},
                {0, 0, 7, 0, 7}
            };
            puzzle.MakeMoveUpperRotateLeft();
            Assert.IsTrue(puzzle.IsInIdenticalPosition(positionAfterMoveUpperLeft), $"After move upper left puzzle is not in the expected position. Instead is {puzzle}");
            puzzle.MakeMoveUpperRotateRight();
            Assert.IsTrue(puzzle.IsInIdenticalPosition(solvedUpperPosition), $"After move upper left and right puzzle is not in the starting solved upper position. Instead is {puzzle}");
        }

        [Test]
        public void TestMoveLowerLeftAndRight()
        {
            var positionAfterMoveLowerLeft = new byte[,]
            {
                {6, 6, 7, 6, 7},
                {1, 2, 3, 4, 5},
                {1, 2, 3, 4, 5},
                {2, 3, 4, 5, 1},
                {2, 3, 4, 5, 1},
                {0, 0, 7, 0, 7}
            };
            puzzle.MakeMoveLowerRotateLeft();
            Assert.IsTrue(puzzle.IsInIdenticalPosition(positionAfterMoveLowerLeft), $"After move lower left puzzle is not in the expected position. Instead is {puzzle}");
            puzzle.MakeMoveLowerRotateRight();
            Assert.IsTrue(puzzle.IsInIdenticalPosition(solvedUpperPosition), $"After move lower left and right puzzle is not in the starting solved upper position. Instead is {puzzle}");
        }
    }
}