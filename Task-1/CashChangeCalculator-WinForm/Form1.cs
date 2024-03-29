﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashChangeCalculator_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int price;
        int amountPaid;

        private static void CalculateChange(int price, int paid)
        {
            int[] denominations = { 500, 200, 100, 50, 20, 10, 5, 1 };
            int[] amountOfBills = { 0, 0, 0, 0, 0, 0, 0, 0 };
            int change = paid - price;
            if (change < 0)
            {
                Console.WriteLine("Payment was not enough, please try again.");
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
            //ToString(amountOfBills);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            price = 0; 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CalculateChange(price, paid);
        }
    }
}
