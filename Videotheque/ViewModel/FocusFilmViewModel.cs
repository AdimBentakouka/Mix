using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;


namespace Videotheque.ViewModel 
{

    class FocusFilmViewModel : AbstractModel
    {
        public MainViewModel ViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }


        private List<Genre> Genres;

        public FocusFilmViewModel(MainViewModel _viewModel)
        {
            ViewModel = _viewModel;

        }

    }
}
