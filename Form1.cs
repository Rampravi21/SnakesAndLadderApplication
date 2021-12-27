using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakesAndLadderApp
{
    public partial class Form1 : Form
    {
        int flag = 0;
        int p1x = 20, p1y=423, diceValue,player1Pos=0; // p1x,p1y tells the initial position of player 1
        int p2x = 20, p2y = 423,player2Pos = 0;//p2x,p2y tells the initial position of player 2
        bool green = false,yellow = false;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                btn_roll2.Enabled = false;
            }
            p5_pbx.Visible = false;
            p6_pbx.Visible = false;
            dice_pbx.Image = Image.FromFile(@"C:\Users\Sai\source\repos\SnakesAndLadderApp\Resources\dice.png");
            dice_pbx.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // * Player 1 *//
        private void btn_roll_Click(object sender, EventArgs e)
        {
            try
            {


                diceValue = Logics.Rolldice(dice_pbx);// this method used to get the dice value
                lbl_number.Text = diceValue.ToString();

                if (green == true)
                {

                    player1Pos = Logics.Move(ref p1x, ref p1y, player1Pos, diceValue, p5_pbx); // To move the dice 

                }

                if (lbl_number.Text == "6" && green == false)
                {
                    p5_pbx.Visible = true;
                    p1_pbx.Visible = false;
                    green = true;
                    p5_pbx.Location = new Point(p1x, p1y);
                    player1Pos++;

                }

                if (player1Pos == 100)
                {
                    MessageBox.Show(".............Hurray I Win.......... ");
                    btn_roll.Visible = false;
                }
                
                player1Pos = Logics.Snakebite(ref p1x, ref p1y, player1Pos, p5_pbx);// method to slide down when  a snake bite 
                player1Pos = Logics.Ladder(ref p1x, ref p1y, player1Pos, p5_pbx);// method to climb ladder

                if (diceValue == 6)
                {
                    flag = 0;
                }
                else
                {
                    flag = 1;
                    btn_roll.Enabled = false;
                    btn_roll2.Enabled = true;
                }
            }


            catch(Exception ex)
            {
                MessageBox.Show("Exception Caught" + ex);
            }
        }

        // * Player 2 *//
        private void btn_roll2_Click(object sender, EventArgs e)
        {
            diceValue = Logics.Rolldice(dice_pbx);
            lbl_number.Text = diceValue.ToString();
            if (yellow == true)
            {

                player2Pos = Logics.Move(ref p2x, ref p2y, player2Pos, diceValue, p6_pbx);

            }

            if (lbl_number.Text=="6" && yellow == false)
            {
                p6_pbx.Visible = true;
                p2_pbx.Visible = false;
                yellow = true;
                p6_pbx.Location = new Point(p2x, p2y);
                player2Pos++;

            }

            if (player2Pos == 100)
            {
                MessageBox.Show("..........Hurray I Win.......");
                btn_roll2.Visible = false;
            }

            player2Pos = Logics.Snakebite(ref p2x, ref p2y, player2Pos, p6_pbx);
            player2Pos = Logics.Ladder(ref p2x, ref p2y, player2Pos, p6_pbx);

            if (diceValue == 6)
            {
                flag = 0;
            }
            else
            {
                flag = 1;
                btn_roll2.Enabled = false;
                btn_roll.Enabled = true;
            }
        }

    }
}
