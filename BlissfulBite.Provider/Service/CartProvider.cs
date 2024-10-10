using BlissfulBite.Provider.Interface;
using BlissfulBite.ViewModel.Cart;
using BlissfulBite.ViewModel.Food;
using BlissfullBite.DataAccess.models;
using Microsoft.EntityFrameworkCore;


namespace BlissfulBite.Provider.Service
{
    public class CartProvider : ICartProvider
    {
        public void addToCart(int foodId)
        {
            var entity = new Cart
            {
                FoodId = foodId,
                PurchaseDate = null
            };

            Cart result;
            using (var dbContext = new BlissfulBiteContext()) { 
                result = dbContext.Carts.Add(entity).Entity;
                dbContext.SaveChanges();
            }
        }

        public CartListVM GetCart()
        {
            var list = new CartListVM()
            {
                cartList = new List<CartVM>()
            };
            using (var dbContext = new BlissfulBiteContext())
            {
                var query = from cart in dbContext.Carts
                            where cart.PurchaseDate == null
                            select new CartVM
                            {
                                foodName = cart.Food.Name,
                                purchaseDate = cart.PurchaseDate,
                            };
            list.cartList = query.ToList();
            }
            return list;

        }

        public void purchaseAll()
        {
            using (var dBContext = new BlissfulBiteContext())
            {
                var entity = dBContext.Carts.
                    Where(cart => cart.PurchaseDate == null)
                    .ToList();

                foreach (var cart in entity)
                {
                    cart.PurchaseDate = DateTime.Now;
                }
                dBContext.SaveChanges();
            }
        }

        public void deleteFood(int foodId)
        {
            using (var dBContext = new BlissfulBiteContext())
            {
                var entity = dBContext.Carts.
                    FirstOrDefault(cart => cart.FoodId == foodId && cart.PurchaseDate == null);

                if (entity != null)
                {
                    dBContext.Carts.Remove(entity);
                    dBContext.SaveChanges();
                }
            }
        }

  
 
}

}
