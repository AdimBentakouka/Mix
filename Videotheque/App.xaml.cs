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

            FilmService test = new FilmService();
            var context = await DataAccess.BooksDbContext.GetCurrent();

            Genre genre = new Genre { Nom = "Horreur" };
            context.Genres.Add(genre);

            await test.AddFilm("Mon film", 5, "test syno", 10, 3);
            await context.SaveChangesAsync();
            List<Film> maliste = await test.GetAllFilm();

            foreach(Film f in maliste)
            {
                Console.WriteLine(f.Titre);
            }
        }

    }
}
