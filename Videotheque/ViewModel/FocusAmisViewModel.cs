using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;
using Videotheque.Service;
using Videotheque.View;

namespace Videotheque.ViewModel
{
    class FocusAmisViewModel : AbstractModel
    {
        private MainViewModel ViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }

        private AmiService AmiService;
        public FocusAmisViewModel(MainViewModel _viewModel)
        {
            ViewModel = _viewModel;

            AmiService = new AmiService();
        }

        public void InitData(ref String _nom, ref String _prenom, ref String _mail)
        {
            _nom = ViewModel.Ami.Nom;
            _prenom = ViewModel.Ami.Prenom;
            _mail = ViewModel.Ami.Email;
        }

        public async Task<String> EditAmi(String _nom, String _prenom, String _mail)
        {
            if(_nom == "" || _prenom == "" || _mail == "")
            {
                return "Aucun doit être vide";
            }
            else
            {
                await AmiService.EditAmi(ViewModel.Ami.Id, _prenom, _nom, _mail);
                return "Modifié";
            }
            
        }

        public async Task DeleteAmi()
        {
            await AmiService.DeleteAmi(ViewModel.Ami.Id);

            ViewModel.Ami = null;
            ViewModel.Source = NavigationServices.GetPage<Amis, AmisViewModel>(ViewModel);
        }
    }
}
