using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Videotheque.Service;

namespace Videotheque.ViewModel
{
    class AdminViewModel : AbstractModel
    {
        public MainViewModel ViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }

        private FilmService FilmService;
        public AdminViewModel(MainViewModel _ViewModel)
        {
            ViewModel = _ViewModel;
            FilmService = new FilmService();
        }


        public String CheckAddFilm(String _name, String _note, String _synopsis, String _ageMini, int _genre)
        {
            //Vérifie tout les champs et retourne une erreur si champs vides.
            if (_name.Equals("") || _note.Equals("") || _synopsis.Equals("") || _ageMini.Equals("") || _genre == -1) // -1 = combobox vide
            {
               return "Veuillez remplir tous les champs";
            }
            else
            {
                FilmService.AddFilm(_name, Convert.ToInt32(_note), _synopsis, Convert.ToInt32(_ageMini), Convert.ToInt32(_genre));
                return "Success";
            }
        }
    }
}
