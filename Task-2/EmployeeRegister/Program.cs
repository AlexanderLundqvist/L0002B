/* EmployeeRegister
 * 
 * This program is a single file program that 
 * 
 * Author: Alexander Lundqvist
 */

using System;
using System.IO;

namespace EmployeeRegister
{
    class Program
    {

        private static void AddSeller(String name, int ssn, String district, int amountOfSoldItems)
        {

        }

        private static void ViewRegister()
        {

        }

        private static void Sort()
        {

        }

        private static void ToFile()
        {
        }

        // Helper function to parse data into readable format
        private static void ConsoleToString()
        {
         
        }

        /// <summary>
        /// The main method that initializes and controlls the program flow.
        /// </summary>
        /// <param name="args">The program expects no command line arguments.</param>
        static void Main(string[] args)
        {
            String name;
            int ssn;
            String district;
            int amountOfSoldItems;
            int run = 1;
            int choice = 1;

            string path = "seller_database.txt";

            if (File.Exists(path))
            {
                // Do nothing
            }
            else
            {   
                using StreamWriter sw = File.CreateText(path);
            }

            Console.WriteLine(">>> Program has started!\n");
            System.Threading.Thread.Sleep(2000);


            // Read in register file

            // Menu UI loop runs until choice 3 is made
            while (run == 1)
            {
                Console.Clear();
                Console.WriteLine("*********************** Options **********************\n");
                Console.WriteLine("To add seller information to the register, press 1.");
                Console.WriteLine("To view the register, press 2.");
                Console.WriteLine("To exit the program, press 3.");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("***************** Seller information *****************\n");

                        Console.Write("\nName: ");
                        name = Console.ReadLine();

                        Console.Write("\nSocial security number: ");
                        ssn = Convert.ToInt32(Console.ReadLine());

                        Console.Write("\nDistrict: ");
                        district = Console.ReadLine();

                        Console.Write("\nAmount of sold items: ");
                        amountOfSoldItems = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();

                        AddSeller(name, ssn, district, amountOfSoldItems);
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("**************** Register information ****************\n");
                        //ViewRegister();
                        break;

                    case 3:
                        run = 0;
                        Console.Clear();
                        Console.WriteLine(">>> Program has ended!");
                        break;
                }
            }
        }
    }
}
