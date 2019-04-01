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
    public partial class Form3 : Form
    {
        String gameTime;
        public Form3(String time)
        {
            InitializeComponent();
            gameTime = time;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label2.Text = gameTime;
        }
    }
}
