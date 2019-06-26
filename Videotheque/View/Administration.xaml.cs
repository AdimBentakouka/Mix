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

namespace Videotheque.View
{
    /// <summary>
    /// Logique d'interaction pour Administration.xaml
    /// </summary>
    public partial class Administration : Page
    {
        public Administration()
        {
            InitializeComponent();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void OnClickButton(object sender, RoutedEventArgs e)
        {
            //Vérifie tout les champs et retourne une erreur si champs vides.
            if(NameMedia.Text.Equals("") || Note.Text.Equals("") || Synopsis.Text.Equals("") || AgeMini.Text.Equals("") || Genre.Text.Equals(""))
            {
                ErrMess.Content = "Veuillez remplir tous les champs";
            }
            else
            {
                ErrMess.Content = "Tous les champs remplis";
            }

        }
    }
}
