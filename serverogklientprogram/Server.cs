using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Collections.Generic;

namespace serverogklientprogram
{
    public class MyServer
    {
        public List<TcpClient> clients = new List<TcpClient>();
        public MyServer()
        {
            Console.WriteLine("Skriv portnummer");
            int portnummer = Convert.ToInt32(Console.ReadLine());
            
            IPAddress ip = IPAddress.Any;
            
            IPEndPoint localEndpoint = new IPEndPoint(ip, portnummer);
            
            TcpListener listener = new TcpListener(localEndpoint);
            listener.Start();
            
            Console.WriteLine("Awaiting Clients");
            
            TcpClient client = listener.AcceptTcpClient();
            
            int random = new Random().Next(1, 101);
            Console.WriteLine(random);
            
            while (true)
            {
                NetworkStream stream = client.GetStream();
                
                byte[] buffer = new byte[256];
                int numberOfBytesRead = stream.Read(buffer, 0, 256);
                string message = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

                Console.WriteLine("Client message: " + message);
                
                int Numbergæt;
                bool checknumber = Int32.TryParse(message, out Numbergæt);
                
                if (checknumber)
                {
                    if (Numbergæt < random)
                    {

                        byte[] højtnummer = Encoding.UTF8.GetBytes("Dit nummer er højere" + "\n");
                        client.GetStream().Write(højtnummer, 0, højtnummer.Length);

                    }

                    else if (Numbergæt > random)
                    {
                        byte[] lavtnummer = Encoding.UTF8.GetBytes("Det er lavere" + "\n");
                        client.GetStream().Write(lavtnummer, 0, lavtnummer.Length);
                    }
                    
                    else
                    {
                        byte[] rigtigttal = Encoding.UTF8.GetBytes("You guessed it, the number was " + random + "\n");
                        client.GetStream().Write(rigtigttal, 0, rigtigttal.Length);

                    }
                }
            }
        }
    }
}

