using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Klient

{
    public class Program
    {
        static void Main(string[] args)
        {
            // the parameters used in the code
            string svar;

            // asking you to write something
            Console.WriteLine("Hvad vil du gerne være serveren eller klienten");
            svar = Console.ReadLine();

            // tjeking what you writen in the console 
            if (svar == "klienten")
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
