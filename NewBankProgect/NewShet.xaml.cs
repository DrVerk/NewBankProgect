using System.Windows;

namespace NewBankProgect
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class NewShet : Window
    {
        public bool v;
        public NewShet()
        {
            InitializeComponent();
        }
        public NewShet(System.Data.DataRow dataRow, string str) : this()
        {
            Dispose.Click += delegate { DialogResult = false; };
            Create.Click += delegate
            {
                dataRow[0] = Money.Text;
                dataRow[1] = Stavka.Text;
                dataRow[2] = Deposite.Text;
                DialogResult = !false;
            };
            Raiter.Click += delegate { v ^= true; };
        }
    }
}
