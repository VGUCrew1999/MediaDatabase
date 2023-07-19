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
                        Console.WriteLine();
                        AddRecords();
                        break;
                    case 2:
                        Console.WriteLine();
                        SearchRecords();
                        break;
                    case 3:
                        Console.WriteLine();
                        EditRecords();
                        break;
                    case 4:
                        Console.WriteLine();
                        DeleteRecords();
                        break;
                    case 5:
                        Console.WriteLine();
                        ViewLogFile();
                        break;
                    case 6:
                        Console.WriteLine();
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
            Console.WriteLine();
        }

        //methods to add records
        static void AddGames()
        {
            VideoGame newGame = new VideoGame();
            try
            {
                //collect information from user
                Console.WriteLine("Enter the game's name:");
                newGame.GameName = Console.ReadLine();
                Console.WriteLine("Enter the game's id:");
                newGame.GameId = Console.ReadLine().ToUpper();
                Console.WriteLine("Enter the console the game is for:");
                newGame.Console = Console.ReadLine();
                Console.WriteLine("Enter the game's primary developer:");
                newGame.Developer = Console.ReadLine();
                Console.WriteLine("Enter the game's primary publisher:");
                newGame.Publisher = Console.ReadLine();
                Console.WriteLine("Enter the month for the game's release date:");
                var month = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the day for the game's release date:");
                var day = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the year for the game's release date:");
                var year = int.Parse(Console.ReadLine());
                DateTime date = new DateTime(year, month, day);
                newGame.ReleaseDate = date;
                newGame.DateAdded = DateTime.Today;
            }
            catch(Exception ex) //error handling
            {
                Console.WriteLine("An error has occured while entering data. Please try again.");
                newGame = null;
            }
            
            if(newGame != null)
            {
                try
                {
                    _context.VideoGames.Add(newGame);
                    _context.SaveChanges();
                    Console.WriteLine("Video Game added to database");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding to database. Please try again.");
                }
            } 
        }
        static void AddMovies()
        {
            Movie newMovie = new Movie();
            try
            {
                //collect information from user
                Console.WriteLine("Enter the movie's name:");
                newMovie.MovieName = Console.ReadLine();
                Console.WriteLine("Enter the movie's id:");
                newMovie.MovieId = Console.ReadLine().ToUpper();
                Console.WriteLine("Enter the length of the movie in minutes:");
                newMovie.LengthMinutes = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the movie's primary director:");
                newMovie.Director = Console.ReadLine();
                Console.WriteLine("Enter the movie's primary producer:");
                newMovie.Producer = Console.ReadLine();
                Console.WriteLine("Enter the month for the game's release date:");
                var month = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the day for the game's release date:");
                var day = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the year for the game's release date:");
                var year = int.Parse(Console.ReadLine());
                DateTime date = new DateTime(year, month, day);
                newMovie.ReleaseDate = date;
                newMovie.DateAdded = DateTime.Today;
            }catch(Exception ex) // error handling
            {
                Console.WriteLine("An error has occured while entering data. Please try again.");
                newMovie = null;
            }
            
            if(newMovie != null)
            {
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
                        var selectedGame = SearchForGame();
                        if (selectedGame != null)
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
                        else
                        {
                            Console.WriteLine("Search cancelled");
                            Console.ReadLine();
                        }
                        
                        break;
                    case 4:
                        var selectedMovie = SearchForMovie();
                        if(selectedMovie != null)
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
                        else
                        {
                            Console.WriteLine("Search cancelled");
                            Console.ReadLine();
                        }
                        break;
                    case 5:
                        Console.WriteLine("Returning to Main Menu");
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Please try again.");
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
                }

                // print data if found or give not found
                if (selectedGame == null)
                {
                    Console.WriteLine("Video Game not in Database.");
                    Console.WriteLine("Would you like to cancel your search? (y/n)");
                    endSearch = Console.ReadLine();
                    while (!endSearch.ToLower().StartsWith("n") && !endSearch.ToLower().StartsWith("y"))
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                        Console.WriteLine("Would you like to cancel your search? (y/n)");
                        endSearch = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("You have selected " + selectedGame.GameName +".");
                    Console.WriteLine("Would you like to continue with this selection? (y/n)");
                    endSearch = Console.ReadLine();
                    while (!endSearch.ToLower().StartsWith("n") && !endSearch.ToLower().StartsWith("y"))
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                        Console.WriteLine("You have selected " + selectedGame.GameName + ".");
                        Console.WriteLine("Would you like to continue with this selection? (y/n)");
                        endSearch = Console.ReadLine();
                    }
                }
                
                Console.WriteLine();

            } while (!endSearch.ToLower().StartsWith("y")); // only stops the loop if the user decides to continue with their selection or ends the search
            return selectedGame;
        }

        public static Movie SearchForMovie()
        {
            var movies = GetAllMovies();
            var endSearch = "no";
            var selectedMovie = new Movie();
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
                }

                // print data if found or give not found
                if (selectedMovie == null)
                {
                    Console.WriteLine("Movie not in Database.");
                    Console.WriteLine("Would you like to cancel your search? (y/n)");
                    endSearch = Console.ReadLine();
                    while (!endSearch.ToLower().StartsWith("n") && !endSearch.ToLower().StartsWith("y"))
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                        Console.WriteLine("Would you like to cancel your search? (y/n)");
                        endSearch = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("You have selected " + selectedMovie.MovieName + ".");
                    Console.WriteLine("Would you like to continue with this selection? (y/n)");
                    endSearch = Console.ReadLine();
                    while (!endSearch.ToLower().StartsWith("n") && !endSearch.ToLower().StartsWith("y"))
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                        Console.WriteLine("You have selected " + selectedMovie.MovieName + ".");
                        Console.WriteLine("Would you like to continue with this selection? (y/n)");
                        endSearch = Console.ReadLine();
                    }
                }

                Console.WriteLine();

            } while (!endSearch.ToLower().StartsWith("y")); // only stops the loop if the user decides to continue with their selection or ends the search
            return selectedMovie;
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
                        Console.WriteLine();
                        VideoGame game = SearchForGame();
                        if(game != null)
                        {
                            EditGame(game);
                        }
                        else
                        {
                            Console.WriteLine("Editing cancelled.");
                        }
                        break;
                    case 2:
                        Console.WriteLine();
                        Movie movie = SearchForMovie();
                        if(movie != null)
                        {
                            EditMovie(movie);
                        }
                        else
                        {
                            Console.WriteLine("Editing cancelled.");
                        }
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
        //methods to edit records
        static void EditGame(VideoGame game)
        {
            int menuSelection;
            do
            {
                Console.WriteLine("You have selected " + game.GameName + ".");
                Console.WriteLine("Which data for this game would you like to edit?");
                Console.WriteLine("1. Id");
                Console.WriteLine("2. Name");
                Console.WriteLine("3. Console");
                Console.WriteLine("4. Primary Developer");
                Console.WriteLine("5. Primary Publisher");
                Console.WriteLine("6. Release Date");
                Console.WriteLine("7. Date Added to Database");
                Console.WriteLine("8. Confirm Edits");
                menuSelection = int.Parse(Console.ReadLine());
                switch (menuSelection)
                {
                    case 1:
                        game.GameId = EditText(game.GameId, "GameId");
                        break;
                    case 2:
                        game.GameName = EditText(game.GameName, "Game Name");
                        break;
                    case 3:
                        game.Console = EditText(game.Console, "Console");
                        break;
                    case 4:
                        game.Developer = EditText(game.Developer, "Primary Developer");
                        break;
                    case 5:
                        game.Publisher = EditText(game.Publisher, "Primary Publisher");
                        break;
                    case 6:
                        game.ReleaseDate = EditDate(game.ReleaseDate, "Release Date");
                        break;
                    case 7:
                        game.DateAdded = EditDate(game.DateAdded, "Date Added");
                        break;
                    case 8:
                        Console.WriteLine("Confirming Edits.");
                        ConfirmGameEdits(game);
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            } while (menuSelection != 8);
            

        }

        static void EditMovie(Movie movie)
        {
            int menuSelection;
            do
            {
                Console.WriteLine("You have selected " + movie.MovieName + ".");
                Console.WriteLine("Which data for this game would you like to edit?");
                Console.WriteLine("1. Id");
                Console.WriteLine("2. Name");
                Console.WriteLine("3. Length in Minutes");
                Console.WriteLine("4. Primary Director");
                Console.WriteLine("5. Primary Producer");
                Console.WriteLine("6. Release Date");
                Console.WriteLine("7. Date Added to Database");
                Console.WriteLine("8. Confirm Edits");
                menuSelection = int.Parse(Console.ReadLine());
                switch (menuSelection)
                {
                    case 1:
                        movie.MovieId = EditText(movie.MovieId, "MovieId");
                        break;
                    case 2:
                        movie.MovieName = EditText(movie.MovieName, "Movie Name");
                        break;
                    case 3:
                        movie.LengthMinutes = EditNumber(movie.LengthMinutes, "Length in Minutes");
                        break;
                    case 4:
                        movie.Director = EditText(movie.Director, "Primary Director");
                        break;
                    case 5:
                        movie.Producer = EditText(movie.Producer, "Primary Producer");
                        break;
                    case 6:
                        movie.ReleaseDate = EditDate(movie.ReleaseDate, "Release Date");
                        break;
                    case 7:
                        movie.DateAdded = EditDate(movie.DateAdded, "Date Added");
                        break;
                    case 8:
                        Console.WriteLine("Confirming Edits.");
                        ConfirmMovieEdits(movie);
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            } while (menuSelection != 8);
        }

        //reusable edit methods
        static string EditText(string oldText, string description)
        {
            try
            {
                Console.WriteLine("Currently editing: " + description);
                Console.WriteLine("Old Version: " + oldText);
                Console.WriteLine("Please enter the New Version:");
                string newText = Console.ReadLine();
                return newText;
            }catch(Exception ex)
            {
                Console.WriteLine("Error while editing data. Reverting to old version.");
                return oldText;
            }
            
        }

        static DateTime EditDate(DateTime oldDate, string description)
        {
            try
            {
                Console.WriteLine("Currently editing: " + description);
                Console.WriteLine("Old Version: " + oldDate);
                Console.WriteLine("Please enter the New Version:");
                Console.WriteLine("Month: ");
                int month = int.Parse(Console.ReadLine());
                Console.WriteLine("Day: ");
                int day = int.Parse(Console.ReadLine());
                Console.WriteLine("Year:");
                int year = int.Parse(Console.ReadLine());
                DateTime newDate = new DateTime(year, month, day);
                return newDate;
            }catch(Exception ex)
            {
                Console.WriteLine("Error while editing data. Reverting to old version.");
                return oldDate;
            }
            
        }

        static int EditNumber(int oldNumber, string description)
        {
            try
            {
                Console.WriteLine("Currently editing: " + description);
                Console.WriteLine("Old Version: " + oldNumber);
                Console.WriteLine("Please enter the New Version:");
                int newNumber = int.Parse(Console.ReadLine());
                return newNumber;
            }catch(Exception ex)
            {
                Console.WriteLine("Error while editing data. Reverting to old version.");
                return oldNumber;
            }
            
        }

        //methods to confirm any edits
        static void ConfirmGameEdits(VideoGame game)
        {
            try
            {
                _context.VideoGames.Update(game);
                _context.SaveChanges();
                Console.WriteLine(game.GameName + " has been updated.");

            }catch(Exception ex)
            {
                Console.WriteLine("Error while updating Database. Please try again.");
            }
            Console.WriteLine();
        }

        static void ConfirmMovieEdits(Movie movie)
        {
            try
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
                Console.WriteLine(movie.MovieName + " has been updated.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while updating Database. Please try again.");
            }
            Console.WriteLine();
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