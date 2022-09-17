using MahApps.ViewModels;

namespace MahApps.Models
{
    public class ThemeValue : ViewModelBase
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _value;

        public string Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }
    }
}