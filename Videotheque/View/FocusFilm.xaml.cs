using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public new async void IsLoaded(object sender, RoutedEventArgs e)
        {
            FocusFilmViewModel = DataContext as FocusFilmViewModel;

            await FocusFilmViewModel.InitGenre();

            String _NameMedia = "";
            String _Synopsis = "";
            String _AgeMini = "";
            String _commentaire = "";
            int _Note = 0;
            int _genre = 0;
            FocusFilmViewModel.InitFilm(ref _NameMedia, ref _Synopsis, ref _Note, ref _AgeMini, ref _genre, ref _commentaire);

            NameMedia.Text = _NameMedia;
            Synopsis.Text = _Synopsis;
            Note.SelectedIndex = _Note;
            AgeMini.Text = _AgeMini;
            Genre.SelectedIndex = _genre - 1;
            Commentaire.Text = _commentaire;
        }
  
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void OnClickButton(object sender, RoutedEventArgs e)
        {
            ErrMess.Content = FocusFilmViewModel.CheckEditFilm(NameMedia.Text, Synopsis.Text, AgeMini.Text, Genre.SelectedIndex).Result;
            


        }

        private async void OnClickDelete(object sender, RoutedEventArgs e)
        {
            await FocusFilmViewModel.DeleteFilm();
        }

        private async void OnClickButtonCommentaire(object sender, RoutedEventArgs e)
        {
            await FocusFilmViewModel.EditCommentaire(Convert.ToInt32(Note.SelectionBoxItem), Commentaire.Text);
        }
    }
}
