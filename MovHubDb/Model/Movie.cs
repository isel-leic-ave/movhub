namespace MovHubDb.Model
{
    public struct Movie
    {
        [HtmlIgnore]
        public int Id { get; set; }
        public string Original_Title { get; set; }
        public string Tagline { get; set; }
        [HtmlAs("\t<li class='list-group-item'><a href = '/movies/{value}/credits' > Cast</a></li>")]
        public string Credits { get { return Id.ToString(); } }
        public int Budget { get; set; }
        public float Vote_Average { get; set; }
        [HtmlAs("\t<div style=\"position:absolute; top:0; right:0;\"><img width=\"75%\" src=\"http://image.tmdb.org/t/p/w185/{value}\"></div>")]
        public string Poster_Path { get; set; }
        public double Popularity { get; set; }
        public string Release_Date { get; set; }
        [HtmlAs("\t<div class='card-body bg-light'><div><strong>{name}</strong>:</div>{value}</div>")]
        public string Overview { get; set; }
       
    }
}