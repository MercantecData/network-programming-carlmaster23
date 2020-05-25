using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Server

{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hvad vil du gerne være serveren eller klienten");
            string nummer = Console.ReadLine();
            if (nummer == "klienten")
            {
                klient();

                static void klient()
                {
                    TcpClient client = new TcpClient();

                    int port = 13356;
                    IPAddress ip = IPAddress.Parse("172.16.113.239");
                    IPEndPoint endPoint = new IPEndPoint(ip, port);

                    client.Connect(endPoint);

                    NetworkStream stream = client.GetStream();

                    string text = "Hello World!";
                    byte[] buffer = Encoding.UTF8.GetBytes(text);

                    stream.Write(buffer, 0, buffer.Length);

                    client.Close();
                }
            }
            else if(nummer == "serveren")
            {
                server();

                static void server()
                {
                    int port = 13356;
                    IPAddress ip = IPAddress.Any;
                    IPEndPoint localEndpoint = new IPEndPoint(ip, port);

                    TcpListener listener = new TcpListener(localEndpoint);
                    listener.Start();

                    Console.WriteLine("Awaiting Clients");
                    TcpClient client = listener.AcceptTcpClient();

                    NetworkStream stream = client.GetStream();

                    byte[] buffer = new byte[256];

                    int numberOfBytesRead = stream.Read(buffer, 0, 256);

                    string message = Encoding.UTF8.GetString(buffer, 0,
                    numberOfBytesRead);

                    Console.WriteLine(message);
                }
            }
            else
            {
                Console.WriteLine("Du skrev noget forkert");
            }
        }
            
    }
}
