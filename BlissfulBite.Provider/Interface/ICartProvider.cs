using BlissfulBite.ViewModel.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlissfulBite.Provider.Interface
{
    public interface ICartProvider
    {
        public void addToCart(int foodId);

        public CartListVM GetCart();

        public void purchaseAll();
        public void deleteFood(int foodId);
    }
}
