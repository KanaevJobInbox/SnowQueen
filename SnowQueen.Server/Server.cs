using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using SnowQueen.Core.Contract; 

namespace SnowQueen.Server
{
    class Server
    {
        static void Main(string[] args)
        {
            Console.Title = "SERVER";

            Uri address = new Uri("http://localhost:4001/IContractAddEndGet");
            BasicHttpBinding binding = new BasicHttpBinding();
            Type contract = typeof(IContractAddEndGet);

            ServiceHost host = new ServiceHost(typeof(Service));
            host.AddServiceEndpoint(contract, binding, address);
            host.Open();

            Console.WriteLine("Сервер запущен. Для завершения работы нажмите любую клавишу.");
            Console.ReadKey();

            host.Close();
        }
    }
}
