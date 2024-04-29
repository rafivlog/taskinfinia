using Dapper;
using System.Data.SqlClient;
using System.Data;
using taskinfinia.Repository;
using taskinfinia.Areas.Stock.Models;

namespace taskinfinia.Areas.Stock.Repository
{
    public class DropDownRepository : dbcontext
    {

        public static string LoadConnectionString()
        {
            return Getconnection();
        }
        public static IEnumerable<DropDownModel> GetCategoryName()
        {
            string query = "SELECT cat_id AS id, catname AS dd_value FROM STK_Category";

            using (IDbConnection connection = new SqlConnection(LoadConnectionString()))
            {
                return connection.Query<DropDownModel>(query, new DynamicParameters()).ToList();
            }
        }
    }
}
