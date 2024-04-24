using System.Data.SqlClient;
using System.Data;
using taskinfinia.Areas.Hrm.Models;
using taskinfinia.Repository;
using Dapper;

namespace taskinfinia.Areas.Hrm.Repository
{
    public class DesignationRepository : dbcontext
    {
        public static string LoadConnectionString()
        {
            return Getconnection();
        }

        public static int Create(DesignationModel desname)
        {
            var datetime = DateTime.Now;
            string response = string.Empty;
            string query = "INSERT INTO HRM_Designations (designame,insertat) VALUES (@designame,@insertat)";
            using (IDbConnection con = new SqlConnection(LoadConnectionString()))
            {
                return con.Execute(query, new
                {
                    desname.designame,
                    insertat = datetime,
                });
            }

        }


        public static List<DesignationModel> getdesignation()
        {
            string response = string.Empty;
            string query = "Select designame,insertat from HRM_Designations";
            using IDbConnection con = new SqlConnection(LoadConnectionString());
            return con.Query<DesignationModel>(query, new DynamicParameters()).ToList();



        }
    }
}
