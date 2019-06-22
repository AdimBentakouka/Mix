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
    /// Logique d'interaction pour Films.xaml
    /// </summary>
    public partial class Films : Page
    {
        private FilmsViewModel FilmViewModel;

        public Films()
        {
            InitializeComponent();
            TextSearch.Text = "Rechercher un film / série";
        }
        public new void IsLoaded(object sender, RoutedEventArgs e)
        {
            FilmViewModel = DataContext as FilmsViewModel;
            FilmViewModel.InitData();
        }

        private void OnFocusSearchText(object sender, RoutedEventArgs e)
        {
            if(TextSearch.Text.Equals("Rechercher un film / série"))
            {
                TextSearch.Text = "";
            }
        }

        private void OnLostFocusSearchText(object sender, RoutedEventArgs e)
        {
            if (TextSearch.Text.Equals(""))
            {
                TextSearch.Text = "Rechercher un film / série";
            }
            else
            {
                //Faire un recherche
            }
        }

        private void SearchMedia(object sender, TextChangedEventArgs e)
        {
            if(TextSearch.Text.Length > 3)
            {
                Console.WriteLine("Recherche sur " + TextSearch.Text);
            }
        }
    }
}
