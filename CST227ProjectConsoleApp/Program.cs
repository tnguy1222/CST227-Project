using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST227ProjectConsoleApp
{
    class Program
    {

        static Board b = new Board(10);
        static void Main(string[] args)
        {
            
            b.activeSomeCellswithBombs();
            b.printGrid();
          
            Console.ReadLine();
        }
    }
}
