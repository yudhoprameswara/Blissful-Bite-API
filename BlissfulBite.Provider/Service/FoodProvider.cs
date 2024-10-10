using BlissfulBite.Provider.Interface;
using BlissfulBite.ViewModel.Food;
using BlissfullBite.DataAccess.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlissfulBite.Provider.Service
{
    public class FoodProvider : IFoodProvider
    {
        
        public FoodListVM getAllFoods()
        {
            var list = new FoodListVM()
            {
                foodList = new List<FoodVM>()
            };
            using (var dbContext = new BlissfulBiteContext())
            {
                var query = from food in dbContext.Foods
                            select new FoodVM
                            {
                                id = food.Id,
                                name = food.Name,
                                category = food.Category,
                                price = food.Price,
                                availability = food.Availability,
                                description = food.Description,
                                imagePath = food.ImagePath,
                            };

            list.foodList = query.ToList();
            }
            return list;
        }

        public FoodVM getFood(int id)
        {   
            var foodDetails =new FoodVM();
            using(var dbContext =new BlissfulBiteContext())
            {
                var query = from food in dbContext.Foods
                            where food.Id == id
                            select new FoodVM
                            {
                                id = food.Id,
                                name = food.Name,
                                category = food.Category,
                                price = food.Price,
                                availability = food.Availability,
                                description = food.Description,
                                imagePath = food.ImagePath,
                            };
                foodDetails = query.FirstOrDefault();
            }
            return foodDetails;
        }

        public void CreateFood(FoodVM foodVm)
        {
            using (var dbContext = new BlissfulBiteContext())
            {
                var foodEntity = new Food
                {
                    Name = foodVm.name,
                    Category = foodVm.category,
                    Price = foodVm.price,
                    Availability = foodVm.availability,
                    Description = foodVm.description,
                    ImagePath = foodVm.imagePath
                };

                dbContext.Foods.Add(foodEntity);
                dbContext.SaveChanges();
            }
        }

        public void EditFood(FoodVM foodVm)
        {
            using (var dbContext = new BlissfulBiteContext())
            {
                var existingFood = dbContext.Foods.FirstOrDefault(f => f.Id == foodVm.id);

                if (existingFood != null)
                {
                    existingFood.Name = foodVm.name;
                    existingFood.Category = foodVm.category;
                    existingFood.Price = foodVm.price;
                    existingFood.Availability = foodVm.availability;
                    existingFood.Description = foodVm.description;
                    existingFood.ImagePath = foodVm.imagePath;

                    dbContext.SaveChanges();
                }
            }
        }

        public void DeleteFood(int id) { 
            using (var dBContext = new BlissfulBiteContext())
            {
                var query = dBContext.Foods.FirstOrDefault(f => f.Id == id);
                dBContext.Remove(query);
                dBContext.SaveChanges() ;
            }
        }

    }
}
