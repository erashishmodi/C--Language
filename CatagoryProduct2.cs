using System;

namespace CatagoryProduct
{
    public class Catagory
    {
        private int id;
        private string name;

        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public string Name
        {
            set { name= value; }
            get { return name; }
        }

      }
    public class Product
    {
        private int id;
        private string name;
        private decimal rate;
        private int qty;
        private decimal ammount;
        private Catagory _catagory;

        public Catagory catagory
        {
            get { return _catagory; }
            set { _catagory = value; }
        }


        public int Id
        {
            set { id = value; }
            get { return id; }

        }

        public string Name
        {
            set { name = value; }
            get { return name; }

        }

        public decimal Rate
        {
            set { rate = value; }
            get { return rate; }
        }
        public int Qty 
        {
         
            set
            {qty=value; }
            get {return qty;}
        }


        public decimal AmMount
        {
           get{
               return rate * qty;
           }
        }


        public Product()
        {
            _catagory = new Catagory();
        }


        }

    public class MainClass
    {
        static void Main()
        {
            Product p =new Product();
              p.catagory.Id=01;
            p.catagory.Name="PEN";
            p.Name="CELLO GRIPPER";
            p.Id=011;
            p.Qty=12;
            p.Rate=5.5M;
            Console.WriteLine("CATAGORY ID      : "+p.catagory.Id);
            Console.WriteLine("CATAGORY NAME    : "+p.catagory.Name);
            Console.WriteLine("PRODUCT ID       : "+p.Id);
            Console.WriteLine("PRODUCT NAME     : "+p.Name);
            Console.WriteLine("PRODUCT QUANTITY : "+p.Qty);
            Console.WriteLine("PRODUCT RATE     : "+p.Rate);
            Console.WriteLine("TOTAL AMMOUNT    : "+p.AmMount);

        }
    }

}
