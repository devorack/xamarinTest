using Prueba.Models;
using Prueba.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using ThemingDemo;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Prueba.ViewModels
{
        
    class CarouselViewModel : BaseViewModel
    {
       
        ObservableCollection<CarouselModel> list = new ObservableCollection<CarouselModel> {

           new CarouselModel{
            Title = "Flexi Free",
            Price = "Gratis",
            Color = "#6CF5FF",
            Items = "1 Empresa,1 Usuario,2 Tipos de Documento,2 GB",
           },

           new CarouselModel{
            Title = "Flexi Basic",
            Price = "18.05",
            Color = "#3FA4FB",
            Items =  "1 Empresa,2 Usuario,10 Tipos de Documentos,Docuviewer,10 GB",
           },

           new CarouselModel{
            Title = "Flexi Business",
            Price = "36.83",
            Color = "#FF64F3",
            Items = "1 Empresa,4 Usuario,20 Tipos de Documento,Versionamiento de documentos,Flow,Notificacion,Docuviewer,25 GB,4 Firma digital adobe Sing ",
           },

           new CarouselModel{
            Title = "Flexi Enterprise",
            Price = "80.33",
            Color = "#FF4B6D",
            Items = "1 Empresa,4 Usuario,30 Tipos de Documento,Versionamiento de documentos,Flow,Notificacion,Docuviewer,60 GB,4 Firma digital adobe Sing ",
           },

           new CarouselModel{
            Title = "Flexi Personalizado",
            Price = " ",
            Color = "#FD66AB",
            Items = "Escríbanos para más información a flexy-info@myflexifile.com",
           },

        };

        public ICommand changeThemeCommand { get; set; }
        public ICommand FlexiFilePlanCommand { get; set; }
        #region Properties
        public ObservableCollection<CarouselModel> List
        {
            get { return list; }
            set { list = value; OnPropertyChanged(); }
        }

        #endregion



        public CarouselViewModel()
        {
            Console.WriteLine("entro en el constructor");
            FlexiFilePlanCommand = new Command(async => FlexifilePlanClicked());
            changeThemeCommand = new Command(async => FlexifilePlanClicked());
        }

        private async void FlexifilePlanClicked()
        {
            Console.WriteLine("abrir planes ");
            try
            {
                await Browser.OpenAsync("https://www.myflexifile.com", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                // An unexpected error occured. No browser may be installed on the device.
            }
        }



        private async void ApiConection()
        {
            httpModel client = new httpModel();
            var result = await client.Get<WSResult>("https://jsonplaceholder.typicode.com/posts/1");
            if (result != null)
            {

                Console.WriteLine("entro en el metodo *********************************************************");
                Console.WriteLine(result);
                Console.WriteLine(result.title);
                Console.WriteLine(result.body);
                Console.WriteLine(result.id);
                list.Add(new CarouselModel
                {
                    Title = result.title,
                    Price = result.body,
                });

                OnPropertyChanged();
            }
        }

    }
}


