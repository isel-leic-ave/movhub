using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovHubDb;
using HtmlReflect;
using MovHubDb.Model;

namespace HtmlReflectTest
{
    [TestClass]
    public class HtmlectTest
    {
        [TestMethod]
        public void ToHtmlArrayTest()
        {
            Htmlect s = new Htmlect();
            string r =s.ToHtml(a.MovieDetails(1018));
            Console.WriteLine(r);
        }

        [TestMethod]
        public void TestSearch()
        {
            
            MovieSearchItem[] B =a.Search("Deadpool", 1);
            foreach (var item in B)
            {
                Console.WriteLine(item.Id);
            }
        }
        TheMovieDbClient a = new TheMovieDbClient();
        [TestMethod]
        public void MovieDetails()
        {
            
            a.MovieDetails(508);
        }
        [TestMethod]
        public void MovieCredits()
        {
            a.MovieCredits(1018);
        }
        [TestMethod]
        public void PersonCredits()
        {
            a.PersonDetais(15008);

        }
        [TestMethod]
        public void PersonMovies()
        {
            a.PersonMovies(15008);
        }
    }
}
