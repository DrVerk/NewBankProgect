using System;
using System.Windows;

namespace NewBankProgect
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class NewAccaunt : Window
    {
        public int rand;
        Random random = new Random();
        public NewAccaunt()
        {
            InitializeComponent();
        }
        public NewAccaunt(System.Data.DataRow dataRow) : this()
        {
            Output.Click += delegate { DialogResult = false; };
            Input.Click += delegate
            {
                rand = random.Next(10000000, 100000000);
                dataRow[0] = NameAccaunt.Text;
                dataRow[1] = rand;
                DialogResult = !false;
            };
        }
    }
}
