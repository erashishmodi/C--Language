using System;

namespace LiteralsUse
{
    class LiteralsUseDemo
    {
        static void Main()
        {
           checked
            {
                long longnum = 200000 * 200000;
                Console.WriteLine(longnum);
            }
        }
    }
}
