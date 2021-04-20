using System;
using System.Collections.Generic;
using ThemingDemo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prueba
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.TabbedPage1());
            Console.WriteLine("leyendo valores del thema de la app");
            Console.WriteLine(Application.Current.Properties.ContainsKey("Theme"));
            if (Application.Current.Properties.ContainsKey("Theme"))
            {
                string theme = Application.Current.Properties["Theme"].ToString();
                Console.WriteLine(theme);
                ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
                if (mergedDictionaries != null)
                {
                    mergedDictionaries.Clear();

                    switch (theme)
                    {
                        case "Dark":
                            
                            Application.Current.UserAppTheme = OSAppTheme.Dark;
                            mergedDictionaries.Add(new DarkTheme());



                            break;

                        case "Light":
                            
                            Application.Current.UserAppTheme = OSAppTheme.Light;
                            mergedDictionaries.Add(new LightTheme());

                            break;
                        default:

                            break;
                    }

                    

                }
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
