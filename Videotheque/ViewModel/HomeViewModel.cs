using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;
using Videotheque.Service;

namespace Videotheque.ViewModel
{
    class HomeViewModel : AbstractModel
    {
        public MainViewModel ViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }
        public SeriesCollection MediaParGenre { get { return GetValue<SeriesCollection>(); } set { SetValue<SeriesCollection>(value); } }
        public SeriesCollection MediaParNote { get { return GetValue<SeriesCollection>(); } set { SetValue<SeriesCollection>(value); } }

        public String NbMedia { get { return GetValue<String>(); } set { SetValue<String>(value); } }

        private FilmService FilmService;
        private GenreService GenreService;

        private List<Genre> Genres;

        public HomeViewModel(MainViewModel _viewModel)
        {
            ViewModel = _viewModel;

            FilmService = new FilmService();
            GenreService = new GenreService();
            Genres = new List<Genre>();
        }

        public async Task InitData()
        {
       
            List<int> NombresMediaPerGenre = await CountFilmPerGenre();
            List<int> NombresMediaPerNote = await CountFilmPerGenre();

            var nbFilm = await CountFilm();
            NbMedia = nbFilm+ " Films / Séries Enregistrés";

            MediaParGenre = new SeriesCollection();
            MediaParNote = new SeriesCollection();

            for (int i = 0; i < NombresMediaPerGenre.Count(); i++)
            {
                PieSeries Pie = new PieSeries
                {
                    Title = Genres[i].Nom,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(NombresMediaPerGenre[i]) },
                    DataLabels = true
                };
                MediaParGenre.Add(Pie);
            }

            NombresMediaPerNote = await CountFilmPerNote();

            for(int i = 0; i < NombresMediaPerNote.Count(); i++)
            {
                PieSeries Pie = new PieSeries
                {
                    Title = i + "*",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(NombresMediaPerNote[i]) },
                    DataLabels = true
                };
                MediaParNote.Add(Pie);

            };
            
            //adding values or series will update and animate the chart automatically
            //SeriesCollection.Add(new PieSeries());
            //SeriesCollection[0].Values.Add(5);
        }
        public async Task<int> CountFilm()
        {
            var listFilms = await FilmService.GetAllFilm();

            return listFilms.Count();
        }

        public async Task<List<int>> CountFilmPerNote()
        {
            var listFilms = await FilmService.GetAllFilm();
            List<int> NombresMedia = new List<int>();

            for (int i = 0; i < 6; i++)
            {
                NombresMedia.Add(0);
            }
            
            foreach (Film film in listFilms)
            {
                NombresMedia[film.Note]++;
            }

            return NombresMedia;

        }

        public async Task<List<int>> CountFilmPerGenre()
        {

            //Récup tous les genres
            Genres = await GenreService.GetAllGenre();


            List<int> NombresMedia = new List<int>();


            //Parcours tous les genres
            foreach (Genre genre in Genres)
            {
                //Recup les films par genre
                var films = await FilmService.GetAllFilmByGenre(genre.Id);

                // Ajoutes dans le tableau la valeur
                NombresMedia.Add(films.Count());

            }
            return NombresMedia;
        }
    }
}
