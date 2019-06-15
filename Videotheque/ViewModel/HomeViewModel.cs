using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;

namespace Videotheque.ViewModel
{
    class HomeViewModel : AbstractModel
    {
        public MainViewModel ViewModel { get { return GetValue<MainViewModel>(); } set { SetValue<MainViewModel>(value); } }
        public SeriesCollection MediaParGenre { get { return GetValue<SeriesCollection>(); } set { SetValue<SeriesCollection>(value); } }
        public SeriesCollection MediaParNote { get { return GetValue<SeriesCollection>(); } set { SetValue<SeriesCollection>(value); } }

        public String NbMedia { get { return GetValue<String>(); } set { SetValue<String>(value); } }
      
        public HomeViewModel(MainViewModel _viewModel)
        {
            ViewModel = _viewModel;
        }

        public void InitData()
        {
            NbMedia = "22 Films / Séries enregistrés";
            MediaParGenre = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Chrome",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(8) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Mozilla",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(6) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Opera",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(10) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Explorer",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(4) },
                    DataLabels = true
                }
            };

            MediaParNote = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "5*",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(8) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "4*",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(6) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "3*",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(10) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "2*",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(4) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "1*",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(4) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "0*",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(0) },
                    DataLabels = true
                }
            };

            //adding values or series will update and animate the chart automatically
            //SeriesCollection.Add(new PieSeries());
            //SeriesCollection[0].Values.Add(5);
        }
    }
}
