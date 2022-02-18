using API.Dto;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Movie, MovieToReturnDto>()
            .ForMember(x => x.UserReviews, o => o.MapFrom(s => s.UserReviews))
            .ForMember(x => x.Categories, o => o.MapFrom(s => s.MovieCategories))
            .ForMember(x => x.PictureUrl, o => o.MapFrom<MovieUrlResolver>());

        CreateMap<UserReview, UserReviewToReturnDto>();
        CreateMap<Category, CategoryToReturnDto>();
        CreateMap<MovieCategory, CategoryToReturnDto>()
            .ForMember(x => x.CategoryName, o => o.MapFrom(s => s.Category.CategoryName))
            .ForMember(x => x.Id, o => o.MapFrom(s => s.CategoryId));
    }
}