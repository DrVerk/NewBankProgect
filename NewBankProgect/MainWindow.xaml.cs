using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Windows;

namespace NewBankProgect
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Model1Container model1;
        public MainWindow()
        {
            InitializeComponent();

            model1 = new Model1Container();

            PeopleDataTeble.DataContext = model1.UserTable.Local.ToBindingList();
        }
        /// <summary>
        /// Загрузка счутов акаунта
        /// </summary>
        private void Uctive(object sender, RoutedEventArgs e)
        {
            ShetWiuvWindow shetWiuv = new ShetWiuvWindow((UserTable)PeopleDataTeble.SelectedItem, model1);
            shetWiuv.Show();

        }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        private void Hersing(object sender, RoutedEventArgs e)
        {
            NewAccaunt newAccaunt = new NewAccaunt(model1);
            newAccaunt.ShowDialog();

        }
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        private void Remuve(object sender, RoutedEventArgs e)
        {
            if (PeopleDataTeble.SelectedItem != null)
            {
                try
                {
                    model1.UserTable.Remove((UserTable)PeopleDataTeble.SelectedItem);
                }
                catch (Exception ee) { MessageBox.Show(ee.Message); }
            }

        }
    }
}
