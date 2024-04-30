using Dapper;
using System.Data.SqlClient;
using System.Data;
using taskinfinia.Areas.Hrm.Models;
using taskinfinia.Repository;

namespace taskinfinia.Areas.Hrm.Repository
{
    public class DropDownRepository :dbcontext
    {
        public static string LoadConnectionString()
        {
            return Getconnection();
        }

        public static IEnumerable<DropDownModel> Getdepartment()
        {
            string query = "SELECT dept_id as id ,deptname  as dd_value FROM HRM_Departments;";

            using (IDbConnection connection = new SqlConnection(LoadConnectionString()))
            {
                return connection.Query<DropDownModel>(query, new DynamicParameters()).ToList();
            }
        } 
        
        public static IEnumerable<DropDownModel> Getdesignation()
        {
            string query = "SELECT desig_id as id ,designame  as dd_value FROM HRM_Designations;";

            using (IDbConnection connection = new SqlConnection(LoadConnectionString()))
            {
                return connection.Query<DropDownModel>(query, new DynamicParameters()).ToList();
            }
        } 
        
        public static IEnumerable<DropDownModel> GetEmployeeName()
        {
            string query = "SELECT id as id ,empname  as dd_value FROM HRM_Employees";

            using (IDbConnection connection = new SqlConnection(LoadConnectionString()))
            {
                return connection.Query<DropDownModel>(query, new DynamicParameters()).ToList();
            }
        }
    }
}
