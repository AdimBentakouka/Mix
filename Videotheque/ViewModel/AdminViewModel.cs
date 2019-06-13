using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;

namespace Videotheque.ViewModel
{
    class AdminViewModel : AbstractModel
    {
        public MainViewModel ViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }
        public AdminViewModel(MainViewModel _ViewModel)
        {
            ViewModel = _ViewModel;
        }
    }
}
