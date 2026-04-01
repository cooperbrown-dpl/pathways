namespace MovieApp.Tests;

[TestClass]
public class MovieAccessTests
{
    private readonly MovieAccess _movieAccess;

    public MovieAccessTests()
    {
        _movieAccess = new MovieAccess();
    }

    // Test 1: Adding a movie increases the total count
    [TestMethod]
    public void AddMovie_IncreasesMovieCount_ReturnsCorrectCount()
    {
        // Arrange
        var movie = new Movie { Title = "Dumb and Dumber", Genre = "Comedy", ReleaseYear = 1994, Rating = 9.5m };

        // Act
        _movieAccess.AddMovie(movie);
        int count = _movieAccess.GetTotalMovieCount();

        // Assert
        Assert.AreEqual(1, count);
    }

    // Test 2: GetMovieById returns the correct movie
    [TestMethod]
    public void GetMovieById_ValidId_ReturnsCorrectMovie()
    {
        // Arrange
        var movie = new Movie { Title = "Dumb and Dumber", Genre = "Comedy", ReleaseYear = 1994, Rating = 9.5m };
        _movieAccess.AddMovie(movie);

        // Act
        var result = _movieAccess.GetMovieById(1);

        // Assert
        Assert.AreEqual("Dumb and Dumber", result.Title);
    }

    // Test 3: GetMoviesByGenre returns only movies of that genre
    [TestMethod]
    public void GetMoviesByGenre_ValidGenre_ReturnsOnlyMatchingGenre()
    {
        // Arrange
        var movie1 = new Movie
        {
            Title = "Dumb and Dumber",
            Genre = "Comedy",
            ReleaseYear = 1994,
            Rating = 9.5m
        };

        var movie2 = new Movie
        {
            Title = "Ace Ventura Pet Detective",
            Genre = "Comedy",
            ReleaseYear = 1994,
            Rating = 9.7m
        };

        _movieAccess.AddMovie(movie1);
        _movieAccess.AddMovie(movie2);

        // Act
        var comedyMovies = _movieAccess.GetMoviesByGenre("Comedy");

        // Assert
        Assert.AreEqual(2, comedyMovies.Count);
        Assert.IsTrue(comedyMovies.All(m => m.Genre.Equals("Comedy")));
    }

    // Test 4: DeleteMovie returns true when movie exists and is deleted
    [TestMethod]
    public void DeleteMovie_ValidId_ReturnsTrue()
    {
        // Arrange
        var movie = new Movie { Title = "Dumb and Dumber", Genre = "Comedy", ReleaseYear = 1994, Rating = 9.5m };
        _movieAccess.AddMovie(movie);

        // Act
        var wasMovieDeleted = _movieAccess.DeleteMovie(movie.Id);

        // Assert
        Assert.AreEqual(true, wasMovieDeleted);
    }

    // Test 5: GetAllMovies returns a copy (not the original list)
    [TestMethod]
    public void GetAllMovies_ContainsTwoMovies_ReturnsCopyOfList()
    {
        // Arrange
        var movie1 = new Movie
        {
            Title = "Dumb and Dumber",
            Genre = "Comedy",
            ReleaseYear = 1994,
            Rating = 9.5m
        };

        var movie2 = new Movie
        {
            Title = "Ace Ventura Pet Detective",
            Genre = "Comedy",
            ReleaseYear = 1994,
            Rating = 9.7m
        };
        _movieAccess.AddMovie(movie1);
        _movieAccess.AddMovie(movie2);

        // Act
        var allMovies = _movieAccess.GetAllMovies();

        // Assert
        Assert.AreEqual(2, allMovies.Count);
    }
}
