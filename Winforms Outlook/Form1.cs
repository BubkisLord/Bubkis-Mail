using BetterFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace Winforms_Outlook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Welcome to the Email Sender App.\nThis app allows you to send emails on outlook.");

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            if (radioButton1.Checked)
            {
                if (checkBox2.Checked)
                {
                    BetterFunctions.BetterFunctions.SendMail(textBox2.Text, textBox3.Text, textBox4.Text, textBox1.Text, bodyTextBox.Text, textBox5.Text, textBox6.Text, textBox7.Text, BetterFunctions.BetterFunctions.HostTypes.Office, BetterFunctions.BetterFunctions.Priority.Low, checkBox1.Checked);
                }
                else
                {
                    BetterFunctions.BetterFunctions.SendMail(textBox2.Text, textBox3.Text, textBox4.Text, textBox1.Text, bodyTextBox.Text, textBox5.Text, textBox6.Text, textBox7.Text, BetterFunctions.BetterFunctions.HostTypes.Gmail, BetterFunctions.BetterFunctions.Priority.Low, checkBox1.Checked);
                }
            }
            else if (radioButton2.Checked)
            {
                if (checkBox2.Checked)
                {
                    BetterFunctions.BetterFunctions.SendMail(textBox2.Text, textBox3.Text, textBox4.Text, textBox1.Text, bodyTextBox.Text, textBox5.Text, textBox6.Text, textBox7.Text, BetterFunctions.BetterFunctions.HostTypes.Office, BetterFunctions.BetterFunctions.Priority.Medium, checkBox1.Checked);
                }
                else
                {
                    BetterFunctions.BetterFunctions.SendMail(textBox2.Text, textBox3.Text, textBox4.Text, textBox1.Text, bodyTextBox.Text, textBox5.Text, textBox6.Text, textBox7.Text, BetterFunctions.BetterFunctions.HostTypes.Gmail, BetterFunctions.BetterFunctions.Priority.Medium, checkBox1.Checked);
                }
            }
            else if (radioButton3.Checked)
            {
                if (checkBox2.Checked)
                {
                    BetterFunctions.BetterFunctions.SendMail(textBox2.Text, textBox3.Text, textBox4.Text, textBox1.Text, bodyTextBox.Text, textBox5.Text, textBox6.Text, textBox7.Text, BetterFunctions.BetterFunctions.HostTypes.Office, BetterFunctions.BetterFunctions.Priority.High, checkBox1.Checked);
                }
                else
                {
                    BetterFunctions.BetterFunctions.SendMail(textBox2.Text, textBox3.Text, textBox4.Text, textBox1.Text, bodyTextBox.Text, textBox5.Text, textBox6.Text, textBox7.Text, BetterFunctions.BetterFunctions.HostTypes.Gmail, BetterFunctions.BetterFunctions.Priority.High, checkBox1.Checked);
                }
            }
            while (progressBar1.Value < 100)
            {
                progressBar1.Value++;
                Thread.Sleep(Random.Shared.Next(0, 16));
            }
            label9.Text = "Sent Message.";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}