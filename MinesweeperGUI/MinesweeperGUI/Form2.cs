using CST227ProjectConsoleApp;
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

namespace MinesweeperGUI
{
    public partial class Form2 : Form
    {
        public Board myBoard;
        public Button[,] btnGrid;
        
        public string time;
        public int theSquare;
        public int safemove;

        public int clicks = 0;
        public static Stopwatch watch = new Stopwatch();
        int levelChoice;
        
        

        public Form2(int Size, int Difficulty, int Level)
        {
            InitializeComponent();
            
            
            myBoard = new Board(Size, Difficulty);
            
            btnGrid = new Button[myBoard.Size, myBoard.Size];
            myBoard.activeSomeCellswithBombs(Difficulty);
            levelChoice = Level;
            myBoard.calcualateNeighbors();
            populateGrid();
            watch.Start();
        }
       

        public void populateGrid()
        {
           
            int buttonSize = panel1.Width / myBoard.Size;
            panel1.Height = panel1.Width;

            
            for(int r = 0; r< myBoard.Size; r++)
            {
                for(int c = 0; c < myBoard.Size; c++)
                {
                    btnGrid[r, c] = new Button();

                    btnGrid[r, c].Width = buttonSize;
                    btnGrid[r, c].Height = buttonSize;

                    btnGrid[r, c].Click += HandleButtonClick;
                    btnGrid[r, c].MouseDown += HandlerMouseDown;
                    panel1.Controls.Add(btnGrid[r, c]);
                    btnGrid[r, c].Location = new Point(buttonSize * r, buttonSize * c);

                    btnGrid[r, c].Tag = new Point(r,c);
                }
            }
            

        }

        private void HandlerMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                Button buttonClicked = (Button)sender;
                Point p = (Point)buttonClicked.Tag;
                myBoard.theGrid[p.X, p.Y].cellFlagged = !myBoard.theGrid[p.X, p.Y].cellFlagged;

                displayBoard(false, p);
            }
        }

        private void HandleButtonClick(object sender, EventArgs e)
        {
            //Button b = (Button)sender;
            Point p = (Point)(sender as Button).Tag;

            //String tag = (String) b.Tag;
            //String [] tagParts = tag.Split('|');


            int row, col;
            row = p.X;
            col = p.Y;
            
            PlaceTurn(row, col);
            displayBoard(false, p);
            clicks++;
            //label5.Text = clicks.ToString();
        }
        private void displayBoard(bool refreshBoard, Point p)
        {
            if (refreshBoard)
            {
                for(int r = 0; r < myBoard.Size; r++)
                {
                    for(int c = 0; c < myBoard.Size; c++)
                    {
                        updateOneCell(r, c);
                    }
                }
            }
            else
            {
                updateOneCell(p.X, p.Y);
            }

            void updateOneCell(int r, int c)
            {
                btnGrid[r, c].BackgroundImage = null;

                if(myBoard.theGrid[r,c].isVisited == true && myBoard.theGrid[r,c].numberNeighborBombs != 0)
                {
                    btnGrid[r, c].Text = myBoard.theGrid[r, c].numberNeighborBombs.ToString();
                    btnGrid[r, c].BackColor = Color.White;
                }
                else if(myBoard.theGrid[r, c].isVisited == true && myBoard.theGrid[r, c].numberNeighborBombs == 0)
                {
                    btnGrid[r, c].BackColor = Color.White;
                }else if (myBoard.theGrid[r, c].cellFlagged)
                {
                    btnGrid[r, c].Text = "^";
                }
            }
        }

        public void displayBombs(bool winner)
        
        {
            if(winner == false)
            {
                for(int r = 0; r < myBoard.Size; r++)
                {
                    for(int c = 0; c<myBoard.Size; c++)
                    {
                        if (myBoard.theGrid[r, c].hasABomb)
                        {
                            btnGrid[r, c].Text = "*";
                        }
                           
                    }
                }
            }
            else
            {
                for (int r = 0; r < myBoard.Size; r++)
                {
                    for (int c = 0; c < myBoard.Size; c++)
                    {
                        if (myBoard.theGrid[r, c].hasABomb)
                        {
                            btnGrid[r, c].Text = "^";
                        }

                    }
                }

            }
        }

        public bool checkWinCondition()
        {
            bool winCondition = true;
            for(int i = 0; i < myBoard.Size; i++)
            {
                for(int j = 0; j <myBoard.Size; j++)
                {
                    if(myBoard.theGrid[i,j].isVisited==false && myBoard.theGrid[i,j].hasABomb == false)
                    {
                        winCondition = false;
                    }
                }
            }

            return winCondition;
        }
       
       
        

        private void PlaceTurn(int rowNumber, int columnNumber)
        {
            if (myBoard.isValidate(rowNumber, columnNumber) && myBoard.theGrid[rowNumber, columnNumber].isVisited == false && myBoard.theGrid[rowNumber, columnNumber].hasABomb == false)
            {
                myBoard.theGrid[rowNumber, columnNumber].isVisited = true;

                if (myBoard.theGrid[rowNumber, columnNumber].numberNeighborBombs == 0)
                {
                    myBoard.floodFill(rowNumber, columnNumber);
                }
                displayBoard(true, new Point(0, 0));
                if (checkWinCondition() == true)
                {
                    watch.Stop();
                    displayBoard(true, new Point(0, 0));
                    displayBombs(true);

                    //MessageBox.Show("You won. Time = " + watch.Elapsed.ToString());
                    time = watch.Elapsed.ToString();
                    Form4 f4 = new Form4(levelChoice,time);
                    f4.Show();
                    
                }
            }
            else if (myBoard.isValidate(rowNumber, columnNumber) && myBoard.theGrid[rowNumber, columnNumber].isVisited == false && myBoard.theGrid[rowNumber, columnNumber].hasABomb == true)
            {
                for (int i = 0; i < myBoard.Size; i++)
                {
                    for (int j = 0; j < myBoard.Size; j++)
                    {
                        myBoard.theGrid[i, j].isVisited = true;
                    }
                }
                watch.Stop();
                displayBoard(true, new Point(0, 0));
                displayBombs(false);
                //MessageBox.Show("Bomb! you lose");
                time = watch.Elapsed.ToString();
                Form3 f3 = new Form3(time);
                
                f3.Show();
            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = levelChoice.ToString();

        }

        public void timer1_Tick(object sender, EventArgs e)
        {
           
           
            label2.Text = watch.Elapsed.ToString();
        }

      
    }
}
