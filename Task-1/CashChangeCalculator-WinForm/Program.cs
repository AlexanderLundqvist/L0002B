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
