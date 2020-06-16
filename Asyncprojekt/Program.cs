using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace Asyncprojekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hvad vil du gerne være serveren eller klienten");
            string nummer = Console.ReadLine();

            // tjekking if console.readline match
            if (nummer == "klienten")
            {
                Clientsite client = new Clientsite();
            }
            else if (nummer == "serveren")
            {
                Serversite Server = new Serversite();
            }
            else
            {
                Console.WriteLine("Du skrev noget forkert");
            }
        }

        public class Serversite
        {

            public Serversite()
            {
                // setting up server
                int port = 13356;

                IPAddress ip = IPAddress.Any;

                IPEndPoint localEndpoint = new IPEndPoint(ip, port);

                TcpListener listener = new TcpListener(localEndpoint);

                listener.Start();

                Console.WriteLine("Awaiting Clients");
                TcpClient client = listener.AcceptTcpClient();

                // starting loop
                bool kør = true;
                while (kør)
                {
                    NetworkStream stream = client.GetStream();
                    ReceiveMessage(stream);

                    Console.Write("Write your message here: ");
                    string text = Console.ReadLine();
                    byte[] buffer = Encoding.UTF8.GetBytes(text);

                    stream.Write(buffer, 0, buffer.Length);
                }
                    Console.ReadKey();
                
            }
            // starting a function
            public async void ReceiveMessage(NetworkStream stream)
            {
                byte[] buffer = new byte[256];
                int numberOfBytesRead = await stream.ReadAsync(buffer, 0, 256);
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

                Console.Write("\n" + "Client message: " + receivedMessage);
            }
        }


        class Clientsite
        {
            public Clientsite()
            {
                TcpClient client = new TcpClient();

                // connection to server
                int port = 13356;
                IPAddress ip = IPAddress.Parse("127.0.0.1");
                IPEndPoint endPoint = new IPEndPoint(ip, port);

                client.Connect(endPoint);
                
                // starting loop
                bool kør = true;
                while (kør)
                {
                    NetworkStream stream = client.GetStream();
                    ReceiveMessage(stream);

                    Console.Write("Write your message here: ");
                    string text = Console.ReadLine();
                    byte[] buffer = Encoding.UTF8.GetBytes(text);
                    stream.Write(buffer, 0, buffer.Length);
                }

                Console.ReadKey();
                client.Close();
            }
            // reseiving answer from server after sent message
            public async void ReceiveMessage(NetworkStream stream)
            {
                byte[] buffer = new byte[256];
                int numberOfBytesRead = await stream.ReadAsync(buffer, 0, 256);
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

                Console.Write("\n" + "Server message: " + receivedMessage);
            }

        }
    }
}
