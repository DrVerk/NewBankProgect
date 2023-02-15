using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewBankProgect.Logic
{
    internal class MainWindowController
    {
        IViewMainWindow _viewMainWindow;
        readonly Model1Container model1;
        public MainWindowController(IViewMainWindow viewMainWindow)
        {
            _viewMainWindow = viewMainWindow;
            model1 = new Model1Container();

            viewMainWindow.grid.DataContext = model1.UserTable.Local.ToBindingList();
        }
        /// <summary>
        /// Загрузка счутов акаунта
        /// </summary>
       public void Uctive()
        {
            ShetWiuvWindow shetWiuv = new ShetWiuvWindow((UserTable)_viewMainWindow.grid.SelectedItem, model1);
            shetWiuv.Show();

        }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        public void Hersing()
        {
            NewAccaunt newAccaunt = new NewAccaunt(model1);
            newAccaunt.ShowDialog();

        }
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        public void Remuve()
        {
            if (_viewMainWindow.grid.SelectedItem != null)
            {
                try
                {
                    model1.UserTable.Remove((UserTable)_viewMainWindow.grid.SelectedItem);
                }
                catch (Exception ee) { MessageBox.Show(ee.Message); }
            }

        }
    }
}
