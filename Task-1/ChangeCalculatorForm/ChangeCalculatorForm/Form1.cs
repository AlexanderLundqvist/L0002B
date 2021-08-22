using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeCalculatorForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int price = Convert.ToInt32(textBox1.Text);
            int paid = Convert.ToInt32(textBox2.Text);
            CalculateChange(price, paid);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void Clear()
        {
            richTextBox1.Text = "";
        }

        private void CalculateChange(int price, int paid)
        {
            Clear();
            int[] denominations = { 500, 200, 100, 50, 20, 10, 5, 1 };
            int[] amountOfBills = { 0, 0, 0, 0, 0, 0, 0, 0 };
            int change = paid - price;
            if (change < 0)
            {
                richTextBox1.AppendText("Payment was not enough, please try again.");
                return;
            }
            else
            {
                for (int i = 0; i < denominations.Length - 1; i++)
                {
                    if (change < denominations[i])
                    {
                        continue;
                    }
                    else
                    {
                        int newAmount = 0;
                        int temp = change;
                        while (temp >= denominations[i])
                        {
                            temp = temp / denominations[i];
                            newAmount++;
                        }
                        amountOfBills[i] = newAmount;
                        change %= denominations[i];
                    }
                }
            }
            amountOfBills[amountOfBills.Length - 1] = change; // Adding the last 1 SEK
            ToString(amountOfBills);
        }

        private void ToString(int[] result)
        {
            int[] denominations = { 500, 200, 100, 50, 20, 10, 5, 1 };
            richTextBox1.AppendText("Change back is:");

            // Loop for bills
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == 0)
                {
                    continue;
                }
                else
                {
                    richTextBox1.AppendText("\n" + result[i] + " x " + denominations[i] + billOrCoin(i));
                }
            }
        }

        private static string billOrCoin(int index)
        {
            if (index < 5)
            {
                return " SEK bills";
            }
            else
            {
                return " SEK coins";
            }
        }
    }
}
