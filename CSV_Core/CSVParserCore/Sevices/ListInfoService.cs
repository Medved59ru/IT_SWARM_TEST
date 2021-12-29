using CSVParserCore.Dtos;
using CSVParserCore.Enteties;

namespace CSVParserCore.Sevices
{
    public class ListInfoService
    {
        private readonly ApplicationContext _context;

        public ListInfoService(ApplicationContext context)
        {
            _context = context;
        }

        public void AddListInfoAsync(Dto dto)
        {
            ListInfo listInfo = new ListInfo()
            {
                SourceName = dto.SourceName,
                Comments = dto.Comments,
                CreationDay = dto.CreationDay
            };

            // добавить проверку друих полей на уникальность

            try
            {
                _context.AddAsync(listInfo);
                _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

    }
}
