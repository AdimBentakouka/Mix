using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;
using Videotheque.Service;

namespace Videotheque.ViewModel
{
    class AddAmiViewModel : AbstractModel
    {
        public MainViewModel ViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }

        private AmiService AmiService;



        public AddAmiViewModel(MainViewModel _ViewModel)
        {
            ViewModel = _ViewModel;
            AmiService = new AmiService();

        }

        public async Task<String> SetAmi(String _nom, String _prenom, String _mail)
        {
            if(_nom == "" || _prenom == "" || _mail == "")
            {
                return "Tous les champs doit être remplis";
            }

            await AmiService.AddAmi(_prenom, _nom, _mail);
            return "Ami ajouté";
        }

        
    }
}
