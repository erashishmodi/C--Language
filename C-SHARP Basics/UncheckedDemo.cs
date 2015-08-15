using System;

namespace LiteralsUse
{
    class LiteralsUseDemo
    {
        static void Main()
        {
           unchecked
            {
                long longnum = 200000 * 200000;
                Console.WriteLine(longnum);
            }
        }
    }
}
