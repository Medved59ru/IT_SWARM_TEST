using CSVParserCore.Dtos;
using CSVParserCore.Enteties;

namespace CSVParserCore.Sevices
{
    public class SexService
    {
        private readonly ApplicationContext _context;

        public SexService(ApplicationContext context)
        {
            _context = context;
        }

        public void AddSexAsync(Dto dto)
        {
            Sex sex = new Sex() { Name = dto.Sex };
            //добавить проверку уникальности
            try
            {
                _context.AddAsync(sex);
                _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

    }
}
