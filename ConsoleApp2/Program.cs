using ConsoleApp2.ConsoleHelper;
using ConsoleApp2.Repository;
using ConsoleApp2.Services;
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
            var repository = new AutomovelRepository();
            var service = new AutomovelService(repository);
            var console = new AutomovelConsole(service);
            try
            {
                Menu.MenuPrincipal(console);
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