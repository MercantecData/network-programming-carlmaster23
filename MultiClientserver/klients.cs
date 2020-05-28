using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace MultiClientserver
{
    class klienter
    {
        public static void klienterne()
        {
            int portnummer;
            string text;
            // int beskedfraserver;
            // string serverbeskedlæsning;
            string ipadresse;

            TcpClient client = new TcpClient();

            Console.WriteLine("Skriv portnummeret");
            portnummer = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Skriv IPadressen");
            ipadresse = Console.ReadLine();

            IPAddress ip = IPAddress.Parse(ipadresse);
            IPEndPoint endPoint = new IPEndPoint(ip, portnummer);

            client.Connect(endPoint);
            bool kør = true;
            while (true)
                if (kør == true)
                {
                    NetworkStream stream = client.GetStream();
                    Console.WriteLine("Skriv en besked til serveren");
                    text = Console.ReadLine();
                    byte[] buffer = Encoding.UTF8.GetBytes(text);
                    stream.Write(buffer, 0, buffer.Length);
                }
            else
                { 
                    client.Close();
                }
            
        }
    }
}
