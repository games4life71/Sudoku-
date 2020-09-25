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

            for (int i = 0; i < panel.RowCount - 3; i += 3)
                for (int j = 0; j < panel.ColumnCount - 3; j += 3)
                {
                        numbersToPick = 4;
                    List<int> digits = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                    while (numbersToPick > 0)
                    {
                        int pickedPos = rnd.Next(0, digits.Count -1 );
                        int pickedNumber = digits[pickedPos];
                        digits.RemoveAt(pickedPos);
                        int rnd_x = rnd.Next(j, j + 3);
                        int rnd_y = rnd.Next(i, i + 3);
                        numbersToPick--;

                        //add to the map and tablepanel 
                        panel.GetControlFromPosition(rnd_x, rnd_y).Text = pickedNumber.ToString();
                        virtualMap[rnd_x, rnd_y] = pickedNumber;

                    }


                }

                }

        public static bool isEligible ( int  number , int[,] map, ValueTuple<int, int> pos  )
        {
            



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
    }
}
