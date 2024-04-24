using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using taskinfinia.Areas.Hrm.Models;
using taskinfinia.Repository;

namespace taskinfinia.Areas.Hrm.Repository
{
  
    public class DepartmentRepository : dbcontext
    {
        public static string LoadConnectionString()
        {
            return Getconnection();
        }

        public static int Create(DepartmentModel dname)
        {
            var datetime = DateTime.Now;
            string response = string.Empty;
            string query = "INSERT INTO HRM_Departments (deptname,insertat) VALUES (@deptname,@insertat)";
            using (IDbConnection con = new SqlConnection(LoadConnectionString()))
            {
                return con.Execute(query, new
                {
                    dname.deptname,
                    insertat = datetime,
                });
            }

        }


        public static List<DepartmentModel> getdepartment()
        {
            string response = string.Empty;
            string query = "Select deptname,insertat from HRM_Departments";
            using IDbConnection con = new SqlConnection(LoadConnectionString());
            return con.Query<DepartmentModel>(query, new DynamicParameters()).ToList();



        }

    }

    
}
