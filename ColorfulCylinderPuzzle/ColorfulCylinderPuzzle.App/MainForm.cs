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

        private void InitializeRectangles(int panelWidth, int panelHeight)
        {
            puzzlePieces = new Rectangle[puzzle.Rows, puzzle.Columns];
            var singleItemWidth = panelWidth / puzzle.Columns;
            var singleItemHeight = panelHeight / puzzle.Rows;
            var size = new Size(singleItemWidth, singleItemHeight);
            for (int row = 0; row < puzzle.Rows; row++)
            {
                for (int column = 0; column < puzzle.Columns; column++)
                {
                    var position = new Point(column * singleItemWidth, row * singleItemHeight);
                    puzzlePieces[row, column] = new Rectangle(position, size);
                    puzzlePieces[row, column].Inflate(-2, -2);
                }
            }
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
                InitializeRectangles(panel.Width, panel.Height);
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

        //do odświeżania panelu, np po kliknięciu gdzieś:
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    panel1.Refresh();
        //}
    }
}