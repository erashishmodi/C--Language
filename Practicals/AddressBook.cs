using System;
namespace AddressBook
{
   public class Address
    {
        public string City { get; set; }
        public string Area { get; set; }
        public int PinCode { get; set; }
        public Address ()
        {
            City = string.Empty;
            Area = string.Empty;
            PinCode = 0;
        }
       public Address(string area, string city,int pin)
        {
            City = city;
            PinCode = pin;
            Area = area;
        }
    }

   public class PostalAddress
   {
       public Address PostalAdd { set; get; }

       public PostalAddress()
       {
           PostalAdd = new Address();
       }
       public PostalAddress(string Area, string City, int PinCode)
       {
           PostalAdd = new Address();

           PostalAdd.Area = Area;
           PostalAdd.City = City;
           PostalAdd.PinCode = PinCode;
       }
   }

    public class LocalAddress
    {
        public Address LocalAdd{ get; set; }
        public LocalAddress()
        {
            LocalAdd = new Address();
         }
        public LocalAddress(string Area, string City, int PinCode)
        {
            LocalAdd = new Address(Area,City,PinCode);
        }

    }
    public class MailAddress
    {
        public string MailID { get; set; }
        public MailAddress()
        {
            MailID = string.Empty;
        }
    }
    public class ContactNo
    {
        public long MobileNo{get;set;}
        //public long MobileN
        //{
        //    set 
        //    {
        //        if ((value.ToString().Length) == 10)
        //            _MobileNo = value;
        //        else
        //            return;
        //    }
        //    get
        //    {
        //        return _MobileNo;
        //    }
        //}

    }
    public class AddressBook
    {
        public LocalAddress LOCALADDRESS { get; set; }
        public PostalAddress POSTALADDRESS { get; set; }
        public ContactNo MOBILENO { get; set; }
        public MailAddress MAILADDRESS { get; set; }
        public string Name { get; set; }
        public AddressBook()
        {
            Name = string.Empty;
            LOCALADDRESS = new LocalAddress();
            POSTALADDRESS = new PostalAddress();
            MAILADDRESS = new MailAddress();
            MOBILENO = new ContactNo();

        }

    }
   class Test
   {
       
       static void Main()
       {
           AddressBook ab = new AddressBook();
           ab.Name = "Ashish";
           ab.MAILADDRESS.MailID = "SOMETHING@SOMETHING.COM";
           ab.MOBILENO.MobileNo = 989898989898;
           ab.POSTALADDRESS.PostalAdd.Area = "MAIN BAZAR ROAD";
           ab.POSTALADDRESS.PostalAdd.City = "PATAN";
           ab.POSTALADDRESS.PostalAdd.PinCode = 384265;
           ab.LOCALADDRESS.LocalAdd.Area = "MAIN BAZAR ROAD";
           ab.LOCALADDRESS.LocalAdd.City = "PATAN";
           ab.LOCALADDRESS.LocalAdd.PinCode = 384265;
           Console.WriteLine("NAME           : "+ab.Name);
           Console.WriteLine("CONTACT NO     : "+ab.MOBILENO.MobileNo);
           Console.WriteLine("E-MAIL ADDRESS : " + ab.MAILADDRESS.MailID);
           Console.WriteLine("====Postal Address=====");
           Console.WriteLine(ab.POSTALADDRESS.PostalAdd.Area);
           Console.WriteLine(ab.POSTALADDRESS.PostalAdd.City);
           Console.WriteLine(ab.POSTALADDRESS.PostalAdd.PinCode);
           Console.WriteLine("=====Local Address=====");
           Console.WriteLine(ab.LOCALADDRESS.LocalAdd.Area);
           Console.WriteLine(ab.LOCALADDRESS.LocalAdd.City);
           Console.WriteLine(ab.LOCALADDRESS.LocalAdd.PinCode);
           



       }
   }

         
}