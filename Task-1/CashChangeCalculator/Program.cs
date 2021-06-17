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

        public void Interface()
        {
            Console.WriteLine("Prints the interface");
        }

        /// <summary>
        /// The main method that initializes and controlls the program flow.
        /// </summary>
        /// <param name="args">The program expects no command line arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Starting the change calculator...");
        }
    }
}
