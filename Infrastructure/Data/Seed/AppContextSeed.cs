using System.Text.Json;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data.Seed;

public class AppContextSeed
{
    public static async Task SeedDataAsync(AppDbContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            TryLoadMovies(context);
            TryLoadCategories(context);
            TryLoadReviews(context);
            TryLoadMovieCategories(context);
            await context.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            ILogger<AppContextSeed> logger = loggerFactory.CreateLogger<AppContextSeed>();
            logger.LogError(exception, "There was problem with seeding sample data!");
        }
    }

    private static void TryLoadMovies(AppDbContext context)
    {
        if (!context.Movies.Any())
        {
            string json = File.ReadAllText("../Infrastructure/Data/Seed/SeedData/movies.json");
            List<Movie> movies = JsonSerializer.Deserialize<List<Movie>>(json);
            foreach (Movie type in movies)
                context.Movies.Add(type);
        }
    }
    
    private static void TryLoadCategories(AppDbContext context)
    {
        if (!context.Categories.Any())
        {
            string json = File.ReadAllText("../Infrastructure/Data/Seed/SeedData/categories.json");
            List<Category> categories = JsonSerializer.Deserialize<List<Category>>(json);
            foreach (Category type in categories)
                context.Categories.Add(type);
        }
    }
    
    private static void TryLoadReviews(AppDbContext context)
    {
        if (!context.UserReviews.Any())
        {
            string json = File.ReadAllText("../Infrastructure/Data/Seed/SeedData/reviews.json");
            List<UserReview> reviews = JsonSerializer.Deserialize<List<UserReview>>(json);
            foreach (UserReview type in reviews)
                context.UserReviews.Add(type);
        }
    }
    
    private static void TryLoadMovieCategories(AppDbContext context)
    {
        if (!context.MovieCategories.Any())
        {
            string json = File.ReadAllText("../Infrastructure/Data/Seed/SeedData/movieCategories.json");
            List<MovieCategory> movieCategories = JsonSerializer.Deserialize<List<MovieCategory>>(json);
            foreach (MovieCategory type in movieCategories)
                context.MovieCategories.Add(type);
        }
    }
}