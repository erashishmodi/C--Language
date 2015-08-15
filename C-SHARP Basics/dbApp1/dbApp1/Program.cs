using System;
using System.Data.SqlClient;

class Test
{
    static void Main()
    {
        dbApp1.Model.Emp c1 = new dbApp1.Model.Emp() { EmpNo = 102, EmpName = "Ram", JoinDate = DateTime.Now };
        if (dbApp1.Model.EmpDao.Add(c1))
            Console.WriteLine("Added");
        else
        {
            Console.WriteLine("Duplicate emp no");
        }

        dbApp1.Model.Emp result = dbApp1.Model.EmpDao.GetEmp(new dbApp1.Model.Emp { EmpNo = 10 });
        if (result != null)
            Console.WriteLine(result.EmpNo + " " + result.EmpName + " " + result.JoinDate);
    }
    static void Main1()
    {
        var CnStr = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\csnet\C--Language\dbApp1\dbApp1\SampleDb.mdf;Integrated Security=True";
        var no = 15;
        var name = "R";
        var isFound = false;
        var date = DateTime.Parse("12/3/2002");
        using(var cn= new SqlConnection(CnStr))
        using (var cmd = new SqlCommand())
        {
            cmd.CommandText = "select * from emp where eno=@eno";
            var eno = 10;
            cmd.Connection = cn; cmd.Parameters.AddWithValue("@eno", eno);
            cn.Open();
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2]);
                    isFound = true;
                }
                else
                {
                    Console.WriteLine("Record not found.");
                }
            }
            cn.Close();
        }

        if (isFound)
        {

        }
    }
}
