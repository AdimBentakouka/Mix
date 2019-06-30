using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;
using Videotheque.Service;
using Videotheque.View;
using Videotheque.ViewModel;


namespace Videotheque.ViewModel
{
    class AmisViewModel : AbstractModel
    {
        public MainViewModel ViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }

        public ObservableCollection<String> ListBoxAmis { get { return GetValue<ObservableCollection<String>>(); } set { SetValue<ObservableCollection<String>>(value); } }
        private AmiService amiservice;
        private List<Ami> Amis;


        public AmisViewModel(MainViewModel _ViewModel)
        {
            ViewModel = _ViewModel;
            amiservice = new AmiService();
            ListBoxAmis = new ObservableCollection<string>();
        }
        public async Task InitAmi()
        {
            await RefreshListAmiAsync();

        }

        public async Task RefreshListAmiAsync(int _genre = 0)
        {
                Amis = await amiservice.GetAllAmi();
        }


        public void ShowAmi(String _filtre = "")
        {
            var listAmis = Amis;
            listAmis = listAmis.OrderBy(n => n.Nom).ToList();
            //ListBoxAmis.Clear();
            //foreach (Ami Ami in listAmis)
            //{
            // Trie seulement si on a renseigner plus de deux lettres
            //    if (!_filtre.Equals("") && !_filtre.Equals("Rechercher un ami") && _filtre.Length > 2)
            //    {
            //        // Si l'ami contient pas le mot entrer on passe au prochains
            //        if (!Ami.Nom.ToUpper().Contains(_filtre.ToUpper()))
            //        {
            //           continue;
            //        }
            //    }
            //    ListBoxAmis.Add(Ami.Nom);
            //}
            ListBoxAmis.Add("test");

            if (ListBoxAmis.Count() == 0)
            {
                ListBoxAmis.Add("Pas d'ocurrence ...");
            }
        }

    }
}
