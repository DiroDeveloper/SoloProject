using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectClasses
{
    public class Basket
    {
        private List<Item> items = new List<Item>();

        public int Size
        {
            get
            {
                return items.Count;
            }
        }

        public void Add(Item item)
        {
            items.Add(item);
        }



        public List<Item> GetItem()
        {
            return items.ToList();
        }
    }
}

