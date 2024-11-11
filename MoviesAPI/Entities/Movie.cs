namespace MoviesAPI.Entities
{
    public class Movie
    {
        public required int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public required int year { get; set; }
        public required double rate { get; set; }

    }
}