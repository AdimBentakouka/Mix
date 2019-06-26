using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Videotheque.Model;
using Videotheque.Service;


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
            await test.AddFilm("Mon film", 5, "test syno", 10, 2);
        }

    }
}
