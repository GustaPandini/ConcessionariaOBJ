using System;
using System.Collections;
using System.IO.Pipes;
using System.Reflection;
using System.Text.Json;
using ConsoleApp2.ConsoleHelper;
using MySql.Data.MySqlClient;
using Mysqlx.Prepare;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Menu.MenuPrincipal();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Erro MySql");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro");
                Console.WriteLine(ex.Message);
            }

        }

    }
}