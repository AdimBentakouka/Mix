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
            string fpath = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "database.db");
            if(System.IO.File.Exists(fpath))
            {
                System.IO.File.Delete(fpath);
            }


            FilmService filmservice = new FilmService();
            GenreService genreservice = new GenreService();
            AmiService amiservice = new AmiService();
            await genreservice.AddGenre("Action");
            await genreservice.AddGenre("Aventure");
            await genreservice.AddGenre("Fantasy");
            await genreservice.AddGenre("Horreur");

            await filmservice.AddFilm("Film 1", "action", 10, 1);
            await filmservice.AddFilm("Film 2", "aventure", 10, 2);
            await filmservice.AddFilm("Film 3", "fantasy", 10, 3);
            await filmservice.AddFilm("Film 4", "action", 10, 1);
            await filmservice.AddFilm("Film 5", "aventure", 10, 2);
            List<Film> filmAction = await filmservice.GetAllFilmByGenre(1);
            List<Film> filmAventure = await filmservice.GetAllFilmByGenre(2);
            List<Film> filmFantasy = await filmservice.GetAllFilmByGenre(3);
            List<Film> filmHorreur = await filmservice.GetAllFilmByGenre(4);
            await amiservice.AddAmi("Adim", "BENTAKOUKA", "adim.bentakouka@gmail.com");
            await amiservice.EditAmi(1, "Adimedit", "BENTAKOUKA", "adim.bentakouka@gmail.com");
            await filmservice.DeleteFilm(1);
            await filmservice.EditFilm(2,"Film 2 edit", "action", 10, 1);
            foreach (Film f in filmFantasy)
            {
                Console.WriteLine(f.Note + " " + f.Commentaire);
            }
            await filmservice.RateFilm(3, 4, "rating");
            foreach (Film f in filmFantasy)
            {
                Console.WriteLine(f.Note + " " + f.Commentaire);
            }
        }

    }
}
