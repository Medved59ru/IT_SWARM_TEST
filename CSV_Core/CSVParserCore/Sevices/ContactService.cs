using CSVParserCore.Dtos;
using CSVParserCore.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParserCore.Sevices
{
    public class ContactService
    {
        private readonly ApplicationContext _context;

        public ContactService(ApplicationContext context)
        {
            _context = context;
        }

        public void AddContactAsync(Dto dto)
        {
            //добавить проверку уникальности
            Contact contact = new Contact()
            {
                Number = dto.Number,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                MidName = dto.MidName,
                BirthDay = dto.BirthDay,
                SexId = _context.Sexes.First(s => s.Name == dto.Sex).Id,
                CategoryId = _context.Categories.First(cat => cat.Name == dto.Category).Id,
                CityId = _context.Cities.First(city => city.Name == dto.City).Id,
                ListInfoId = _context.ListInfos.First(list => list.SourceName == dto.SourceName).Id

            };
            try
            {
                _context.Contacts.AddAsync(contact);
                _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<Contact> GetAllContact()
        {
            return _context.Contacts.ToList();
        }
        public string GetCategoryBy(int id) => _context.Categories.First(cat=>cat.Id == id).Name;
        public string GetSexBy(int id) => _context.Sexes.First(s=>s.Id == id).Name;
        public string GetCityBy(int id) => _context.Cities.First(c => c.Id == id).Name;
        public string GetSourceNameBy(int id) => _context.ListInfos.First(l=>l.Id == id).SourceName;
        public string GetCommentsBy(int id) => _context.ListInfos.First(l => l.Id == id).Comments;
        public DateTime GetCreationDateBy(int id) => _context.ListInfos.First(l => l.Id == id).CreationDay;



    }
}
