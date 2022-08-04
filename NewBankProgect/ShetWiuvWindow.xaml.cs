using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NewBankProgect
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class ShetWiuvWindow : Window
    {
        public ShetWiuvWindow() => InitializeComponent();
        public ShetWiuvWindow(DataRowView row) : this()
        {
            #region иницилизация
            var conect = new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "BankSistemBD"
            };
            var sqlConect = new SqlConnection(conect.ConnectionString);
            var table = new DataTable();
            var sqlAdapter = new SqlDataAdapter();
            #endregion
            string str = Convert.ToString(row[1]);
            var comand = @"Select Accaunt.Money as 'Деньги',
Accaunt.Stavka as 'ставка',
Accaunt.Deposite as 'депозит'
from Accaunt WHERE Accaunt.AccauntNumber = "+str;
            
            sqlAdapter.SelectCommand = new SqlCommand(comand, sqlConect);
            sqlAdapter.Fill(table);

            ShetWiuwer.DataContext = table.DefaultView;
        }

        private void create(object sender, RoutedEventArgs e)
        {
            NewShet newShet = new NewShet();
            newShet.ShowDialog();
        }

        private void Remuve(object sender, RoutedEventArgs e)
        {

        }
    }
}
