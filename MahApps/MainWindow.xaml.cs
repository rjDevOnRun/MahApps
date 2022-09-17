using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.ViewModels;
using System.Diagnostics;
using System.Windows;

namespace MahApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new MainViewModel(this);

            this.DataContext = ViewModel;
        }
    }
}