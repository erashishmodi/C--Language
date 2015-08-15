//in this program we will see the difference between "ref" and "out"




using System;


class MainClass
{
    static void RefCheck(ref int no1)
    {
        Console.WriteLine("The read value by ref of no1 : " + no1);
        no1 = 10;//<---you may leav the updation of variable in case of "ref"

    }
    static void OutCheck(out int no2)
    {
        //Console.WriteLine("The read value by ref of no1 : " + no1);<---INVALID because the out can not read the value
        no2 = 20;//<--you must update the value of the variable in case of "out"
    }
    static void Main()
    {
        int no1 = 1;
        Console.WriteLine("The value of no1 : " + no1);
        RefCheck(ref no1);
        Console.WriteLine("After invoking the RefCheck()... value of no1 : " + no1);
        OutCheck(out no1);
        Console.WriteLine("After invoking the OutCheck()... value of no1 : " + no1);

    }
}
