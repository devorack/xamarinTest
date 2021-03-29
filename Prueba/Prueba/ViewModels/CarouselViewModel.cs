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
            Title = "Titulo",
            Description = "Descripcion",
           },

           new CarouselModel{
            Title = "Titulo2",
            Description = "Descripcion2",
           },

           new CarouselModel{
            Title = "Titulo3",
            Description = "Descripcion3",
           },

           new CarouselModel{
            Title = "Titulo4",
            Description = "Descripcion4",
           },
        };
        

        #region Properties
        public ObservableCollection<CarouselModel> List
        {
            get { return list; }
            set { list = value; OnPropertyChanged(); }
        }

        #endregion


        private ObservableCollection<Car> items;
        public ObservableCollection<Car> Items
        {
            get {
                return items; 
            }
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }

        public CarouselViewModel()
        {

            Console.WriteLine("entro en el constructor");
            // Here you can have your data form db or something else,
            // some data that you already have to put in the list
            Items = new ObservableCollection<Car>() {
                new Car()
                {
                    CarID = 1,
                    Make = "Tesla Model S",
                    YearOfModel = 2015
                },
                  new Car()
                {
                    CarID = 2,
                    Make = "Audi R8",
                    YearOfModel = 2012
                },

            };
            apiConection();



            // Web service call to update list with new values
            

        }

        private async void apiConection()
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
                    Description = result.body,
                });

                OnPropertyChanged();
            }
        }

    }
}


