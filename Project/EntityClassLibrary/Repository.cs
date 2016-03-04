using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClassLibrary
{
    public class Repository
    {


        //public List<Category> repository()
        //{
        //    List<Category> listOfCategory = new List<Category>();

        //    using (var context = new ProjectEntities())
        //    {
        //        foreach (var category in context.Categories)
        //        {
        //            listOfCategory.Add(category);



        //        }
        //        return listOfCategory;
        ////    }
        //}

       
            //List<Category> listOfCategory = new List<Category>();
            SqlDatabaseReader sDBReader = new SqlDatabaseReader();
            public Repository(SqlDatabaseReader GivenDbReader)
        {
            sDBReader = GivenDbReader;
        }

            public List<Category> GetItems()
            {
                
                return sDBReader.ReadQuantity();

        }
    }
}
       
