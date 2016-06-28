using System;
using System.Collections.Generic;

namespace ColorfulCylinderPuzzle.Logic
{
    public class Puzzle
    {
        //l: todo: add check if given parameters are correct (in separate class like: PuzzleInitializeChecker or sth like that)
        public Puzzle(int rows, int columns, List<byte> higherColumns, List<byte> upperRows, List<byte> lowerRows, bool isInUpPosition)
        {
            Map = new byte[rows, columns];
            Rows = rows;
            Columns = columns;
            HigherColumns = higherColumns;
            UpperRows = upperRows;
            LowerRows = lowerRows;
            IsInUpPosition = isInUpPosition;
        }

        /// <summary>
        /// 2D map model of rotating cylinder.
        /// </summary>
        public byte[,] Map { get; }

        /// <summary>
        /// Total rows count
        /// </summary>
        public int Rows { get; }

        /// <summary>
        /// Total columns count
        /// </summary>
        public int Columns { get; }

        /// <summary>
        /// Set of columns with open spaces in first and last row.
        /// </summary>
        public List<byte> HigherColumns { get; }

        /// <summary>
        /// Defines upper rows numbers for rotating upper part of the puzzle
        /// </summary>
        public List<byte> UpperRows { get; }

        /// <summary>
        /// Defines lower rows numbers for rotating lower part of the puzzle
        /// </summary>
        public List<byte> LowerRows { get; }

        /// <summary>
        /// Determines if puzzle is in UP position (full first row, empty last row) or DOWN position (full last row, empty first row).
        /// </summary>
        public bool IsInUpPosition { get; }

        public void MakeRandomMove()
        {
            throw new NotImplementedException();
        }

        //l: todo: mthod need testing
        public void MakeMoveUp()
        {
            if (IsInUpPosition) throw new InvalidOperationException("Impossible to make move up. Puzzle is already in up position");
            foreach (var column in HigherColumns)
            {
                for (int row = 0; row < Rows - 1; row++)
                {
                    Map[row, column] = Map[row + 1, column];
                }
                Map[Rows - 1, column] = 0;
            }
        }

        //l: todo: mthod need testing
        public void MakeMoveDown()
        {
            if (!IsInUpPosition) throw new InvalidOperationException("Impossible to make move down. Puzzle is already in down position");
            foreach (var column in HigherColumns)
            {
                for (int row = Rows - 1; row > 0; row--)
                {
                    Map[row, column] = Map[row - 1, column];
                }
                Map[0, column] = 0;
            }
        }

        //l: todo: mthod need testing
        public void MakeMoveUpperRotateLeft()
        {
            foreach (var row in UpperRows)
            {
                RotateRowLeft(row);
            }
        }

        //l: todo: mthod need testing
        public void MakeMoveUpperRotateRight()
        {
            foreach (var row in UpperRows)
            {
                RotateRowRight(row);
            }
        }

        //l: todo: mthod need testing
        public void MakeMoveLowerRotateLeft()
        {
            foreach (var row in LowerRows)
            {
                RotateRowLeft(row);
            }
        }

        //l: todo: mthod need testing
        public void MakeMoveLowerRotateRight()
        {
            foreach (var row in LowerRows)
            {
                RotateRowRight(row);
            }
        }

        private void RotateRowLeft(byte row)
        {
            var firstElement = Map[row, 0];
            for (int column = 0; column < Columns - 1; column++)
            {
                Map[row, column] = Map[row, column + 1];
            }
            Map[row, Columns - 1] = firstElement;
        }

        private void RotateRowRight(byte row)
        {
            var lastElement = Map[row, Columns - 1];
            for (int column = Columns - 1; column > 0; column--)
            {
                Map[row, column] = Map[row, column - 1];
            }
            Map[row, 0] = lastElement;
        }
    }
}