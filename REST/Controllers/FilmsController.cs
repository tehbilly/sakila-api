using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;

namespace REST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmsController : ControllerBase
    {
        private readonly Repository _repository;

        public FilmsController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public Task<List<FilmDTO>> ListFilms() => _repository
            .GetFilms(f => FilmDTO.FromFilm(f));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFilm(int id)
        {
            var film = await _repository.GetFilm(id);
            if (film == null) return NotFound();
            return Ok(FilmDTO.FromFilm(film));
        }
    }

    public class FilmDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReleaseYear { get; set; }
        public byte RentalDuration { get; set; }
        public decimal RentalRate { get; set; }
        public short? Length { get; set; }
        public decimal ReplacementCost { get; set; }
        public string Rating { get; set; }
        public string SpecialFeatures { get; set; }
        public DateTime LastUpdate { get; set; }

        public ICollection<ActorDTO> Actors { get; set; }
        public ICollection<CategoryDTO> Categories { get; set; }

        public static FilmDTO FromFilm(Film film) => new FilmDTO
        {
            ID = film.FilmId,
            Title = film.Title,
            Description = film.Description,
            ReleaseYear = film.ReleaseYear,
            RentalDuration = film.RentalDuration,
            RentalRate = film.RentalRate,
            Length = film.Length,
            ReplacementCost = film.ReplacementCost,
            Rating = film.Rating,
            SpecialFeatures = film.SpecialFeatures,
            LastUpdate = film.LastUpdate,
            Actors = film.FilmActors
                .Select(fa => ActorDTO.FromActor(fa.Actor))
                .ToList(),
            Categories = film.FilmCategories
                .Select(fc => CategoryDTO.FromCategory(fc.Category))
                .ToList(),
        };
    }
}