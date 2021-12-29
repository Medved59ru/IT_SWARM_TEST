using System.ComponentModel.DataAnnotations;

namespace CSVParserCore.Enteties
{
    public class Sex
    {
        public int Id { get; set; }

        [Display(Name = "Пол")]
        public string? Name { get; set; }
    }
}
