using ConsoleApp2.ConsoleHelper;
using MySql.Data.MySqlClient;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IniciarAplicacao();
        }
        private static void IniciarAplicacao()
        {
            try
            {
                Menu.MenuPrincipal();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Ocorreu um erro relacionado ao banco de dados:");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro inesperado:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}