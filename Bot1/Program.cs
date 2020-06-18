using System;

namespace Bot1
{
    class Program
    {
        static void Bot1(string obj)
        {
            Console.WriteLine(obj);
        }
        static void Main(string[] args)
        {
           ChatBot bot =new ChatBot(@"C:\Users\Николай\Desktop\otr.txt");
            bot.GetStr += Bot1;
            while(true)
            {
                string s = Console.ReadLine();
                bot.Ans(s);
            }
        }
    }
}
