using Microsoft.SqlServer.Server;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewBankProgect
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlDataAdapter sqlAdapter;
        DataTable table;
        DataRowView row;
        public MainWindow()
        {
            InitializeComponent();

            #region иницилизация
            var conect = new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "BankSistemBD"
            };
            var sqlConect = new SqlConnection(conect.ConnectionString);
            table = new DataTable();
            sqlAdapter = new SqlDataAdapter();
            #endregion

            #region SELECT
            var comand = @"SELECT UserTable.Username AS 'Имя пользователя',
UserTable.Useraccauntid as 'Номер пользователя'
from UserTable";
            sqlAdapter.SelectCommand = new SqlCommand(comand, sqlConect);
            #endregion

            #region delete

            comand = "DELETE FROM UserTable WHERE Username = @Username";

            sqlAdapter.DeleteCommand = new SqlCommand(comand, sqlConect);
            sqlAdapter.DeleteCommand.Parameters.Add("@Username", SqlDbType.Char, 4, "Username");

            #endregion

            #region INSETR
            var com = @"INSERT INTO UserTable(Username) values (@Username); SET @Useraccauntid=ABS(CHECKSUM(NEWID()),@Id= @@IDENTITY;";
            sqlAdapter.InsertCommand = new SqlCommand(com, sqlConect);
            #endregion

            sqlAdapter.Fill(table);
            PeopleDataTeble.DataContext = table.DefaultView;
        }
        private void Uctive(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)PeopleDataTeble.SelectedItem;
            ShetWiuvWindow shetWiuv = new ShetWiuvWindow(row);
            shetWiuv.Show();
            
        }
        private void Hersing(object sender, RoutedEventArgs e)
        {
            DataRow r = table.NewRow();
            NewAccaunt newAccaunt = new NewAccaunt(r);
            newAccaunt.ShowDialog();
            if (newAccaunt.DialogResult.Value)
            {
                table.Rows.Add(r);
                sqlAdapter.Update(table);
            }
        }
        private void Remuve(object sender, RoutedEventArgs e)
        {
            row = (DataRowView)PeopleDataTeble.SelectedItem;
            row.Row.Delete();
            try
            {
                sqlAdapter.Update(table);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }
    }
}
