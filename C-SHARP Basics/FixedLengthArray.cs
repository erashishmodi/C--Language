using System;

namespace ArrayNs
{
    class ArraTest
    {
        public static void Main()
        {
            int[] Digit;
            Digit= new int[]{0,1,2,3,4,5,6,7,8,9};
            string[] WeekDays={"sunday","monday","Tues Day","Wednesday","Thursday","Friday","Saturday"};
            string[] Months = new System.String[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            Console.WriteLine("Total Months : " + Months.Length);
            Console.WriteLine("Lenngth Of the WeekDay Array : "+WeekDays.Length);
            Console.WriteLine("Lenngth Of the Digit Array   : " + Digit.Length);
            Console.WriteLine("**********************Week Days**********************");
            foreach (System.String start in WeekDays)
            {
                Console.WriteLine("\t\t"+start);
            }
            Console.WriteLine("*********************Months******************************");
            foreach (dynamic a in Months)
            {
                Console.WriteLine("\t\t" + a);
            }

            Console.WriteLine("*****************DIGIT ARRAY**************************");
                foreach(var dgt in Digit)
                    Console.WriteLine("\t\t"+dgt);
        }
    }
}