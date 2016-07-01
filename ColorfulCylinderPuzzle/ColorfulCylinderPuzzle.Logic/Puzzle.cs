using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColorfulCylinderPuzzle.Logic
{
    /// <summary>
    /// Specifies state of the single Colorful Cylinder Puzzle piece.
    /// </summary>
    public class Puzzle
    {
        //l: todo: add check if given parameters are correct (in separate class like: PuzzleInitializeChecker or sth like that)
        public Puzzle(int rows, int columns, List<byte> higherColumns, List<byte> upperRows, List<byte> lowerRows, bool isInUpPosition)
        {
            Map = new byte[rows, columns];
            Rows = rows;
            Columns = columns;
            HigherColumns = higherColumns;
            BasicColumns = Enumerable.Range(0, Columns).Select(x => (byte)x).Except(higherColumns).ToList();
            UpperRows = upperRows;
            LowerRows = lowerRows;
            IsInUpPosition = isInUpPosition;
            SetUnavailableMapCells();
        }

        public void SetUpPuzzlePosition(byte[,] position)
        {
            var positionRows = position.GetLength(0);
            var positionColumns = position.GetLength(1);
            if (positionRows != Rows) throw new ArgumentException($"Invalid rows count of position array. Is {positionRows}, should be {Rows}");
            if (positionColumns != Columns) throw new ArgumentException($"Invalid columns count of position array. Is {positionColumns}, should be {Columns}");
            // dodać sprawdzenie czy unavailable map cells są poprawne
            // dodać sprawdzenie czy puzzle jest w up czy down position i czy są odpowiednie puste miejsca
            // dodać sprawdzenie czy liczba kolorów się zgadza z każdego typu koloru
            //l: todo: zamiast tych wyjątków, wyjąć takie sprawdzanie zasad do osobnej klasy?
            for (int row = 0; row < Rows; row++)
                for (int column = 0; column < Columns; column++)
                    Map[row, column] = position[row, column];
        }

        public void SetUpPuzzleInUpperSolvedPosition()
        {
            SetUpPuzzleInSolvedPosition(true);
        }

        public void SetUpPuzzleInLowerSolvedPosition()
        {
            SetUpPuzzleInSolvedPosition(false);
        }

        private void SetUpPuzzleInSolvedPosition(bool setUpperPosition)
        {
            IsInUpPosition = setUpperPosition;
            SetUnavailableMapCells();
            var brownBallsRow = setUpperPosition ? 0 : Rows - 1;
            var emptyRow = setUpperPosition ? Rows - 1 : 0;
            foreach (var column in HigherColumns)
            {
                Map[brownBallsRow, column] = (byte)Colors.Brown;
                Map[emptyRow, column] = (byte)Colors.None;
            }
            for (int row = 1; row < Rows - 1; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    Map[row, column] = (byte)(column + 1);
                }
            }
        }

        private void SetUnavailableMapCells()
        {
            foreach (var column in BasicColumns)
            {
                Map[0, column] = (byte)Colors.Unavailable;
                Map[Rows - 1, column] = (byte)Colors.Unavailable;
            }
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
        /// Set of columns with open spaces in first and last row. Column number is here or in BasicColumns
        /// </summary>
        public List<byte> HigherColumns { get; }

        /// <summary>
        /// Set of columns WITHOUT open spaces in first and last row. Column number is here or in HigherColumns
        /// </summary>
        public List<byte> BasicColumns { get; }

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
        public bool IsInUpPosition { get; private set; }

        //l: todo: mthod need testing
        public void MakeMoveUp()
        {
            if (IsInUpPosition) throw new InvalidOperationException("Impossible to make move up. Puzzle is already in up position");
            IsInUpPosition = true;
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
            IsInUpPosition = false;
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
            for (int column = Columns - 1; column > 1; column--)
            {
                Map[row, column] = Map[row, column - 1];
            }
            Map[row, 0] = lastElement;
        }

        public bool IsInIdenticalPosition(Puzzle anotherPuzzle)
        {
            //l: todo: dodać sprawdzenia wierszy i kolumn z nowej klasy sprawdzającej
            for (int row = 0; row < Rows; row++)
                for (int column = 0; column < Columns; column++)
                    if (Map[row, column] != anotherPuzzle.Map[row, column])
                        return false;
            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int row = 0; row < Rows; row++)
            {
                sb.Append("{");
                for (int column = 0; column < Columns; column++)
                {
                    sb.Append(Map[row, column]);
                    if (column != Columns - 1)
                        sb.Append(", ");
                }
                sb.Append("}");
            }
            return sb.ToString();
        }
    }
}