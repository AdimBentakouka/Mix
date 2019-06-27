using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;

namespace Videotheque.Service
{
    class GenreService
    {
        public async Task AddGenre(string nom)
        {
            var context = await DataAccess.BooksDbContext.GetCurrent();
            Genre newGenre = new Genre { Nom = nom };
            context.Genres.Add(newGenre);
            await context.SaveChangesAsync();
        }

        public async Task<List<Genre>> GetAllGenre()
        {
            var context = await DataAccess.BooksDbContext.GetCurrent();
            return context.Genres.ToList();
        }
    }
}
