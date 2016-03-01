using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectClasses
{
    public class Till
    {

        public double Process(Basket basket)
        {
            List<Item> items = basket.GetItem();
            double total = 0.0;
            foreach (Item item in items)
            {
                total += item.price;
            }
            return total;
        }
    }
}

        
   


           
       
           
        


         
        

       
    
