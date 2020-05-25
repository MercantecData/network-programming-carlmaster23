using System;
using System.Text;

namespace Encoding2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Jeg håber du er glad";
            string text2 = "Jeg øver mig lige lidt";

            byte[] bytes2 = Encoding.ASCII.GetBytes(text2);
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            foreach(byte i in bytes2)
            {
                Console.WriteLine(i);
            }

            foreach(byte i in bytes)
            {
                Console.WriteLine(i);
            }

            string converted2 = Encoding.ASCII.GetString(bytes2);

            string converted = Encoding.UTF8.GetString(bytes);

            Console.WriteLine(converted);

            Console.WriteLine(converted2);
        }
    }
}
