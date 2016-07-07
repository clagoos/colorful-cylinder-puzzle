namespace ColorfulCylinderPuzzle.App
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelPuzzle = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelPuzzle
            // 
            this.panelPuzzle.Location = new System.Drawing.Point(43, 43);
            this.panelPuzzle.Name = "panelPuzzle";
            this.panelPuzzle.Size = new System.Drawing.Size(300, 300);
            this.panelPuzzle.TabIndex = 0;
            this.panelPuzzle.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPuzzle_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panelPuzzle);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPuzzle;
    }
}

