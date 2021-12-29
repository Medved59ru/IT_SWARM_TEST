using System.ComponentModel.DataAnnotations;

namespace CSVParserCore.Enteties
{
    public class Contact
    {
        public int Id { get; set; }

        [Display(Name = "Телефон")]
        public string? Number { get; set; }
        [Display(Name = "Фамилия")]
        public string? LastName { get; set; }
        [Display(Name = "Имя")]
        public string? FirstName { get; set; }
        [Display(Name = "Отчество")]
        public string? MidName { get; set; }

        [Display(Name = "Категория контакта")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Display(Name = "Пол")]
        public int SexId { get; set; }
        public Sex? Sex { get; set; }

        [Display(Name = "Город")]
        public int CityId { get; set; }
        public City? City { get; set; }

        [Display(Name = "Дата рождения")]
        public string? BirthDay { get; set; }

        public int ListInfoId { get; set; }
        public ListInfo? ListInfo { get; set; }

       
    }
}
