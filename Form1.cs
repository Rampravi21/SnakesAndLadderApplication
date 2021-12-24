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
        int x = 20, y=423, diceValue,p=0;
        int bx = 20, by = 423,q = 0;
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

                    p = Logics.Move(ref x, ref y, p, diceValue, p5_pbx); // To move the dice 

                }

                if (lbl_number.Text == "6" && green == false)
                {
                    p5_pbx.Visible = true;
                    p1_pbx.Visible = false;
                    green = true;
                    p5_pbx.Location = new Point(x, y);
                    p++;

                }

                if (p == 100)
                {
                    MessageBox.Show(".............Hurray I Win.......... ");
                    btn_roll.Visible = false;
                }
                
                p = Logics.Snakebite(ref x, ref y, p, p5_pbx);// method to slide down when  a snake bite 
                p = Logics.Ladder(ref x, ref y, p, p5_pbx);// method to climb ladder

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

                q = Logics.Move(ref bx, ref by, q, diceValue, p6_pbx);

            }

            if (lbl_number.Text=="6" && yellow == false)
            {
                p6_pbx.Visible = true;
                p2_pbx.Visible = false;
                yellow = true;
                p6_pbx.Location = new Point(x, y);
                q++;

            }

            if (q == 100)
            {
                MessageBox.Show("..........Hurray I Win.......");
                btn_roll2.Visible = false;
            }

            q = Logics.Snakebite(ref bx, ref by, q, p6_pbx);
            q = Logics.Ladder(ref bx, ref by, q, p6_pbx);

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
