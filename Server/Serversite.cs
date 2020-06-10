using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Server
{
        public class MyServer
        {
            public MyServer()
            {
                // the parameters that vil be used in the code
                int portnummer;
                int numberOfBytesRead;
                string message;
                string IP;
                
            // Console.writeline print a message to console and after the user types a portnumber
                Console.WriteLine("Skriv portnummer");
                portnummer = Convert.ToInt32(Console.ReadLine());

            // print line in the console and tries to parse the ip from console.readline(IP);
                Console.WriteLine("Skriv ip");
                IP = Console.ReadLine();
                IPAddress ip = IPAddress.Parse(IP);
                
            // setting and saving port and ip in localEndpoint
                IPEndPoint localEndpoint = new IPEndPoint(ip, portnummer);

            // set to listen to ip ports that match the port and ip in localEndpoint
                TcpListener listener = new TcpListener(localEndpoint);
                listener.Start();
                
            // awaiting the client to connect to the server 
                Console.WriteLine("Awaiting Clients");
                TcpClient client = listener.AcceptTcpClient();

            // getting the message from the client and Encoding it from numbers to letters again
                NetworkStream stream = client.GetStream();

                byte[] buffer = new byte[256];

                numberOfBytesRead = stream.Read(buffer, 0, 256);

                message = Encoding.UTF8.GetString(buffer, 0,
                numberOfBytesRead);
            // printing the message from client to console
                Console.WriteLine(message);

            // sends a message back to client after getting and printing the message from client to console
                byte[] svartilbage = Encoding.UTF8.GetBytes("Det er modtaget" + "\n");
                client.GetStream().Write(svartilbage, 0, svartilbage.Length);

            }
        }
    }