using System;

namespace AddressBook
{
	public class Address 
	{
		public string City{ get; set;}
		public string Area{ set; get; }
		public string State{ get; set; }
		public int Pincode{ set; get; }
		public Address()
		{
			City = string.Empty;
			Area = string.Empty;
			State = string.Empty;
		}

	}
	public class  ContactDetails
	{
		public string MailId{get;set;}
		public long MobileNo{ get; set;}
		public ContactDetails ()
		{
			MailId = string.Empty;
		}

	}
	public class Addressbook
	{
		public Address PostalAddress{ get; set;}
		public Address LocalAddress{ get; set;}
		public ContactDetails ContactDetail{ get; set;}
		public String Name{ get; set;}
		public Addressbook()
		{
			Name = string.Empty;
			PostalAddress = new Address ();
			LocalAddress = new Address ();
			ContactDetail = new ContactDetails ();
		}

	}




	class MainClass
	{
		public static void Main (string[] args)
		{
			Addressbook a = new Addressbook ();
			a.Name = "Ashish";
			a.ContactDetail.MailId = "something@something.com";
			a.ContactDetail.MobileNo = 89988998899;
			a.PostalAddress.Area="MAIN BAZAR ROAD";
			a.PostalAddress.City = "PATAN";
			a.PostalAddress.State = "GUJARAT";
			a.PostalAddress.Pincode = 384265;
			a.PostalAddress.Area = "MAIN BAZAR ROAD";
			a.LocalAddress.City = "PATAN";
			a.LocalAddress.State = "GUJARAT";
			a.LocalAddress.Pincode = 384265;
			Console.WriteLine ("Name         : " + a.Name);
			Console.WriteLine ("Mobile No    : " + a.ContactDetail.MobileNo);
			Console.WriteLine ("Mail Address : " + a.ContactDetail.MailId);
			Console.WriteLine ("========Postal Address=======");
			Console.WriteLine (a.PostalAddress.Area);
			Console.WriteLine (a.PostalAddress.City);
			Console.WriteLine (a.PostalAddress.State);
			Console.WriteLine (a.PostalAddress.Pincode);
			Console.WriteLine ("========Local Address========");
			Console.WriteLine (a.LocalAddress.Area);
			Console.WriteLine (a.LocalAddress.City);
			Console.WriteLine (a.LocalAddress.State);
			Console.WriteLine (a.LocalAddress.Pincode);

		}
	}
}
