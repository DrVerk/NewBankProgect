using System;
using System.Windows;

namespace NewBankProgect
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class NewShet : Window
    {
        public bool v=false;
        public NewShet()
        {
            InitializeComponent();
        }
        public NewShet(Model1Container model, int str) : this()
        {
            Dispose.Click += delegate { DialogResult = false; };
            Create.Click += delegate
            {
                if (v)
                    model.KreditSet.Add(
                        new Kredit(str,
                        Convert.ToInt32(Money.Text),
                        Convert.ToInt32(Deposite.Text)));
                else
                    model.AccauntSet.Add(
                        new Accaunt(str,
                        Convert.ToInt32(Money.Text),
                        Convert.ToInt32(Stavka.Text)));
                DialogResult = !false;
            };
            Raiter.Click += delegate
            {
                v ^= true;
                if (v) { Deposite.Visibility = Visibility.Visible; Stavka.Visibility = Visibility.Hidden; }
                else { Deposite.Visibility = Visibility.Hidden; Stavka.Visibility = Visibility.Visible; }
            };
        }
    }
}
