using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
<<<<<<< HEAD
using Videotheque.Model;
using Videotheque.Service;
=======
using Videotheque.DataAccess;
using Videotheque.Model;
>>>>>>> 8f90d8f32193b43180c44ad5ba8af7c86ee08a59

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
