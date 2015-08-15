using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbApp1.Model
{
    public class EmpDao
    {
        public static bool Add(Emp emp)
        {
            if (EmpDao.FindByEmpNo(emp))
                return false;
            using (var cn = new SqlConnection(Config.CnStr))
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = cn;
                cmd.CommandText = "insert into emp values (@p1,@p2,@p3)";
                cmd.Parameters.AddWithValue("@p1", emp.EmpNo);
                cmd.Parameters.AddWithValue("@p2", emp.EmpName);
                cmd.Parameters.AddWithValue("@p3", emp.JoinDate);
                cn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
        }
        public static bool Update(Emp emp)
        {
            if (!EmpDao.FindByEmpNo(emp))
                return false;
            using (var cn = new SqlConnection(Config.CnStr))
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = cn;
                cmd.CommandText = "update emp set ename=@p2,edate=@p3 where eno=@p1";
                cmd.Parameters.AddWithValue("@p1", emp.EmpNo);
                cmd.Parameters.AddWithValue("@p2", emp.EmpName);
                cmd.Parameters.AddWithValue("@p3", emp.JoinDate);
                cn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        public static bool FindByEmpNo(Emp emp)
        {
            using (var cn = new SqlConnection(Config.CnStr))
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = cn;
                cmd.CommandText = "select eno from emp where eno=@p1";
                cmd.Parameters.AddWithValue("@p1", emp.EmpNo);

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                        return true;
                }
                return false;
            }
        }

        public static Emp GetEmp(Emp emp)
        {
            using (var cn = new SqlConnection(Config.CnStr))
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = cn;
                cmd.CommandText = "select * from emp where eno=@p1";
                cmd.Parameters.AddWithValue("@p1", emp.EmpNo);

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new Emp
                        {
                            EmpNo = dr.GetInt32(0),
                            EmpName = dr.GetString(1),
                            JoinDate = dr.GetDateTime(2)
                        };
                    }

                }
                return null;
            }
        }
    }
}
