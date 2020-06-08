using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Channels;

namespace UDPproject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server eller Klient");
            string serverellerklient = Console.ReadLine();

            if(serverellerklient == "server")
            {
                Server server = new Server();
            }
            
            else if(serverellerklient == "klient")
            {
                Client client = new Client();
            }
            
            else
            {
                return;
            }
            
        }
    }
}
