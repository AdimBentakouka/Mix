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
using Videotheque.Model;
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
        public new async void IsLoaded(object sender, RoutedEventArgs e)
        {
            FilmViewModel = DataContext as FilmsViewModel;
            await FilmViewModel.InitData();
            ShowFilm();
            await FilmViewModel.InitGenre();
            Genre.SelectedIndex = 0;
            
        }
     
        private void OnFocusSearchText(object sender, RoutedEventArgs e)
        {
            if (TextSearch.Text.Equals("Rechercher un film / série"))
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
        }

        private void SearchMedia(object sender, TextChangedEventArgs e)
        {
            ShowFilm();
        }

        private async void OnSelectGenre(object sender, SelectionChangedEventArgs e)
        {
            await FilmViewModel.RefreshListfilmAsync(Genre.SelectedIndex);
            ShowFilm();
        }

        private void OnSelectOrder(object sender, SelectionChangedEventArgs e)
        {
            ShowFilm();
        }

        private void ShowFilm()
        {
            if (FilmViewModel != null)
            {
                FilmViewModel.ShowFilm(ComboBoxOrder.SelectedIndex + 1, TextSearch.Text);
            }
        }

        private void OnClickFilm(object sender, MouseButtonEventArgs e)
        {
            if(ListFilm.SelectedIndex > -1)
            {
                FilmViewModel.setFocusFilm(ListFilm.Items[ListFilm.SelectedIndex].ToString());
            }
            

        }
    }
}
