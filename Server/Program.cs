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

            if (nummer == "serveren")
            {
                MyServer server = new MyServer();
            }
            else
            {
                Console.WriteLine("Du skrev noget forkert");
            }
        }
    }
}