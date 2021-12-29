using System.ComponentModel.DataAnnotations;

namespace CSVParserCore.Enteties
{
    public class ListInfo
    {
        public int Id { get; set; }

        [Display(Name = "Файл загрузки")]
        public string? SourceName { get; set; }

        [Display(Name = "Дата загрузки")]
        public DateTime CreationDay { get; set; }

        [Display(Name = "Комментарии")]
        public string? Comments { get; set; }
    }
}
