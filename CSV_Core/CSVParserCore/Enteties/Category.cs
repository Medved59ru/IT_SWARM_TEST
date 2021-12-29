using System.ComponentModel.DataAnnotations;

namespace CSVParserCore.Enteties
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Категория контакта")]
        public string? Name { get; set; }
    }
}
