using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST227ProjectConsoleApp
{
    public class Board
    {
        public int Size { get; set; }
        public int Difficulty { get; set; }
        public Cell[,] theGrid;

        
        
        public Board(int s, int d)
        {
            Size = s;
            Difficulty = d;
            theGrid = new Cell[Size, Size];
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i,j,false,false,0, false);
                }
            }
        }
        //method to add bombs to random cells using difficulty level.
        public void activeSomeCellswithBombs(int Difficulty)
        {
            Random rng = new Random();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {

                    if (rng.Next(100) < Difficulty)
                    {
                        theGrid[i, j].hasABomb = true;
                    }

                }
            }
        }
        
        //calcualateNeighbors method to count the number of neighbor with bombs to display that number on safe cells
        public void calcualateNeighbors()
        {
            foreach(Cell currentcell in theGrid)
            {
                if(currentcell.hasABomb == false)
                {
                    currentcell.numberNeighborBombs = 0;
                    for (int r = -1; r<=1; r++)
                    {
                        for(int c = -1; c<=1; c++)
                        {
                            if (isValidate(currentcell.RowNumber + r, currentcell.ColumnNumber + c) && theGrid[currentcell.RowNumber + r, currentcell.ColumnNumber + c].hasABomb == true)
                            {
                                currentcell.numberNeighborBombs++;
                            }
                        }
                    }
                    if(currentcell.hasABomb == true)
                    {
                        currentcell.numberNeighborBombs = 9;
                    }

                }
            }
        }

        //check for out of bound error and make sure 
        public bool isValidate(int r, int c)
        {
            return (r >= 0 && r < Size && c >= 0 && c < Size);
        }

        //floodfil method to reveal neighbors that has the same number but not alive
        public void floodFill(int x, int y)
        {
            theGrid[x, y].isVisited = true;
            // Use floodfill recursively on all neighboring cells.
            
            for (int r = -1; r <= 1; r++)
            {
                for (int c = -1; c <= 1; c++)
                {
                    if (isValidate(x + r, y + c) && theGrid[x + r, y + c].isVisited == false && theGrid[x, y].numberNeighborBombs == 0)
                    {

                        floodFill(x + r, y + c);
                    }
                }
            }
        }
    }
}

