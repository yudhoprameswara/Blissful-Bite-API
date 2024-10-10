using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlissfulBite.ViewModel.Cart
{
    public class CartListVM
    {
        public IEnumerable<CartVM> cartList {  get; set; } = new List<CartVM>();
    }
}
