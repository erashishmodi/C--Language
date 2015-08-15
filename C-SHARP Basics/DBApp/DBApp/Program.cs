using System;
using System.Data.SqlClient;


namespace DBApp
{
    class Program
    {
        
        public static void Main0()
        {
            var cnstr = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ashish\Documents\GitHub\C--Language\DBApp\DBApp\StudentDB.mdf;Integrated Security=True";
            using(SqlConnection con=new SqlConnection(cnstr))
            {
                using(SqlCommand cmd=new SqlCommand())
                {
                    var sql = "delete from student where id=@sid";
                    cmd.CommandText=sql;
                    cmd.Connection=con;
                    cmd.Parameters.AddWithValue("@sid",29);
                    con.Open();
                    cmd.ExecuteNonQuery();

                }

            }
        }




        public static void MAin1()
        {
            var cnstr = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Ashish\DBApp\DBApp\StudentDB.mdf;Integrated Security=True";
            using(var con=new SqlConnection(cnstr))
            {
                using (var cmd = new SqlCommand())
                {
                    var query = "update student set name=@sname,dob=@sdob where id =@sid";
                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@sid", 10);
                    cmd.Parameters.AddWithValue("@sname", "Ashish");
                    cmd.Parameters.AddWithValue("@sdob", DateTime.Parse("11/02/1992"));
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        } 
            
            
            
            
            
            static void MAin2(string[] args)
        {
            var constr = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Ashish\DBApp\DBApp\StudentDB.mdf;Integrated Security=True";
            using (SqlConnection con=new SqlConnection(constr))
            {
                using(SqlCommand cmd=new SqlCommand())
                {
                    var sql = "insert into student values(@sid,@sname,@sdob)";
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@sid",83);
                    cmd.Parameters.AddWithValue("@sname", "Abhishek");
                    cmd.Parameters.AddWithValue("@sdob", DateTime.Parse("11/19/1991"));
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }
    }
}
