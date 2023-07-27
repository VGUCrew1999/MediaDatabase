using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDatabase
{
    internal class LogFileLogic
    {
        public static void ViewLogFile()
        {
            string filePath = GetFilePath();
            if (!File.Exists(filePath))
            {
                File.CreateText(filePath);
            }
            StreamReader reader = File.OpenText(filePath);
            string logText = "";
            Console.WriteLine("Beginning of Log File.");
            Console.WriteLine("----------------------");
            while ((logText = reader.ReadLine()) != null)
            {
                Console.WriteLine(logText);
            }
            reader.Close();
            Console.WriteLine("----------------------");
            Console.WriteLine("End of Log File.");
            Console.WriteLine();
            Console.ReadLine();
        }

        //writing to log file
        public static void WriteToLog(string message)
        {
            string filePath = GetFilePath();
            if (!File.Exists(filePath))
            {
                File.CreateText(filePath).Close();
            }
            StreamWriter writer = File.AppendText(filePath);
            writer.WriteLine(message);
            writer.Close();
        }

        //file path for log
        public static string GetFilePath()
        {
            return @"LogFile.txt";
        }
    }
}
