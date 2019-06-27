using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Videotheque.Model;
using Videotheque.Service;

namespace Videotheque.ViewModel
{
    class FilmsViewModel : AbstractModel
    {
        public MainViewModel ViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }
        public ObservableCollection<String> ListBoxFilms { get { return GetValue<ObservableCollection<String>>(); } set { SetValue<ObservableCollection<String>>(value); } }

        private FilmService FilmService;
        private List<Film> Films;


        public FilmsViewModel(MainViewModel _ViewModel)
        {
            ViewModel = _ViewModel;
            FilmService = new FilmService();
            ListBoxFilms = new ObservableCollection<string>();
        }

        public async void InitData()
        {
            await RefreshListfilmAsync();
            ShowFilm();

        }

        public async Task RefreshListfilmAsync()
        {
            Films = await FilmService.GetAllFilm();
        }

        public async void ShowFilm(int _order = 1)
        {
            await RefreshListfilmAsync();
            switch (_order)
            {
                case 1:
                    Films = Films.OrderBy(n => n.Titre).ToList();
                    break;
                case 2:
                    Films = Films.OrderByDescending(n => n.Titre).ToList();
                    break;
                default:
                    throw new System.ArgumentException("Ordre non définis");
            }
            ListBoxFilms.Clear();
            foreach (Film film in Films)
            {
                ListBoxFilms.Add(film.Titre);
            }
        }



    }

}
