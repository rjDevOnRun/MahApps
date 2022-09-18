using MahApps.Metro.Controls;
using MahApps.ViewModels;
using MahApps.Views;

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