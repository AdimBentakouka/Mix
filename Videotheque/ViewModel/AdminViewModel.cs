using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Videotheque.ViewModel
{
    class AdminViewModel : AbstractModel
    {
        public MainViewModel ViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }
        public AdminViewModel(MainViewModel _ViewModel)
        {
            ViewModel = _ViewModel;
        }


        public String CheckAddFilm(String _name, String _note, String _synopsis, String _ageMini, String _genre)
        {
            //Vérifie tout les champs et retourne une erreur si champs vides.
            if (_name.Equals("") || _note.Equals("") || _synopsis.Equals("") || _ageMini.Equals("") || _genre.Equals(""))
            {
               return "Veuillez remplir tous les champs";
            }
            else
            {
                return "Tous les champs remplis";
            }
        }
    }
}
