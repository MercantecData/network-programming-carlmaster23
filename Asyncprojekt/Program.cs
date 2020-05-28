﻿using System;
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
                int port = 13356;

                IPAddress ip = IPAddress.Any;

                IPEndPoint localEndpoint = new IPEndPoint(ip, port);

                TcpListener listener = new TcpListener(localEndpoint);

                listener.Start();

                Console.WriteLine("Awaiting Clients");
                TcpClient client = listener.AcceptTcpClient();

                NetworkStream stream = client.GetStream();
                ReceiveMessage(stream);
                Console.Write("Vil du skrive eller ud ");
                string indellerud = Console.ReadLine();
                bool kør = true;
                while (kør)
                {
                    if (indellerud == "exit")
                    {
                        kør = false;
                    }
                    else
                    {
                        Console.Write("Write your message here: ");
                        string text = Console.ReadLine();
                        byte[] buffer = Encoding.UTF8.GetBytes(text);

                        stream.Write(buffer, 0, buffer.Length);

                        Console.ReadKey();
                    }
                }
            }
            public async void ReceiveMessage(NetworkStream stream)
            {
                byte[] buffer = new byte[256];
                int numberOfBytesRead = await stream.ReadAsync(buffer, 0, 256);
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

                Console.Write("\n" + receivedMessage);
            }
        }


        class Clientsite
        {
            public Clientsite()
            {
                TcpClient client = new TcpClient();

                int port = 13356;
                IPAddress ip = IPAddress.Parse("127.0.0.1");
                IPEndPoint endPoint = new IPEndPoint(ip, port);

                client.Connect(endPoint);

                NetworkStream stream = client.GetStream();
                ReceiveMessage(stream);

                bool kør = true;
                while (kør)
                {
                    if (kør == false)
                    {
                        client.Close();
                        kør = false;
                    }
                    else
                    {
                        Console.Write("Write your message here: ");
                        string text = Console.ReadLine();
                        byte[] buffer = Encoding.UTF8.GetBytes(text);

                        stream.Write(buffer, 0, buffer.Length);

                        Console.ReadKey();
                    }
                }
                
            }
            public async void ReceiveMessage(NetworkStream stream)
            {
                byte[] buffer = new byte[256];
                int numberOfBytesRead = await stream.ReadAsync(buffer, 0, 256);
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

                Console.Write("\n" + receivedMessage);
            }

        }
    }
}
