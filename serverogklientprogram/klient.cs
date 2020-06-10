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
            
            // asking you to type port number and saving the output
            Console.WriteLine("Skriv portnummeret");
            int port = Convert.ToInt32(Console.ReadLine());

            // asking you to type ip adresse and saving the output
            Console.WriteLine("Skriv ip");
            string ipen = Console.ReadLine();
            
            IPAddress ip = IPAddress.Parse(ipen);

            // making a object with ip port number saved inside
            IPEndPoint endPoint = new IPEndPoint(ip, port);

            // connecting to server
            client.Connect(endPoint);

            // starting loop
            while (true)
            {
                // asking you to type a number and sending it to server console
                Console.Write("Skriv et tal: ");
                
                NetworkStream stream = client.GetStream();
                
                string text = Console.ReadLine();
                
                byte[] buffer = Encoding.UTF8.GetBytes(text);
                stream.Write(buffer, 0, buffer.Length);
                
                // receiving message from server after sending answer
                ReceiveMessage(stream);

            // receiving message from server function 
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
