namespace MovHubDb.Model
{
    public class MovieSearchItem
    {
        [HtmlAs("<td><a href=http://localhost:3000/movies/{value}>{value}</a></td>")]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Release_Date { get; set; }
        public double Popularity { get; set; }
        public float Vote_Average { get; set; }
    }
}