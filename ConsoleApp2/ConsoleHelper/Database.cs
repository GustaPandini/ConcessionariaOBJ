using MySql.Data.MySqlClient;
using System.Configuration;
using Dapper;


namespace ConsoleApp2.ConsoleHelper
{
    internal class Database
    {
        protected string conectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(conectionString);
        }

        protected int Execute(string sql, object obj)
        {
            using (MySqlConnection conexao = GetConnection())
            {
                return conexao.Execute(sql, obj);
            }
        }
    }
}
