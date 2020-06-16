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
            // awaiting answer from server
            Console.WriteLine("Awaiting answer?");
            Receiver();
            Console.ReadLine();
        }
        // receiving message from client 
        public static async void Receiver()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            UdpClient client = new UdpClient(endPoint);

            UdpReceiveResult result = await client.ReceiveAsync();

            byte[] buffer = result.Buffer;
            string text = Encoding.UTF8.GetString(buffer);

            Console.WriteLine("Received: " + text);
        }
    }
}
