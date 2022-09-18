using ControlzEx.Theming;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Models;
using MahApps.Views;
using Microsoft.VisualStudio.PlatformUI;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MahApps.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region PROPERTIES

        private readonly MainWindow _mainWindow;

        private ObservableCollection<ThemeValue> _lstTheme;

        public ObservableCollection<ThemeValue> LstTheme
        {
            get { return _lstTheme; }
            set { SetProperty(ref _lstTheme, value); }
        }

        private ObservableCollection<ThemeValue> _lstColor;

        public ObservableCollection<ThemeValue> LstColor
        {
            get { return _lstColor; }
            set { SetProperty(ref _lstColor, value); }
        }

        private ThemeValue _selectedColor;

        public ThemeValue SelectedColor
        {
            get { return _selectedColor; }
            set { SetProperty(ref _selectedColor, value); }
        }

        private ThemeValue _selectedTheme;

        public Employee Employee { get; set; }

        public ThemeValue SelectedTheme
        {
            get { return _selectedTheme; }
            set { SetProperty(ref _selectedTheme, value); }
        }

        #endregion PROPERTIES

        #region COMMANDS

        public ICommand ApplyThemeCommand { get; set; }
        public ICommand ApplyColorCommand { get; set; }

        #endregion COMMANDS

        #region CONSTRUCTOR

        public MainViewModel(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            SubscribeViewEvents();
            SetupEmployee();

            SetupGlobalThemes();

            SyncWithWindowsTheme();
        }

        private static void SyncWithWindowsTheme()
        {
            ThemeManager.Current.ThemeSyncMode = ThemeSyncMode.SyncWithAppMode;
            ThemeManager.Current.SyncTheme();
        }

        #endregion CONSTRUCTOR

        #region APP THEME RELATED

        private void SetupGlobalThemes()
        {
            //TODO:
            // Get save Accent and Theme from Registery and apply

            ApplyThemeCommand = new DelegateCommand(ApplyTheme);
            ApplyColorCommand = new DelegateCommand(ApplyColor);

            _lstTheme = new ObservableCollection<ThemeValue>()
            {
                new ThemeValue() {Name = "Light", Value = "White"},
                new ThemeValue() {Name = "Dark", Value = "Black"}
            };

            SelectedTheme = LstTheme[0];

            _lstColor = new ObservableCollection<ThemeValue>()
            {
                new ThemeValue() {Name = "Blue", Value = "#2196F3"},
                new ThemeValue() {Name = "Red", Value = "#e52400"},
                new ThemeValue() {Name = "Green", Value = "#60a917"},
                new ThemeValue() {Name = "Purple", Value = "#800080"},
                new ThemeValue() {Name = "Orange", Value = "#fa6800"},
                new ThemeValue() {Name = "Lime", Value = "#00FF00"},
                new ThemeValue() {Name = "Emerald", Value = "#046307"},
                new ThemeValue() {Name = "Teal", Value = "#008080"},
                new ThemeValue() {Name = "Cyan", Value = "#00ffff"},
                new ThemeValue() {Name = "Cobalt", Value = "#0047ab"},
                new ThemeValue() {Name = "Indigo", Value = "#FF4B0082"},
                new ThemeValue() {Name = "Violet", Value = "#8F00FF"},
                new ThemeValue() {Name = "Pink", Value = "#FFC0CB"},
                new ThemeValue() {Name = "Crimson", Value = "#DC143C"},
                new ThemeValue() {Name = "Amber", Value = "#FFBF00"},
                new ThemeValue() {Name = "Yellow", Value = "#ffff00"},
                new ThemeValue() {Name = "Brown", Value = "#a52a2a"},
                new ThemeValue() {Name = "Olive", Value = "#808000"},
                new ThemeValue() {Name = "Steel", Value = "#71797E"},
                new ThemeValue() {Name = "Mauve", Value = "#e0b0ff "},
                new ThemeValue() {Name = "Taupe", Value = "#483C32"},
                new ThemeValue() {Name = "Sienna", Value = "#A0522D"},
            };

            SelectedColor = _lstColor[0];
        }

        private void ApplyColor()
        {
            ApplyThemeColor();
        }

        private void ApplyTheme()
        {
            ApplyThemeColor();
        }

        private void ApplyThemeColor()
        {
            try
            {
                var accent = SelectedColor.Name ?? LstColor[0].Name;
                var theme = SelectedTheme.Name ?? LstTheme[0].Name;

                var appTheme = ThemeManager.Current.GetTheme("BaseDark");

                ThemeManager.Current.ChangeTheme(Application.Current, $"{theme}.{accent}");

                // Save Accent and Theme to Registery

                // OBSOLETE
                //Accent newAccent = ThemeManager.GetAccent(accent);
                //AppTheme newTheme = ThemeManager.GetAppTheme("Base" + theme);
                //ThemeManager.ChangeAppStyle(Application.Current, newAccent, newTheme);
            }
            catch (System.Exception ex)
            {
            }
        }

        #endregion APP THEME RELATED

        #region EVENT HANDLERS

        private void SetupEmployee()
        {
            Employee = new Employee("Roby John", "Engg IT", 20220822, "roby.john@mail.com");
        }

        private void SubscribeViewEvents()
        {
            _mainWindow.btnCupCakes.Click += BtnCupCakes_Click;
            _mainWindow.btnGitHubSite.Click += BtnGitHubSite_Click;
            _mainWindow.btnFlyout.Click += BtnFlyout_Click;
            _mainWindow.btnTest.Click += BtnTest_Click;
            _mainWindow.btnShowModal.Click += BtnShowModal_Click;
        }

        private void BtnShowModal_Click(object sender, RoutedEventArgs e)
        {
            ModalWindow modalWindow = new ModalWindow();
            modalWindow.ShowDialog();
        }

        private void BtnTest_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _ = Task.Run(() => MessageDisplayAsync());
        }

        private async Task MessageDisplayAsync()
        {
            var result = await _mainWindow.ShowMessageAsync("title here", "The main message!",
                MessageDialogStyle.AffirmativeAndNegative);

            Debug.Print(result.ToString());
        }

        private void BtnFlyout_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _mainWindow.foUpdate.Width = _mainWindow.Width + 2;
            _mainWindow.foUpdate.Content = "Test";
            _mainWindow.foUpdate.IsOpen = true;
        }

        private void BtnGitHubSite_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Launch Github Site
        }

        private void BtnCupCakes_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // deploy some CupCakes...
        }

        #endregion EVENT HANDLERS
    }
}