// In this program we will see the use of "ref"keyword to call a method using call by reference


using System;


class RefTest
{
    static void RefMethod(ref int no1,int no2)
    {
        no1 = 21;
        no2 = 22;
    }
    static void Main()
    {
        int no1=1, no2=2;
        Console.WriteLine("The value of no1 is {0} and no2 is {1}.", no1, no2);
        RefMethod(ref no1, no2);
        Console.WriteLine("After invoking the RefMethod the vakue of no1 is {0} and  no2 is {1}.", no1, no2);
        
    }
}
