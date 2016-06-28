using System.Collections.Generic;

namespace ColorfulCylinderPuzzle.Logic
{
    public class StandardPuzzleInitializer
    {
        public void Initialize()
        {
            var puzzle = new Puzzle(6, 5, new List<byte> {0, 1, 3}, new List<byte> {1, 2}, new List<byte> {3, 4}, false);
            var rules = new Rules
            {
                ProhibitedFields = {{0, 2}, {0, 4}, {5, 2}, {5, 4}}
            };
        }
    }
}