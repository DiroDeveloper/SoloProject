using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var context = new tradingsystemEntities())
            //{

            //    broker b = new broker() { id = 4, name = "Rukshi", fk_company_id = 1, city = "Stoke"};
            //    context.brokers.Add(b);
            //    context.SaveChanges();
            //}

            using (var context = new tradingsystemEntities())
            {
                foreach (var broker in context.brokers)

                {
                    Console.WriteLine(broker.name);    
                }
            }

            //Relations
            using (var context = new tradingsystemEntities())
            {
                var query = (from b in context.brokers where b.company.city == "London" select b);
                foreach (var broker in query)
                {
                    Console.WriteLine(broker.name);
                }
                
            }

            using (var context = new tradingsystemEntities())
            {
                var brokers = context.brokers.Where(b => b.name == "Rukshi");
                foreach (var broker in brokers) { context.brokers.Remove(broker); }
                context.SaveChanges();
            }

        }
    }
}
