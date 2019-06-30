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
            string fpath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"mix.db");
            if(System.IO.File.Exists(fpath))
            {
                System.IO.File.Delete(fpath);
            }

            FilmService filmservice = new FilmService();
            GenreService genreservice = new GenreService();
            AmiService amiservice = new AmiService();
            await genreservice.AddGenre("Drame");
            await genreservice.AddGenre("Aventure");
            await genreservice.AddGenre("Science-fiction");
            await genreservice.AddGenre("Action");
            await genreservice.AddGenre("Fantasy");


            await filmservice.AddFilm("Fight Club", "La vie d'un employé de bureau est bouleversée lorsqu'il rencontre Tyler Durden. Ils forment ensemble le Fight Club, un club de lutte clandestine.", 18, 1);
            await filmservice.AddFilm("Pulp Fiction", "'odyssée sanglante, burlesque et cocasse de petits malfrats dans la jungle de Hollywood à travers trois histoires qui s'entremêlent.", 18, 1);
            await filmservice.AddFilm("2001 : L'Odyssée de l'espace", "action", 10, 2);
            await filmservice.AddFilm("Blade Runner", "Après avoir massacré un équipage et pris le contrôle d'un vaisseau, quatre androïdes ultra perfectionnés parviennent à s'introduire dans Los Angeles.", 14, 3);
            await filmservice.AddFilm("Interstellar", "Un groupe d'explorateurs exploite une faille dans l'espace-temps afin de parcourir des distances incroyables dans le but de sauver l'humanité.", 12, 3);
            await filmservice.AddFilm("Le Parrain", "Suite à une tentative d'assassinat sur la personne de Don Vito Corleone, deux puissantes familles de la mafia New-Yorkaise s'affrontent, en quête de vengeance.", 10, 1);
            await filmservice.AddFilm("Forrest Gump", "Forrest raconte sa fabuleuse histoire, celle d'un simple d'esprit se laissant porter par les événements américains les plus marquants du XXe siècle.", 10, 2);
            await filmservice.AddFilm("Le Seigneur des Anneaux : Le Retour du roi", "Guidés par Gollum, Frodon et Sam continuent leur périple vers la montagne du destin, tandis que Gandalf et ses compagnons se retrouvent à Isengard.", 12, 5);
            await filmservice.AddFilm("Le Seigneur des Anneaux : La Communauté de l'anneau", "Frodon reçoit l'Anneau de son oncle Bilbo. Sa vie et son monde sont pourtant en danger, car cet anneau appartient à Sauron, le maître des ténèbres.", 10, 5);
            await filmservice.AddFilm("L'Empire contre-attaque", "Après la destruction de l'Etoile noire, l'Empire fait tout pour traquer et anéantir les rebelles qui se sont réfugiés sur la planète Hoth.", 12, 4);
            await filmservice.RateFilm(1, 5, "");
            Random random = new Random();

            for (int i = 1; i < 11; i++)
            {
                int randomnumber = random.Next(0, 6);
                if (randomnumber > 5) { randomnumber = 5; }
                await filmservice.RateFilm(i, randomnumber, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum suscipit quam quis elit bibendum ultrices. Ut volutpat diam sed tempus viverra. Praesent malesuada feugiat est, in finibus nisi pretium sed. Nam vitae mi ut augue sodales lobortis in nec enim. Sed eget tincidunt purus. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. ");
            }


            await amiservice.AddAmi("Sacripant", "Garceau", "SacripantGarceau@armyspy.com");
            await amiservice.AddAmi("Monique", "Gamelin", "MoniqueGamelin@rhyta.com");
            await amiservice.AddAmi("Curtis", "Poirier", "CurtisPoirier@dayrep.com");
            await amiservice.AddAmi("Robert", "Garceau", "RobertGarceau@rhyta.com");
            await amiservice.AddAmi("Searlait", "Fontaine", "SearlaitFontaine@jourrapide.com");
        }

    }
}
