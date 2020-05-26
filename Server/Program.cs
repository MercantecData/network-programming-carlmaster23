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


            }
            else if (nummer == "serveren")
            {
                server();
            }
            else
            {
                Console.WriteLine("Du skrev noget forkert");
            }
            
            static void klient()
            {
                TcpClient client = new TcpClient();

                Console.WriteLine("Skriv portnummeret");
                int portnummer = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Skriv IPadressen");
                string ipadresse = Console.ReadLine();

                IPAddress ip = IPAddress.Parse(ipadresse);

                IPEndPoint endPoint = new IPEndPoint(ip, portnummer);

                client.Connect(endPoint);

                NetworkStream stream = client.GetStream();
                Console.WriteLine("Skriv en besked til serveren");
                string text = Console.ReadLine();
                byte[] buffer = Encoding.UTF8.GetBytes(text);

                stream.Write(buffer, 0, buffer.Length);

                client.Close();
            }
            
            static void server()
            {
                int portnummer = Convert.ToInt32(Console.ReadLine());

                IPAddress ip = IPAddress.Any;
                IPEndPoint localEndpoint = new IPEndPoint(ip, portnummer);

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
    }
}
