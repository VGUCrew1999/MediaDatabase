using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("MediaDatabaseTest")]
namespace MediaDatabase
{
    
    internal class Program
    {
        private static MediaContext _context = new MediaContext();
        public GameLogic gameLogic = new GameLogic();
        public MovieLogic movieLogic = new MovieLogic();
        public LogFileLogic logFileLogic = new LogFileLogic();

        //main menu
        static void Main(string[] args)
        {
            _context.Database.EnsureCreated();
            int menuSelection;
            string logText = DateTime.Now + " Started the program.";
            LogFileLogic.WriteToLog(logText);
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
                        Console.WriteLine();
                        logText = DateTime.Now + " Entered the Add Records Menu.";
                        LogFileLogic.WriteToLog(logText);
                        AddRecords();
                        break;
                    case 2:
                        Console.WriteLine();
                        logText = DateTime.Now + " Entered the Search Records Menu.";
                        LogFileLogic.WriteToLog(logText);
                        SearchRecords();
                        break;
                    case 3:
                        Console.WriteLine();
                        logText = DateTime.Now + " Entered the Edit Records Menu.";
                        LogFileLogic.WriteToLog(logText);
                        EditRecords();
                        break;
                    case 4:
                        Console.WriteLine();
                        logText = DateTime.Now + " Entered the Delete Records Menu.";
                        LogFileLogic.WriteToLog(logText);
                        DeleteRecords();
                        break;
                    case 5:
                        Console.WriteLine();
                        logText = DateTime.Now + " Printed the Log File.";
                        LogFileLogic.WriteToLog(logText);
                        LogFileLogic.ViewLogFile();
                        break;
                    case 6:
                        Console.WriteLine();
                        Console.WriteLine("Exiting Program");
                        logText = DateTime.Now + " Exited the program.";
                        LogFileLogic.WriteToLog(logText);
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Please try again.");
                        logText = DateTime.Now + " Entered invalid input on Main Menu.";
                        LogFileLogic.WriteToLog(logText);
                        break;
                }
                

            }while(menuSelection != 6);
        }

        //add menu
        public static void AddRecords()
        {
            int menuSelection;
            string logText = "";
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
                        logText = DateTime.Now + " Entered the Add Games Menu.";
                        LogFileLogic.WriteToLog(logText);
                        GameLogic.AddGames();
                        break;
                    case 2:
                        logText = DateTime.Now + " Entered the Add Movies Menu.";
                        LogFileLogic.WriteToLog(logText);
                        MovieLogic.AddMovies();
                        break;
                    case 3:
                        Console.WriteLine("Returning to Main Menu");
                        logText = DateTime.Now + " Exited the Add Records Menu.";
                        LogFileLogic.WriteToLog(logText);
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Please try again.");
                        logText = DateTime.Now + " Entered invalid input in the Add Records Menu.";
                        LogFileLogic.WriteToLog(logText);
                        break;
                }


            } while (menuSelection != 3);
            Console.WriteLine();
        }

        //search menu
        public static void SearchRecords()
        {
            int menuSelection;
            string logText = "";
            do
            {
                Console.WriteLine("Record Search Menu");
                Console.WriteLine("1. List all Video Games");
                Console.WriteLine("2. List all Movies");
                Console.WriteLine("3. Search Video Games by Code");
                Console.WriteLine("4. Search Movies by Code");
                Console.WriteLine("5. Return to Main Menu");
                menuSelection = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (menuSelection)
                {
                    case 1:
                        Console.WriteLine("All Video Games in Database:");
                        logText = DateTime.Now + " Printed all games.";
                        LogFileLogic.WriteToLog(logText);
                        var games = GameLogic.GetAllGames();
                        foreach(var game in games)
                        {
                            Console.WriteLine(game.GameName + " - " + game.GameId);
                        }
                        break;
                    case 2:
                        Console.WriteLine("All Movies in Database:");
                        logText = DateTime.Now + " Printed all movies.";
                        LogFileLogic.WriteToLog(logText);
                        var movies = MovieLogic.GetAllMovies();
                        foreach (var movie in movies)
                        {
                            Console.WriteLine(movie.MovieName + " - " + movie.MovieId);
                        }
                        break;
                    case 3:
                        var selectedGame = GameLogic.SearchForGame();
                        if (selectedGame != null)
                        {
                            logText = DateTime.Now + " Printed data for " + selectedGame.GameName + ".";
                            LogFileLogic.WriteToLog(logText);
                            Console.WriteLine("Game Id: " + selectedGame.GameId);
                            Console.WriteLine("Game Name: " + selectedGame.GameName);
                            Console.WriteLine("Console: " + selectedGame.Console);
                            Console.WriteLine("Primary Developer: " + selectedGame.Developer);
                            Console.WriteLine("Primary Publisher: " + selectedGame.Publisher);
                            Console.WriteLine("Release Date: " + selectedGame.ReleaseDate);
                            Console.WriteLine("Date added to Database: " + selectedGame.DateAdded);
                            Console.ReadLine();
                        }
                        else
                        {
                            logText = DateTime.Now + " Printed no game data.";
                            LogFileLogic.WriteToLog(logText);
                            Console.WriteLine("Search cancelled");
                            Console.ReadLine();
                        }
                        
                        break;
                    case 4:
                        var selectedMovie = MovieLogic.SearchForMovie();
                        if(selectedMovie != null)
                        {
                            logText = DateTime.Now + " Printed data for " + selectedMovie.MovieName + ".";
                            LogFileLogic.WriteToLog(logText);
                            Console.WriteLine("Movie Id: " + selectedMovie.MovieId);
                            Console.WriteLine("Movie Name: " + selectedMovie.MovieName);
                            Console.WriteLine("Length in Minutes: " + selectedMovie.LengthMinutes);
                            Console.WriteLine("Primary Director: " + selectedMovie.Director);
                            Console.WriteLine("Primary Producer: " + selectedMovie.Producer);
                            Console.WriteLine("Release Date: " + selectedMovie.ReleaseDate);
                            Console.WriteLine("Date added to Database: " + selectedMovie.DateAdded);
                            Console.ReadLine();
                        }
                        else
                        {
                            logText = DateTime.Now + " Printed no movie data.";
                            LogFileLogic.WriteToLog(logText);
                            Console.WriteLine("Search cancelled");
                            Console.ReadLine();
                        }
                        break;
                    case 5:
                        Console.WriteLine("Returning to Main Menu");
                        logText = DateTime.Now + " Exited the Search Records Menu.";
                        LogFileLogic.WriteToLog(logText);
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Please try again.");
                        logText = DateTime.Now + " Entered invalid input in the Search Records Menu.";
                        LogFileLogic.WriteToLog(logText);
                        break;
                }
                Console.WriteLine();

            } while (menuSelection != 5);
        }

        //edit menu
        public static void EditRecords()
        {
            int menuSelection;
            string logText = "";
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
                        Console.WriteLine();
                        VideoGame game = GameLogic.SearchForGame();
                        if(game != null)
                        {
                            logText = DateTime.Now + " Entered the Edit Game Menu with " + game.GameName + ".";
                            LogFileLogic.WriteToLog(logText);
                            GameLogic.EditGame(game);
                        }
                        else
                        {
                            Console.WriteLine("Editing cancelled.");
                            logText = DateTime.Now + " Cancelled game editing.";
                            LogFileLogic.WriteToLog(logText);
                        }
                        break;
                    case 2:
                        Console.WriteLine();
                        Movie movie = MovieLogic.SearchForMovie();
                        if(movie != null)
                        {
                            logText = DateTime.Now + " Entered the Edit Movie Menu with " + movie.MovieName +".";
                            LogFileLogic.WriteToLog(logText);
                            MovieLogic.EditMovie(movie);
                        }
                        else
                        {
                            Console.WriteLine("Editing cancelled.");
                            logText = DateTime.Now + " Cancelled movie editing.";
                            LogFileLogic.WriteToLog(logText);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Returning to Main Menu");
                        logText = DateTime.Now + " Exited the Edit Records Menu.";
                        LogFileLogic.WriteToLog(logText);
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Please try again.");
                        logText = DateTime.Now + " Entered invalid input in the Edit Records Menu.";
                        LogFileLogic.WriteToLog(logText);
                        break;
                }


            } while (menuSelection != 3);
            logText = DateTime.Now + " Exited the Edit Records Menu.";
            LogFileLogic.WriteToLog(logText);
        }

        //delete menu
        public static void DeleteRecords()
        {
            int menuSelection;
            string logText = "";
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
                        Console.WriteLine();
                        VideoGame game = GameLogic.SearchForGame();
                        if (game != null)
                        {
                            logText = DateTime.Now + " Selected " + game.GameName + " for deletion.";
                            LogFileLogic.WriteToLog(logText);
                            GameLogic.DeleteGame(game);
                        }
                        else
                        {
                            Console.WriteLine("No records deleted.");
                            logText = DateTime.Now + " Cancelled deleting a game.";
                            LogFileLogic.WriteToLog(logText);
                        }
                        break;
                    case 2:
                        Console.WriteLine();
                        Movie movie = MovieLogic.SearchForMovie();
                        if (movie != null)
                        {
                            logText = DateTime.Now + " Selected " + movie.MovieName + " for deletion.";
                            LogFileLogic.WriteToLog(logText);
                            MovieLogic.DeleteMovie(movie);
                        }
                        else
                        {
                            Console.WriteLine("No records deleted.");
                            logText = DateTime.Now + " Cancelled deleting a movie.";
                            LogFileLogic.WriteToLog(logText);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Returning to Main Menu");
                        logText = DateTime.Now + " Exited the Delete Records Menu.";
                        LogFileLogic.WriteToLog(logText);
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Please try again.");
                        break;
                }


            } while (menuSelection != 3);
        }
    }
}