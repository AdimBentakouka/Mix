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
    /// Logique d'interaction pour FocusAmis.xaml
    /// </summary>
    public partial class FocusAmis : Page
    {
        private FocusAmisViewModel FocusAmisViewModel;
        public FocusAmis()
        {
            InitializeComponent();
        }
        public new void IsLoaded(object sender, RoutedEventArgs e)
        {
            FocusAmisViewModel = DataContext as FocusAmisViewModel;
            String _nom ="";
            String _prenom="";
            String _mail="";
            Mess.Content = "";
            FocusAmisViewModel.InitData(ref _nom, ref _prenom, ref _mail);

            nom.Text = _nom;
            prenom.Text = _prenom;
            mail.Text = _mail;

        }
        private async void OnClickButton(object sender, RoutedEventArgs e)
        {
           var result = await FocusAmisViewModel.EditAmi(nom.Text, prenom.Text, mail.Text);
            Mess.Content = result;

        }

        private async void OnClickDelete(object sender, RoutedEventArgs e)
        {
            await FocusAmisViewModel.DeleteAmi();
        }
    }
}
