using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Videotheque.DataAccess;
using Videotheque.Model;

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
            var context = await DataAccess.BooksDbContext.GetCurrent();

            context.Films.Add(new Film { Titre = "Titre1", Commentaire = "Commentaire test", Synopsis = "Synopsis test" });
            await context.SaveChangesAsync();
        }

    }
}
