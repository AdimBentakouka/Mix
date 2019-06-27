using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;

namespace Videotheque.Service
{
    class FilmService
    {
        public async Task AddFilm(string titre, int note, string synopsis, int ageMini, int genre)
        {
            var context = await DataAccess.BooksDbContext.GetCurrent();
            Film newFilm = new Film { Titre = titre, Note = note, Synopsis = synopsis, Age_Minimum = ageMini };
            context.Films.Add(newFilm);
            Media_Genre media_Genre = new Media_Genre { Id_Media = newFilm.Id, Id_Genre = genre };
            context.MediasGenres.Add(media_Genre);
            await context.SaveChangesAsync();
        }

        public async Task<List<Film>> GetAllFilm()
         {
            var context = await DataAccess.BooksDbContext.GetCurrent();
            return context.Films.ToList();
         }

        public async Task<Film> GetFilm(int idFilm)
        {
            var context = await DataAccess.BooksDbContext.GetCurrent();
            return context.Films.Where(film => film.Id == idFilm).First();
        }

        public async Task<List<Genre>> GetFilmGenre(int idFilm)
        {
            var context = await DataAccess.BooksDbContext.GetCurrent();
            List <Media_Genre> listmg = context.MediasGenres.Where(mg => mg.Id_Media == idFilm).ToList();
            List<Genre> listGenre = new List<Genre>();
            foreach (Media_Genre mg in listmg)
            {
                listGenre.Add(context.Genres.Where(g => g.Id == mg.Id_Genre).First());
            }

            return listGenre;

        }

    }
}
