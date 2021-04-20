using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ThemingDemo;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Prueba.ViewModels
{
    class SettingsViewModel : BaseViewModel
    {
        string nameTheme;


        bool _radioButtonCheck;
        public bool RadioButtonCheck
        {
            get
            { return _radioButtonCheck; }
            set
            {
                _radioButtonCheck = value;
                OnPropertyChanged();
                
            }
        }
        public ICommand changeThemeCommand { get; set; }
        public ICommand changeValueRadioButtonCommand { get; set; }
        public ICommand viewTermsAndConditionsCommand { get; set; }

        public string NameTheme
        {
            get { return nameTheme; }
            set { nameTheme = value; OnPropertyChanged(nameof(nameTheme)); }
        }


        public SettingsViewModel()
        {

            Console.WriteLine("entro en el constructor");
            changeThemeCommand = new Command(async => changeThemeClicked());
            changeValueRadioButtonCommand = new Command(async => ValueRadioButtonClicked());
            viewTermsAndConditionsCommand = new Command(async => viewTermsAndConditionsClickedAsync());
            OSAppTheme currentTheme = Application.Current.RequestedTheme;
            nameTheme = currentTheme.ToString();


        }

        private async void viewTermsAndConditionsClickedAsync()
        {
            try
            {
                await Browser.OpenAsync("https://www.myflexifile.com/TermsConditionLogin/Index", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                // An unexpected error occured. No browser may be installed on the device.
            }
        }

        
        private void ValueRadioButtonClicked()
        {
            _radioButtonCheck = !_radioButtonCheck;
            OnPropertyChanged();
        }

        private void changeThemeClicked()
        {

            //Picker picker = sender as Picker;
            //Theme theme = (Theme)picker.SelectedItem;
            OSAppTheme currentTheme = Application.Current.RequestedTheme;

            Console.WriteLine("cual tema es");
            Console.WriteLine(currentTheme.ToString());
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                switch (currentTheme.ToString())
                {
                    case "Dark":
                        nameTheme = currentTheme.ToString();
                        Application.Current.UserAppTheme = OSAppTheme.Light;
                        mergedDictionaries.Add(new LightTheme());
                        Application.Current.Properties["Theme"] = "Light";
                        Application.Current.SavePropertiesAsync();
                        break;

                    case "Light":
                        nameTheme = currentTheme.ToString();
                        Application.Current.UserAppTheme = OSAppTheme.Dark;
                        mergedDictionaries.Add(new DarkTheme());
                        Application.Current.Properties["Theme"] = "Dark";
                        Application.Current.SavePropertiesAsync();
                        break;

                    default:

                        break;
                }

                OnPropertyChanged();

            }
        }

    }
}
