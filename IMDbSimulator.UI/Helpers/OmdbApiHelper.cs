using IMDbSimulator.UI.Models;
using Newtonsoft.Json;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IMDbSimulator.UI.Helpers
{
    public class OmdbApiHelper
    {
        private static readonly string API_KEY = ConfigurationManager.AppSettings["ApiKey"];
        private const string BASE_URL = "http://www.omdbapi.com/";
        private const string SEARCH_ENDPOINT = "?s={0}&apikey={1}";
        private const string MOVIE_ENDPOINT = "?i={0}&apikey={1}";

        public static async Task<SearchMovie> SearchMoviesAsync(string query)
        {
            string url = BASE_URL + string.Format(SEARCH_ENDPOINT, query.Replace(" ","+"), API_KEY);
            using HttpClient client = new();
            try
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                SearchMovie searchMovie = JsonConvert.DeserializeObject<SearchMovie>(json);
                return searchMovie;
            }
            catch (HttpRequestException e)
            {

                throw new HttpRequestException(e.Message);
            }
        }


        public static async Task<Movie> GetMovieAsync(string imdbID)
        {
            string url = BASE_URL + string.Format(MOVIE_ENDPOINT, imdbID, API_KEY);
            using HttpClient client = new();
            try
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                Movie movie = JsonConvert.DeserializeObject<Movie>(json);
                return movie;
            }
            catch (HttpRequestException e)
            {

                throw new HttpRequestException(e.Message);
            }
        }
    }
}
