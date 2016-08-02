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
            this.buttonUpDown = new System.Windows.Forms.Button();
            this.buttonUpRotateLeft = new System.Windows.Forms.Button();
            this.buttonUpRotateRight = new System.Windows.Forms.Button();
            this.buttonDownRotateLeft = new System.Windows.Forms.Button();
            this.buttonDownRotateRight = new System.Windows.Forms.Button();
            this.buttonClearPuzzle = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.labelLog = new System.Windows.Forms.Label();
            this.labelPuzzle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelPuzzle
            // 
            this.panelPuzzle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPuzzle.Location = new System.Drawing.Point(183, 42);
            this.panelPuzzle.Name = "panelPuzzle";
            this.panelPuzzle.Size = new System.Drawing.Size(301, 301);
            this.panelPuzzle.TabIndex = 0;
            this.panelPuzzle.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPuzzle_Paint);
            // 
            // buttonUpDown
            // 
            this.buttonUpDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUpDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonUpDown.Location = new System.Drawing.Point(561, 44);
            this.buttonUpDown.Name = "buttonUpDown";
            this.buttonUpDown.Size = new System.Drawing.Size(50, 50);
            this.buttonUpDown.TabIndex = 1;
            this.buttonUpDown.Text = "Up / Down";
            this.buttonUpDown.UseVisualStyleBackColor = true;
            this.buttonUpDown.Click += new System.EventHandler(this.buttonUpDown_Click);
            // 
            // buttonUpRotateLeft
            // 
            this.buttonUpRotateLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUpRotateLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonUpRotateLeft.Location = new System.Drawing.Point(518, 115);
            this.buttonUpRotateLeft.Name = "buttonUpRotateLeft";
            this.buttonUpRotateLeft.Size = new System.Drawing.Size(50, 50);
            this.buttonUpRotateLeft.TabIndex = 2;
            this.buttonUpRotateLeft.Text = "UL";
            this.buttonUpRotateLeft.UseVisualStyleBackColor = true;
            this.buttonUpRotateLeft.Click += new System.EventHandler(this.buttonUpRotateLeft_Click);
            // 
            // buttonUpRotateRight
            // 
            this.buttonUpRotateRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUpRotateRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonUpRotateRight.Location = new System.Drawing.Point(599, 115);
            this.buttonUpRotateRight.Name = "buttonUpRotateRight";
            this.buttonUpRotateRight.Size = new System.Drawing.Size(50, 50);
            this.buttonUpRotateRight.TabIndex = 3;
            this.buttonUpRotateRight.Text = "UR";
            this.buttonUpRotateRight.UseVisualStyleBackColor = true;
            this.buttonUpRotateRight.Click += new System.EventHandler(this.buttonUpRotateRight_Click);
            // 
            // buttonDownRotateLeft
            // 
            this.buttonDownRotateLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDownRotateLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDownRotateLeft.Location = new System.Drawing.Point(518, 187);
            this.buttonDownRotateLeft.Name = "buttonDownRotateLeft";
            this.buttonDownRotateLeft.Size = new System.Drawing.Size(50, 50);
            this.buttonDownRotateLeft.TabIndex = 4;
            this.buttonDownRotateLeft.Text = "DL";
            this.buttonDownRotateLeft.UseVisualStyleBackColor = true;
            this.buttonDownRotateLeft.Click += new System.EventHandler(this.buttonDownRotateLeft_Click);
            // 
            // buttonDownRotateRight
            // 
            this.buttonDownRotateRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDownRotateRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDownRotateRight.Location = new System.Drawing.Point(599, 187);
            this.buttonDownRotateRight.Name = "buttonDownRotateRight";
            this.buttonDownRotateRight.Size = new System.Drawing.Size(50, 50);
            this.buttonDownRotateRight.TabIndex = 5;
            this.buttonDownRotateRight.Text = "DR";
            this.buttonDownRotateRight.UseVisualStyleBackColor = true;
            this.buttonDownRotateRight.Click += new System.EventHandler(this.buttonDownRotateRight_Click);
            // 
            // buttonClearPuzzle
            // 
            this.buttonClearPuzzle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClearPuzzle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClearPuzzle.Location = new System.Drawing.Point(542, 293);
            this.buttonClearPuzzle.Name = "buttonClearPuzzle";
            this.buttonClearPuzzle.Size = new System.Drawing.Size(80, 50);
            this.buttonClearPuzzle.TabIndex = 7;
            this.buttonClearPuzzle.Text = "Clear Puzzle";
            this.buttonClearPuzzle.UseVisualStyleBackColor = true;
            this.buttonClearPuzzle.Click += new System.EventHandler(this.buttonClearPuzzle_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLog.Font = new System.Drawing.Font("Comic Sans MS", 7F);
            this.textBoxLog.Location = new System.Drawing.Point(21, 58);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(156, 285);
            this.textBoxLog.TabIndex = 8;
            // 
            // labelLog
            // 
            this.labelLog.AutoSize = true;
            this.labelLog.Location = new System.Drawing.Point(18, 42);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(71, 13);
            this.labelLog.TabIndex = 9;
            this.labelLog.Text = "Moves made:";
            // 
            // labelPuzzle
            // 
            this.labelPuzzle.AutoSize = true;
            this.labelPuzzle.Location = new System.Drawing.Point(180, 26);
            this.labelPuzzle.Name = "labelPuzzle";
            this.labelPuzzle.Size = new System.Drawing.Size(41, 13);
            this.labelPuzzle.TabIndex = 10;
            this.labelPuzzle.Text = "Puzzle:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 436);
            this.Controls.Add(this.labelPuzzle);
            this.Controls.Add(this.labelLog);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonClearPuzzle);
            this.Controls.Add(this.buttonDownRotateRight);
            this.Controls.Add(this.buttonDownRotateLeft);
            this.Controls.Add(this.buttonUpRotateRight);
            this.Controls.Add(this.buttonUpRotateLeft);
            this.Controls.Add(this.buttonUpDown);
            this.Controls.Add(this.panelPuzzle);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPuzzle;
        private System.Windows.Forms.Button buttonUpDown;
        private System.Windows.Forms.Button buttonUpRotateLeft;
        private System.Windows.Forms.Button buttonUpRotateRight;
        private System.Windows.Forms.Button buttonDownRotateLeft;
        private System.Windows.Forms.Button buttonDownRotateRight;
        private System.Windows.Forms.Button buttonClearPuzzle;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.Label labelPuzzle;
    }
}

