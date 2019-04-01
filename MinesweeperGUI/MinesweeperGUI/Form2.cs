using MinesweeperGUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private string time;
        public int theSquare;
        public int safemove;
        public static Stopwatch watch = new Stopwatch();
        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];
        String levelChoice;
        private int numberBombs;

        public Form2(String level)
        {
            InitializeComponent();
            populateGrid();
            levelChoice = level;
            
        }
       

        public void populateGrid()
        {
            int theSquare = 10 * 10;
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
                                numberBombs++;
                            }
                            if (!myBoard.theGrid[r, c].hasABomb)
                            {
                                btnGrid[r, c].Text = myBoard.theGrid[r, c].numberNeighborBombs.ToString();
                                safemove++;
                            }

                    }
                }
                watch.Stop();
                Form3 form3 = new Form3(time);
                form3.Show();
            }

        }

        public void gameWin()
        {
            if(safemove == theSquare - numberBombs)
            {
                watch.Stop();
                Form4 form4 = new Form4(time);
                form4.Show();
            }
        }
       
        private void Grid_Button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            String tag = (String) b.Tag;
            String [] tagParts = tag.Split('|');

            watch.Start();
            int rowClicked = int.Parse(tagParts[0]);
            int colClicked = int.Parse(tagParts[1]);
            myBoard.theGrid[rowClicked, colClicked].isVisited = true;
            if (myBoard.theGrid[rowClicked, colClicked].isVisited && myBoard.theGrid[rowClicked, colClicked].hasABomb)
            {
                updateButtonLabels(true);
            }
            else
            {
                updateButtonLabels(false);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = levelChoice;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time = watch.Elapsed.ToString();
            label2.Text = time.ToString();
        }
    }
}
