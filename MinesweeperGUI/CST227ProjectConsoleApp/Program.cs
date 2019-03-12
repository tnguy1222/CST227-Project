using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST227ProjectConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            MinesweeperGame game = new MinesweeperGame();
            game.playGame();
            Console.ReadLine();
        }

       
    }
}
