using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp.Model
{
    class studentdao
    {
        public static bool add(Student student)
        {
            using (var con = new SqlConnection(config.connectionstring))
            {
                using (var cmd = new SqlCommand())
                {
                    var sql = "insert into student values(@id,@name,@dob)";
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@id",student.Id);
                    cmd.Parameters.AddWithValue("@name",student.Name);
                    cmd.Parameters.AddWithValue("@dob", student.Dob);
                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }
            return true;

        }
        public static bool delete(Student student)
        {
            using(var con=new SqlConnection(Model.config.connectionstring))
            {
                using(var cmd=new SqlCommand())
                {
                    var sql = "delete from student where id=@id";
                    cmd.Connection = con;
                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("@id", student.Id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }
        public static bool update(Student student)
        {
            using(SqlConnection con =new SqlConnection(Model.config.connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    var sql = "update student set name=@name,dob=@dob where id= @id";
                    cmd.CommandText = sql;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@name",student.Name);
                    cmd.Parameters.AddWithValue("@id",student.Id);
                    cmd.Parameters.AddWithValue("dob",student.Dob);
                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }
            return true;
        }
        public static bool listtall (Student student)
        {
            using(SqlConnection con=new SqlConnection(Model.config.connectionstring))
            {
                using(SqlCommand cmd=new SqlCommand())
                {
                    cmd.CommandText = "select * from student";
                    cmd.Connection = con;
                    con.Open();
                    using(SqlDataReader dr=cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            Console.WriteLine(dr[0]+"\t"+dr["name"]+"\t"+dr.GetDateTime(2).ToString("dd-MMM-yyy"));
                        }
                    }
                }
            }
            return true;
        }
        public static bool findby(Student student)
        {
            using(SqlConnection con=new SqlConnection(Model.config.connectionstring))
            {
                using(SqlCommand cmd=new SqlCommand())
                {
                    var sql = "Select * from student where id=@id";
                    cmd.Connection = con;
                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("@id", student.Id);
                    con.Open();
                    using (SqlDataReader dr=cmd.ExecuteReader())
                    {
                        if(dr.Read())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static Student Select(Student student)
        {
            using(SqlConnection con=SqlConnection(config.connectionstring))
            {
                using(SqlCommand cmd=new SqlCommand())
                {

                   cmd.CommandText = "select * from student where id=@id";


                }
            }
            return null;
        }
    }
}
