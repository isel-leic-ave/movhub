using MovHubDb.Model;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MovHubDb
{
    public class TheMovieDbClient
    {
        private readonly string key = "?api_key=6f19e21bc3e2952f8d1c4d7e139695fd";
        private readonly string uri = "https://api.themoviedb.org/3";
        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/search/movie?api_key=*****&query=war%20games
        /// </summary>
        public MovieSearchItem[] Search(string title, int page)
        {
            WebClient client = new WebClient();
            title.Replace(" ","%20");
            string body = client.DownloadString(uri + "/search/movie" + key +"&query="+title+"&page="+page);
            MovieSearch result = (MovieSearch)JsonConvert.DeserializeObject(body, typeof(MovieSearch));
            return result.Results;
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/movie/508?api_key=*****
        /// </summary>
        public Movie MovieDetails(int id) {
            WebClient client =new WebClient();
            string body = client.DownloadString(uri + "/movie/"+id+key);
            return (Movie) JsonConvert.DeserializeObject(body, typeof(Movie));
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/movie/508/credits?api_key=*****
        /// </summary>
        public CreditsItem[] MovieCredits(int id) {
            WebClient client = new WebClient();
            string body = client.DownloadString(uri + "/movie/" + id + "/credits" + key);
            Credits r = (Credits)JsonConvert.DeserializeObject(body, typeof(Credits));
            return r.Cast;
            
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/person/3489?api_key=*****
        /// </summary>
        public Person PersonDetais(int actorId)
        {
            WebClient client = new WebClient();
            string body = client.DownloadString(uri + "/person/" + actorId + key);
            return (Person) JsonConvert.DeserializeObject(body, typeof(Person));
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/person/3489/movie_credits?api_key=*****
        /// </summary>
        public MovieSearchItem[] PersonMovies(int actorId) {
            WebClient client = new WebClient();
            string body = client.DownloadString(uri + "/person/" + actorId + "/movie_credits" + key);
            PersonCredits r = (PersonCredits) JsonConvert.DeserializeObject(body, typeof(PersonCredits));
            return r.Cast;
        }
    }
}
