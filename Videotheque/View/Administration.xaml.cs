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
    /// Logique d'interaction pour Administration.xaml
    /// </summary>
    public partial class Administration : Page
    {
        private AdminViewModel AdminViewModel;
        public Administration()
        {
            InitializeComponent();
           
        }
        public new void IsLoaded(object sender, RoutedEventArgs e)
        {
            AdminViewModel = DataContext as AdminViewModel;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void OnClickButton(object sender, RoutedEventArgs e)
        {
            ErrMess.Content = AdminViewModel.CheckAddFilm(NameMedia.Text, Note.Text, Synopsis.Text, AgeMini.Text, Genre.SelectedIndex);
            if(ErrMess.Content.Equals("Success")) 
            {

                NameMedia.Text = "";
                Synopsis.Text = "";
                AgeMini.Text = "";

            }
           

        }
    }
}
