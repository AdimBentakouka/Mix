using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Videotheque.Model;
using Videotheque.Service;
using Videotheque.DataAccess;

namespace Videotheque
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
  
        protected override async void OnStartup(StartupEventArgs e)
        {
         
            base.OnStartup(e);

            FilmService filmservice = new FilmService();
            GenreService genreservice = new GenreService();
            var context = await DataAccess.BooksDbContext.GetCurrent();

            await genreservice.AddGenre("Fantasy");

            await filmservice.AddFilm("Mon film", 5, "test syno", 10, 1);
            await context.SaveChangesAsync();
            List<Genre> maliste = await filmservice.GetFilmGenre(1);

            foreach (Genre g in maliste)
            {
                Console.WriteLine(g.Nom);
            };
        }

    }
}
