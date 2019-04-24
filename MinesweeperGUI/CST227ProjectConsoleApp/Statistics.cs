using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperGUI
{
    public class Statistics: IComparable<Statistics>
    {
        

        public string Name { get; set; }
        public int  Difficulty { get; set; }
        public string Time { get; set; }

        public int CompareTo(Statistics other)
        {
            if(this.Time == other.Time)
            {
                if(this.Difficulty == other.Difficulty)
                {
                    return this.Difficulty.CompareTo(other.Difficulty);
                }
            }
            return this.Time.CompareTo(other.Time);
        }

        public override string ToString()
        {
           return this.Name.ToString() + " ," + this.Difficulty.ToString() + " ," + this.Time.ToString();
            
        }

        //static void Main(string[] args)
        //{
            
        //    string path = @"C:\Users\ThongPNguyen\Desktop\MinesweeperScores.txt";
            
        //    List<string> list = File.ReadAllLines(path).ToList();
        //    string[] scores;

        //    /* var highscores = from scores in list orderby scores select scores;
        //    for( var scores in highscores)
        //    {
        //        Console.WriteLine("They are {0}", scores);
        //    }
        //    */
        //    Console.ReadLine();

        
    }
}
