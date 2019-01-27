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

        public Board(int s)
        {
            Size = s;
            theGrid = new Cell[Size, Size];
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i,j,false,0);
                }
            }
        }

        public Boolean isValidate(int r, int c)
        {
            return (r >= 0 && r < Size && c >= 0 && c < Size);
        }
        public void printGrid()
        {
            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < Size; j++)
                {
                    int count = 0;
                    if (theGrid[i,j].hasABomb )
                    Console.Write("*");
                    else
                    {
                        
                        if (isValidate(i + 1, j) && theGrid[i + 1, j].hasABomb)
                        {
                            count++;
                            
                        }
                        if (isValidate(i + 1, j + 1) && theGrid[i + 1, j + 1].hasABomb)
                        {
                            count++;
                            
                        }
                        if (isValidate(i + 1, j - 1) && theGrid[i + 1, j - 1].hasABomb)
                        {
                            count++;
                            
                        }
                        if (isValidate(i, j - 1) && theGrid[i, j - 1].hasABomb)
                        {
                            count++;
                            
                        }
                        if (isValidate(i, j + 1) && theGrid[i, j + 1].hasABomb)
                        {
                            count++;
                            
                        }
                        if (isValidate(i - 1, j) && theGrid[i - 1, j].hasABomb)
                        {
                            count++;
                            
                        }
                        if (isValidate(i - 1, j + 1) && theGrid[i - 1, j + 1].hasABomb)
                        {
                            count++;
                            
                        }
                        if (isValidate(i - 1, j - 1) && theGrid[i - 1, j - 1].hasABomb)
                        {
                            count++;
                            
                        }
                        Console.Write(count);
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
    }
}

