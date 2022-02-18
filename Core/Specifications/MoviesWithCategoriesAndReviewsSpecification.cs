using Core.Entities;

namespace Core.Specifications;

public class MoviesWithCategoriesAndReviewsSpecification : BaseSpecification<Movie>
{
    public MoviesWithCategoriesAndReviewsSpecification(MovieSpecificationParams specParams) : base(x =>
        (string.IsNullOrEmpty(specParams.Search) || x.Title.ToLower().Contains(specParams.Search)) &&
        (specParams.CategoriesId == null || x.MovieCategories.Any(c => specParams.CategoriesId.Contains(c.CategoryId))) &&
        (!specParams.MinRating.HasValue || x.Rating >= specParams.MinRating)) 
        
    {
        AddInclude(x => x.MovieCategories);
        AddInclude(x => x.UserReviews);
        AddOrderBy(x => x.Title);
        ApplyPagination(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
        
        if (string.IsNullOrEmpty(specParams.Sort))
            return;
        
        switch (specParams.Sort)
        {
            case "yearAsc":
                AddOrderBy(x => x.ReleaseYear);
                break;
            case "yearDesc":
                AddOrderByDescending(x => x.ReleaseYear);
                break;
            case "ratingAsc":
                AddOrderBy(x => x.Rating);
                break;
            case "ratingDesc":
                AddOrderByDescending(x => x.Rating);
                break;
            default:
                AddOrderBy(x => x.Title);
                break;
        }
    }
    
    public MoviesWithCategoriesAndReviewsSpecification(int id) : base(x => x.Id == id)
    {
        AddInclude(x => x.MovieCategories);
        AddInclude(x => x.UserReviews);
    }
}