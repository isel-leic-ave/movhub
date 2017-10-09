namespace MovHubDb.Model
{
    public class Person
    {
        [HtmlIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public string Deathday { get; set; }
        public string Biography { get; set; }
        [HtmlAs("\t<div style=\"position:absolute; top:0; right:0;\"><img width=\"50%\" src=\"http://image.tmdb.org/t/p/w185/{value}\"></div>")]
        public string Profile_Path { get; set; }
        public double Popularity { get; set; }
        public string Place_Of_Birth { get; set; }
        
    }
}
