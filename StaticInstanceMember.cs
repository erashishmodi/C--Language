using System;


namespace ClassDemo
{
   public class StaticContainer
    {
       public static int no1;   //<---This variable will automatically initialized with 0
       public int no2;                 //<---This variable will automatically initialized with 0
    }
    class MainClass
    {
        static void Main()
        {
            System.Console.WriteLine("Static member : "+StaticContainer.no1);  //<--static members are accessible with its class name.
            //System.Console.WriteLine(StaticContainer.no2);  //<--this will throw error because here we need to create a variable type of the class name
            StaticContainer obj1;   //<--variable declared to referance to the class StaticContainer
            obj1 = new StaticContainer();   //<--heap  memory allocated to the variable obj1
            System.Console.WriteLine("Instance member : " + obj1.no2);
        }
    }
}
