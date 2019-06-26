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
        private List<Media_Genre> listeGenre;

        public async Task AddFilm(string titre, int note, string synopsis, int ageMini, int genre)
        {
            var context = await DataAccess.BooksDbContext.GetCurrent();
            Film newFilm = new Film { Titre = titre, Note = note, Synopsis = synopsis, Age_Minimum = ageMini };
            context.Films.Add(newFilm);
            Media_Genre media_Genre = new Media_Genre { Id_Media = newFilm.Id, Id_Genre = genre };
            context.MediasGenres.Add(media_Genre);
            await context.SaveChangesAsync();
        }
    }
}
