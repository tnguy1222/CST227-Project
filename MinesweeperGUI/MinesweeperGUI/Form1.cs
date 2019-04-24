using CST227ProjectConsoleApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class Form1 : Form
    {
        static int Size;
        static int Difficulty = 9;
        static int Level;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Size = 5;
                Difficulty = 20;
                Level = 1;
            }else if (radioButton2.Checked)
            {
                Size = 8;
                Difficulty = 20;
                Level = 2;
            }
            else if (radioButton3.Checked)
            {
                Size = 10;
                Difficulty = 25;
                Level = 3;
            }
            Form2 form2 = new Form2(Size,Difficulty, Level);
            this.Hide();
            form2.Show();
        }

        
    }
}
