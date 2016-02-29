using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectClasses
{
    public class Catalogue
    {
        DatabaseReader dbReader = new DatabaseReader();

        public Catalogue(DatabaseReader GivenDbReader)
        {
            dbReader = GivenDbReader;
        }
        
        public List<Item> GetAllItems()
        {
            return dbReader.ReadQuantity();
        }
    }
}
