using IMDbSimulator.UI.Models;
using IMDbSimulator.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IMDbSimulator.UI.Commands;

namespace IMDbSimulator.UI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand SearchMovieCommand { get; set; }

        public MainViewModel()
        {
            SearchMovieCommand = Factory.GetRelayCommand(SearchMovies, CanSearchMovie);
        }

        private Movie _movie;

        public Movie Movie
        {
            get { return _movie; }
            set { _movie = value; OnPropertyChanged(nameof(Movie)); }
        }


        private Search _selectedSearchResult;

        public Search SelectedSearchResult
        {
            get { return _selectedSearchResult; }
            set
            { 
                _selectedSearchResult = value;
                OnPropertyChanged(nameof(SelectedSearchResult));
                GetMovieDetail(SelectedSearchResult?.ImdbID);
            }
        }

        private string _movieName;

        public string MovieName
        {
            get { return _movieName; }
            set { _movieName = value; OnPropertyChanged(nameof(MovieName)); }
        }

        private SearchMovie _searchMovie;

        public SearchMovie SearchMovie
        {
            get { return _searchMovie; }
            set { _searchMovie = value; OnPropertyChanged(nameof(SearchMovie)); }
        }

        private async void SearchMovies(object parameter)
        {
            SearchMovie = new SearchMovie();
            SearchMovie = await OmdbApiHelper.SearchMoviesAsync(MovieName);
        }

        private bool CanSearchMovie(object parameter)
        {
            return !string.IsNullOrEmpty(MovieName);
        }

        private async void GetMovieDetail(string imdbID)
        {
            Movie = new Movie();
            Movie = await OmdbApiHelper.GetMovieAsync(imdbID);
        }

    }
}
