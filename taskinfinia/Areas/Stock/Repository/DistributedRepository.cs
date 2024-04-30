using System.Data.SqlClient;
using System.Data;
using taskinfinia.Areas.Stock.Models;
using taskinfinia.Repository;
using Dapper;

namespace taskinfinia.Areas.Stock.Repository
{
    public class DistributedRepository : dbcontext
    {
        public static string LoadConnectionString()
        {
            return Getconnection();
        }

        public static int Create(DistributedModel item)
        {
            string response = string.Empty;
            string query = "Insert into STK_Distributed(id,cat_id,stk_id,qty,distributed_date,remarks) " +
                "values (@id,@cat_id,@stk_id,@qty,@distributed_date,@remarks)" +
                "UPDATE STK_Stock SET qty = ((SELECT COALESCE(qty, 0) FROM STK_Stock WHERE stk_id = @stk_id) -  (SELECT COALESCE(SUM(qty), 0) FROM STK_Distributed WHERE stk_id = @stk_id)) WHERE stk_id = @stk_id;";
            using (IDbConnection con = new SqlConnection(LoadConnectionString()))
            {
                return con.Execute(query, new
                {
                    item.id,
                    item.cat_id,
                    item.stk_id,
                    item.qty,
                    item.distributed_date,
                    item.remarks,
                });
            }

        }
        public static List<DistributedModel> GetDistributedList()
        {
            string response = string.Empty;
            string query = "SELECT  (SELECT empname FROM HRM_Employees WHERE id = STK_Distributed.id) AS empname, (SELECT catname FROM STK_Category WHERE cat_id = STK_Distributed.cat_id) AS catname, (SELECT item_name FROM STK_Stock WHERE stk_id = STK_Distributed.stk_id) AS item_name, qty, distributed_date FROM   STK_Distributed;";
            using IDbConnection con = new SqlConnection(LoadConnectionString());
            return con.Query<DistributedModel>(query, new DynamicParameters()).ToList();


        }






    }
}
