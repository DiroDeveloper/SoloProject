using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOConnection
{
    interface IBrokerRepository
    {
        void Refresh();
        void AddNewBroker(Broker brokerToAdd);
        List<Broker> GetAllBroker();
        
    }
}
