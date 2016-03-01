using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOConnection
{
    class Program
    {
        static void Main(string[] args)
        {

            //Connect string
            //string connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fdmgroup.com)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));Pooling=false;User Id=RukshikaFernando;Password=Oracle101;";
            string connectionString = ConfigurationManager.ConnectionStrings["FDMOracle"].ToString();
            IBrokerRepository brokerRepository = new OracleSqlBrokerRepository(connectionString);
            brokerRepository.Refresh();

            foreach(Broker broker in brokerRepository.GetAllBroker())
            {
                Console.WriteLine("{0},{1},{2}",
                     broker.id,
                     broker.firstName,
                     broker.lastName);
            }
            Console.WriteLine("Now add some new ones......");
            while(true)
            {
               
                Console.WriteLine("id: ");
                string id = Console.ReadLine();
                Console.WriteLine("First_Name: ");
                string first_name = Console.ReadLine();
                Console.WriteLine("Last_Name : ");
                string last_name = Console.ReadLine();

                 Broker newbroker = new Broker()
                {
                    id = int.Parse(id),
                    firstName = first_name,
                    lastName = last_name
                };

                brokerRepository.AddNewBroker(newbroker);
            }

        }
    }
}
