using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDatabase
{
    internal class EditLogic
    {
        //reusable edit methods
        public static string EditText(string oldText, string description)
        {
            string logText = DateTime.Now + " Entered the Edit Text Menu";
            LogFileLogic.WriteToLog(logText);
            try
            {
                Console.WriteLine("Currently editing: " + description);
                Console.WriteLine("Old Version: " + oldText);
                Console.WriteLine("Please enter the New Version:");
                string newText = Console.ReadLine();
                logText = DateTime.Now + " Changed the " + description + " from " + oldText + " to " + newText + ".";
                LogFileLogic.WriteToLog(logText);
                logText = DateTime.Now + " Exited the Edit Text Menu";
                LogFileLogic.WriteToLog(logText);
                return newText;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while editing data. Reverting to old version.");
                logText = DateTime.Now + " An error occured while editing text. Reverting to original.";
                LogFileLogic.WriteToLog(logText);
                logText = DateTime.Now + " Exited the Edit Text Menu";
                LogFileLogic.WriteToLog(logText);
                return oldText;
            }
        }

        public static DateTime EditDate(DateTime oldDate, string description)
        {
            string logText = DateTime.Now + " Entered Edit Date Menu";
            LogFileLogic.WriteToLog(logText);
            try
            {
                Console.WriteLine("Currently editing: " + description);
                Console.WriteLine("Old Version: " + oldDate);
                Console.WriteLine("Please enter the New Version:");
                Console.WriteLine("Month (number): ");
                int month = int.Parse(Console.ReadLine());
                Console.WriteLine("Day: ");
                int day = int.Parse(Console.ReadLine());
                Console.WriteLine("Year:");
                int year = int.Parse(Console.ReadLine());
                DateTime newDate = new DateTime(year, month, day);
                logText = DateTime.Now + " Changed the " + description + " from " + oldDate + " to " + newDate + ".";
                LogFileLogic.WriteToLog(logText);
                logText = DateTime.Now + " Exited the Edit Date Menu";
                LogFileLogic.WriteToLog(logText);
                return newDate;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while editing data. Reverting to old version.");
                logText = DateTime.Now + " An error occured while editing a date. Reverting to original.";
                LogFileLogic.WriteToLog(logText);
                logText = DateTime.Now + " Exited the Edit Date Menu";
                LogFileLogic.WriteToLog(logText);
                return oldDate;
            }

        }

        public static int EditNumber(int oldNumber, string description)
        {
            string logText = DateTime.Now + " Entered the Edit Number Menu.";
            LogFileLogic.WriteToLog(logText);
            try
            {
                Console.WriteLine("Currently editing: " + description);
                Console.WriteLine("Old Version: " + oldNumber);
                Console.WriteLine("Please enter the New Version:");
                int newNumber = int.Parse(Console.ReadLine());
                logText = DateTime.Now + " Changed the " + description + " from " + oldNumber + " to " + newNumber + ".";
                LogFileLogic.WriteToLog(logText);
                logText = DateTime.Now + " Exited the Edit Number Menu";
                LogFileLogic.WriteToLog(logText);
                return newNumber;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while editing data. Reverting to old version.");
                logText = DateTime.Now + " An error occured while editing a number. Reverting to original.";
                LogFileLogic.WriteToLog(logText);
                logText = DateTime.Now + " Exited the Edit Text Menu";
                LogFileLogic.WriteToLog(logText);
                return oldNumber;
            }

        }
    }
}
