using Prueba.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prueba.Models
{
    public class Car : BaseViewModel
    {

        public int CarID { get; set; }
        public string Make { get; set; }
        public int YearOfModel { get; set; }

    }
}
