using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Server_and_Client_first_asignment
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hvad vil du gerne være serveren eller klienten");
            string svar = Console.ReadLine();

            if (svar == "serveren")
            {
                MyServer server = new MyServer();
            }
            else if(svar == "klienten")
            {
                Klienten klient = new Klienten();
            }
            else
            {
                Console.WriteLine("Du skrev noget forkert");
            }
        }
    }
}
