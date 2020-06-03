using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Collections.Generic;

namespace serverogklientprogram
{
    public class Klienter
    {
        public Klienter()
        {
            TcpClient client = new TcpClient();
            
            Console.WriteLine("Skriv portnummeret");
            int port = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Skriv ip");
            string ipen = Console.ReadLine();
            
            IPAddress ip = IPAddress.Parse(ipen);
            IPEndPoint endPoint = new IPEndPoint(ip, port);

            client.Connect(endPoint);

            while (true)
            {
                Console.Write("Skriv et tal: ");
                
                NetworkStream stream = client.GetStream();
                
                string text = Console.ReadLine();
                
                byte[] buffer = Encoding.UTF8.GetBytes(text);
                stream.Write(buffer, 0, buffer.Length);
                ReceiveMessage(stream);

            static void ReceiveMessage(NetworkStream stream)
                {
                   byte[] buffer = new byte[256];
                   int numberOfBytesRead = stream.Read(buffer, 0, 256);
                   string receivedMessage = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);
                   
                   Console.Write("Server message: " + receivedMessage + "\n");
                }
            }
        }
    }
}
