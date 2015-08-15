using System;

namespace ArrayNs
{
    class Arraytest
    {
        public static void Main()
        {
            string[] Array = new string[3];
           System.String Str = "";
           // Console.WriteLine("Eneter Three name");
            for(int iteration=0;iteration<Array.Length;iteration++)
            {
                Console.Write("Enter Name : ");
                Str= Console.ReadLine();
                Array[iteration] = Str;
             }
            foreach(var ArrayVar in Array)
            {

                Console.Write(ArrayVar + " ");
            }
            Console.ReadKey();
        }
    }
}