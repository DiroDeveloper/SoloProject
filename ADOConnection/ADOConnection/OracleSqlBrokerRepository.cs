using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOConnection
{
    public class OracleSqlBrokerRepository : IBrokerRepository
    {
        public string connectionString;
        private List<Broker> allBrokers;

        public OracleSqlBrokerRepository(string connectionString)
        {
            this.connectionString = connectionString;
            allBrokers = new List<Broker>();


        }

        public void Refresh()
        {
            OracleConnection connection = null;

            try
            {

                //Connection
                connection = new OracleConnection(connectionString);
                connection.Open();
                //Command
                string commnadText = "SELECT broker_id, first_name, last_name FROM brokers";
                OracleCommand command = new OracleCommand(commnadText, connection);
                //Reader
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {

                    Broker broker = new Broker()
                    {
                        id = int.Parse(dataReader["broker_id"].ToString()),
                        firstName = dataReader["first_name"].ToString(),
                        lastName = dataReader["last_name"].ToString()
                    };
                    allBrokers.Add(broker);



                    //Console.WriteLine(dataReader["first_name"]);
                    //Console.WriteLine(dataReader["last_name"]);
                    //Console.WriteLine(dataReader["broker_id"]);
                    ////   Console.ReadLine();

                }



            }
            catch (OracleException exception)
            {
                Console.WriteLine("Error: {0} Inner Exception: {1}", exception.Message, exception.InnerException);
            }

            finally
            {
                connection.Close();
            }
        }

        public List<Broker> GetAllBroker()
        {
            return allBrokers;
            //new List<Broker>();
        }


        public void AddNewBroker(Broker brokerToAdd)
        {
            string _sqlStatement = "INSERT INTO brokers(broker_id, first_name, last_name) VALUES (:broker_id, :first_name, :last_name)";
            IDbConnection connection = new OracleConnection(connectionString);
            OracleCommand command = new OracleCommand(_sqlStatement, (OracleConnection)connection);
            command.BindByName = true;
            IDbDataParameter param = new OracleParameter(":first_name", OracleDbType.Varchar2, 25);
            param.Value = brokerToAdd.firstName; command.Parameters.Add(param);
            param = new OracleParameter(":last_name", OracleDbType.Varchar2, 25);
            param.Value = brokerToAdd.lastName; command.Parameters.Add(param);
            param = new OracleParameter(":broker_id", OracleDbType.Int16, 50);
            param.Value = brokerToAdd.id; command.Parameters.Add(param);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (OracleException exception)
            {
                Console.WriteLine("Error: {0} Inner Exception: {1}", exception.Message, exception.InnerException);
            }
            finally
            {
                connection.Close();
            }
        }

       
    }
}

        //
       
    

