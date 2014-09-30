using System;

namespace ClassImplementation
{
   public class Catagory
    {
      public  int id { get; set; }
       public string name { get; set; }

    }
  public  class Product

    {
       public int id{get ;set;}

      public  string name{get ;set;}

        public double rate{get ; set;}

       public int qty{get;set;}

        public Catagory catagory{get;set;}
        public double ammount;
      public double Ammount
        {
            set { ammount = value;}

            get { return rate * qty; }
        }

        public Product()
        {
            catagory= new Catagory();
        }

    }
    class MainClass
    {
        static void Main()
        {
            Product p=new Product();
            p.catagory.id=1;
            p.catagory.name = "pen";
            p.id = 01;
            p.name = "Cello gripper";
            p.qty = 10;
            Console.WriteLine("ENTER THE RATE");
            p.rate = 5;
            Console.WriteLine("CATAGORY ID      : "+p.catagory.id);
            Console.WriteLine("CATAGORY NAME    : "+ p.catagory.name);
            Console.WriteLine("PRODUCT NAME     : "+p.name);
            Console.WriteLine("PRODUCT RATE     : "+p.rate);
            Console.WriteLine("PRODUCT QUANTITY : "+p.qty);
            Console.WriteLine("TOTAL AMMOUNT    : "+p.Ammount);
        }
    }
}
