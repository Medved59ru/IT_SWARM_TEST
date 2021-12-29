using CSVParserCore.Dtos;
using CSVParserCore.Enteties;

namespace CSVParserCore.Sevices
{
    public class CategoryService
    {
        private readonly ApplicationContext _context;

        public CategoryService(ApplicationContext context)
        {
            _context = context;
        }

        public void AddCategoryAsync(Dto dto)
        {
            Category category = new Category() { Name = dto.Category };

            //добавить проверку уникальности
            try
            {
                _context.Categories.AddAsync(category);
                _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
    }
}
