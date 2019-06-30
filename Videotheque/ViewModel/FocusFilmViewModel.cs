using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;
using Videotheque.Service;
using Videotheque.View;

namespace Videotheque.ViewModel 
{

    class FocusFilmViewModel : AbstractModel
    {
        public MainViewModel ViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }
        public ObservableCollection<String> ComboBoxGenre { get { return GetValue<ObservableCollection<String>>(); } set { SetValue<ObservableCollection<String>>(value); } }

        private GenreService GenreService;
        private FilmService FilmService;

        public FocusFilmViewModel(MainViewModel _viewModel)
        {
            ViewModel = _viewModel;

            GenreService = new GenreService();
            ComboBoxGenre = new ObservableCollection<string>();
            FilmService = new FilmService();
        }

        public void InitFilm(ref String _NameMedia, ref String _Synopsis, ref int _Note, ref String _AgeMini, ref int _genre, ref String _commentaire)
        {
            _NameMedia = ViewModel.Film.Titre;
            _Synopsis = ViewModel.Film.Synopsis;
            _AgeMini = ViewModel.Film.Age_Minimum.ToString();
            _Note = ViewModel.Film.Note;
            _genre = ViewModel.Film.Genre[0].Id_Genre;
            _commentaire = ViewModel.Film.Commentaire;

        }

        public async Task InitGenre()
        {
            //Recup en BDD tout les genres
            var listGenres = await GenreService.GetAllGenre();
            // on trie la liste avant de l'inserer
            listGenres = listGenres.OrderBy(n => n.Id).ToList();
            // On add les genres dans la combobox
            ComboBoxGenre.Clear();
            foreach (Genre genre in listGenres)
            {
                ComboBoxGenre.Add(genre.Nom);
            }

        }

        public async Task<String> CheckEditFilm(String _name, String _synopsis, String _ageMini, int _genre)
        {
            //Vérifie tout les champs et retourne une erreur si champs vides.
            if (_name.Equals("") || _synopsis.Equals("") || _ageMini.Equals("") || _genre == -1) // -1 = combobox vide
            {
                return "Veuillez remplir tous les champs";
            }
            else
            {
                await FilmService.EditFilm(ViewModel.Film.Id, _name, _synopsis, Convert.ToInt32(_ageMini), Convert.ToInt32(_genre) + 1);
                ViewModel.Source = NavigationServices.GetPage<Films, FilmsViewModel>(ViewModel);
                return "Success";
            }
        }

        public async Task DeleteFilm()
        {
            await FilmService.DeleteFilm(ViewModel.Film.Id);
            ViewModel.Film = null;
            ViewModel.Source = NavigationServices.GetPage<Films, FilmsViewModel>(ViewModel);
          
        }

        public async Task EditCommentaire(int _note, String _commentaire)
        {
            await FilmService.RateFilm(ViewModel.Film.Id, _note, _commentaire);
            ViewModel.Source = NavigationServices.GetPage<Films, FilmsViewModel>(ViewModel);
        }




    }
}
