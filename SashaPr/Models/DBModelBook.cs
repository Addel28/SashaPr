namespace SashaPr.Models
{
    public class DBModelBook
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string YearOfPub { get; set; }
        public byte[] Picture { get; set; }
    }
}
