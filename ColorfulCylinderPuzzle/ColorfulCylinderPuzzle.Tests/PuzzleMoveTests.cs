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

        [OneTimeSetUp]
        public void InitOnceBeforeAnyTest()
        {
            puzzle = new Puzzle(6, 5, new List<byte> {0, 1, 3}, new List<byte> {1, 2}, new List<byte> {3, 4}, true);
            expected = new Puzzle(6, 5, new List<byte> {0, 1, 3}, new List<byte> {1, 2}, new List<byte> {3, 4}, true);
        }

        [SetUp]
        public void InitBeforeEachTest()
        {
            puzzle.SetUpPuzzleInUpperSolvedPosition();
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
            Assert.IsTrue(puzzle.IsInIdenticalPosition(expected), "After move down puzzle is not in the same position as expected.");
            expected.SetUpPuzzleInUpperSolvedPosition();
            puzzle.MakeMoveUp();
            Assert.IsTrue(puzzle.IsInIdenticalPosition(expected), "After move down puzzle is not in the same position as expected.");
        }
    }
}