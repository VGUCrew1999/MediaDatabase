using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MediaDatabase
{
    internal class Program
    {
        private static MediaContext _context = new MediaContext();
        //main menu
        static void Main(string[] args)
        {
            _context.Database.EnsureCreated();
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
                Console.WriteLine();

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
                        AddGames();
                        break;
                    case 2:
                        AddMovies();
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

        //methods to add records
        static void AddGames()
        {
            //collect information from user
            VideoGame newGame = new VideoGame();
            Console.WriteLine("Enter the game's name:");
            newGame.GameName = Console.ReadLine();
            Console.WriteLine("Enter the game's id:");
            newGame.GameId = Console.ReadLine();
            Console.WriteLine("Enter the console the game is for:");
            newGame.Console = Console.ReadLine();
            Console.WriteLine("Enter the game's primary developer:");
            newGame.Developer = Console.ReadLine();
            Console.WriteLine("Enter the game's primary publisher:");
            newGame.Publisher = Console.ReadLine();
            Console.WriteLine("Enter the year for the game's release date:");
            var year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the month for the game's release date:");
            var month = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the day for the game's release date:");
            var day = int.Parse(Console.ReadLine());
            DateTime date = new DateTime(year, month, day);
            newGame.ReleaseDate = date;
            newGame.DateAdded = DateTime.Today;

            //adding to database and error handling
            try
            {
                _context.VideoGames.Add(newGame);
                _context.SaveChanges();
                Console.WriteLine("Video Game added to database");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error adding to database. Please try again.");
            }
        }
        static void AddMovies()
        {
            //collect information from user
            Movie newMovie = new Movie();
            Console.WriteLine("Enter the movie's name:");
            newMovie.MovieName = Console.ReadLine();
            Console.WriteLine("Enter the movie's id:");
            newMovie.MovieId = Console.ReadLine();
            Console.WriteLine("Enter the length of the movie in minutes:");
            newMovie.LengthMinutes = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the movie's primary director:");
            newMovie.Director = Console.ReadLine();
            Console.WriteLine("Enter the movie's primary producer:");
            newMovie.Producer = Console.ReadLine();
            Console.WriteLine("Enter the year for the movie's release date:");
            var year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the month for the movie's release date:");
            var month = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the day for the movie's release date:");
            var day = int.Parse(Console.ReadLine());
            DateTime date = new DateTime(year, month, day);
            newMovie.ReleaseDate = date;
            newMovie.DateAdded = DateTime.Today;

            //adding to database and error handling
            try
            {
                _context.Movies.Add(newMovie);
                _context.SaveChanges();
                Console.WriteLine("Movie added to Database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding to Database. Please try again.");
            }
            Console.WriteLine();
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
                Console.WriteLine();
                switch (menuSelection)
                {
                    case 1:
                        Console.WriteLine("All Video Games in Database:");
                        var games = GetAllGames();
                        foreach(var game in games)
                        {
                            Console.WriteLine(game.GameName + " - " + game.GameId);
                        }
                        break;
                    case 2:
                        Console.WriteLine("All Movies in Database:");
                        var movies = GetAllMovies();
                        foreach (var movie in movies)
                        {
                            Console.WriteLine(movie.MovieName + " - " + movie.MovieId);
                        }
                        break;
                    case 3:
                        SearchForGame();
                        break;
                    case 4:
                        SearchForMovie();
                        break;
                    case 5:
                        Console.WriteLine("Returning to Main Menu");
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Please try again.");
                        break;
                }


            } while (menuSelection != 5);
            Console.WriteLine();
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

        //methods for retrieving everything
        public static List<VideoGame> GetAllGames()
        {
            var games = _context.VideoGames.ToList();
            return games;
        }
        public static List<Movie> GetAllMovies()
        {
            var movies = _context.Movies.ToList();
            return movies;
        }

        //methods for individual search
        public static void SearchForGame()
        {
            var games = GetAllGames();
            var continueSearch = "";
            do
            {
                Console.WriteLine("Please enter a Game Id to search for: ");
                var gameId = Console.ReadLine();
                var selectedGame = new VideoGame();

                //catch and prevent any errors
                try
                {
                    selectedGame = games.Single(g => g.GameId == gameId.ToUpper());
                }
                catch(Exception Ex)
                {
                    selectedGame = null; // set to null if not found
                }

                // print data if found or give not found
                if(selectedGame == null)
                {
                    Console.WriteLine("Video Game not in Database.");
                }
                else
                {
                    Console.WriteLine("Game Id: " + selectedGame.GameId);
                    Console.WriteLine("Game Name: " + selectedGame.GameName);
                    Console.WriteLine("Console: " + selectedGame.Console);
                    Console.WriteLine("Primary Developer: " + selectedGame.Developer);
                    Console.WriteLine("Primary Publisher: " + selectedGame.Publisher);
                    Console.WriteLine("Release Date: " + selectedGame.ReleaseDate);
                    Console.WriteLine("Date added to Database: " + selectedGame.DateAdded);
                    Console.ReadLine();
                }
                Console.WriteLine("Would you like to continue searching?(y/n)");
                continueSearch = Console.ReadLine();
                while (!continueSearch.ToLower().StartsWith("n") && !continueSearch.ToLower().StartsWith("y"))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.WriteLine("Would you like to continue searching?(y/n)");
                    continueSearch = Console.ReadLine();
                }
                Console.WriteLine();

            } while (!continueSearch.ToLower().StartsWith("n"));
        }

        public static void SearchForMovie()
        {
            var movies = GetAllMovies();
            var continueSearch = "";
            do
            {
                Console.WriteLine("Please enter a Movie Id to search for: ");
                var movieId = Console.ReadLine();
                var selectedMovie = new Movie();

                // catch and prevent any errors
                try
                {
                    selectedMovie = movies.Single(m => m.MovieId == movieId.ToUpper());
                }
                catch(Exception ex)
                {
                    selectedMovie = null; // set to null if not found
                }

                // print data if found or give not found
                if (selectedMovie == null)
                {
                    Console.WriteLine("Movie not in Database.");
                }
                else
                {
                    Console.WriteLine("Movie Id: " + selectedMovie.MovieId);
                    Console.WriteLine("Movie Name: " + selectedMovie.MovieName);
                    Console.WriteLine("Length in Minutes: " + selectedMovie.LengthMinutes);
                    Console.WriteLine("Primary Director: " + selectedMovie.Director);
                    Console.WriteLine("Primary Producer: " + selectedMovie.Producer);
                    Console.WriteLine("Release Date: " + selectedMovie.ReleaseDate);
                    Console.WriteLine("Date added to Database: " + selectedMovie.DateAdded);
                    Console.ReadLine();
                }
                Console.WriteLine("Would you like to continue searching?(y/n)");
                continueSearch = Console.ReadLine();
                while (!continueSearch.ToLower().StartsWith("n") && !continueSearch.ToLower().StartsWith("y"))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.WriteLine("Would you like to continue searching?(y/n)");
                    continueSearch = Console.ReadLine();
                }
                Console.WriteLine();

            } while (!continueSearch.ToLower().StartsWith("n"));
        }
    }
}