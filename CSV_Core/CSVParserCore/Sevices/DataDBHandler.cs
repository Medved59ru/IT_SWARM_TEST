using CSVParserCore.Dtos;
using CSVParserCore.Enteties;

namespace CSVParserCore.Sevices
{
    public class DataDBHandler
    {
        private CategoryService _categoryService;
        private CityService _cityService;
        private ContactService _contactService;
        private ListInfoService _listInfoService;
        private SexService _sexService;

        public DataDBHandler (ApplicationContext context)
        {
            _categoryService = new CategoryService (context);
            _cityService = new CityService (context);
            _sexService = new SexService (context);
            _listInfoService = new ListInfoService (context);
            _contactService = new ContactService (context);
        }
       
        public DataDBHandler(CategoryService categoryService, CityService cityService, ListInfoService listInfoService, SexService sexService, ContactService contactService)
        {
            _sexService = sexService;
            _categoryService = categoryService;
            _cityService = cityService;
            _listInfoService = listInfoService;
            _contactService = contactService;

        }

        public void FillTeData(List<Dto> dtos)
        {
            foreach (Dto dto in dtos)
            { //заполняем вспомогательные таблицы
                _sexService.AddSexAsync(dto);
                _cityService.AddCityAsync(dto);
                _categoryService.AddCategoryAsync(dto);
                _listInfoService.AddListInfoAsync(dto);
            }

            foreach (Dto dto in dtos)
            {
                //заполняем таблицу контакты
                _contactService.AddContactAsync(dto);

            }

        }

        public List<Dto> GetDataFromDB()
        {
            List<Dto> list = new List<Dto>();
            var contactList = _contactService.GetAllContact();

            foreach (var contact in contactList)
            {
                Dto localDto = new Dto();
                localDto.Number = contact.Number;
                localDto.LastName = contact.LastName;
                localDto.FirstName = contact.FirstName;
                localDto.MidName = contact.MidName;
                localDto.Category = _contactService.GetCategoryBy(contact.CategoryId);
                localDto.Sex = _contactService.GetSexBy(contact.SexId);
                localDto.City = _contactService.GetCityBy(contact.CityId);
                localDto.BirthDay = contact.BirthDay;
                localDto.SourceName = _contactService.GetSourceNameBy(contact.Id);
                localDto.CreationDay = _contactService.GetCreationDateBy(contact.Id);
                localDto.Comments = _contactService.GetCommentsBy(contact.Id);

                list.Add(localDto);
            }

            return list;
        }

      
    }
}
