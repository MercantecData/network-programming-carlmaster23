using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Collections.Generic;

namespace MultiClientserver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("serveren eller tryk på en knap for at lukke");
            string statercode = Console.ReadLine();

            // tjekking what you have writen in the console.readline and tjekking it with if and else statments
            if (statercode == "server")
            {
                MyServer Server = new MyServer();
            }
            else if(statercode == "klient")
            {
                Klienter klienten = new Klienter();
            }
            else if(statercode == "klienten")
            {
                Klienter klienten = new Klienter();
            }
            else if(statercode == "serveren")
            {
                MyServer Server = new MyServer();
            }
            else
            {
                Console.WriteLine("closing program");
            }
        }

        public class MyServer
        {
            public List<TcpClient> clients = new List<TcpClient>();
            public MyServer()
            {
                IPAddress ip = IPAddress.Parse("172.16.113.239");
                int port = 5000;

                // listing to incoming client with the same ip as the server
                TcpListener listener = new TcpListener(ip, port);
                listener.Start();

                AcceptClients(listener);

                // creating a bool and starting a loop
                bool isRunning = true;
                while (isRunning)
                {
                    // send a Message
                    Console.Write("Write message: ");
                    string text = Console.ReadLine();
                    byte[] buffer = Encoding.UTF8.GetBytes(text);
                    
                    
                    foreach(TcpClient client in clients)
                    {
                        client.GetStream().Write(buffer, 0, buffer.Length);
                    }
                }
            }
            // the function that runs when awaiting clients and accepting clients 
            public async void AcceptClients(TcpListener listener)
            {
                bool isRunning = true;
                while(isRunning)
                {
                    TcpClient client = await listener.AcceptTcpClientAsync();
                    clients.Add(client);
                    NetworkStream stream = client.GetStream();
                    ReceiveMessages(stream);

                }

            }
        // the function that Changing the bites to letters and priting them in the console
        public async void ReceiveMessages(NetworkStream stream) {
                byte[] buffer = new byte[256];
                bool IsRunning = true;
                while (IsRunning)
                {
                    int read = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string text = Encoding.UTF8.GetString(buffer, 0, read);
                    Console.WriteLine("client writes: " + text);
                }
            }
        
        }
    }
}