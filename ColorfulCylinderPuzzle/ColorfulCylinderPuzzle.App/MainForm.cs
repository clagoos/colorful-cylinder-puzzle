using ColorfulCylinderPuzzle.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ColorfulCylinderPuzzle.App
{
    public partial class MainForm : Form
    {
        private readonly Puzzle puzzle;
        private readonly Dictionary<Colors, SolidBrush> colorBrushes;

        private Rectangle[,] puzzlePieces;

        public MainForm()
        {
            InitializeComponent();
            puzzle = StandardPuzzleInitializer.GetUpperSolvedPuzzle();
            colorBrushes = InitializeColorBrushes();
        }

        private static Rectangle[,] InitializeRectangles(int panelWidth, int panelHeight, int puzzleRows, int puzzleColumns)
        {
            var rectangles = new Rectangle[puzzleRows, puzzleColumns];
            var singleItemWidth = panelWidth / puzzleColumns;
            var singleItemHeight = panelHeight / puzzleRows;
            var size = new Size(singleItemWidth, singleItemHeight);
            for (int row = 0; row < puzzleRows; row++)
            {
                for (int column = 0; column < puzzleColumns; column++)
                {
                    var position = new Point(column * singleItemWidth, row * singleItemHeight);
                    rectangles[row, column] = new Rectangle(position, size);
                    rectangles[row, column].Inflate(-2, -2);
                }
            }
            return rectangles;
        }

        private static Dictionary<Colors, SolidBrush> InitializeColorBrushes()
        {
            return Enum.GetNames(typeof(Colors))
                .ToDictionary(
                    colorName => (Colors)Enum.Parse(typeof(Colors), colorName),
                    colorName => new SolidBrush(Color.FromName(colorName)));
        }

        private void panelPuzzle_Paint(object sender, PaintEventArgs e)
        {
            var panel = sender as Panel;
            if (panel == null) return;
            if (puzzlePieces == null)
                puzzlePieces = InitializeRectangles(panel.Width, panel.Height, puzzle.Rows, puzzle.Columns);
            for (int row = 0; row < puzzle.Rows; row++)
            {
                for (int column = 0; column < puzzle.Columns; column++)
                {
                    var brush = colorBrushes[(Colors)puzzle.Map[row, column]];
                    var rectangle = puzzlePieces[row, column];
                    e.Graphics.FillRectangle(brush, rectangle);
                }
            }
        }

        private void TryMakeMoveAndRefresh(Action move)
        {
            try
            {
                move.Invoke();
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show(e.Message);
            }
            panelPuzzle.Refresh();
        }

        private void LogMessage(string message)
        {
            textBoxLog.AppendText($"{DateTime.Now.ToString("HH:mm:ss")} - {message}\n");
        }

        private void ClearLog()
        {
            textBoxLog.Clear();
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (puzzle.IsInUpPosition)
            {
                TryMakeMoveAndRefresh(puzzle.MakeMoveDown);
                LogMessage("Down");
            }
            else
            {
                TryMakeMoveAndRefresh(puzzle.MakeMoveUp);
                LogMessage("Up");
            }
        }

        private void buttonUpRotateLeft_Click(object sender, EventArgs e)
        {
            TryMakeMoveAndRefresh(puzzle.MakeMoveUpperRotateLeft);
            LogMessage("Rotate Up Left");
        }

        private void buttonUpRotateRight_Click(object sender, EventArgs e)
        {
            TryMakeMoveAndRefresh(puzzle.MakeMoveUpperRotateRight);
            LogMessage("Rotate Up Right");
        }

        private void buttonDownRotateLeft_Click(object sender, EventArgs e)
        {
            TryMakeMoveAndRefresh(puzzle.MakeMoveLowerRotateLeft);
            LogMessage("Rotate Down Left");
        }

        private void buttonDownRotateRight_Click(object sender, EventArgs e)
        {
            TryMakeMoveAndRefresh(puzzle.MakeMoveLowerRotateRight);
            LogMessage("Rotate Down Right");
        }

        private void buttonClearPuzzle_Click(object sender, EventArgs e)
        {
            puzzle.SetUpPuzzleInUpperSolvedPosition();
            ClearLog();
            LogMessage("Puzzle reset to upper solved position!");
            panelPuzzle.Refresh();
        }
    }
}