using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class NewAccaunt : Window
    {

        public NewAccaunt()
        {
            InitializeComponent();
        }
        public NewAccaunt(System.Data.DataRow dataRow) : this()
        {
            Output.Click += delegate { DialogResult = false; };
            Input.Click += delegate
            {
                dataRow[0] = NameAccaunt.Text;
                DialogResult = !false;
            };
        }
    }
}
