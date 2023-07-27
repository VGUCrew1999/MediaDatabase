using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDatabase
{
    internal class MovieLogic
    {
        private static MediaContext _context = new MediaContext();
        public LogFileLogic logFileLogic = new LogFileLogic();
        public EditLogic editLogic = new EditLogic();

        //add a movie
        public static void AddMovies()
        {
            Movie newMovie = new Movie();
            string logText = "";
            try
            {
                logText = DateTime.Now + " Began adding a new movie.";
                LogFileLogic.WriteToLog(logText);
                //collect information from user
                Console.WriteLine("Enter the movie's name:");
                newMovie.MovieName = Console.ReadLine();
                logText = DateTime.Now + " Entered " + newMovie.MovieName + " as the movie's name.";
                LogFileLogic.WriteToLog(logText);
                Console.WriteLine("Enter the movie's id:");
                newMovie.MovieId = Console.ReadLine().ToUpper();
                logText = DateTime.Now + " Entered " + newMovie.MovieId + " as the movie's id.";
                LogFileLogic.WriteToLog(logText);
                Console.WriteLine("Enter the length of the movie in minutes:");
                newMovie.LengthMinutes = int.Parse(Console.ReadLine());
                logText = DateTime.Now + " Entered " + newMovie.LengthMinutes + " as the movie's length in minutes.";
                LogFileLogic.WriteToLog(logText);
                Console.WriteLine("Enter the movie's primary director:");
                newMovie.Director = Console.ReadLine();
                logText = DateTime.Now + " Entered " + newMovie.Director + " as the movie's primary director.";
                LogFileLogic.WriteToLog(logText);
                Console.WriteLine("Enter the movie's primary producer:");
                newMovie.Producer = Console.ReadLine();
                logText = DateTime.Now + " Entered " + newMovie.Producer + " as the movie's primary producer.";
                LogFileLogic.WriteToLog(logText);
                Console.WriteLine("Enter the month (number) for the game's release date:");
                var month = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the day for the game's release date:");
                var day = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the year for the game's release date:");
                var year = int.Parse(Console.ReadLine());
                DateTime date = new DateTime(year, month, day);
                newMovie.ReleaseDate = date;
                logText = DateTime.Now + " Entered " + newMovie.ReleaseDate + " as the movie's release date.";
                LogFileLogic.WriteToLog(logText);
                newMovie.DateAdded = DateTime.Today;
            }
            catch (Exception ex) // error handling
            {
                Console.WriteLine("An error has occured while entering data. Please try again.");
                newMovie = null;
                logText = DateTime.Now + " An error occured while entering data for the movie.";
                LogFileLogic.WriteToLog(logText);
            }
            AddMovie(newMovie);
        }

        //confirm adding a movie
        public static void AddMovie(Movie movie)
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
                    LogFileLogic.WriteToLog(logText);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding to Database. Please try again.");
                    logText = DateTime.Now + " An error occured while adding the game to the database.";
                    LogFileLogic.WriteToLog(logText);
                }
                Console.WriteLine();
            }
            else
            {
                logText = DateTime.Now + " The new movie was not added to the database.";
                LogFileLogic.WriteToLog(logText);
            }
        }

        //search for a movie
        public static Movie SearchForMovie()
        {
            var movies = GetAllMovies();
            var endSearch = "no";
            var selectedMovie = new Movie();
            string logText = DateTime.Now + " Entered the Search For Movie Menu.";
            LogFileLogic.WriteToLog(logText);
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
                    LogFileLogic.WriteToLog(logText);
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
                        LogFileLogic.WriteToLog(logText);
                        Console.WriteLine("Invalid input. Please try again.");
                        Console.WriteLine("Would you like to cancel your search? (y/n)");
                        endSearch = Console.ReadLine();
                    }
                }
                else
                {
                    logText = DateTime.Now + " Selected " + selectedMovie.MovieName + " in search menu.";
                    LogFileLogic.WriteToLog(logText);
                    Console.WriteLine("You have selected " + selectedMovie.MovieName + ".");
                    Console.WriteLine("Would you like to continue with this selection? (y/n)");
                    endSearch = Console.ReadLine();
                    while (!endSearch.ToLower().StartsWith("n") && !endSearch.ToLower().StartsWith("y"))
                    {
                        logText = DateTime.Now + " Entered invalid input during movie search.";
                        LogFileLogic.WriteToLog(logText);
                        Console.WriteLine("Invalid input. Please try again.");
                        Console.WriteLine("You have selected " + selectedMovie.MovieName + ".");
                        Console.WriteLine("Would you like to continue with this selection? (y/n)");
                        endSearch = Console.ReadLine();
                    }
                }

                Console.WriteLine();

            } while (!endSearch.ToLower().StartsWith("y")); // only stops the loop if the user decides to continue with their selection or ends the search
            logText = DateTime.Now + " Exited Search For Movie Menu.";
            LogFileLogic.WriteToLog(logText);
            return selectedMovie;
        }

        //get everything - converts a raw sql query result to a list
        public static List<Movie> GetAllMovies()
        {
            var movies = _context.Movies.FromSql($"SELECT * FROM Movies").ToList();
            return movies;
        }

        //edit a movie
        public static void EditMovie(Movie movie)
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
                        movie.MovieName = EditLogic.EditText(movie.MovieName, "Movie Name");
                        break;
                    case 2:
                        movie.LengthMinutes = EditLogic.EditNumber(movie.LengthMinutes, "Length in Minutes");
                        break;
                    case 3:
                        movie.Director = EditLogic.EditText(movie.Director, "Primary Director");
                        break;
                    case 4:
                        movie.Producer = EditLogic.EditText(movie.Producer, "Primary Producer");
                        break;
                    case 5:
                        movie.ReleaseDate = EditLogic.EditDate(movie.ReleaseDate, "Release Date");
                        break;
                    case 6:
                        movie.DateAdded = EditLogic.EditDate(movie.DateAdded, "Date Added");
                        break;
                    case 7:
                        Console.WriteLine("Confirming Edits.");
                        ConfirmMovieEdits(movie);
                        logText = DateTime.Now + " Confirmed Edits for " + movie.MovieName + ".";
                        LogFileLogic.WriteToLog(logText);
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        logText = DateTime.Now + " Entered invalid input in the Edit Movie Menu";
                        LogFileLogic.WriteToLog(logText);
                        break;
                }
            } while (menuSelection != 7);
            logText = DateTime.Now + " Exited the Edit Movie Menu";
            LogFileLogic.WriteToLog(logText);
        }

        //confirm & submit edits
        public static void ConfirmMovieEdits(Movie movie)
        {
            string logText = "";
            try
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
                Console.WriteLine(movie.MovieName + " has been updated.");
                logText = DateTime.Now + " Successfully updated data for " + movie.MovieName + ".";
                LogFileLogic.WriteToLog(logText);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while updating Database.");
                logText = DateTime.Now + " An error occured while updating data for " + movie.MovieName + ".";
                LogFileLogic.WriteToLog(logText);
            }
            Console.WriteLine();
        }

        //delete a movie
        public static void DeleteMovie(Movie movie)
        {
            String logText = DateTime.Now + " Entered the Delete Movie Menu.";
            LogFileLogic.WriteToLog(logText);
            Console.WriteLine("Record Deletion Menu:");
            Console.WriteLine("You have selected " + movie.MovieName + ".");
            Console.WriteLine("Are you sure you want to delete this movie? (y/n)");
            var delete = Console.ReadLine().ToLower();
            while (!delete.StartsWith("y") && !delete.EndsWith("n"))
            {
                logText = DateTime.Now + " Entered invalid input in the Delete Movie Menu";
                LogFileLogic.WriteToLog(logText);
                Console.WriteLine("Invalid input. Please try again");
                Console.WriteLine("You have selected " + movie.MovieName + ".");
                Console.WriteLine("Are you sure you want to delete this movie? (y/n)");
                delete = Console.ReadLine().ToLower();
            }
            if (delete.StartsWith("y"))
            {
                logText = DateTime.Now + " Decided to delete " + movie.MovieName + ".";
                LogFileLogic.WriteToLog(logText);
                ConfirmDeleteMovie(movie);
            }
            else
            {
                logText = DateTime.Now + " Decided not to delete " + movie.MovieName + ".";
                LogFileLogic.WriteToLog(logText);
                Console.WriteLine(movie.MovieName + " was not deleted.");
            }
            logText = DateTime.Now + " Exited the Delete Movie Menu.";
            LogFileLogic.WriteToLog(logText);
            Console.WriteLine();
        }

        //confirm deletion
        public static void ConfirmDeleteMovie(Movie movie)
        {
            string logText = "";
            try
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
                Console.WriteLine(movie.MovieName + " was deleted from the Database.");
                logText = DateTime.Now + " Deleted " + movie.MovieName + " from database.";
                LogFileLogic.WriteToLog(logText);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while updating the Database. Please try again.");
                logText = DateTime.Now + " An error occured while deleting " + movie.MovieName + " from database.";
                LogFileLogic.WriteToLog(logText);
            }
        }
    }
}
