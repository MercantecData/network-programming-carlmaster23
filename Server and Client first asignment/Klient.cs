using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Server_and_Client_first_asignment
{
    public class Klienten
    {
        public Klienten()
        {
            string text;

            TcpClient client = new TcpClient();

            IPAddress IP = IPAddress.Parse("127.0.0.1");

            IPEndPoint endPoint = new IPEndPoint(IP, 5000);

            client.Connect(endPoint);

            NetworkStream stream = client.GetStream();

            Console.WriteLine("Skriv en besked til serveren");

            text = Console.ReadLine();

            byte[] buffer = Encoding.UTF8.GetBytes(text);

            stream.Write(buffer, 0, buffer.Length);

            ReceiveMessage(stream);

            client.Close();
        }
        public static void ReceiveMessage(NetworkStream stream)
        {
            byte[] buffer = new byte[256];
            int numberOfBytesRead = stream.Read(buffer, 0, 256);
            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

            Console.Write("Server message: " + receivedMessage + "\n");
        }
    }
}
