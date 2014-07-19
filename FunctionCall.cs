//This program wiil illustrate the approach of calling the functions by value and referene in c#
using System;

class Test
{
    public int no;
}
class MainClass
{
    static int CheckValue(int num)
    {
        num = 90;
        return num;
    }
    static void CheckRef(Test refobj)
    {
        refobj.no = 100;
    }


    static void Main()
    {
        int no1;
        no1 = 10;
        Console.WriteLine("The value of No1 in main block : " + no1); //out put will be 10
        CheckValue(no1);
        Console.WriteLine("The value of No1 after invoking SetValue () : " + no1);   //out put will be 10
        //Console.WriteLine("Invoked in the write function : "+CheckValue(0));
        /*---------This will change the output----------------------------
        no1=CheckValue(no1);
        console.Writeline("The value of No1 after invoking SetValue()"+no1);
        */
        Test obj = new Test();
        obj.no = 400;
        Console.WriteLine("The value of obj.no : " + obj.no);//output will be 400
        CheckRef(obj);
        Console.WriteLine("After calling the checkRef the value of obj.no : " + obj.no);//100
    }
}
