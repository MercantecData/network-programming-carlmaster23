using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Server_and_Client_first_asignment
{
    public class MyServer
    {
        public MyServer()
        {
            // the parameters that vil be used in the code
            int portnummer;
            int numberOfBytesRead;
            string message;
            // string beskeden;

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

            byte[] svartilbage = Encoding.UTF8.GetBytes("Det er modtaget" + "\n");
            client.GetStream().Write(svartilbage, 0, svartilbage.Length);

        }
    }
}