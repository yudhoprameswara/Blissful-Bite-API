using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlissfulBite.ViewModel.Food
{
    public class FoodListVM
    {
       public IEnumerable<FoodVM> foodList { get; set; } = new List<FoodVM>();
    }
}
