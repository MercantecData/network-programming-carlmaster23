using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Collections.Generic;

namespace serverogklientprogram
{
    class Program
    {
        static void Main(string[] args)
        {
            // asking you to type something in the console
            Console.WriteLine("serveren eller tryk på en knap for at lukke");
            string statercode = Console.ReadLine();

            //tjekking if its matching anything in the if else statments
            if (statercode == "server")
            {
                MyServer Server = new MyServer();
            }
            else if(statercode == "klient")
            {
                Klienter klienter = new Klienter();
            }
            else if(statercode == "klienten")
            {
                Klienter klienten = new Klienter();
            }
            else if(statercode == "serveren")
            {
                MyServer Server = new MyServer();
            }
            else
            {
                Console.WriteLine("closing program");
            }
        }
    }
}