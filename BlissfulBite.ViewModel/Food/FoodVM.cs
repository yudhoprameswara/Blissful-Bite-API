using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlissfulBite.ViewModel.Food
{
    public class FoodVM
    {
        public int id {get; set;}
        public string name { get; set; }
        public string category { get; set; }
        public decimal price { get; set; }
        public bool? availability { get; set; }
        public string description { get; set; }
        public string imagePath { get; set; }

    }
}
