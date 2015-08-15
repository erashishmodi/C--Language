using System;
using MySql.Data.MySqlClient; 

public class Program
{

	static void Main() 
	{
		string cs = @"server=localhost;userid=root;
            password=096310307110;database=mydb";

		MySqlConnection conn = null;
		MySqlDataReader rdr = null;

		try 
		{
			conn = new MySqlConnection(cs);
			conn.Open();

			string stm = "SELECT * FROM student";
			MySqlCommand cmd = new MySqlCommand(stm, conn);
			rdr = cmd.ExecuteReader();
			Console.WriteLine("Roll NO\t\t:\tName");
			Console.WriteLine("=======================================================================");

			while (rdr.Read()) 
			{
				Console.WriteLine(rdr.GetInt32(0)+"\t\t:\t"+rdr.GetString(1));
			}

		} catch (MySqlException ex) 
		{
			Console.WriteLine (ex.ToString());
		}
	}
}