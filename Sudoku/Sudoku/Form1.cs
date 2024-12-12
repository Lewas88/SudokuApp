using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        private int[,] board = new int[9,9];
        public Form1()
        {
            InitializeComponent();            
        }


        private void test_Click(object sender, EventArgs e)
        {
            upgradeGrid(createRandomBoard());
            /*obtenerTextboxes();
            string message = "";
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    message += board[j, i];
                }
                message += "\n";
            }
            MessageBox.Show(message);*/
            if (!isSafe(0, 0))
            {
                MessageBox.Show("Repetido");
            }
        }
        private void obtenerTextboxes()
        {
            for (int rows = 0; rows < 9; rows++)
            {
                for (int column = 0; column < 9; column++)
                {
                    if (int.TryParse(sudokuGrid[column, rows].Text, out int value))
                    {
                        board[column, rows] = value;
                    }
                    else
                    {
                        board[column, rows] = 0;
                    }
                }
            }
        }
        private void upgradeGrid(int[,] boardAux)
        {
            for (int rows = 0; rows < 9; rows++)
            {
                for (int column = 0; column < 9; column++)
                {
                    sudokuGrid[column,rows].Text = boardAux[column,rows].ToString();
                }
            }
        }
        private int[,] createRandomBoard()
        {
            int[,] boardC = new int[9, 9];
            boardC[0, 2] = 1;
            boardC[0, 1] = 2;
            boardC[0, 0] = 3;
            //boardC[0, 8] = 3;
            boardC[2, 1] = 3;
            return boardC;  
        }
        private bool isSafe(int col,int row)
        {
            obtenerTextboxes();
            int valueCheck = board[col, row];
            //Check the subgrid
            int startRow = (row / 3) * 3;
            int startCol = (col / 3) * 3;

            // Recorre el cuadrante 3x3
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int aux = board[startRow + i, startCol + j];
                    // Si se encuentra el número y no es la posición actual, retorna true
                    if (aux == valueCheck && (startRow + i != row || startCol + j != col))
                    {
                        return false;
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                int valueCol = board[i, row];
                //Check the col
                if (valueCheck == valueCol && i != col)
                {
                    return false;
                }
                int valueRow = board[col, i];
                //Check the row
                if (valueCheck == valueRow && i != row)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
