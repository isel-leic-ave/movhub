using MovHubDb.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace MovHubDb
{
    public class TheMovieDbClient
    {
        private readonly string key = "?api_key=6f19e21bc3e2952f8d1c4d7e139695fd";
        private readonly string uri = "https://api.themoviedb.org/3";
        private Dictionary<string, object> cache = new Dictionary<string, object>();
        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/search/movie?api_key=*****&query=war%20games
        /// </summary>
        public MovieSearchItem[] Search(string title, int page)
        {
            if (cache.ContainsKey("search"+title + page))
            {
                return ((MovieSearch) cache["search"+title + page]).Results;
            }
            WebClient client = new WebClient();
            title.Replace(" ","%20");
            string body = client.DownloadString(uri + "/search/movie" + key +"&query="+title+"&page="+page);
            MovieSearch result = (MovieSearch)JsonConvert.DeserializeObject(body, typeof(MovieSearch));
            cache.Add("search"+title+page,result);
            return result.Results;
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/movie/508?api_key=*****
        /// </summary>
        public Movie MovieDetails(int id) {
            if (cache.ContainsKey("movie"+id))
            {
                return (Movie) cache["movie" + id];
            }
            WebClient client =new WebClient();
            string body = client.DownloadString(uri + "/movie/"+id+key);
            cache.Add("movie"+id, (Movie)JsonConvert.DeserializeObject(body, typeof(Movie)));
            return (Movie)cache["movie"+id];
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/movie/508/credits?api_key=*****
        /// </summary>
        public CreditsItem[] MovieCredits(int id) {
            if (cache.ContainsKey("cast" + id))
            {
                return ((Credits) cache["cast" + id]).Cast;
            }
            WebClient client = new WebClient();
            string body = client.DownloadString(uri + "/movie/" + id + "/credits" + key);
            Credits r = (Credits)JsonConvert.DeserializeObject(body, typeof(Credits));
            cache.Add("cast"+id,r);
            return r.Cast;
            
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/person/3489?api_key=*****
        /// </summary>
        public Person PersonDetais(int actorId)
        {
            if (cache.ContainsKey("actor" + actorId))
            {
                return (Person) cache["actor" + actorId];
            }
            WebClient client = new WebClient();
            string body = client.DownloadString(uri + "/person/" + actorId + key);
            Person p = (Person) JsonConvert.DeserializeObject(body, typeof(Person));
            cache.Add("actor"+actorId,p);
            return p;
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/person/3489/movie_credits?api_key=*****
        /// </summary>
        public MovieSearchItem[] PersonMovies(int actorId)
        {
            if (cache.ContainsKey("actormovies" + actorId))
                return ((PersonCredits) cache["actormovies" + actorId]).Cast;
            WebClient client = new WebClient();
            string body = client.DownloadString(uri + "/person/" + actorId + "/movie_credits" + key);
            PersonCredits r = (PersonCredits) JsonConvert.DeserializeObject(body, typeof(PersonCredits));
            cache.Add("actormovies"+actorId,r);
            return r.Cast;
        }
    }
}
