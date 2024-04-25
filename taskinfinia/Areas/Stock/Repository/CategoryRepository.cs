using Dapper;
using System.Data.SqlClient;
using System.Data;
using taskinfinia.Areas.Stock.Models;
using taskinfinia.Repository;
using taskinfinia.Areas.Hrm.Models;

namespace taskinfinia.Areas.Stock.Repository
{
    public class CategoryRepository : dbcontext
    {
        public static string LoadConnectionString()
        {
            return Getconnection();
        }

        public static int Create(CategoryModel categryname)
        {
            var check = categryname.catname;
            if(check == null)
            {
                return 0;
            }
            else
            {
                var datetime = DateTime.Now;
                string response = string.Empty;
                string query = "INSERT INTO STK_Category (catname,InsertAT) VALUES (@catname,@InsertAT)";
                using (IDbConnection con = new SqlConnection(LoadConnectionString()))
                {
                    return con.Execute(query, new
                    {

                        categryname.catname,
                        InsertAT = datetime,

                    });
                }

            }



        }

        public static List<CategoryModel> getcategory()
        {
            string response = string.Empty;
            string query = "SELECT catname , InsertAT FROM STK_Category WHERE catname IS NOT NULL";
            using IDbConnection con = new SqlConnection(LoadConnectionString());
            return con.Query<CategoryModel>(query, new DynamicParameters()).ToList();



        }

       /* public static CategoryModel GetEditCategoryData(int cat_id)
        {
            string query = @"SELECT * FROM STK_Category WHERE cat_id = " + cat_id;
            using IDbConnection con = new SqlConnection(LoadConnectionString());
            return con.Query<CategoryModel>(query, new DynamicParameters()).FirstOrDefault();
        }*/


        /*public static int Update(CategoryModel categry)
        {
            var check = categry.catname;
            if (check == null)
            {
                return 0;
            }
            else
            {
                var datetime = DateTime.Now;
                string response = string.Empty;
                string query = "UPDATE  STK_Category SET catname=@catname , InsertAT=@InsertAT WHERE cat_id = @cat_id";
                using (IDbConnection con = new SqlConnection(LoadConnectionString()))
                {
                    return con.Execute(query, new
                    {

                        categry.catname,
                        InsertAT = datetime,
                        categry.cat_id

                    });
                }

            }


        }*/


       /* public static int deleteCategory(int cat_id)
        {
            string query = "DELETE  FROM STK_Category WHERE cat_id = @cat_id";
            using (IDbConnection con = new SqlConnection(LoadConnectionString()))
            {
                return con.Execute(query, new
                {
                    cat_id
                });
            }


        }*/











    }
}
