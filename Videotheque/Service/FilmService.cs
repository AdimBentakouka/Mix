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

        public async Task DeleteFilm(int idFilm)
        {
            var context = await DataAccess.BooksDbContext.GetCurrent();
            context.Remove(context.Films.Where(film => film.Id == idFilm).First());
            await context.SaveChangesAsync();
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

        public async Task<List<Film>> GetAllFilmByGenre(int genre)
        {
            var context = await DataAccess.BooksDbContext.GetCurrent();
            List<Media_Genre> listmg = context.MediasGenres.Where(mg => mg.Id_Genre == genre).ToList();
            List<Film> listFilmByGenre = new List<Film>();
            foreach (Media_Genre mg in listmg)
            {
                if (!listFilmByGenre.Contains(context.Films.Where(film => film.Id == mg.Id_Media).First()))
                {
                    listFilmByGenre.Add(context.Films.Where(film => film.Id == mg.Id_Media).First());
                }
            }
            return listFilmByGenre;
        }

        public async Task RateFilm(int idFilm, int note, string commentaire)
        {
            var context = await DataAccess.BooksDbContext.GetCurrent();
            context.Films.Where(film => film.Id == idFilm).First().Note = note;
            context.Films.Where(film => film.Id == idFilm).First().Commentaire = commentaire;
            await context.SaveChangesAsync();
        }


        public async Task EditFilm(int idFilm,string titre, int note, string synopsis, int ageMini, int genre)
        {
            var context = await DataAccess.BooksDbContext.GetCurrent();
            context.Films.Where(film => film.Id == idFilm).First().Titre = titre;
            context.Films.Where(film => film.Id == idFilm).First().Note = note;
            context.Films.Where(film => film.Id == idFilm).First().Synopsis = synopsis;
            context.Films.Where(film => film.Id == idFilm).First().Age_Minimum = ageMini;
            context.Remove(context.MediasGenres.Where(md => md.Id_Media == idFilm).First());
            context.MediasGenres.Add(new Media_Genre { Id_Media = idFilm, Id_Genre = genre });
            await context.SaveChangesAsync();
        }

    }
}
