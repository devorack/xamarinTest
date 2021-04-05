using Prueba.Models;
using Prueba.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Prueba.ViewModels
{
        
    class CarouselViewModel : BaseViewModel
    {

        ObservableCollection<CarouselModel> list = new ObservableCollection<CarouselModel> {

           new CarouselModel{
            Title = "Flexi Free",
            Price = "Gratis",
            ListItems = new List<Item>{
                new Item()
                {
                    Items = "1 Empresa",
                    
                },

                new Item()
                {
                    Items = "1 Usuario",

                },
                new Item()
                {
                    Items = "2 Tipos de Documento",

                },
                new Item()
                {
                    Items = "2 GB",

                },

            }
           },

           new CarouselModel{
            Title = "Flexi Basic",
            Price = "18.05",
            ListItems = new List<Item>{
                new Item()
                {
                    Items = "1 Empresa",

                },

                new Item()
                {
                    Items = "2 Usuario",

                },
                new Item()
                {
                    Items = "10 Tipos de Documentos",

                },

                new Item()
                {
                    Items = "Docuviewer",

                },
                new Item()
                {
                    Items = "10 GB",

                },

            }
           },

           new CarouselModel{
            Title = "Flexi Business",
            Price = "36.83",
            ListItems = new List<Item>{
                new Item()
                {
                    Items = "1 Empresa",

                },

                new Item()
                {
                    Items = "4 Usuario",

                },

                new Item()
                {
                    Items = "20 Tipos de Documento",

                },
                new Item()
                {
                    Items = "Versionamiento de documentos",

                },

                new Item()
                {
                    Items = "Flow",

                },

                new Item()
                {
                    Items = "Notificacion",

                },

                new Item()
                {
                    Items = "Docuviewer",

                },
                new Item()
                {
                    Items = "25 GB",

                },


                new Item()
                {
                    Items = "4 Firma digital adobe Sing ",

                },

            }
           },

           new CarouselModel{
            Title = "Flexi Enterprise",
            Price = "80.33",
            ListItems = new List<Item>{
                new Item()
                {
                    Items = "1 Empresa",

                },

                new Item()
                {
                    Items = "4 Usuario",

                },
                new Item()
                {
                    Items = "30 Tipos de Documento",

                },

                new Item()
                {
                    Items = "Versionamiento de documentos",

                },

                new Item()
                {
                    Items = "Flow",

                },

                new Item()
                {
                    Items = "Notificacion",

                },
                new Item()
                {
                    Items = "Docuviewer",

                },
                new Item()
                {
                    Items = "60 GB",

                },

                new Item()
                {
                    Items = "4 Firma digital adobe Sing ",

                },

            }
           },

           new CarouselModel{
            Title = "Flexi Personalizado",
            Price = "Escríbanos para más información",
            ListItems = new List<Item>{
                new Item()
                {
                    Items = "flexy-info@myflexifile.com",

                },

               

            }
           },

        };
        

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


