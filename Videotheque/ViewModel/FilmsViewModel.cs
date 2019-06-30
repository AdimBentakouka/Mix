using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Videotheque.Model;
using Videotheque.Service;
using Videotheque.View;
using Videotheque.ViewModel;

namespace Videotheque.ViewModel
{
    class FilmsViewModel : AbstractModel
    {
        public MainViewModel ViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }
        public ObservableCollection<String> ListBoxFilms { get { return GetValue<ObservableCollection<String>>(); } set { SetValue<ObservableCollection<String>>(value); } }
        public ObservableCollection<String> ComboBoxGenre { get { return GetValue<ObservableCollection<String>>(); } set { SetValue<ObservableCollection<String>>(value); } }

        private FilmService FilmService;
        private GenreService GenreService;
        private List<Film> Films;


        public FilmsViewModel(MainViewModel _ViewModel)
        {
            ViewModel = _ViewModel;
            FilmService = new FilmService();
            GenreService = new GenreService();
            ListBoxFilms = new ObservableCollection<string>();
            ComboBoxGenre = new ObservableCollection<string>();
            
        }

        public async Task InitData()
        {
            await RefreshListfilmAsync();

        }

        public async Task RefreshListfilmAsync(int _genre = 0)
        {
            if(_genre > 0)
            {
                Films = await FilmService.GetAllFilmByGenre(_genre);
            }
            else
            {
                Films = await FilmService.GetAllFilm();
            }
        }

        public async Task InitGenre()
        {
            //Recup en BDD tout les genres
            var listGenres = await GenreService.GetAllGenre();
            // on trie la liste avant de l'inserer
            listGenres = listGenres.OrderBy(n => n.Id).ToList();
            // On add les genres dans la combobox
            ComboBoxGenre.Clear();
            ComboBoxGenre.Add("Tous");
            foreach (Genre genre in listGenres)
            {
                ComboBoxGenre.Add(genre.Nom);
            }
        }

        public void ShowFilm(int _order = 1, String _filtre = "")
        {
            var listFilms = Films;
            switch (_order)
            {
                default:
                case 1:
                    listFilms = listFilms.OrderBy(n => n.Titre).ToList();
                    break;
                case 2:
                    listFilms = listFilms.OrderByDescending(n => n.Titre).ToList();
                    break;
               
            }
            ListBoxFilms.Clear();
            foreach (Film film in listFilms)
            {
                // Trie seulement si on a renseigner plus de deux lettres
                if(!_filtre.Equals("") && !_filtre.Equals("Rechercher un film / série"))
                {
                    // Si le film contient pas le mot entrer on passe au prochains
                    if(!film.Titre.ToUpper().Contains(_filtre.ToUpper()))
                    {
                        continue;
                    }
                }
                ListBoxFilms.Add(film.Titre);
            }

            if(ListBoxFilms.Count() == 0)
            {
                ListBoxFilms.Add("Pas d'ocurrence ...");
            }
        }

        public void setFocusFilm(String _titre = "")
        {
             if(_titre != "")
             {
                foreach(Film Film in Films)
                {
                    if(Film.Titre.Equals(_titre))
                    {
                        ViewModel.Film = Film;
                        break;
                    }
                    continue;
                }
                   
               ViewModel.Source = NavigationServices.GetPage<FocusFilm, FocusFilmViewModel>(ViewModel);
             }
        }
      


    }

}
