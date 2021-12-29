using System.ComponentModel.DataAnnotations;

namespace CSVParserCore.Enteties
{
    public class City
    {
        public int Id { get; set; }
        [Display(Name = "Город")]
        public string? Name { get; set; }
    }
}
