using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form1 : Form
    {

        private static int[,] virtualMap = new int[9, 9];

        public Form1()
        {
            InitializeComponent();
           
            GenerateMap(panel);
            GenerateNumbers(virtualMap, panel);
        }
         public static void GenerateMap(TableLayoutPanel panel )
        {
            int ColorChange = 1;
            bool isGrey = true;
            for(int i = 0; i<panel.RowCount;i++)
                for(int j = 0; j<panel.ColumnCount;j++)
                {
                    Button btn = new Button();
                   
                    btn.Margin = new Padding(0);
                    btn.Dock = DockStyle.Fill;
                    btn.Font = new Font("Arial", 12, FontStyle.Bold);
                   //color the butons 
                  


                    panel.Controls.Add(btn, j, i);

                }
            for (int i = 0; i < panel.RowCount - 2; i += 3)
                for (int j = 0; j < panel.ColumnCount - 2; j+=3)
                {
                    if (ColorChange % 2 == 0)
                    {
                        panel.GetControlFromPosition(j, i).BackColor = Color.DarkGray;
                        panel.GetControlFromPosition(j, i + 1).BackColor = Color.DarkGray;
                        panel.GetControlFromPosition(j, i + 2).BackColor = Color.DarkGray;
                        panel.GetControlFromPosition(j+1, i).BackColor = Color.DarkGray;
                        panel.GetControlFromPosition(j+2, i ).BackColor = Color.DarkGray;
                        panel.GetControlFromPosition(j, i ).BackColor = Color.DarkGray;
                        panel.GetControlFromPosition(j+1, i+1 ).BackColor = Color.DarkGray;
                        panel.GetControlFromPosition(j+2, i+1 ).BackColor = Color.DarkGray;
                        panel.GetControlFromPosition(j+1, i+2 ).BackColor = Color.DarkGray;
                        panel.GetControlFromPosition(j+2, i+2 ).BackColor = Color.DarkGray;
                        
                       
                        ColorChange++;
                    }
                    else
                    {
                       
                        ColorChange++;
                    }
                }
                


        }
        public static void GenerateNumbers(int[,] virtualMap, TableLayoutPanel panel )
        {


            Random rnd = new Random();
            int numbersToPick = 3;

            for (int i = 0; i < panel.RowCount - 1; i += 3)
                for (int j = 0; j < panel.ColumnCount - 1; j += 3)
                {
                    Console.WriteLine();
                        numbersToPick = 5;
                    List<int> digits = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                    while (numbersToPick > 0)
                    {     
                        int pickedPos = rnd.Next(0, digits.Count -1 );
                        int pickedNumber = digits[pickedPos];
                        int rnd_x = rnd.Next(j, j + 3);
                        int rnd_y = rnd.Next(i, i + 3);
                        bool eligible = false;
                        while (eligible == false )
                        {

                            if (isEligible(pickedNumber, virtualMap, (rnd_x, rnd_y)))
                            {
                                
                                //then number is good to go 


                                panel.GetControlFromPosition(rnd_x, rnd_y).Text = pickedNumber.ToString();
                                virtualMap[rnd_x, rnd_y] = pickedNumber;
                                digits.RemoveAt(pickedPos);
                                eligible = true; 
                            }
                            else
                            {
                                //reselect the number 
                                pickedPos = rnd.Next(0, digits.Count - 1);
                                pickedNumber = digits[pickedPos];
                                rnd_x = rnd.Next(j, j + 3);
                                rnd_y = rnd.Next(i, i + 3);

                            }
                        }
                        numbersToPick--;

                        //add to the map and tablepanel 

                    }


                }

                    ShowMap(virtualMap);
                }
        public static void ShowMap (int[,] map )
        {

            for (int i = 0; i < 9;i++)
            {
                for (int j = 0; j < 9; j++)
                    Console.Write(map[i, j]+ " ");

            }

            Console.WriteLine();
        }
        public static void ClearMap(int[,] map, TableLayoutPanel panel)
        {

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    map[i, j] = 0;
                    panel.GetControlFromPosition(j, i).Text = null;

                }

            }
        }

        public static bool isEligible ( int  number , int[,] map, ValueTuple<int, int> pos  )
        {
            for (int i  = 0; i<9;i++)
            {
                if (map[i, pos.Item2] == number || map[pos.Item1, i] == number) return false;
                
            }

            return true; 

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            //initialize the map 
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void restartGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to restart ? ", "Restart Game" , MessageBoxButtons.YesNo , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClearMap(virtualMap  , panel);
                GenerateNumbers(virtualMap, panel);

            }
        }
    }
}
