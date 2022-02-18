using API.Dto;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class MoviesController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Movie> _moviesRepository;
    private readonly IGenericRepository<Category> _categoriesRepository;

    public MoviesController(IMapper mapper, IGenericRepository<Movie> moviesRepository, IGenericRepository<Category> categoriesRepository)
    {
        _mapper = mapper;
        _moviesRepository = moviesRepository;
        _categoriesRepository = categoriesRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<Pagination<MovieToReturnDto>>> GetMovies([FromQuery] MovieSpecificationParams movieParams)
    {
        MoviesWithCategoriesAndReviewsSpecification spec = new MoviesWithCategoriesAndReviewsSpecification(movieParams);
        MoviesFilteredForCountSpecification countSpec = new MoviesFilteredForCountSpecification(movieParams);

        int totalMovies = await _moviesRepository.CountAsync(countSpec);
        IReadOnlyList<Movie> movies = await _moviesRepository.ListSpecifiedAsync(spec);
        
        if (movies == null || movies.Count == 0)
            return NotFound();
        
        IReadOnlyList<MovieToReturnDto> data = _mapper.Map<IReadOnlyList<Movie>, IReadOnlyList<MovieToReturnDto>>(movies);
        return Ok(new Pagination<MovieToReturnDto>(movieParams.PageIndex, movieParams.PageSize, totalMovies, data));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<MovieToReturnDto>> GetMovie(int id)
    {
        MoviesWithCategoriesAndReviewsSpecification spec = new MoviesWithCategoriesAndReviewsSpecification(id);
        Movie movie = await _moviesRepository.GetWithSpecificationAsync(spec);
        if (movie == null)
            return NotFound();

        return Ok(_mapper.Map<Movie, MovieToReturnDto>(movie));
    }
    
    [HttpGet("categories")]
    public async Task<ActionResult<IReadOnlyList<CategoryToReturnDto>>> GetMovieCategories()
    {
        IReadOnlyList<Category> data = await _categoriesRepository.ListAllAsync();
        return Ok(_mapper.Map<IReadOnlyList<Category>, IReadOnlyList<CategoryToReturnDto>>(data));
    }
}