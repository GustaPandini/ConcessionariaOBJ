using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ConsoleApp2.ConsoleHelper
{
    internal class Database
    {
        protected string conectionString = "Server=localhost;Database=concesionaria;Uid=root;Pwd=2017;";

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
