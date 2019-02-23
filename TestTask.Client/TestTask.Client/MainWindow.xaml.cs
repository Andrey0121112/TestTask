using System;
using System.Windows;

namespace TestTask.Client
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    }
}
