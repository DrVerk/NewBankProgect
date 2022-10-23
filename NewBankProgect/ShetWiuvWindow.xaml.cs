using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace NewBankProgect
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class ShetWiuvWindow : Window
    {
        readonly Model1Container model1;
        readonly int str;
        public ShetWiuvWindow() => InitializeComponent();
        public ShetWiuvWindow(UserTable userTable, Model1Container model) : this()
        {
            model1 = model;
            str = Convert.ToInt32(userTable.Useraccauntid);
            Title = "Счета открытые пользователем "+userTable.Username;
            ShetWiuwer.DataContext = model1.AccauntSet.Local.ToBindingList().Where(e => e.AccauntNumber == str);
            KreditWiuwer.DataContext = model1.KreditSet.Local.ToBindingList().Where(e => e.AccauntNumber == str);
        }
        /// <summary>
        /// Создать счет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Create(object sender, RoutedEventArgs e)
        {
            NewShet newShet = new NewShet(model1, str);
            newShet.ShowDialog();
            ShetWiuwer.DataContext = model1.AccauntSet.Local.ToBindingList().Where(ex => ex.AccauntNumber == str);
            KreditWiuwer.DataContext = model1.KreditSet.Local.ToBindingList().Where(ex => ex.AccauntNumber == str);
        }
        /// <summary>
        /// Удалить счет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Remuve(object sender, RoutedEventArgs e)
        {
            if (ShetWiuwer.SelectedItem != null)
            {
                try
                {
                    model1.AccauntSet.Remove((Accaunt)ShetWiuwer.SelectedItem);
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }

        }
    }
}
