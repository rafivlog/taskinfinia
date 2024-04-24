namespace taskinfinia.Repository
{
    public class dbcontext
    {
        public static readonly string dbconnection = @"Data Source=RAHAT;Initial Catalog=INFINIA;Integrated Security=True;TrustServerCertificate=True";
        public static string Getconnection()
        {
            return dbconnection;
        }
    }
}
