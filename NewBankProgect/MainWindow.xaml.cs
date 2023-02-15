using NewBankProgect.Logic;
using System;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;

namespace NewBankProgect
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,IViewMainWindow
    {
        MainWindowController controller;

        public DataGrid grid { get => PeopleDataTeble; set => PeopleDataTeble=value; }

        public MainWindow()
        {
            InitializeComponent();
            controller= new MainWindowController(this);

            Uctive.Click += (e,s)=>controller.Uctive();
            Hersing.Click += (e, s) => controller.Hersing();
            Remuve.Click += (e, s) => controller.Remuve();
        }
       
    }
}
