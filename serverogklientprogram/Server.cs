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
            // the parameters used in the code
            string message;
            int Numbergæt;
            bool checknumber;
            int numberOfBytesRead;
            int portnummer;
            int random;

            // typing the port you want to use in the console
            Console.WriteLine("Skriv portnummer");
            portnummer = Convert.ToInt32(Console.ReadLine());
            
            // taking your local ip adresse and using
            IPAddress ip = IPAddress.Any;
            
            // making a object with the ip and port number inside
            IPEndPoint localEndpoint = new IPEndPoint(ip, portnummer);
            
            // starting the server and it listen to all clients that want to join
            TcpListener listener = new TcpListener(localEndpoint);
            listener.Start();
            
            Console.WriteLine("Awaiting Clients");
            
            // accepting clients to server            
            TcpClient client = listener.AcceptTcpClient();
            
            // saving a random number between 1 and 101 and printing it in the console
            random = new Random().Next(1, 101);
            Console.WriteLine(random);
            
            // starting loop
            while (true)
            {
                // Receiving the message from client and Encoding it to print in console 
                NetworkStream stream = client.GetStream();
                
                byte[] buffer = new byte[256];
                numberOfBytesRead = stream.Read(buffer, 0, 256);
                message = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

                Console.WriteLine("Client message: " + message);
                
                // tjekking if it is a number, the message from client
                checknumber = Int32.TryParse(message, out Numbergæt);
                
                // tjekking if its higher, lower or the right answer to random
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

