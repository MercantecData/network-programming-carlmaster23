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
                int portnummer;
                string text;
                int beskedfraserver;
                string serverbeskedlæsning;
                string ipadresse;

                TcpClient client = new TcpClient();

                Console.WriteLine("Skriv portnummeret");
                portnummer = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Skriv IPadressen");
                ipadresse = Console.ReadLine();

                IPAddress ip = IPAddress.Parse(ipadresse);
                IPEndPoint endPoint = new IPEndPoint(ip, portnummer);

                client.Connect(endPoint);

                NetworkStream stream = client.GetStream();

                Console.WriteLine("Skriv en besked til serveren");
                text = Console.ReadLine();

                byte[] buffer = Encoding.UTF8.GetBytes(text);

                stream.Write(buffer, 0, buffer.Length);

                TcpListener fåbeskendtilbage = new TcpListener(endPoint);
                fåbeskendtilbage.Start();

                Console.WriteLine("Awaiting Clients");
                TcpClient server2 = fåbeskendtilbage.AcceptTcpClient();

                NetworkStream klientsvares = server2.GetStream();

                byte[] serverbesked = new byte[256];
                beskedfraserver = stream.Read(serverbesked, 0, 256);
                serverbeskedlæsning = Encoding.UTF8.GetString(serverbesked, 0, beskedfraserver);
                Console.WriteLine(serverbeskedlæsning);

                client.Close();
            }


            static void server()
            {
                // the parameters that vil be used in the code
                int portnummer;
                int numberOfBytesRead;
                string message;
                string beskeden;


                TcpClient server2 = new TcpClient();

                Console.WriteLine("Skriv portnummer");
                portnummer = Convert.ToInt32(Console.ReadLine());

                IPAddress ip = IPAddress.Any;
                IPEndPoint localEndpoint = new IPEndPoint(ip, portnummer);

                TcpListener listener = new TcpListener(localEndpoint);
                listener.Start();

                Console.WriteLine("Awaiting Clients");
                TcpClient client = listener.AcceptTcpClient();

                NetworkStream stream = client.GetStream();

                byte[] buffer = new byte[256];

                numberOfBytesRead = stream.Read(buffer, 0, 256);

                message = Encoding.UTF8.GetString(buffer, 0,
                numberOfBytesRead);

                Console.WriteLine(message);

                server2.Connect(localEndpoint);

                NetworkStream klientsvares = server2.GetStream();
                beskeden = "Tak for din tid";
                byte[] beskedtilklient = Encoding.UTF8.GetBytes(beskeden);
                stream.Write(beskedtilklient, 0, beskedtilklient.Length);
            }
        }
    }
}