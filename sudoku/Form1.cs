using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudoku
{
    public partial class Form1 : Form
    {
        SudokuGrid grid;
        public Form1()
        {
            InitializeComponent();
            grid = new SudokuGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            grid.GenerateGrid();
            this.textBox1.Text = grid.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grid.Reset();
            grid.GenerateGrid();
            this.textBox1.Text = grid.ToString();
        }
    }
}
