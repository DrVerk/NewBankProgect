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
        readonly Random random = new Random();
        public NewAccaunt()
        {
            InitializeComponent();
        }
        public NewAccaunt(Model1Container model1) : this()
        {
            Output.Click += delegate { DialogResult = false; };
            Input.Click += delegate
            {
                rand = random.Next(10000000, 100000000);
                model1.UserTable.Add(new UserTable(NameAccaunt.Text, rand));
                DialogResult = !false;

            };

        }
    }
}
