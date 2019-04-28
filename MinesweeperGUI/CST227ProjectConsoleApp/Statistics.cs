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
        public int Time { get; set; }

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

    }
}
