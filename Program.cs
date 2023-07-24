using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

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
            string logText = DateTime.Now + " Started the program.";
            WriteToLog(logText);
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
                        WriteToLog(logText);
                        AddRecords();
                        break;
                    case 2:
                        Console.WriteLine();
                        logText = DateTime.Now + " Entered the Search Records Menu.";
                        WriteToLog(logText);
                        SearchRecords();
                        break;
                    case 3:
                        Console.WriteLine();
                        logText = DateTime.Now + " Entered the Edit Records Menu.";
                        WriteToLog(logText);
                        EditRecords();
                        break;
                    case 4:
                        Console.WriteLine();
                        logText = DateTime.Now + " Entered the Delete Records Menu.";
                        WriteToLog(logText);
                        DeleteRecords();
                        break;
                    case 5:
                        Console.WriteLine();
                        logText = DateTime.Now + " Printed the Log File.";
                        WriteToLog(logText);
                        ViewLogFile();
                        break;
                    case 6:
                        Console.WriteLine();
                        Console.WriteLine("Exiting Program");
                        logText = DateTime.Now + " Exited the program.";
                        WriteToLog(logText);
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
                        WriteToLog(logText);
                        AddGames();
                        break;
                    case 2:
                        logText = DateTime.Now + " Entered the Add Movies Menu.";
                        WriteToLog(logText);
                        AddMovies();
                        break;
                    case 3:
                        Console.WriteLine("Returning to Main Menu");
                        logText = DateTime.Now + " Exited the Add Records Menu.";
                        WriteToLog(logText);
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Please try again.");
                        logText = DateTime.Now + " Entered invalid input in the Add Records Menu.";
                        WriteToLog(logText);
                        break;
                }


            } while (menuSelection != 3);
            Console.WriteLine();
        }

        //methods to add records
        static void AddGames()
        {
            VideoGame newGame = new VideoGame();
            string logText = "";
            try
            {
                //collect information from user
                logText = DateTime.Now + " Began adding a new game.";
                WriteToLog(logText);
                Console.WriteLine("Enter the game's name:");
                newGame.GameName = Console.ReadLine();
                logText = DateTime.Now + " Entered " + newGame.GameName + " as the game's name.";
                WriteToLog(logText);
                Console.WriteLine("Enter the game's id:");
                newGame.GameId = Console.ReadLine().ToUpper();
                logText = DateTime.Now + " Entered " + newGame.GameId + " as the game's id.";
                WriteToLog(logText);
                Console.WriteLine("Enter the console the game is for:");
                newGame.Console = Console.ReadLine();
                logText = DateTime.Now + " entered " + newGame.Console + " as the game's console.";
                WriteToLog(logText);
                Console.WriteLine("Enter the game's primary developer:");
                newGame.Developer = Console.ReadLine();
                logText = DateTime.Now + " Entered " + newGame.Developer + " as the game's primary developer.";
                WriteToLog(logText);
                Console.WriteLine("Enter the game's primary publisher:");
                newGame.Publisher = Console.ReadLine();
                logText = DateTime.Now + " Entered " + newGame.Publisher + " as the game's primary publisher.";
                WriteToLog(logText);
                Console.WriteLine("Enter the month (number) for the game's release date:");
                var month = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the day for the game's release date:");
                var day = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the year for the game's release date:");
                var year = int.Parse(Console.ReadLine());
                DateTime date = new DateTime(year, month, day);
                newGame.ReleaseDate = date;
                logText = DateTime.Now + " Entered " + newGame.ReleaseDate + " as the game's release dat.";
                WriteToLog(logText);
                newGame.DateAdded = DateTime.Today;
            }
            catch(Exception ex) //error handling
            {
                Console.WriteLine("An error has occured while entering data. Please try again.");
                logText = DateTime.Now + " An error occured while entering data for the game.";
                WriteToLog(logText);
                newGame = null;
            }
            AddGame(newGame);
        }
        static void AddMovies()
        {
            Movie newMovie = new Movie();
            string logText = "";
            try
            {
                logText = DateTime.Now + " Began adding a new movie.";
                WriteToLog(logText);
                //collect information from user
                Console.WriteLine("Enter the movie's name:");
                newMovie.MovieName = Console.ReadLine();
                logText = DateTime.Now + " Entered " + newMovie.MovieName + " as the movie's name.";
                WriteToLog(logText);
                Console.WriteLine("Enter the movie's id:");
                newMovie.MovieId = Console.ReadLine().ToUpper();
                logText = DateTime.Now + " Entered " + newMovie.MovieId+ " as the movie's id.";
                WriteToLog(logText);
                Console.WriteLine("Enter the length of the movie in minutes:");
                newMovie.LengthMinutes = int.Parse(Console.ReadLine());
                logText = DateTime.Now + " Entered " + newMovie.LengthMinutes + " as the movie's length in minutes.";
                WriteToLog(logText);
                Console.WriteLine("Enter the movie's primary director:");
                newMovie.Director = Console.ReadLine();
                logText = DateTime.Now + " Entered " + newMovie.Director + " as the movie's primary director.";
                WriteToLog(logText);
                Console.WriteLine("Enter the movie's primary producer:");
                newMovie.Producer = Console.ReadLine();
                logText = DateTime.Now + " Entered " + newMovie.Producer + " as the movie's primary producer.";
                WriteToLog(logText);
                Console.WriteLine("Enter the month (number) for the game's release date:");
                var month = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the day for the game's release date:");
                var day = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the year for the game's release date:");
                var year = int.Parse(Console.ReadLine());
                DateTime date = new DateTime(year, month, day);
                newMovie.ReleaseDate = date;
                logText = DateTime.Now + " Entered " + newMovie.ReleaseDate + " as the movie's release date.";
                WriteToLog(logText);
                newMovie.DateAdded = DateTime.Today;
            }catch(Exception ex) // error handling
            {
                Console.WriteLine("An error has occured while entering data. Please try again.");
                newMovie = null;
                logText = DateTime.Now + " An error occured while entering data for the movie.";
                WriteToLog(logText);
            }
            AddMovie(newMovie);
        }

        //add methods that can skip input phase for automation
        static void AddGame(VideoGame game)
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
                    WriteToLog(logText);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding to database. Please try again.");
                    logText = DateTime.Now + " An error occured while adding the game to the database.";
                    WriteToLog(logText);
                }
                Console.WriteLine();
            }
            else
            {
                logText = DateTime.Now + " The new game was not added to the database.";
                WriteToLog(logText);
            }
        }
        static void AddMovie(Movie movie)
        {
            string logText = "";
            if (movie != null)
            {
                //adding to database and error handling
                try
                {
                    _context.Movies.Add(movie);
                    _context.SaveChanges();
                    Console.WriteLine("Movie added to Database.");
                    logText = DateTime.Now + " The new movie was added to the database.";
                    WriteToLog(logText);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding to Database. Please try again.");
                    logText = DateTime.Now + " An error occured while adding the game to the database.";
                    WriteToLog(logText);
                }
                Console.WriteLine();
            }
            else
            {
                logText = DateTime.Now + " The new movie was not added to the database.";
                WriteToLog(logText);
            }
        }

        //search menu
        static void SearchRecords()
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
                        WriteToLog(logText);
                        var games = GetAllGames();
                        foreach(var game in games)
                        {
                            Console.WriteLine(game.GameName + " - " + game.GameId);
                        }
                        break;
                    case 2:
                        Console.WriteLine("All Movies in Database:");
                        logText = DateTime.Now + " Printed all movies.";
                        WriteToLog(logText);
                        var movies = GetAllMovies();
                        foreach (var movie in movies)
                        {
                            Console.WriteLine(movie.MovieName + " - " + movie.MovieId);
                        }
                        break;
                    case 3:
                        var selectedGame = SearchForGame();
                        if (selectedGame != null)
                        {
                            logText = DateTime.Now + " Printed data for " + selectedGame.GameName + ".";
                            WriteToLog(logText);
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
                            WriteToLog(logText);
                            Console.WriteLine("Search cancelled");
                            Console.ReadLine();
                        }
                        
                        break;
                    case 4:
                        var selectedMovie = SearchForMovie();
                        if(selectedMovie != null)
                        {
                            logText = DateTime.Now + " Printed data for " + selectedMovie.MovieName + ".";
                            WriteToLog(logText);
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
                            WriteToLog(logText);
                            Console.WriteLine("Search cancelled");
                            Console.ReadLine();
                        }
                        break;
                    case 5:
                        Console.WriteLine("Returning to Main Menu");
                        logText = DateTime.Now + " Exited the Search Records Menu.";
                        WriteToLog(logText);
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Please try again.");
                        logText = DateTime.Now + " Entered invalid input in the Search Records Menu.";
                        WriteToLog(logText);
                        break;
                }
                Console.WriteLine();

            } while (menuSelection != 5);
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
        public static VideoGame SearchForGame()
        {
            string logText = DateTime.Now + " Entered the Search For Game Menu.";
            WriteToLog(logText);
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
                    WriteToLog(logText);
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
                        WriteToLog(logText);
                        Console.WriteLine("Invalid input. Please try again.");
                        Console.WriteLine("Would you like to cancel your search? (y/n)");
                        endSearch = Console.ReadLine();
                    }
                }
                else
                {
                    logText = DateTime.Now + " Selected " + selectedGame.GameName + " in search menu.";
                    WriteToLog(logText);
                    Console.WriteLine("You have selected " + selectedGame.GameName +".");
                    Console.WriteLine("Would you like to continue with this selection? (y/n)");
                    endSearch = Console.ReadLine();
                    while (!endSearch.ToLower().StartsWith("n") && !endSearch.ToLower().StartsWith("y"))
                    {
                        logText = DateTime.Now + " Entered invalid input during game search.";
                        WriteToLog(logText);
                        Console.WriteLine("Invalid input. Please try again.");
                        Console.WriteLine("You have selected " + selectedGame.GameName + ".");
                        Console.WriteLine("Would you like to continue with this selection? (y/n)");
                        endSearch = Console.ReadLine();
                    }
                }
                
                Console.WriteLine();

            } while (!endSearch.ToLower().StartsWith("y")); // only stops the loop if the user decides to continue with their selection or ends the search
            logText = DateTime.Now + " Exited Search For Game Menu.";
            WriteToLog(logText);
            return selectedGame;
        }

        public static Movie SearchForMovie()
        {
            var movies = GetAllMovies();
            var endSearch = "no";
            var selectedMovie = new Movie();
            string logText = DateTime.Now + " Entered the Search For Movie Menu.";
            WriteToLog(logText);
            do
            {
                Console.WriteLine("Please enter a Movie Id to search for: ");
                var movieId = Console.ReadLine();
                

                // catch and prevent any errors
                try
                {
                    selectedMovie = movies.Single(m => m.MovieId.ToUpper() == movieId.ToUpper());
                }
                catch (Exception ex)
                {
                    selectedMovie = null; // set to null if not found
                    logText = DateTime.Now + " Entered an invalid movie id.";
                    WriteToLog(logText);
                }

                // print data if found or give not found
                if (selectedMovie == null)
                {
                    Console.WriteLine("Movie not in Database.");
                    Console.WriteLine("Would you like to cancel your search? (y/n)");
                    endSearch = Console.ReadLine();
                    while (!endSearch.ToLower().StartsWith("n") && !endSearch.ToLower().StartsWith("y"))
                    {
                        logText = DateTime.Now + " Entered invalid input during movie.";
                        WriteToLog(logText);
                        Console.WriteLine("Invalid input. Please try again.");
                        Console.WriteLine("Would you like to cancel your search? (y/n)");
                        endSearch = Console.ReadLine();
                    }
                }
                else
                {
                    logText = DateTime.Now + " Selected " + selectedMovie.MovieName + " in search menu.";
                    WriteToLog(logText);
                    Console.WriteLine("You have selected " + selectedMovie.MovieName + ".");
                    Console.WriteLine("Would you like to continue with this selection? (y/n)");
                    endSearch = Console.ReadLine();
                    while (!endSearch.ToLower().StartsWith("n") && !endSearch.ToLower().StartsWith("y"))
                    {
                        logText = DateTime.Now + " Entered invalid input during movie search.";
                        WriteToLog(logText);
                        Console.WriteLine("Invalid input. Please try again.");
                        Console.WriteLine("You have selected " + selectedMovie.MovieName + ".");
                        Console.WriteLine("Would you like to continue with this selection? (y/n)");
                        endSearch = Console.ReadLine();
                    }
                }

                Console.WriteLine();

            } while (!endSearch.ToLower().StartsWith("y")); // only stops the loop if the user decides to continue with their selection or ends the search
            logText = DateTime.Now + " Exited Search For Movie Menu.";
            WriteToLog(logText);
            return selectedMovie;
        }


        //edit menu
        static void EditRecords()
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
                        VideoGame game = SearchForGame();
                        if(game != null)
                        {
                            logText = DateTime.Now + " Entered the Edit Game Menu with " + game.GameName + ".";
                            WriteToLog(logText);
                            EditGame(game);
                        }
                        else
                        {
                            Console.WriteLine("Editing cancelled.");
                            logText = DateTime.Now + " Cancelled game editing.";
                            WriteToLog(logText);
                        }
                        break;
                    case 2:
                        Console.WriteLine();
                        Movie movie = SearchForMovie();
                        if(movie != null)
                        {
                            logText = DateTime.Now + " Entered the Edit Movie Menu with " + movie.MovieName +".";
                            WriteToLog(logText);
                            EditMovie(movie);
                        }
                        else
                        {
                            Console.WriteLine("Editing cancelled.");
                            logText = DateTime.Now + " Cancelled movie editing.";
                            WriteToLog(logText);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Returning to Main Menu");
                        logText = DateTime.Now + " Exited the Edit Records Menu.";
                        WriteToLog(logText);
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Please try again.");
                        logText = DateTime.Now + " Entered invalid input in the Edit Records Menu.";
                        WriteToLog(logText);
                        break;
                }


            } while (menuSelection != 3);
            logText = DateTime.Now + " Exited the Edit Records Menu.";
            WriteToLog(logText);
        }
        //methods to edit records
        static void EditGame(VideoGame game)
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
                        game.GameName = EditText(game.GameName, "Game Name");
                        break;
                    case 2:
                        game.Console = EditText(game.Console, "Console");
                        break;
                    case 3:
                        game.Developer = EditText(game.Developer, "Primary Developer");
                        break;
                    case 4:
                        game.Publisher = EditText(game.Publisher, "Primary Publisher");
                        break;
                    case 5:
                        game.ReleaseDate = EditDate(game.ReleaseDate, "Release Date");
                        break;
                    case 6:
                        game.DateAdded = EditDate(game.DateAdded, "Date Added");
                        break;
                    case 7:
                        Console.WriteLine("Confirming Edits.");
                        ConfirmGameEdits(game);
                        logText = DateTime.Now + " Confirmed Edits for " + game.GameName + ".";
                        WriteToLog(logText);
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        logText = DateTime.Now + " Entered invalid input in the Edit Game Menu";
                        WriteToLog(logText);
                        break;
                }
            } while (menuSelection != 7);
            logText = DateTime.Now + " Exited the Edit Game Menu";
            WriteToLog(logText);

        }

        static void EditMovie(Movie movie)
        {
            int menuSelection;
            string logText = "";
            do
            {
                Console.WriteLine("You have selected " + movie.MovieName + ".");
                Console.WriteLine("Which data for this game would you like to edit?");
                Console.WriteLine("1. Name");
                Console.WriteLine("2. Length in Minutes");
                Console.WriteLine("3. Primary Director");
                Console.WriteLine("4. Primary Producer");
                Console.WriteLine("5. Release Date");
                Console.WriteLine("6. Date Added to Database");
                Console.WriteLine("7. Confirm Edits");
                menuSelection = int.Parse(Console.ReadLine());
                switch (menuSelection)
                {
                    case 1:
                        movie.MovieName = EditText(movie.MovieName, "Movie Name");
                        break;
                    case 2:
                        movie.LengthMinutes = EditNumber(movie.LengthMinutes, "Length in Minutes");
                        break;
                    case 3:
                        movie.Director = EditText(movie.Director, "Primary Director");
                        break;
                    case 4:
                        movie.Producer = EditText(movie.Producer, "Primary Producer");
                        break;
                    case 5:
                        movie.ReleaseDate = EditDate(movie.ReleaseDate, "Release Date");
                        break;
                    case 6:
                        movie.DateAdded = EditDate(movie.DateAdded, "Date Added");
                        break;
                    case 7:
                        Console.WriteLine("Confirming Edits.");
                        ConfirmMovieEdits(movie);
                        logText = DateTime.Now + " Confirmed Edits for " + movie.MovieName + ".";
                        WriteToLog(logText);
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        logText = DateTime.Now + " Entered invalid input in the Edit Movie Menu";
                        WriteToLog(logText);
                        break;
                }
            } while (menuSelection != 7);
            logText = DateTime.Now + " Exited the Edit Movie Menu";
            WriteToLog(logText);
        }

        //reusable edit methods
        static string EditText(string oldText, string description)
        {
            string logText = DateTime.Now + " Entered the Edit Text Menu";
            WriteToLog(logText);
            try
            {
                Console.WriteLine("Currently editing: " + description);
                Console.WriteLine("Old Version: " + oldText);
                Console.WriteLine("Please enter the New Version:");
                string newText = Console.ReadLine();
                logText = DateTime.Now + " Changed the " + description + " from " + oldText + " to " + newText + ".";
                WriteToLog(logText);
                logText = DateTime.Now + " Exited the Edit Text Menu";
                WriteToLog(logText);
                return newText;
            }catch(Exception ex)
            {
                Console.WriteLine("Error while editing data. Reverting to old version.");
                logText = DateTime.Now + " An error occured while editing text. Reverting to original.";
                WriteToLog(logText);
                logText = DateTime.Now + " Exited the Edit Text Menu";
                WriteToLog(logText);
                return oldText;
            }
        }

        static DateTime EditDate(DateTime oldDate, string description)
        {
            string logText = DateTime.Now + " Entered Edit Date Menu";
            WriteToLog(logText);
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
                WriteToLog(logText);
                logText = DateTime.Now + " Exited the Edit Date Menu";
                WriteToLog(logText);
                return newDate;
            }catch(Exception ex)
            {
                Console.WriteLine("Error while editing data. Reverting to old version.");
                logText = DateTime.Now + " An error occured while editing a date. Reverting to original.";
                WriteToLog(logText);
                logText = DateTime.Now + " Exited the Edit Date Menu";
                WriteToLog(logText);
                return oldDate;
            }
            
        }

        static int EditNumber(int oldNumber, string description)
        {
            string logText = DateTime.Now + " Entered the Edit Number Menu.";
            WriteToLog(logText);
            try
            {
                Console.WriteLine("Currently editing: " + description);
                Console.WriteLine("Old Version: " + oldNumber);
                Console.WriteLine("Please enter the New Version:");
                int newNumber = int.Parse(Console.ReadLine());
                logText = DateTime.Now + " Changed the " + description + " from " + oldNumber + " to " + newNumber + ".";
                WriteToLog(logText);
                logText = DateTime.Now + " Exited the Edit Number Menu";
                WriteToLog(logText);
                return newNumber;
            }catch(Exception ex)
            {
                Console.WriteLine("Error while editing data. Reverting to old version.");
                logText = DateTime.Now + " An error occured while editing a number. Reverting to original.";
                WriteToLog(logText);
                logText = DateTime.Now + " Exited the Edit Text Menu";
                WriteToLog(logText);
                return oldNumber;
            }
            
        }

        //methods to confirm any edits
        static void ConfirmGameEdits(VideoGame game)
        {
            string logText = "";
            try
            {
                _context.VideoGames.Update(game);
                _context.SaveChanges();
                Console.WriteLine(game.GameName + " has been updated.");
                logText = DateTime.Now + " Successfully updated data for " + game.GameName + ".";
                WriteToLog(logText);

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error while updating Database.");
                logText = DateTime.Now + " An error occured while updating data for " + game.GameName + ".";
                WriteToLog(logText);
            }
            Console.WriteLine();
        }

        static void ConfirmMovieEdits(Movie movie)
        {
            string logText = "";
            try
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
                Console.WriteLine(movie.MovieName + " has been updated.");
                logText = DateTime.Now + " Successfully updated data for " + movie.MovieName + ".";
                WriteToLog(logText);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while updating Database.");
                logText = DateTime.Now + " An error occured while updating data for " + movie.MovieName + ".";
                WriteToLog(logText);
            }
            Console.WriteLine();
        }

        //delete menu
        static void DeleteRecords()
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
                        VideoGame game = SearchForGame();
                        if (game != null)
                        {
                            logText = DateTime.Now + " Selected " + game.GameName + " for deletion.";
                            WriteToLog(logText);
                            DeleteGame(game);
                        }
                        else
                        {
                            Console.WriteLine("No records deleted.");
                            logText = DateTime.Now + " Cancelled deleting a game.";
                            WriteToLog(logText);
                        }
                        break;
                    case 2:
                        Console.WriteLine();
                        Movie movie = SearchForMovie();
                        if (movie != null)
                        {
                            logText = DateTime.Now + " Selected " + movie.MovieName + " for deletion.";
                            WriteToLog(logText);
                            DeleteMovie(movie);
                        }
                        else
                        {
                            Console.WriteLine("No records deleted.");
                            logText = DateTime.Now + " Cancelled deleting a movie.";
                            WriteToLog(logText);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Returning to Main Menu");
                        logText = DateTime.Now + " Exited the Delete Records Menu.";
                        WriteToLog(logText);
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Please try again.");
                        break;
                }


            } while (menuSelection != 3);
        }

        //methods for deleting records
        static void DeleteGame(VideoGame game)
        {
            String logText = DateTime.Now + " Entered the Delete Game Menu.";
            WriteToLog(logText);
            Console.WriteLine("Record Deletion Menu:");
            Console.WriteLine("You have selected " + game.GameName + ".");
            Console.WriteLine("Are you sure you want to delete this game? (y/n)");
            var delete = Console.ReadLine().ToLower();
            while(!delete.StartsWith("y")  && !delete.EndsWith("n"))
            {
                logText = DateTime.Now + " Entered invalid input in the Delete Game Menu";
                WriteToLog(logText);
                Console.WriteLine("Invalid input. Please try again");
                Console.WriteLine("You have selected " + game.GameName + ".");
                Console.WriteLine("Are you sure you want to delete this game? (y/n)");
                delete = Console.ReadLine().ToLower();
            }
            if (delete.StartsWith("y"))
            {
                logText = DateTime.Now + " Decided to delete " + game.GameName + ".";
                WriteToLog(logText);
                ConfirmDeleteGame(game);
            }
            else
            {
                Console.WriteLine(game.GameName + " was not deleted.");
                logText = DateTime.Now + " Decided not to delete " + game.GameName + ".";
                WriteToLog(logText);
            }
            logText = DateTime.Now + " Exited the Delete Game Menu.";
            WriteToLog(logText);
            Console.WriteLine();
        }
        static void DeleteMovie(Movie movie)
        {
            String logText = DateTime.Now +  " Entered the Delete Movie Menu.";
            WriteToLog(logText);
            Console.WriteLine("Record Deletion Menu:");
            Console.WriteLine("You have selected " + movie.MovieName + ".");
            Console.WriteLine("Are you sure you want to delete this movie? (y/n)");
            var delete = Console.ReadLine().ToLower();
            while (!delete.StartsWith("y") && !delete.EndsWith("n"))
            {
                logText = DateTime.Now + " Entered invalid input in the Delete Movie Menu";
                WriteToLog(logText);
                Console.WriteLine("Invalid input. Please try again");
                Console.WriteLine("You have selected " + movie.MovieName + ".");
                Console.WriteLine("Are you sure you want to delete this movie? (y/n)");
                delete = Console.ReadLine().ToLower();
            }
            if (delete.StartsWith("y"))
            {
                logText = DateTime.Now + " Decided to delete " + movie.MovieName + ".";
                WriteToLog(logText);
                ConfirmDeleteMovie(movie);
            }
            else
            {
                logText = DateTime.Now + " Decided not to delete " + movie.MovieName + ".";
                WriteToLog(logText);
                Console.WriteLine(movie.MovieName + " was not deleted.");
            }
            logText = DateTime.Now + " Exited the Delete Movie Menu.";
            WriteToLog(logText);
            Console.WriteLine();
        }

        //delete methods that can skip input phase for automation
        static void ConfirmDeleteGame(VideoGame game)
        {
            string logText = "";
            try
            {
                _context.VideoGames.Remove(game);
                _context.SaveChanges();
                Console.WriteLine(game.GameName + " was deleted from the Database.");
                logText = DateTime.Now + " Deleted " + game.GameName + " from database.";
                WriteToLog(logText);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while updating the Database. Please try again.");
                logText = DateTime.Now + " An error occured while deleting " + game.GameName + " from database.";
                WriteToLog(logText);
            }

        }
        static void ConfirmDeleteMovie(Movie movie)
        {
            string logText = "";
            try
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
                Console.WriteLine(movie.MovieName + " was deleted from the Database.");
                logText = DateTime.Now + " Deleted " + movie.MovieName + " from database.";
                WriteToLog(logText);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while updating the Database. Please try again.");
                logText = DateTime.Now + " An error occured while deleting " + movie.MovieName + " from database.";
                WriteToLog(logText);
            }
        }

        //methods for log file
        //log menu
        static void ViewLogFile()
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
        }

        //writing to log file
        static void WriteToLog(string message)
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
        static string GetFilePath()
        {
            return @"LogFile.txt";
        }
    }
}