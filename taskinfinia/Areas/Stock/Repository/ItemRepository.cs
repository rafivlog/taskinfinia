using System.Data.SqlClient;
using System.Data;
using taskinfinia.Areas.Stock.Models;
using taskinfinia.Repository;
using Dapper;

namespace taskinfinia.Areas.Stock.Repository
{
    public class ItemRepository:dbcontext
    {
        public static string LoadConnectionString()
        {
            return Getconnection();
        }

        public static int Create(ItemModel item)
        {
            string response = string.Empty;
            string query = "Insert into STK_Stock(cat_id,item_name,item_price,qty,item_location) " +
                "values (@cat_id,@item_name,@item_price,@qty,@item_location)";
            using (IDbConnection con = new SqlConnection(LoadConnectionString()))
            {
                return con.Execute(query, new
                {
                    item.cat_id,
                    item.item_name,
                    item.item_price,
                    item.qty,
                    item.item_location,
                });
            }


        }

        public static List<ItemModel> GetItemList()
        {
            string response = string.Empty;
            string query = "SELECT cat.catname, stk.item_name, stk.item_price, stk.item_location, stk.qty FROM STK_Category cat INNER JOIN  STK_Stock stk ON cat.cat_id = stk.cat_id ";
            using IDbConnection con = new SqlConnection(LoadConnectionString());
            return con.Query<ItemModel>(query, new DynamicParameters()).ToList();

        }





    }
}
