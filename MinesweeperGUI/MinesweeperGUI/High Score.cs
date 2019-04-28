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
    public partial class High_Score : Form
    {
        public High_Score()
        {
            InitializeComponent();
        }

        // load method
        private void High_Score_Load(object sender, EventArgs e)
        {
            // read the text file
            string path = @"C:\Users\ThongPNguyen\Desktop\MinesweeperScores.txt";

            // declare a new list 
            List<Statistics> highscorelist = new List<Statistics>();
            List<string> list = File.ReadAllLines(path).ToList();
            // for each line
            foreach (string l in list)
            {
                // split the line into 3 parts.
                string[] entries = l.Split(',');

                Statistics s = new Statistics();

                // string name
                s.Name = entries[0];
                // int time
                String time = entries[1];
                int hour;
                int minute;
                int second;
                bool success = Int32.TryParse(time.Substring(0, 2), out hour);
                
                bool success1 = Int32.TryParse(time.Substring(3, 2), out minute);
                bool success2 = Int32.TryParse(time.Substring(6, 2), out second);
               
                int totalsec = 3600 * hour +  60 * minute + second;
                s.Time = totalsec;
                

                

                // int level diff
                int d;
                Int32.TryParse(entries[2], out d);
                s.Difficulty = d;




                // create new instance of Statics object

                ///Statitcs s = new Statistics (name, time, diff)

                // hiscorelist.add(s);
                highscorelist.Add(s);

                // now you can sort the highscore list using linq.  sort by name, score , level etc.

                

            }
            // end foreach
            //LinQ applied to sort highest score
            var highScore = from score in highscorelist orderby score select score;
            foreach (var score in highScore)
            {
                listBox1.Items.Add(score.ToString());
            }
        }


    }
}
