using System.Windows;

namespace NewBankProgect
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class NewAccaunt : Window
    {

        public NewAccaunt()
        {
            InitializeComponent();
        }
        public NewAccaunt(System.Data.DataRow dataRow) : this()
        {
            Output.Click += delegate { DialogResult = false; };
            Input.Click += delegate
            {
                dataRow[0] = NameAccaunt.Text;
                DialogResult = !false;
            };
        }
    }
}
