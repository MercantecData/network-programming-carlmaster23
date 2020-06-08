using System;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace UDPproject
{
    class Client
    {
        public Client()
        {
            UdpClient klient = new UdpClient();
            Console.WriteLine("Skriv en besked");
            string text = Console.ReadLine();
            string text2 = " Hello my friend";
            byte[] bytes = Encoding.UTF8.GetBytes(text + text2);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);

            klient.Send(bytes, bytes.Length, endPoint);
        }
    }
}
