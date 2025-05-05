using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {

        private int Counter = 1;
        
        private bool isStoppedUpdate = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen WhitePen = new Pen(Color.White);
            WhitePen.Width = 7;

            WhitePen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            WhitePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(WhitePen, 500, 100, 500, 400);
            e.Graphics.DrawLine(WhitePen, 600, 100, 600, 400);
            e.Graphics.DrawLine(WhitePen, 400, 200, 700, 200);
            e.Graphics.DrawLine(WhitePen, 400, 300, 700, 300);
        }

        private bool UpdateCurrentPlayer(PictureBox pictureBox)
        {
            if (pictureBox.Tag.ToString() == "0")
            {
                if (Counter % 2 == 1)
                {
                    pictureBox.Image = Properties.Resources.X;
                    lblPlayer.Text = "Player 2";
                    pictureBox.Tag = "X";
                }
                else
                {
                    pictureBox.Image = Properties.Resources.O;
                    lblPlayer.Text = "Player 1";
                    pictureBox.Tag = "O";
                }
                Counter++;
                return true;
            }
            return false;
        }

        private void CheckWinner(PictureBox pictureBoxA, PictureBox pictureBoxB, PictureBox pictureBoxC)
        {
            if (pictureBoxA.Tag.ToString() == pictureBoxB.Tag.ToString() && pictureBoxB.Tag.ToString() == pictureBoxC.Tag.ToString() && pictureBoxA.Tag.ToString() != "0")
            {
                if (pictureBoxA.Tag.ToString() == "X")
                {
                    lblWinner.Text = "Player 1";
                }
                else
                {
                    lblWinner.Text = "Player 2";
                }
                pictureBoxA.BackColor = Color.GreenYellow;
                pictureBoxB.BackColor = Color.GreenYellow;
                pictureBoxC.BackColor = Color.GreenYellow;
                if (! isStoppedUpdate)
                    MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isStoppedUpdate = true;
                return;
            }
            else if (Counter == 10)
            {
                lblWinner.Text = "Draw";
                lblPlayer.Text = "Player";
                MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isStoppedUpdate = true;
                Counter++;
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (isStoppedUpdate)
                return;
            if (!UpdateCurrentPlayer((PictureBox)sender))
                return;
            CheckWinner(pictureBox1, pictureBox2, pictureBox3);
            CheckWinner(pictureBox4, pictureBox5, pictureBox6);
            CheckWinner(pictureBox7, pictureBox8, pictureBox9);
            CheckWinner(pictureBox1, pictureBox4, pictureBox7);
            CheckWinner(pictureBox2, pictureBox5, pictureBox8);
            CheckWinner(pictureBox3, pictureBox6, pictureBox9);
            CheckWinner(pictureBox1, pictureBox5, pictureBox9);
            CheckWinner(pictureBox3, pictureBox5, pictureBox7);
        }

        //private void pictureBox1_Click(object sender, EventArgs e)
        //{
        //    if (isStoppedUpdate)
        //        return;
        //    if (! UpdateCurrentPlayer(pictureBox1))
        //        return;
        //    CheckWinner(pictureBox1, pictureBox2, pictureBox3);
        //    CheckWinner(pictureBox1, pictureBox4, pictureBox7);
        //    CheckWinner(pictureBox1, pictureBox5, pictureBox9);
        //}

        //private void pictureBox2_Click(object sender, EventArgs e)
        //{
        //    if (isStoppedUpdate)
        //        return;
        //    if (!UpdateCurrentPlayer(pictureBox2))
        //        return;
        //    CheckWinner(pictureBox1, pictureBox2, pictureBox3);
        //    CheckWinner(pictureBox2, pictureBox5, pictureBox8);
        //}

        //private void pictureBox3_Click(object sender, EventArgs e)
        //{
        //    if (isStoppedUpdate)
        //        return;
        //    if (!UpdateCurrentPlayer(pictureBox3))
        //        return;
        //    CheckWinner(pictureBox1, pictureBox2, pictureBox3);
        //    CheckWinner(pictureBox3, pictureBox6, pictureBox9);
        //    CheckWinner(pictureBox3, pictureBox5, pictureBox7);

        //}

        //private void pictureBox4_Click(object sender, EventArgs e)
        //{
        //    if (isStoppedUpdate)
        //        return;
        //    if (!UpdateCurrentPlayer(pictureBox4))
        //        return;
        //    CheckWinner(pictureBox1, pictureBox4, pictureBox7);
        //    CheckWinner(pictureBox4, pictureBox5, pictureBox6);

        //}

        //private void pictureBox5_Click(object sender, EventArgs e)
        //{
        //    if (isStoppedUpdate)
        //        return;
        //    if (!UpdateCurrentPlayer(pictureBox5))
        //        return;
        //    CheckWinner(pictureBox2, pictureBox5, pictureBox8);
        //    CheckWinner(pictureBox4, pictureBox5, pictureBox6);
        //    CheckWinner(pictureBox3, pictureBox5, pictureBox7);
        //    CheckWinner(pictureBox1, pictureBox5, pictureBox9);

        //}

        //private void pictureBox6_Click(object sender, EventArgs e)
        //{
        //    if (isStoppedUpdate)
        //        return;
        //    if (!UpdateCurrentPlayer(pictureBox6))
        //        return;
        //    CheckWinner(pictureBox3, pictureBox6, pictureBox9);
        //    CheckWinner(pictureBox6, pictureBox5, pictureBox4);

        //}

        //private void pictureBox7_Click(object sender, EventArgs e)
        //{
        //    if (isStoppedUpdate)
        //        return;
        //    if (!UpdateCurrentPlayer(pictureBox7))
        //        return;
        //    CheckWinner(pictureBox1, pictureBox4, pictureBox7);
        //    CheckWinner(pictureBox7, pictureBox8, pictureBox9);
        //    CheckWinner(pictureBox7, pictureBox5, pictureBox3);

        //}

        //private void pictureBox8_Click(object sender, EventArgs e)
        //{
        //    if (isStoppedUpdate)
        //        return;
        //    if (!UpdateCurrentPlayer(pictureBox8))
        //        return;
        //    CheckWinner(pictureBox7, pictureBox8, pictureBox9);
        //    CheckWinner(pictureBox8, pictureBox5, pictureBox2);

        //}

        //private void pictureBox9_Click(object sender, EventArgs e)
        //{
        //    if (isStoppedUpdate)
        //        return;
        //    if (!UpdateCurrentPlayer(pictureBox9))
        //        return;
        //    CheckWinner(pictureBox9, pictureBox6, pictureBox3);
        //    CheckWinner(pictureBox9, pictureBox8, pictureBox7);
        //    CheckWinner(pictureBox9, pictureBox5, pictureBox1);

        //}

        private void button1_Click(object sender, EventArgs e)
        {
            isStoppedUpdate = false;
            pictureBox1.Tag = 0;
            pictureBox2.Tag = 0;
            pictureBox3.Tag = 0;
            pictureBox4.Tag = 0;
            pictureBox5.Tag = 0;
            pictureBox6.Tag = 0;
            pictureBox7.Tag = 0;
            pictureBox8.Tag = 0;
            pictureBox9.Tag = 0;
            pictureBox1.Image = Properties.Resources.question_mark_96;
            pictureBox2.Image = Properties.Resources.question_mark_96;
            pictureBox3.Image = Properties.Resources.question_mark_96;
            pictureBox4.Image = Properties.Resources.question_mark_96;
            pictureBox5.Image = Properties.Resources.question_mark_96;
            pictureBox6.Image = Properties.Resources.question_mark_96;
            pictureBox7.Image = Properties.Resources.question_mark_96;
            pictureBox8.Image = Properties.Resources.question_mark_96;
            pictureBox9.Image = Properties.Resources.question_mark_96;
            lblWinner.Text = "In Progress";
            lblPlayer.Text = "Player 1";
            Counter = 1;
            pictureBox1.BackColor = Color.Black;
            pictureBox2.BackColor = Color.Black;
            pictureBox3.BackColor = Color.Black;
            pictureBox4.BackColor = Color.Black;
            pictureBox5.BackColor = Color.Black;
            pictureBox6.BackColor = Color.Black;
            pictureBox7.BackColor = Color.Black;
            pictureBox8.BackColor = Color.Black;
            pictureBox9.BackColor = Color.Black;
        }

    }
}
