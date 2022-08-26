using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace NewBankProgect
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class ShetWiuvWindow : Window
    {
        DataTable table;
        SqlDataAdapter sqlAdapter;
        string str;
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
            table = new DataTable();
            sqlAdapter = new SqlDataAdapter();
            #endregion

            str = Convert.ToString(row[1]);

            #region Select
            var comand = @"Select Accaunt.Money as 'Деньги',
Accaunt.Stavka as 'ставка',
Accaunt.Deposite as 'депозит'
from Accaunt WHERE Accaunt.AccauntNumber = " + str;

            sqlAdapter.SelectCommand = new SqlCommand(comand, sqlConect);
            #endregion

            #region Insert
            comand = "INSERT INTO Accaunt (Money,Kredit,Stavka,Deposite,AccauntNumber) values(@Money,@Kredit,@Stavka,@Deposite,@AccauntNumber)";
            sqlAdapter.InsertCommand = new SqlCommand(comand, sqlConect);
            #endregion
            sqlAdapter.Fill(table);
            ShetWiuwer.DataContext = table.DefaultView;
        }
        /// <summary>
        /// Создать счет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void create(object sender, RoutedEventArgs e)
        {
            DataRow dataRow = table.NewRow();
            NewShet newShet = new NewShet(dataRow, str);
            newShet.ShowDialog();
            if (newShet.DialogResult.Value)
            {
                table.Rows.Add(dataRow);
                sqlAdapter.InsertCommand.Parameters.AddWithValue("@Money", newShet.Money.Text);
                sqlAdapter.InsertCommand.Parameters.AddWithValue("@Kredit", newShet.v);
                sqlAdapter.InsertCommand.Parameters.AddWithValue("@Stavka", newShet.Stavka.Text);
                sqlAdapter.InsertCommand.Parameters.AddWithValue("@Deposite", newShet.Deposite.Text);
                sqlAdapter.InsertCommand.Parameters.AddWithValue("@AccauntNumber", str);
                sqlAdapter.Update(table);
            }
        }
        /// <summary>
        /// Удалить счет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Remuve(object sender, RoutedEventArgs e)
        {

        }
    }
}
