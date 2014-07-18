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
            StaticContainer obj2 = new StaticContainer();   //<--another object is created
            obj1.no2 = 2000;
            obj2.no2 = 1555;
            StaticContainer.no1 = 55;
            System.Console.WriteLine("OBJECT1.NO2 : " + obj1.no2);
            System.Console.WriteLine("OBJECT2.NO2 : " + obj2.no2);
            System.Console.WriteLine("StaticContainer.NO1 : " + StaticContainer.no1);
        }
    }
}
