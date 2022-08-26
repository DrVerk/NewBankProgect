using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

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
        Random random = new Random();
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
from UserTable ";
            sqlAdapter.SelectCommand = new SqlCommand(comand, sqlConect);
            #endregion

            #region delete
            comand = "DELETE FROM UserTable WHERE Username = @Username";

            sqlAdapter.DeleteCommand = new SqlCommand(comand, sqlConect);
            sqlAdapter.DeleteCommand.Parameters.Add("@Username", SqlDbType.NVarChar, 50, "Username");

            #endregion

            #region INSETR
            var com = @"INSERT INTO UserTable(Useraccauntid,Username) values (@Useraccauntid,@Username)";
            sqlAdapter.InsertCommand = new SqlCommand(com, sqlConect);
            #endregion
            #region UPDATE
            //comand = "UPDATE UserTable SET Username=@Username, Useraccauntid=@Useraccauntid WHERE Id=@id";
            //sqlAdapter.UpdateCommand = new SqlCommand(comand, sqlConect);
            //sqlAdapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 0, "Id").SourceVersion = DataRowVersion.Original;
            //sqlAdapter.UpdateCommand.Parameters.Add("@Username", SqlDbType.NVarChar, 50, "Username");
            //sqlAdapter.UpdateCommand.Parameters.Add("@Useraccauntid", SqlDbType.Int);
            #endregion
            sqlAdapter.Fill(table);
            PeopleDataTeble.DataContext = table.DefaultView;
        }
        /// <summary>
        /// Загрузка счутов акаунта
        /// </summary>
        private void Uctive(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)PeopleDataTeble.SelectedItem;
            ShetWiuvWindow shetWiuv = new ShetWiuvWindow(row);
            shetWiuv.Show();

        }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        private void Hersing(object sender, RoutedEventArgs e)
        {
            DataRow r = table.NewRow();
            NewAccaunt newAccaunt = new NewAccaunt(r);
            newAccaunt.ShowDialog();
            if (newAccaunt.DialogResult.Value)
            {
                table.Rows.Add(r);
                sqlAdapter.InsertCommand.Parameters.AddWithValue("@Username", newAccaunt.NameAccaunt.Text);
                sqlAdapter.InsertCommand.Parameters.AddWithValue("@Useraccauntid", newAccaunt.rand);
                sqlAdapter.Update(table);
            }
        }
        /// <summary>
        /// Удаление пользователя
        /// </summary>
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
