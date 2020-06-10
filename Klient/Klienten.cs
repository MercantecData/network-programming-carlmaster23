using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Klient
{
    public class Klienten
    {
        public Klienten()
        {
            // the parameters used in the code
            string text;

            TcpClient client = new TcpClient();
            
            // the ip and port for the server you want to connect 
            IPAddress IP = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(IP, 5000);

            // connecting to server
            client.Connect(endPoint);

            // sending message to server
            NetworkStream stream = client.GetStream();

            Console.WriteLine("Skriv en besked til serveren");

            text = Console.ReadLine();

            byte[] buffer = Encoding.UTF8.GetBytes(text);

            stream.Write(buffer, 0, buffer.Length);

            // Receive message from server 
            ReceiveMessage(stream);
            
            // closing the client connection to server
            client.Close();
        }

        // receive message from server function
        public static void ReceiveMessage(NetworkStream stream)
        {
            // the parameters used in the code
            int numberOfBytesRead;
            string receivedMessage;

            byte[] buffer = new byte[256];
            numberOfBytesRead = stream.Read(buffer, 0, 256);
            receivedMessage = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

            Console.Write("Server message: " + receivedMessage + "\n");
        }
    }
}