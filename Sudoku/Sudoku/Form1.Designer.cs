using System.Windows.Forms;

namespace Sudoku
{
    partial class Form1
    {
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            int posx = 10;
            int posy = 10;
            int celdaTam = 50;
            this.test = new System.Windows.Forms.Button();
            this.SuspendLayout();
            sudokuGrid = new TextBox[9, 9];
            for (int row = 0; row < 9; row++)
            {
                posx = 20;
                for (int col = 0; col < 9; col++)
                {
                    TextBox celda = new TextBox()
                    {
                        Width = celdaTam,
                        Height = celdaTam,
                        MaxLength = 1,
                        Name = "textBox" + row + col
                    };
                    if (col==3||col==6)
                    {
                        posx += 10;    
                    }
                    celda.Location = new System.Drawing.Point(posx, posy);
                    this.Controls.Add(celda);
                    sudokuGrid[row,col]=celda;
                    posx += celdaTam + 10;
                }
                if (row == 2 || row == 5)
                {
                    posy += 50;
                }else
                posy += 35;
            }
            // 
            // test
            //
            this.test.Location = new System.Drawing.Point(600, 73);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(75, 23);
            this.test.TabIndex = 12;
            this.test.Text = "button1";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 650);
            this.Controls.Add(this.test);
            this.Name = "Form1";
            this.Text = "Sudoku";
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Button test;
        private TextBox[,] sudokuGrid; 
    }
}