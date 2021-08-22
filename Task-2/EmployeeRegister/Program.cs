/* EmployeeRegister
 * 
 * This program is a single file program that manages a register for sellers. The program can recieve 
 * new sellers and will sort the list of sellers according to their amount of sold articles. The 
 * Program stores the information in a text file that acts as a rudimentary database.
 * 
 * Author: Alexander Lundqvist
 */

using System;
using System.IO;

namespace EmployeeRegister
{
    class Program
    {
        // Adds seller information to the register file
        private static void AddSeller(string fileName, string[,] sortedArray)
        {
            string sellerData;

            int[] sellerAmount = { 0, 0, 0, 0 };
            string[] level = { "Under 50 items", "50-99 items", "100-199 items", "Over 199 items" };
            for (int i = 0; i < sortedArray.GetLength(0); i++)
            {
                int amount = Int32.Parse(sortedArray[i, 3]);
                if (amount < 50)
                {
                    sellerAmount[0] += 1;
                }
                else if (amount >= 50 && amount < 100)
                {
                    sellerAmount[1] += 1;
                }
                else if (amount >= 100 && amount < 200)
                {
                    sellerAmount[2] += 1;
                }
                else
                {
                    sellerAmount[3] += 1;
                }
            }

            int sellerIndex = 0;
            for (int levelCount = 0; levelCount < level.Length; levelCount++)
            {
                for (int i = 0; i < sellerAmount[levelCount]; i++)
                {
                    sellerData = $"{sortedArray[sellerIndex, 0],-20}{sortedArray[sellerIndex, 1],-30}{sortedArray[sellerIndex, 2],-20}{sortedArray[sellerIndex, 3],-20}";
                    using (StreamWriter file = File.AppendText(fileName))
                    {
                        file.WriteLine(sellerData);
                    }
                    sellerIndex++;
                }
                using (StreamWriter file = File.AppendText(fileName))
                {
                    file.WriteLine(sellerAmount[levelCount] + " sellers has reached level " + (levelCount + 1) + ": " + level[levelCount] + "\n");
                }
            }
        }

        private static void ViewRegister(string fileName)
        {
            Console.Clear();
            using (StreamReader file = new StreamReader(fileName))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        // Sorting function that implements bubble sort for 2D arrays. Recieves a source array and returns a new sorted array.
        private static string[,] Sort(string[,] registerArray)
        {
            string[,] sortedArray = registerArray;

            string[] tempArray;

            for (int i = 0; i < sortedArray.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < sortedArray.GetLength(0) - 1; j++)
                {
                    // Ugly solution since I didn't work with array lists and instead used 2D array/matrix instead
                    if (Int32.Parse(sortedArray[j, 3]) > Int32.Parse(sortedArray[j+1, 3]))
                    {
                        // temp
                        tempArray = new string[] {sortedArray[j + 1, 0], sortedArray[j + 1, 1], sortedArray[j + 1, 2], sortedArray[j + 1, 3]};

                        // arr[j+1] = arr[j]
                        sortedArray[j + 1, 0] = sortedArray[j, 0];
                        sortedArray[j + 1, 1] = sortedArray[j, 1];
                        sortedArray[j + 1, 2] = sortedArray[j, 2];
                        sortedArray[j + 1, 3] = sortedArray[j, 3];

                        // arr[j] = temp
                        sortedArray[j, 0] = tempArray[0];
                        sortedArray[j, 1] = tempArray[1];
                        sortedArray[j, 2] = tempArray[2];
                        sortedArray[j, 3] = tempArray[3];
                    }
                }
            }
            return sortedArray;
        }

        private static void CreateRegister(string fileName)
        {
            Console.WriteLine(">>> Checking for register file\n");
            System.Threading.Thread.Sleep(1000);
            // Check if file already exists. If it doesn't, create new file with desired format.     
            if (!File.Exists(fileName))
            {
                var columnHeaders = $"{"First name",-20}{"Social security number",-30}{"District",-20}{"Sold items",-20}";
                string time = DateTime.Now.ToString("dddd, dd/MM/yyyy, HH:mm:ss");
                using (StreamWriter file = File.AppendText(fileName))
                {
                    file.WriteLine("****************************** Seller information database *******************************\n");
                    file.WriteLine("Created: " + time + "\n");
                    file.WriteLine(columnHeaders); 
                }
                Console.WriteLine(">>> File not found, creating new register file!\n");
                System.Threading.Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine(">>> File was found, proceeding...\n");
                System.Threading.Thread.Sleep(1500);
            }
        }

        /// <summary>
        /// The main method that initializes the program and controlls the program flow.
        /// </summary>
        /// <param name="args">The program expects no command line arguments.</param>
        static void Main(string[] args)
        {
            string name;
            string ssn;
            string district;
            string amountOfSoldItems;
            int run = 1;
            int choice = 1;
            int arraySize = 0;
            string[,] registerArray = null;
            string[,] sortedArray = null;

            // Path to register file containing the sorted seller information
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                              "SellerDB.txt");

            Console.WriteLine(">>> Program has started!\n");
            System.Threading.Thread.Sleep(1500); // Delay for simulated startup


            // Initialize register file
            CreateRegister(fileName);

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
                        // Ask how many sellers to be added since 2D array lists are a bit overkill and static arrays are enough for this.
                        Console.Clear();
                        if (registerArray != null)
                        {
                            Console.WriteLine("Sellers have already been added, please delete current registry file and restart program.");
                            break;
                        }
                        else 
                        {
                            Console.WriteLine("How many sellers do you want to register?\n");
                            arraySize = Convert.ToInt32(Console.ReadLine());
                            registerArray = new string[arraySize, 4];

                            for (int i = 0; i < arraySize; i++)
                            {
                                Console.Clear();
                                Console.WriteLine("***************** Seller information *****************\n");

                                Console.Write("\nName: ");
                                name = Console.ReadLine();
                                registerArray[i, 0] = name;

                                Console.Write("\nSocial security number: ");
                                ssn = Console.ReadLine();
                                registerArray[i, 1] = ssn;

                                Console.Write("\nDistrict: ");
                                district = Console.ReadLine();
                                registerArray[i, 2] = district;

                                Console.Write("\nAmount of sold items: ");
                                amountOfSoldItems = Console.ReadLine();
                                Console.WriteLine();
                                registerArray[i, 3] = amountOfSoldItems;
                            }
                            sortedArray = Sort(registerArray);
                            AddSeller(fileName, sortedArray);
                            break;
                        }
                       

                    case 2:
                        if (registerArray == null)
                        {
                            Console.WriteLine("\n>>> No sellers has been added to register!");
                            System.Threading.Thread.Sleep(1500);
                        }
                        else
                        {
                            ViewRegister(fileName);
                            Console.WriteLine("\nPress any button to go back to menu!");
                            string exit = Console.ReadLine(); // Unnecessary assignment, but used so the program stays at registry output
                        }
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
