//Write a Program to show the inheritance
using System;

namespace InheritanceNs
{
    class Point
    {
        public int x=10;
    }
    class Circle : Point
    {
        public int x=100;
    }
    class Test
    {
        public static void Main()
        {
            Circle obj = new Circle();
            Console.WriteLine("Value of Variable x in the Class Circle : "+obj.x);//<==Access the value of x of the circle Class using the object of the Circle class.
            Console.WriteLine("Value of Variable x in the class Poitn : " + ((Point)obj).x);//<==Access the value of x of the Point Class using the object of the Circle class.
            Console.WriteLine("Now updating the values");
            obj.x = 200;////<==Update the value of x of the circle Class using the object of the Circle class.
            ((Point)obj).x = 300;//<==Update the value of x of the Point Class using the object of the Circle class.
            Console.WriteLine("VALUES ARE UPDATED");
            Console.WriteLine("Value of Variable x in the Class Circle : " + obj.x);
            Console.WriteLine("Value of Variable x in the class Point : " + ((Point)obj).x);



        }
    }
}
