using API.Dto;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;

public class MovieUrlResolver : IValueResolver<Movie, MovieToReturnDto, string>
{
    private readonly IConfiguration _config;

    public MovieUrlResolver(IConfiguration config)
    {
        _config = config;
    }
    
    public string Resolve(Movie source, MovieToReturnDto destination, string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.PictureUrl))
            return $"{_config["ApiUrl"]}{source.PictureUrl}";
        
        return null;
    }
}