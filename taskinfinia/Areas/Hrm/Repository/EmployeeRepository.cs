using System.Data.SqlClient;
using System.Data;
using taskinfinia.Areas.Hrm.Models;
using taskinfinia.Repository;
using Dapper;

namespace taskinfinia.Areas.Hrm.Repository
{
    public class EmployeeRepository : dbcontext
    {
        public static string LoadConnectionString()
        {
            return Getconnection();
        }

        public static int Create(EmployeeModel employee)
        {
            string response = string.Empty;
            string query = "Insert into HRM_Employees(empname,dtjoin,dtbirth,dept_id,desig_id,salary,emp_status,address,email,password) " +
                "values (@empname,@dtjoin,@dtbirth,@dept_id,@desig_id,@salary,@emp_status,@address,@email,@password )";
            using (IDbConnection con = new SqlConnection(LoadConnectionString()))
            {
                return con.Execute(query, new
                {

                    employee.empname,
                    employee.dtjoin,
                    employee.dtbirth,
                    employee.dept_id,
                    employee.desig_id,
                    employee.salary,
                    employee.emp_status,
                    employee.address,
                    employee.email,
                    employee.password
                });
            }


        }

        public static List<EmployeeModel> getemployeelist()
        {
            string response = string.Empty;
            string query = "SELECT e.empname, d.deptname, dg.designame,e.email,e.dtjoin,e.dtjoin,e.salary,e.emp_status,e.dtbirth FROM   HRM_Employees e INNER JOIN HRM_Departments d ON e.dept_id = d.dept_id INNER JOIN HRM_Designations dg ON e.desig_id = dg.desig_id;";
            using IDbConnection con = new SqlConnection(LoadConnectionString());
            return con.Query<EmployeeModel>(query, new DynamicParameters()).ToList();
        }


    }
}
