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
    /// Logique d'interaction pour AddAmi.xaml
    /// </summary>
    public partial class AddAmi : Page
    {
        private AddAmiViewModel AddAmiViewModel;
        public AddAmi()
        {
            InitializeComponent();
            Mess.Content = "";
        }
        public new void IsLoaded(object sender, RoutedEventArgs e)
        {
            AddAmiViewModel = DataContext as AddAmiViewModel;
        }
        private async void OnClickButton(object sender, RoutedEventArgs e)
        {
            string Message = await AddAmiViewModel.SetAmi(nom.Text, prenom.Text, mail.Text);
            Mess.Content = Message;
        }
    }
}
