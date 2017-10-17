namespace MovHubDb.Model
{
    public class CreditsItem
    {
        [HtmlAs("<td><a href=http://localhost:3000/person/{value}/movies>{value}</a></td>")]
        public int Id { get; set; }
        public string Character { get; set; }
        public string Name { get; set; }
    }
}