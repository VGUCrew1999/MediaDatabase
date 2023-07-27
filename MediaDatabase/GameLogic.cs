using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDatabase
{
    internal class GameLogic
    {
        private static MediaContext _context = new MediaContext();
        public LogFileLogic logFileLogic = new LogFileLogic();
        public EditLogic editLogic = new EditLogic();

        //add a game
        public static void AddGames()
        {
            VideoGame newGame = new VideoGame();
            string logText = "";
            try
            {
                //collect information from user
                logText = DateTime.Now + " Began adding a new game.";
                LogFileLogic.WriteToLog(logText);
                Console.WriteLine("Enter the game's name:");
                newGame.GameName = Console.ReadLine();
                logText = DateTime.Now + " Entered " + newGame.GameName + " as the game's name.";
                LogFileLogic.WriteToLog(logText);
                Console.WriteLine("Enter the game's id:");
                newGame.GameId = Console.ReadLine().ToUpper();
                logText = DateTime.Now + " Entered " + newGame.GameId + " as the game's id.";
                LogFileLogic.WriteToLog(logText);
                Console.WriteLine("Enter the console the game is for:");
                newGame.Console = Console.ReadLine();
                logText = DateTime.Now + " entered " + newGame.Console + " as the game's console.";
                LogFileLogic.WriteToLog(logText);
                Console.WriteLine("Enter the game's primary developer:");
                newGame.Developer = Console.ReadLine();
                logText = DateTime.Now + " Entered " + newGame.Developer + " as the game's primary developer.";
                LogFileLogic.WriteToLog(logText);
                Console.WriteLine("Enter the game's primary publisher:");
                newGame.Publisher = Console.ReadLine();
                logText = DateTime.Now + " Entered " + newGame.Publisher + " as the game's primary publisher.";
                LogFileLogic.WriteToLog(logText);
                Console.WriteLine("Enter the month (number) for the game's release date:");
                var month = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the day for the game's release date:");
                var day = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the year for the game's release date:");
                var year = int.Parse(Console.ReadLine());
                DateTime date = new DateTime(year, month, day);
                newGame.ReleaseDate = date;
                logText = DateTime.Now + " Entered " + newGame.ReleaseDate + " as the game's release dat.";
                LogFileLogic.WriteToLog(logText);
                newGame.DateAdded = DateTime.Today;
            }
            catch(Exception ex) //error handling
            {
                Console.WriteLine("An error has occured while entering data. Please try again.");
                logText = DateTime.Now + " An error occured while entering data for the game.";
                LogFileLogic.WriteToLog(logText);
                newGame = null;
            }
            AddGame(newGame);
        }

        //confirm adding a game
        public static void AddGame(VideoGame game)
        {
            string logText = "";
            if (game != null)
            {
                try
                {
                    _context.VideoGames.Add(game);
                    _context.SaveChanges();
                    Console.WriteLine("Video Game added to database");
                    logText = DateTime.Now + " The new game was added to the database.";
                    LogFileLogic.WriteToLog(logText);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding to database. Please try again.");
                    logText = DateTime.Now + " An error occured while adding the game to the database.";
                    LogFileLogic.WriteToLog(logText);
                }
                Console.WriteLine();
            }
            else
            {
                logText = DateTime.Now + " The new game was not added to the database.";
                LogFileLogic.WriteToLog(logText);
            }
        }

        //search for a game
        public static VideoGame SearchForGame()
        {
            string logText = DateTime.Now + " Entered the Search For Game Menu.";
            LogFileLogic.WriteToLog(logText);
            var games = GetAllGames();
            var endSearch = "no";
            var selectedGame = new VideoGame();
            do
            {
                Console.WriteLine("Please enter a Game Id to search for: ");
                var gameId = Console.ReadLine();


                //catch and prevent any errors
                try
                {
                    selectedGame = games.Single(g => g.GameId.ToUpper() == gameId.ToUpper());
                }
                catch (Exception Ex)
                {
                    selectedGame = null; // set to null if not found
                    logText = DateTime.Now + " Entered an invalid game id.";
                    LogFileLogic.WriteToLog(logText);
                }

                // print data if found or give not found
                if (selectedGame == null)
                {
                    Console.WriteLine("Video Game not in Database.");
                    Console.WriteLine("Would you like to cancel your search? (y/n)");
                    endSearch = Console.ReadLine();
                    while (!endSearch.ToLower().StartsWith("n") && !endSearch.ToLower().StartsWith("y"))
                    {
                        logText = DateTime.Now + " Entered invalid input during game search.";
                        LogFileLogic.WriteToLog(logText);
                        Console.WriteLine("Invalid input. Please try again.");
                        Console.WriteLine("Would you like to cancel your search? (y/n)");
                        endSearch = Console.ReadLine();
                    }
                }
                else
                {
                    logText = DateTime.Now + " Selected " + selectedGame.GameName + " in search menu.";
                    LogFileLogic.WriteToLog(logText);
                    Console.WriteLine("You have selected " + selectedGame.GameName + ".");
                    Console.WriteLine("Would you like to continue with this selection? (y/n)");
                    endSearch = Console.ReadLine();
                    while (!endSearch.ToLower().StartsWith("n") && !endSearch.ToLower().StartsWith("y"))
                    {
                        logText = DateTime.Now + " Entered invalid input during game search.";
                        LogFileLogic.WriteToLog(logText);
                        Console.WriteLine("Invalid input. Please try again.");
                        Console.WriteLine("You have selected " + selectedGame.GameName + ".");
                        Console.WriteLine("Would you like to continue with this selection? (y/n)");
                        endSearch = Console.ReadLine();
                    }
                }

                Console.WriteLine();

            } while (!endSearch.ToLower().StartsWith("y")); // only stops the loop if the user decides to continue with their selection or ends the search
            logText = DateTime.Now + " Exited Search For Game Menu.";
            LogFileLogic.WriteToLog(logText);
            return selectedGame;
        }

        //get everything
        public static List<VideoGame> GetAllGames()
        {
            var games = _context.VideoGames.ToList();
            return games;
        }

        //edit a game
        public static void EditGame(VideoGame game)
        {
            int menuSelection;
            string logText = "";
            do
            {
                Console.WriteLine("You have selected " + game.GameName + ".");
                Console.WriteLine("Which data for this game would you like to edit?");
                Console.WriteLine("1. Name");
                Console.WriteLine("2. Console");
                Console.WriteLine("3. Primary Developer");
                Console.WriteLine("4. Primary Publisher");
                Console.WriteLine("5. Release Date");
                Console.WriteLine("6. Date Added to Database");
                Console.WriteLine("7. Confirm Edits");
                menuSelection = int.Parse(Console.ReadLine());
                switch (menuSelection)
                {
                    case 1:
                        game.GameName = EditLogic.EditText(game.GameName, "Game Name");
                        break;
                    case 2:
                        game.Console = EditLogic.EditText(game.Console, "Console");
                        break;
                    case 3:
                        game.Developer = EditLogic.EditText(game.Developer, "Primary Developer");
                        break;
                    case 4:
                        game.Publisher = EditLogic.EditText(game.Publisher, "Primary Publisher");
                        break;
                    case 5:
                        game.ReleaseDate = EditLogic.EditDate(game.ReleaseDate, "Release Date");
                        break;
                    case 6:
                        game.DateAdded = EditLogic.EditDate(game.DateAdded, "Date Added");
                        break;
                    case 7:
                        Console.WriteLine("Confirming Edits.");
                        ConfirmGameEdits(game);
                        logText = DateTime.Now + " Confirmed Edits for " + game.GameName + ".";
                        LogFileLogic.WriteToLog(logText);
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        logText = DateTime.Now + " Entered invalid input in the Edit Game Menu";
                        LogFileLogic.WriteToLog(logText);
                        break;
                }
            } while (menuSelection != 7);
            logText = DateTime.Now + " Exited the Edit Game Menu";
            LogFileLogic.WriteToLog(logText);

        }

        //confirm & submit edits
        public static void ConfirmGameEdits(VideoGame game)
        {
            string logText = "";
            try
            {
                _context.VideoGames.Update(game);
                _context.SaveChanges();
                Console.WriteLine(game.GameName + " has been updated.");
                logText = DateTime.Now + " Successfully updated data for " + game.GameName + ".";
                LogFileLogic.WriteToLog(logText);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while updating Database.");
                logText = DateTime.Now + " An error occured while updating data for " + game.GameName + ".";
                LogFileLogic.WriteToLog(logText);
            }
            Console.WriteLine();
        }

        //delete a game
        public static void DeleteGame(VideoGame game)
        {
            String logText = DateTime.Now + " Entered the Delete Game Menu.";
            LogFileLogic.WriteToLog(logText);
            Console.WriteLine("Record Deletion Menu:");
            Console.WriteLine("You have selected " + game.GameName + ".");
            Console.WriteLine("Are you sure you want to delete this game? (y/n)");
            var delete = Console.ReadLine().ToLower();
            while (!delete.StartsWith("y") && !delete.EndsWith("n"))
            {
                logText = DateTime.Now + " Entered invalid input in the Delete Game Menu";
                LogFileLogic.WriteToLog(logText);
                Console.WriteLine("Invalid input. Please try again");
                Console.WriteLine("You have selected " + game.GameName + ".");
                Console.WriteLine("Are you sure you want to delete this game? (y/n)");
                delete = Console.ReadLine().ToLower();
            }
            if (delete.StartsWith("y"))
            {
                logText = DateTime.Now + " Decided to delete " + game.GameName + ".";
                LogFileLogic.WriteToLog(logText);
                ConfirmDeleteGame(game);
            }
            else
            {
                Console.WriteLine(game.GameName + " was not deleted.");
                logText = DateTime.Now + " Decided not to delete " + game.GameName + ".";
                LogFileLogic.WriteToLog(logText);
            }
            logText = DateTime.Now + " Exited the Delete Game Menu.";
            LogFileLogic.WriteToLog(logText);
            Console.WriteLine();
        }

        //confirm deletion
        public static void ConfirmDeleteGame(VideoGame game)
        {
            string logText = "";
            try
            {
                _context.VideoGames.Remove(game);
                _context.SaveChanges();
                Console.WriteLine(game.GameName + " was deleted from the Database.");
                logText = DateTime.Now + " Deleted " + game.GameName + " from database.";
                LogFileLogic.WriteToLog(logText);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while updating the Database. Please try again.");
                logText = DateTime.Now + " An error occured while deleting " + game.GameName + " from database.";
                LogFileLogic.WriteToLog(logText);
            }

        }

        
    }
}
