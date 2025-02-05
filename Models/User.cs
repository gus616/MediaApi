namespace MediaApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Email { get; set; }

        public int Age { get; set; }

        public List<Album> Albums { get; set; } = new List<Album>();
    }
}
