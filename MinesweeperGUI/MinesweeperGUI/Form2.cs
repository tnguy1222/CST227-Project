using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CST227ProjectConsoleApp
{
    public partial class Form2 : Form
    {
        static public Board myBoard = new Board(10);

        
        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];
        String levelChoice;
        
        public Form2(String level)
        {
            InitializeComponent();
            populateGrid();
            levelChoice = level;
            
        }
        

        

        public void populateGrid()
        {
            int buttonSize = panel1.Width / myBoard.Size;
            panel1.Height = panel1.Width;

            myBoard.activeSomeCellswithBombs();
            myBoard.calcualateNeighbors();
            for(int r = 0; r< myBoard.Size; r++)
            {
                for(int c = 0; c < myBoard.Size; c++)
                {
                    btnGrid[r, c] = new Button();

                    btnGrid[r, c].Width = buttonSize;
                    btnGrid[r, c].Height = buttonSize;

                    btnGrid[r, c].Click += Grid_Button_Click;
                    panel1.Controls.Add(btnGrid[r, c]);
                    btnGrid[r, c].Location = new Point(buttonSize * r, buttonSize * c);

                    btnGrid[r, c].Tag = r.ToString() + "|" + c.ToString();
                }
            }
            

        }

        private void updateButtonLabels(Boolean showAllCells)
        {

            if (showAllCells == false)
            {
                // show only the cell contents that have been visited.
                for (int r = 0; r < myBoard.Size; r++)
                {
                    for (int c = 0; c < myBoard.Size; c++)
                    {
                        if (myBoard.theGrid[r, c].isVisited)
                        {
                            // show only the cells that the user has clicked and revealed.
                            if (myBoard.theGrid[r, c].hasABomb)
                            {
                                btnGrid[r, c].Text = "*";

                            }
                            if (!myBoard.theGrid[r, c].hasABomb)
                            {
                                btnGrid[r, c].Text = myBoard.theGrid[r, c].numberNeighborBombs.ToString();

                            }
                        }

                    }
                }
            }
            // show entire board with answers
            if (showAllCells == true)
            {
                for (int r = 0; r < myBoard.Size; r++)
                {
                    for (int c = 0; c < myBoard.Size; c++)
                    {
                        
                            // show only the cells that the user has clicked and revealed.
                            if (myBoard.theGrid[r, c].hasABomb)
                            {
                                btnGrid[r, c].Text = "*";

                            }
                            if (!myBoard.theGrid[r, c].hasABomb)
                            {
                                btnGrid[r, c].Text = myBoard.theGrid[r, c].numberNeighborBombs.ToString();

                            }
                        

                    }
                }
            }
          
        }

        private void Grid_Button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            String tag = (String) b.Tag;
            String [] tagParts = tag.Split('|');

            int rowClicked = int.Parse(  tagParts[0]);
            int colClicked = int.Parse(tagParts[1]);
            myBoard.theGrid[rowClicked, colClicked].isVisited = true;
            updateButtonLabels(false);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = levelChoice;

        }
    }
}
