using IMDB_Films.Controllers;
using IMDB_Films.Models;
using IMDB_Films.Repositories;
using IMDB_Films.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_Films.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _moviesRepository;
        private readonly IImdbService _imdbService;

        public MovieController(IImdbService imdbService, IMovieRepository moviesRepository)  
        {
            _moviesRepository = moviesRepository;
            _imdbService = imdbService;
        }
        [HttpGet("search")]
        public async Task<IEnumerable<ImdbMovie>> SearchByTitle([FromQuery]string title)
        {
            return await _imdbService.SearchByTitleAsync(title);
        }

        [HttpGet("watchlist/{id}")]
        public async Task<IEnumerable<WatchList>> GetWatchList(int id)
        {
            return await _moviesRepository.GetWatchList(id);
        }

        [HttpPost]
        public Task AddMovieToWatchList(string movieId, int userId)
        {
            return  _moviesRepository.AddMovieToWatchList(movieId, userId);
        }

        [HttpPost("asWatched")]
        public Task SetAsWatched(string movieId, int userId)
        {
            return _moviesRepository.SetAsWatched(movieId, userId);
        }
    }
}
