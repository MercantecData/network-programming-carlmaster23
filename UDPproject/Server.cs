using System;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace UDPproject
{
    public class Server
    {
        public Server()
        {
            Console.WriteLine("Awaiting answer?");
            Receiver();
            Console.ReadLine();
        }
        public static async void Receiver()
        {
            //Console.WriteLine("Skriv IP");
            //var ip = Console.ReadLine();

            //Console.WriteLine("Skriv Port");
            //int port = Convert.ToInt32(Console.ReadLine());

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            UdpClient client = new UdpClient(endPoint);

            UdpReceiveResult result = await client.ReceiveAsync();

            byte[] buffer = result.Buffer;
            string text = Encoding.UTF8.GetString(buffer);

            Console.WriteLine("Received: " + text);
        }
    }
}
