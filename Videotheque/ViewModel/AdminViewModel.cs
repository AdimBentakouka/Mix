using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Videotheque.Service;
using System.Collections.ObjectModel;

namespace Videotheque.ViewModel
{
    class AdminViewModel : AbstractModel
    {
        public MainViewModel ViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }

        public ObservableCollection<String> ComboBoxGenre { get { return GetValue<ObservableCollection<String>>(); } set { SetValue<ObservableCollection<String>>(value); } }

        private FilmService FilmService;
        private GenreService GenreService;
        public AdminViewModel(MainViewModel _ViewModel)
        {
            ViewModel = _ViewModel;
            FilmService = new FilmService();
            GenreService = new GenreService();
            ComboBoxGenre = new ObservableCollection<string>();
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
        public async Task<String> CheckAddFilm(String _name, String _synopsis, String _ageMini, int _genre)
        {
            //Vérifie tout les champs et retourne une erreur si champs vides.
            if (_name.Equals("") || _synopsis.Equals("") || _ageMini.Equals("") || _genre == -1) // -1 = combobox vide
            {
               return "Veuillez remplir tous les champs";
            }
            else
            {
                await FilmService.AddFilm(_name,  _synopsis, Convert.ToInt32(_ageMini), Convert.ToInt32(_genre) + 1);
                return "Success";
            }
        }
    }
}
