using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using MediaDatabase;

namespace MediaDatabaseTest
{
    [TestClass]
    public class MediaDatabaseTest
    {
        //tests adding a game
        [TestMethod]
        [TestProperty("ExecutionOrder", "1")]
        public void FirstAddVideoGame()
        {
            //arrange
            MediaDatabase.MediaContext _context = new MediaDatabase.MediaContext();
            MediaDatabase.VideoGame game = new MediaDatabase.VideoGame();
            game.GameId = "UNTest";
            game.GameName = "Unit Test Game";
            game.Console = "Unit Test";
            game.Publisher = "Unit Test";
            game.Developer = "Unit Test";
            game.ReleaseDate = DateTime.Now;
            game.DateAdded = DateTime.Now;

            //act
            MediaDatabase.Program.AddGame(game);
            var games = MediaDatabase.Program.GetAllGames();

            //assert
            Assert.IsTrue(games.Contains(game));
        }


        //tests adding a movie
        [TestMethod]
        [TestProperty("ExecutionOrder", "2")]
        public void FirstAddMovie()
        {
            //arrange
            MediaDatabase.MediaContext _context = new MediaDatabase.MediaContext();
            MediaDatabase.Movie movie = new MediaDatabase.Movie();
            movie.MovieId = "UNTMOV";
            movie.MovieName = "Unit Test Movie";
            movie.Director = "Unit Test";
            movie.Producer = "Unit Test";
            movie.LengthMinutes = 10;
            movie.ReleaseDate = DateTime.Now;
            movie.DateAdded = DateTime.Now;

            //act
            MediaDatabase.Program.AddMovie(movie);
            var movies = MediaDatabase.Program.GetAllMovies();

            //assert
            Assert.IsTrue(movies.Contains(movie));
        }


        //tests editing a game
        [TestMethod]
        [TestProperty("ExecutionOrder", "3")]
        public void SecondEditVideoGame()
        {
            //arrange
            MediaDatabase.MediaContext _context = new MediaDatabase.MediaContext();
            MediaDatabase.VideoGame game = new MediaDatabase.VideoGame();
            var games = MediaDatabase.Program.GetAllGames();
            game = games.Single(g => g.GameId.ToUpper() == "UNTEST");
            game.GameName = "Edited Unit Test Game";
            game.Console = "Edit Test";

            //act
            MediaDatabase.Program.ConfirmGameEdits(game);
            games = MediaDatabase.Program.GetAllGames();    // reset to check for new values

            //assert
            Assert.IsTrue(games.Contains(game));
        }


        //tests editing a movie
        [TestMethod]
        [TestProperty("ExecutionOrder", "4")]
        public void SecondEditMovie()
        {
            //arrange
            var movies = MediaDatabase.Program.GetAllMovies();
            MediaDatabase.Movie movie = new MediaDatabase.Movie();
            movie = movies.Single(m => m.MovieId.ToUpper() == "UNTMOV");

            //act
            movie.MovieName = "Edited Unit Test Movie";
            movie.Director = "Edit Test";
            movie.Producer = "Unit Test";
            MediaDatabase.Program.ConfirmMovieEdits(movie);
            movies = MediaDatabase.Program.GetAllMovies();  // reset to check for new values

            //assert
            Assert.IsTrue(movies.Contains(movie));  
        }


        //test deleting a game
        [TestMethod]
        [TestProperty("ExecutionOrder", "5")]
        public void ThirdDeleteGame()
        {
            //arrange
            MediaDatabase.MediaContext _context = new MediaDatabase.MediaContext();
            MediaDatabase.VideoGame game = new MediaDatabase.VideoGame();
            var games = MediaDatabase.Program.GetAllGames();
            game = games.Single(g => g.GameId.ToUpper() == "UNTEST");
            game.GameName = "Edited Unit Test Game";
            game.Console = "Edit Test";

            //act
            MediaDatabase.Program.ConfirmDeleteGame(game);
            games = MediaDatabase.Program.GetAllGames();    // reset to check for new values

            //assert
            Assert.IsFalse(games.Contains(game));
        }


        //tests deleting a movie
        [TestMethod]
        [TestProperty("ExecutionOrder", "6")]
        public void ThirdDeleteMovie() {
            //arrange
            var movies = MediaDatabase.Program.GetAllMovies();
            MediaDatabase.Movie movie = new MediaDatabase.Movie();
            movie = movies.Single(m => m.MovieId.ToUpper() == "UNTMOV");

            //act
            MediaDatabase.Program.ConfirmDeleteMovie(movie);
            movies = MediaDatabase.Program.GetAllMovies();  // reset to check for new values

            //assert
            Assert.IsFalse(movies.Contains(movie));
        }
    }
}