using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Videotheque.ViewModel;

namespace Videotheque.View
{
    /// <summary>
    /// Logique d'interaction pour FocusFilm.xaml
    /// </summary>
    public partial class FocusFilm : Page
    {
        private FocusFilmViewModel FocusFilmViewModel;

        public FocusFilm()
        {
            InitializeComponent();
        }
    }
}
