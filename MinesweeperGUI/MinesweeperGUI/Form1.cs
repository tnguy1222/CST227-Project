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
        public string level;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                level = radioButton1.Text;
            }else if (radioButton2.Checked)
            {
                level = radioButton2.Text;
        
            }else if (radioButton3.Checked)
            {
                level = radioButton3.Text;
                
            }
            Form2 form2 = new Form2(level);
            this.Hide();
            form2.Show();
        }

        
    }
}
