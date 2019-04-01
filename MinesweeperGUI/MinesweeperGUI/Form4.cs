using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class Form4 : Form
    {
        String gameTime;

        public Form4(String time)
        {
            InitializeComponent();
            gameTime = time;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label3.Text = gameTime;
        }
    }
}
