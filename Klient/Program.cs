using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Klient
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();

            int port = 13356;
            IPAddress ip = IPAddress.Parse("172.16.113.68");
            IPEndPoint endPoint = new IPEndPoint(ip, port);
            
            client.Connect(endPoint);

            NetworkStream stream = client.GetStream();

            string text = "Hello World!";
            byte[] buffer = Encoding.UTF8.GetBytes(text);

            stream.Write(buffer, 0, buffer.Length);

            client.Close();
        }
    }
}
