using EntityClassLibrary;
using ProjectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            

            ////Repository repo = new Repository();
            ////List<Category> listOfCategory = repo.repository();

            using (var context = new ProjectEntities())
            {
                foreach (var category in context.Categories)
                {
                    Console.WriteLine(category.CategoryName);
                }
            }


            using (var content = new ProjectEntities())
            {
                foreach (var product in content.Products)
                {
                    Console.WriteLine(product.ProductColour);
                }
            }



            //Basket basket = new Basket();
            //Till till = new Till();

            //while (true)
            //{
            //    Console.Write("Which Item?: ");
            //    string itemName = Console.ReadLine();
            //    Console.Write("Enter the Price?: ");
            //    string itemPrice = Console.ReadLine();
            //    Item item = new Item() { Name = itemName.Trim(), price = Double.Parse(itemPrice) };
            //    basket.Add(item);
            //    Console.Write("Any more? (y/n)");
            //    string yesno = Console.ReadLine();
            //    if (yesno.ToLower().StartsWith("n"))
            //    {
            //        break;
            //    }
            //}

            //double total = till.Process(basket);
            //Console.WriteLine("The total is " + total);
            //Console.WriteLine("Have a nice day!");
            //Console.Read();
        }
    }
}
