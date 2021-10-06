using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Common
{
    public class Repository
    {
        private readonly SakilaContext _context;

        public Repository(SakilaContext context)
        {
            _context = context;
        }

        public Task<List<Actor>> GetActors() => _context.Actors.ToListAsync();

        public Task<List<TActor>> GetActors<TActor>(Expression<Func<Actor, TActor>> selector) =>
            _context.Actors
                .Select(selector)
                .ToListAsync();

        public Task<Actor?> GetActor(int id) => _context.Actors
            .SingleOrDefaultAsync(a => a.ActorId == id);

        public Task<List<TCategory>> GetCategories<TCategory>(Expression<Func<Category, TCategory>> selector) =>
            _context.Categories
                .Select(selector)
                .ToListAsync();

        public Task<Category?> GetCategory(int id) => _context.Categories
            .SingleOrDefaultAsync(c => c.CategoryId == id);

        public Task<List<TFilm>> GetFilms<TFilm>(Expression<Func<Film, TFilm>> selector) =>
            _context.Films
                .Include(f => f.FilmActors)
                .ThenInclude(fa => fa.Actor)
                .Include(f => f.FilmCategories)
                .ThenInclude(fc => fc.Category)
                .Select(selector)
                .ToListAsync();

        public Task<Film?> GetFilm(int id) => _context.Films
            .Include(f => f.FilmActors)
            .ThenInclude(fa => fa.Actor)
            .Include(f => f.FilmCategories)
            .ThenInclude(fc => fc.Category)
            .SingleOrDefaultAsync(f => f.FilmId == id);
    }
}