using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CST227ProjectConsoleApp.Grid;

namespace CST227ProjectConsoleApp
{
    public class MinesweeperGame : IPlayable<MinesweeperGame>

    {
        private int movecount;
        private int theSquare;

        public void playGame()
        {
            Console.WriteLine("How big do you want the the board?");
            int userchoice =  Convert.ToInt32(Console.ReadLine());
            Board b = new Board(userchoice);
            theSquare = userchoice * userchoice;
         
         
            // 1. choose the size of the board
            // 2. fill the grid with some bombs.
            b.activeSomeCellswithBombs();
            b.calcualateNeighbors();
            b.countBomb();
            
            // 3. Loop.
            Boolean endofGamereached = false;

            while (!endofGamereached)

            {
                //        a. ask the user for a row and column (two questions.  save results in two variables)
                Console.WriteLine("Enter the number of row you want to be");
                int rowNum = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the number of column you want to be");
                int colNum = Convert.ToInt32(Console.ReadLine());
                
                b.floodFill(rowNum, colNum);
                //        b. set visited to true from the r c chosen
                if (rowNum < userchoice && colNum < userchoice)
                {
                    b.theGrid[rowNum, colNum].isVisited = true;
                    movecount++;
                    
                }
                
                //        c. print the board.
                b.printGridwithAnswers();
                b.printGridduringGame();
                

                //        if square is bomb, end game and explode
                if (b.theGrid[rowNum,colNum].hasABomb)
                {
                    endofGamereached = true;
                    Console.WriteLine("KAAAABOOOOOOOOOMMMMMM!!!!");
                }
                // if all the square is visited and player visit no bomb, end game and write play win
                if (movecount == theSquare - b.countBomb())
                {
                    endofGamereached = true;
                    Console.WriteLine("You win!!!");
                }



            }
        }
        
    }
}
