using System;
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
        public NewShet(Model1Container model, int str) : this()
        {
            Dispose.Click += delegate { DialogResult = false; };
            Create.Click += delegate
            {
                model.AccauntSet.Add(
                    new Accaunt(str, Convert.ToInt32(v),
                    Convert.ToInt32(Money.Text),
                    Convert.ToInt32(Stavka.Text),
                    Convert.ToInt32(Deposite.Text)));
                DialogResult = !false;
            };
            Raiter.Click += delegate { v ^= true; };
        }
    }
}
