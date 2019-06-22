using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;
using Videotheque.Service;

namespace Videotheque.ViewModel
{
    class FilmsViewModel : AbstractModel
    {
        public MainViewModel ViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }


        public FilmsViewModel(MainViewModel _ViewModel)
        {
            ViewModel = _ViewModel;
        }

        public void InitData()
        {

        }

       

    }

}
