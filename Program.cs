using System.Linq.Expressions;

namespace MediaDatabase
{
    internal class Program
    {
        //main menu
        static void Main(string[] args)
        {
            int menuSelection;
            do {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Add Records");
                Console.WriteLine("2. Search Records");
                Console.WriteLine("3. Edit Records");
                Console.WriteLine("4. Delete Records");
                Console.WriteLine("5. Check Log File");
                Console.WriteLine("6. Exit Program");
                menuSelection = int.Parse(Console.ReadLine());
                switch(menuSelection)
                {
                    case 1:
                        AddRecords();
                        break;
                    case 2:
                        SearchRecords();
                        break;
                    case 3:
                        EditRecords();
                        break;
                    case 4:
                        DeleteRecords();
                        break;
                    case 5:
                        ViewLogFile();
                        break;
                    case 6:
                        Console.WriteLine("Exiting Program");
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Please try again.");
                        break;
                }


            }while(menuSelection != 6);
        }

        //add menu
        static void AddRecords()
        {
            int menuSelection;
            do
            {
                Console.WriteLine("Record Addition Menu");
                Console.WriteLine("1. Add Video Game");
                Console.WriteLine("2. Add Movie");
                Console.WriteLine("3. Return to Main Menu");
                menuSelection = int.Parse(Console.ReadLine());
                switch (menuSelection)
                {
                    case 1:
                        Console.WriteLine("Added a Video Game");
                        break;
                    case 2:
                        Console.WriteLine("Added a Movie");
                        break;
                    case 3:
                        Console.WriteLine("Returning to Main Menu");
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Please try again.");
                        break;
                }


            } while (menuSelection != 3);
        }

        //search menu
        static void SearchRecords()
        {
            int menuSelection;
            do
            {
                Console.WriteLine("Record Search Menu");
                Console.WriteLine("1. List all Video Games");
                Console.WriteLine("2. List all Movies");
                Console.WriteLine("3. Search Video Games by Code");
                Console.WriteLine("4. Search Movies by Code");
                Console.WriteLine("5. Return to Main Menu");
                menuSelection = int.Parse(Console.ReadLine());
                switch (menuSelection)
                {
                    case 1:
                        Console.WriteLine("Listed all Video Games");
                        break;
                    case 2:
                        Console.WriteLine("Listed all Movies");
                        break;
                    case 3:
                        Console.WriteLine("Searched for a Video Game");
                        break;
                    case 4:
                        Console.WriteLine("Searched for a Movie");
                        break;
                    case 5:
                        Console.WriteLine("Returning to Main Menu");
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Please try again.");
                        break;
                }


            } while (menuSelection != 5);
        }

        //edit menu
        static void EditRecords()
        {
            int menuSelection;
            do
            {
                Console.WriteLine("Record Editing Menu");
                Console.WriteLine("1. Edit a Video Game");
                Console.WriteLine("2. Edit a Movie");
                Console.WriteLine("3. Return to Main Menu");
                menuSelection = int.Parse(Console.ReadLine());
                switch (menuSelection)
                {
                    case 1:
                        Console.WriteLine("Edited a Video Game");
                        break;
                    case 2:
                        Console.WriteLine("Edited a Movie");
                        break;
                    case 3:
                        Console.WriteLine("Returning to Main Menu");
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Please try again.");
                        break;
                }


            } while (menuSelection != 3);

        }

        //delete menu
        static void DeleteRecords()
        {
            int menuSelection;
            do
            {
                Console.WriteLine("Record Deletion Menu");
                Console.WriteLine("1. Delete a Video Game");
                Console.WriteLine("2. Delete a Movie");
                Console.WriteLine("3. Return to Main Menu");
                menuSelection = int.Parse(Console.ReadLine());
                switch (menuSelection)
                {
                    case 1:
                        Console.WriteLine("Deleted a Video Game");
                        break;
                    case 2:
                        Console.WriteLine("Deleted a Movie");
                        break;
                    case 3:
                        Console.WriteLine("Returning to Main Menu");
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Please try again.");
                        break;
                }


            } while (menuSelection != 3);
        }

        //log menu
        static void ViewLogFile()
        {
            Console.WriteLine("Begin Log File----------");
            Console.WriteLine("Printing Log File");
            Console.WriteLine("End Log File------------");
        }
    }
}