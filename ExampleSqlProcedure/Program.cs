using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ExampleSqlProcedure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Test("AED","Dirham");
        }
        SqlConnection sqlCon = null;
        public string SqlconString = "Data Source=DESKTOP-VN7Q25S\\SQLEXPRESS;Initial Catalog=Store;Integrated Security=True";
        //String SqlconString = ConfigurationManager.ConnectionStrings["Data Source=DESKTOP-VN7Q25S\\SQLEXPRESS;Initial Catalog=Store;Integrated Security=True"].ConnectionString;
        public void Test(string Curr, string Details)
        {
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("Proc_AddData", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@curr", SqlDbType.NVarChar).Value = Curr;
                sql_cmnd.Parameters.AddWithValue("@details", SqlDbType.VarChar).Value = Details;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
    }
}