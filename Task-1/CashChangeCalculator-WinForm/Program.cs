/* CashChangeCalculator-WinForm
 * 
 * Windows-forms application version of cashChangeCalculator. Performs similar
 * task but XXXXXXX
 * 
 * This program is a single file program that performs the task
 * of calculating how the total amount of change from a transaction
 * should be "constructed" from different bills and coins. In this
 * case it will be in SEK. 
 * For example: change is 120 SEK, so the change will be 1 100 SEK bill
 * and 1 20 SEK bill. 
 * 
 * Author: Alexander Lundqvist
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashChangeCalculator_WinForm
{
    static class Program
    {
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
            ToString(amountOfBills);
        }

        private static void ToString(int[] result)
        {
            int[] denominations = { 500, 200, 100, 50, 20, 10, 5, 1 };
            Console.WriteLine("\nChange back is:");

            // Loop for bills
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == 0)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine(result[i] + " x " + denominations[i] + billOrCoin(i));
                }
            }
            Console.WriteLine();
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

        /// <summary>
        /// The main method that initializes and controlls the program flow.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }
    }
}

/*      
        static void Main(string[] args)
        {
            Console.WriteLine("Starting the change calculator...");

            int price;
            int amountPaid;

            // Loop always running
            while (true)
            {
                try
                {
                    Console.WriteLine("Write price to pay: ");
                    price = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Write amount paid: ");
                    amountPaid = Convert.ToInt32(Console.ReadLine());
                }

                // Error handling as not to disturb the loop
                catch (Exception e)
                {
                    Console.WriteLine("\n>>> Error: Invalid input format <<<\n");
                    continue;
                }
                CalculateChange(price, amountPaid);
            }

        }
    }
}
*/
