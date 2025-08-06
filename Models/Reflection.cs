namespace MyJournalApi.Models
{
    public class Reflection
    {
        public int Id { get; set; }
        public string Date { get; set; } = "";
        public string Mood { get; set; } = "";
        public string High { get; set; } = "";
        public string Low { get; set; } = "";
        public string Log { get; set; } = "";
        public DateTime CreatedAt { get; set; } // Set automatically in ApplicationDbContext
        public DateTime UpdatedAt { get; set; } // Set automatically in ApplicationDbContext
    }
}