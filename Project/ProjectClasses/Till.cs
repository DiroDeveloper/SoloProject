using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectClasses
{
   public class Till
    {
       Basket basket = new Basket();
       
        public int calculateTotal(Item item)
        {
            item.price * item.count
        }
    }
}
