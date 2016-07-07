using System.Drawing;
using System.Windows.Forms;
using ColorfulCylinderPuzzle.Logic;

namespace ColorfulCylinderPuzzle.App
{
    public partial class MainForm : Form
    {
        private Puzzle puzzle;
        private Rectangle[,] puzzlePieces;

        public MainForm()
        {
            InitializeComponent();
            puzzle = StandardPuzzleInitializer.GetUpperSolvedPuzzle();
            puzzlePieces = new Rectangle[puzzle.Rows, puzzle.Columns];
        }

        private void panelPuzzle_Paint(object sender, PaintEventArgs e)
        {
            var panel = sender as Panel;
            if (panel == null) return;
            var singleItemWidth = panel.Width / puzzle.Columns;
            var singleItemHeight = panel.Height / puzzle.Rows;
            for (int row = 0; row < puzzle.Rows; row++)
            {
                for (int column = 0; column < puzzle.Columns; column++)
                {
                    //l: todo: narysuj kwadrat! :)
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