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
            // the parameters used in the code
            string nummer;

            // asking you to write something
            Console.WriteLine("vil du gerne være serveren eller ud");
            nummer = Console.ReadLine();

            // tjeking what you writen in the console 
            if (nummer == "serveren")
            {
                MyServer server = new MyServer();
            }
            else
            {
                Console.WriteLine("Tryk en gang mere for at lukke");
            }
        }
    }
}