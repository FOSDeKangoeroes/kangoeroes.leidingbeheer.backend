namespace kangoeroes.core.Models.Poef
{
    public class Drank
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string ImageUrl { get; set; }
        public bool InStock { get; set; }
        public DrankType Type { get; set; }
    }
}