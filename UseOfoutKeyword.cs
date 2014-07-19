// In this program we will see the use of "out"keyword to call a method using call by reference


using System;


class RefTest
{
    static void RefMethod( int no1,out int no2)
    {
        no1 = 51;
        no2 = 52;
    }
    static void Main()
    {
        int no1=1, no2=2;
        Console.WriteLine("The value of no1 is {0} and no2 is {1}.", no1, no2);
        RefMethod( no1, out no2);
        Console.WriteLine("After invoking the RefMethod the vakue of no1 is {0} and  no2 is {1}.", no1, no2);
        
    }
}
