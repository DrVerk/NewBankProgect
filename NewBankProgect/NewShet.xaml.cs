using System.Windows;

namespace NewBankProgect
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class NewShet : Window
    {
        bool v;
        public NewShet()
        {
            InitializeComponent();
        }
        public NewShet(System.Data.DataRow dataRow) : this()
        {
            Dispose.Click += delegate { DialogResult = false; };
            Create.Click += delegate
            {
                dataRow["Money"] = Money.Text;
                dataRow["Kredit"] = v ? 1 : 0;
                dataRow["Stavka"] = Stavka.Text;
                dataRow["Deposite"] = Deposite.Text;
                DialogResult = !false;
            };
            Raiter.Click += delegate { v ^= true; };
        }
    }
}
