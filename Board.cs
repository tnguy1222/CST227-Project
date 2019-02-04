using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST227ProjectConsoleApp
{
    class Board
    {
        public int Size { get; set; }

        public Cell[,] theGrid;
        private int bombCount;

        public Board(int s)
        {
            Size = s;
            theGrid = new Cell[Size, Size];
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i,j,false,false,0);
                }
            }
        }

        public Boolean isValidate(int r, int c)
        {
            return (r >= 0 && r < Size && c >= 0 && c < Size);
        }




        public void printGridduringGame()

        // similar to the prev printGrid.
        // instead of printing all cells. print ? if the cell is not visited.  print a number if neighborbombs > 0.  print ~ if the cell has no neighbor bombs.
        {
            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < Size; j++)
                {
                    
                    if (this.theGrid[i, j].isVisited)
                    {
                        if (theGrid[i, j].hasABomb)
                        {
                            Console.Write("*");
                        }
                        
                        else if (theGrid[i, j].numberNeighborBombs > 0)
                        {
                            Console.Write(theGrid[i, j].numberNeighborBombs);
                        }
                        else
                        {
                            Console.Write("~");
                        }
                    }
                    else
                    {
                        Console.Write("?");
                    }


                }
            }
            Console.WriteLine();
        }

        public void printGridwithAnswers()
            // prints the board.  Shows all bombs and numbers.  Assumes that all cells are visited.
        {
            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < Size; j++)
                {
                    
                    if (theGrid[i,j].hasABomb )
                    Console.Write("*");
                    else
                    {
                        Console.Write(theGrid[i, j].numberNeighborBombs);
                    }
                }
            }
            Console.WriteLine();
        }

        public void calcualateNeighbors()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (isValidate(i + 1, j) && theGrid[i + 1, j].hasABomb)
                    {
                        theGrid[i,j].numberNeighborBombs++;
                    }
                    if (isValidate(i + 1, j + 1) && theGrid[i + 1, j + 1].hasABomb)
                    {
                        theGrid[i, j].numberNeighborBombs++;
                    }
                    if (isValidate(i + 1, j - 1) && theGrid[i + 1, j - 1].hasABomb)
                    {
                        theGrid[i, j].numberNeighborBombs++;
                    }
                    if (isValidate(i, j - 1) && theGrid[i, j - 1].hasABomb)
                    {
                        theGrid[i, j].numberNeighborBombs++;
                    }
                    if (isValidate(i, j + 1) && theGrid[i, j + 1].hasABomb)
                    {
                        theGrid[i, j].numberNeighborBombs++;
                    }
                    if (isValidate(i - 1, j) && theGrid[i - 1, j].hasABomb)
                    {
                        theGrid[i, j].numberNeighborBombs++;
                    }
                    if (isValidate(i - 1, j + 1) && theGrid[i - 1, j + 1].hasABomb)
                    {
                        theGrid[i, j].numberNeighborBombs++;
                    }
                    if (isValidate(i - 1, j - 1) && theGrid[i - 1, j - 1].hasABomb)
                    {
                        theGrid[i, j].numberNeighborBombs++;

                    }
                }

            }
            


        }
        


        public void activeSomeCellswithBombs()
        {
            Random rng = new Random();
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        double nextnumber = rng.NextDouble();
                        if (nextnumber < 0.2)
                        {
                            theGrid[i, j].hasABomb = true;
                        }
                  
                    }
                }
        }
        public int countBomb()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (theGrid[i, j].hasABomb)
                    {
                        bombCount++;
                    }
                }
            }
            return bombCount;
            
        }
       
    }
}

