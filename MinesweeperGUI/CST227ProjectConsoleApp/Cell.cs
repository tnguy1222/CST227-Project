using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST227ProjectConsoleApp
{
    public class Cell
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public bool isVisited { get; set; }
        public bool hasABomb { get; set; }

        public int numberNeighborBombs { get; set; }
        public bool cellFlagged { get; set; }
        public Cell(int r, int c, bool v,bool b, int n, bool f)
        {
            RowNumber = r;
            ColumnNumber = c;
            isVisited = v;
            hasABomb = b;
            numberNeighborBombs = n;
            cellFlagged = f;
        }
    }
}
