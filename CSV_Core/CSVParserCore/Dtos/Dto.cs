using System.ComponentModel.DataAnnotations;

namespace CSVParserCore.Dtos
{
    public class Dto
    {
        [Display(Name = "Телефон")]
        public string? Number { get; set; }
        [Display(Name = "Фамилия")]
        public string? LastName { get; set; }
        [Display(Name = "Имя")]
        public string? FirstName { get; set; }
        [Display(Name = "Отчество")]
        public string? MidName { get; set; }
        [Display(Name = "Категория контакта")]
        public string? Category { get; set; }
        [Display(Name = "Пол")]
        public string? Sex { get; set; }
        [Display(Name = "Город")]
        public string? City { get; set; }
        [Display(Name = "Дата рождения")]
        public string? BirthDay { get; set; }
        [Display(Name = "Файл загрузки")]
        public string? SourceName { get; set; }
        [Display(Name = "Дата загрузки")]
        public DateTime CreationDay { get; set; }
        [Display(Name = "Комментарии")]
        public string? Comments { get; set; }

    }
}
