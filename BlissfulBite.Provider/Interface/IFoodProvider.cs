using BlissfulBite.ViewModel.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlissfulBite.Provider.Interface
{
    public interface IFoodProvider
    {
        public FoodListVM getAllFoods();
        public FoodVM getFood(int id);
        public void CreateFood(FoodVM foodVm);
        public void EditFood(FoodVM foodVm);
        public void DeleteFood(int id);
    }
}
