using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class Form4 : Form
    {
        string gameTime;
        int lv;
        
        public Form4(int levelChoice, String time)
        {
            InitializeComponent();
            lv = levelChoice;
            gameTime = time;
           
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label3.Text = gameTime;
            label5.Text = lv.ToString();

            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            
            string name = textBox1.Text.ToString();
            
            Int32.TryParse(label5.Text.ToString(), out lv);
            string gameTime = label3.Text.ToString();
            string playerScores = name.ToString()+ "," + gameTime.ToString()+ "," + lv.ToString();
            //string[] allScores = { name, lv, gameTime };

            string path = @"C:\Users\ThongPNguyen\Desktop\MinesweeperScores.txt";
            
            List<string> list = File.ReadAllLines(path).ToList();
            list.Add(playerScores);

            
            System.IO.File.WriteAllLines(path, list);

            High_Score highscoreform = new High_Score();
            highscoreform.Show();

        }
    }
}
