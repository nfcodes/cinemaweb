using Core.Entities;

namespace Core.Specifications;

public class MoviesFilteredForCountSpecification : BaseSpecification<Movie>
{
    public MoviesFilteredForCountSpecification(MovieSpecificationParams specParams) : base(x =>
        (string.IsNullOrEmpty(specParams.Search) || x.Title.ToLower().Contains(specParams.Search)) &&
        (specParams.CategoriesId == null || x.MovieCategories.Any(c => specParams.CategoriesId.Contains(c.CategoryId))) &&
        (!specParams.MinRating.HasValue || x.Rating >= specParams.MinRating))
    {
        
    }
}