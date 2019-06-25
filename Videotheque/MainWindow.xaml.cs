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
using Videotheque.View;
using Videotheque.ViewModel;
using Videotheque.Service;
using Videotheque.DataAccess;

namespace Videotheque
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel view;


        public BooksDbContext context;

        public MainWindow()
        {
            InitializeComponent();
            view = new MainViewModel();
            view.Source = NavigationServices.GetPage<Home, HomeViewModel>(view);
            this.DataContext = view;



        }
        
        public void OnClickHome(object send, RoutedEventArgs e)
        {
            view.Source = NavigationServices.GetPage<Home, HomeViewModel>(view);
        }
        public void OnClickFilm(object sender, RoutedEventArgs e)
        {
            view.Source = NavigationServices.GetPage<Films, FilmsViewModel>(view);
        }
        public void OnClickSerie(object sender, RoutedEventArgs e)
        {
            view.Source = NavigationServices.GetPage<Series, SeriesViewModel>(view);
        }
        public void OnClickAdmin(object sender, RoutedEventArgs e)
        {
            view.Source = NavigationServices.GetPage<Administration, AdminViewModel>(view);
        }

    }
}
