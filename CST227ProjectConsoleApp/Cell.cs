using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST227ProjectConsoleApp
{
    class Cell
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }

        public bool hasABomb { get; set; }

        public int numberNeighborBombs { get; set; }

        public Cell(int RowNumber, int ColumnNumber, bool hasABomb, int numberNeighborBombs)
        {
            RowNumber = -1;
            ColumnNumber = -1;
            hasABomb = false;
            numberNeighborBombs = 0; 
        }
    }
}
