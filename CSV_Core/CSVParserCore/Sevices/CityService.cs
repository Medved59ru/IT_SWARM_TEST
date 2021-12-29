using CSVParserCore.Dtos;
using CSVParserCore.Enteties;

namespace CSVParserCore.Sevices
{
    public class CityService
    {
        private readonly ApplicationContext _context;

        public CityService(ApplicationContext context)
        {
            _context = context;
        }

        public void AddCityAsync(Dto dto)
        {
            City city = new City() { Name = dto.City };
            //добавить проверку уникальности

            try
            {
                _context.Cities.AddAsync(city);
                _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
