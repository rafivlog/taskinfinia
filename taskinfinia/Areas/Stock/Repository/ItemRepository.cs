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
            var check = item.item_name;
            if (check == null)
            {
                return 0;
            }
            else
            {
                var datetime = DateTime.Now;
                string response = string.Empty;
                string query = "Insert into STK_Stock(cat_id,qty,item_name,item_price,item_location,InsertAT) " +
                    "values (@cat_id,@qty,@item_name,@item_price,@item_location,@InsertAT)";
                using (IDbConnection con = new SqlConnection(LoadConnectionString()))
                {
                    return con.Execute(query, new
                    {
                        item.cat_id,
                        item.qty,
                        item.item_name,
                        item.item_price,
                        item.item_location,
                        InsertAT = datetime
                    });
                }
            }
            


        }

        public static List<ItemModel> GetItemList()
        {
            string response = string.Empty;
            string query = "SELECT stk.stk_id, cat.catname, stk.item_name, stk.item_price, stk.item_location, stk.qty FROM STK_Category cat INNER JOIN  STK_Stock stk ON cat.cat_id = stk.cat_id ";
            using IDbConnection con = new SqlConnection(LoadConnectionString());
            return con.Query<ItemModel>(query, new DynamicParameters()).ToList();

        }

        public static int deleteitem(int id)
        {
            string query = "DELETE  FROM STK_Stock WHERE stk_id = @id";
            using (IDbConnection con = new SqlConnection(LoadConnectionString()))
            {
                return con.Execute(query, new
                {
                    id
                });
            }


        }

        public static ItemModel GetItemlistData(int id)
        {
            string query = @"SELECT * FROM STK_Stock WHERE stk_id = " + id;
            using IDbConnection con = new SqlConnection(LoadConnectionString());
            return con.Query<ItemModel>(query, new DynamicParameters()).FirstOrDefault();
        }


        public static int Update(ItemModel itemlist)
        {
            
                var datetime = DateTime.Now;
                string response = string.Empty;
                string query = "UPDATE  STK_Stock SET item_name=@item_name ,item_price = @item_price , item_location = @item_location , InsertAT = @InsertAT , qty = @qty WHERE stk_id = @stk_id";
                using (IDbConnection con = new SqlConnection(LoadConnectionString()))
                {
                    return con.Execute(query, new
                    {
                        itemlist.item_name,
                        itemlist.item_price,
                        itemlist.item_location,
                        InsertAT = datetime,
                        itemlist.qty,
                        itemlist.stk_id,
                    });
                }



        }





    }
}
