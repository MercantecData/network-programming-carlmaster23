using System;
using System.Text;

namespace Encoding2
{
    class Program
    {
        static void Main(string[] args)
        {
            // defining some string message for later use
            string text = "Jeg håber du er glad";
            string text2 = "Jeg øver mig lige lidt";

            // changing message from letters to bytes
            byte[] bytes2 = Encoding.ASCII.GetBytes(text2);
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            // printing the bytes to console
            foreach(byte i in bytes2)
            {
                Console.WriteLine(i);
            }

            // printing the bytes to console
            foreach (byte i in bytes)
            {
                Console.WriteLine(i);
            }

            // changing the message from bytes to letters
            string converted2 = Encoding.ASCII.GetString(bytes2);
            string converted = Encoding.UTF8.GetString(bytes);

            // printing the Encoding message
            Console.WriteLine(converted);
            Console.WriteLine(converted2);
        }
    }
}
