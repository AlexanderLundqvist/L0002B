/* CashChangeCalculator
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
using System.IO;


namespace CashChangeCalculator
{
    class Program
    {
        private readonly int[] denominations = { 1000, 500, 200, 100, 50, 20, 10, 5, 2, 1 };

        private static void CalculateChange(int price, int paid)
        {
            int change = paid - price;
            if (change < 0)
            {
                throw new ArithmeticException("Payment was not enough, please try again.");
            }
            else
            {
                Console.WriteLine(change);
            }
        }

        private static void ToString(int[] result)
        {
            Console.WriteLine("Change back is: ");

        }

        /// <summary>
        /// The main method that initializes and controlls the program flow.
        /// </summary>
        /// <param name="args">The program expects no command line arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Starting the change calculator...");

            int price;
            int amountPaid;

            while (true)
            {
                try
                {
                    Console.WriteLine("Write price to pay: ");
                    price = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Write amount paid: ");
                    amountPaid = Convert.ToInt32(Console.ReadLine());
                }
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
