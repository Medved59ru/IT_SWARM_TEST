using CSVParserCore.Dtos;
using CSVParserCore.Sevices;


namespace CSVParserCore
{
    public partial class MainForm : Form
    {
        private CategoryService _categoryService;
        private CityService _cityService;
        private ContactService _contactService;
        private ListInfoService _listInfoService;
        private SexService _sexService;
        private List<Dto>? listDto = null;


        public MainForm()
        {           
            InitializeComponent();
           
        }
        private void commentTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            commentTextBox.Text = "";
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (commentTextBox.ForeColor != Color.Blue)
            {
                commentTextBox.Text = "";
            }
           
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Файлы (*.CSV)| *.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                
                listDto = FileParser.GetFieldsBy(ofd.FileName, ofd.SafeFileName, commentTextBox.Text);

            }
            dtoBindingSource.DataSource = listDto;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           using (ApplicationContext context = new ApplicationContext())
           {
                if(listDto == null)
                {
                    MessageBox.Show("Выберите файл для сохранения");
                }
                else
                {
                    DataDBHandler dataToBase = new DataDBHandler(context);
                    dataToBase.FillTeData(listDto);
                    MessageBox.Show("Данные в базу сохранены");
                }
                                           
           }
          
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            using(ApplicationContext context = new ApplicationContext())
            {
                DataDBHandler dBHandler = new DataDBHandler(context);
                listDto = dBHandler.GetDataFromDB();
            }
            dtoBindingSource.DataSource = listDto;
            listDto = null;
        }

        private void commentTextBox_TextChanged(object sender, EventArgs e)
        {
            commentTextBox.ForeColor = Color.Blue;
        }
    }


}