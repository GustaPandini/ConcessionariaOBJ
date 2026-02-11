using ConsoleApp2.Entity;
using ConsoleApp2.Interfaces;

namespace ConsoleApp2.ConsoleHelper
{
    public class Menu
    {
        
        private static Icrud<Automovel> automovelConsole = new AutomovelConsole();
        public static void MenuPrincipal()
        {
            Console.WriteLine("Bem vindo ao sistema de controle da concessionária Tainy");
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1 = Adicionar Automóvel");
            Console.WriteLine("2 = Ver lista de Automóveis");
            Console.WriteLine("3 = Alterar Automóvel");
            Console.WriteLine("4 = Excluir Automóvel");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();

            AcesosMenuPrincipal();
        }

        public static void AcesosMenuPrincipal()
        {
            
            Console.Write("Digite o numero da ação que deseja realizar = ");
            int respostaMenu = Convert.ToInt32(Console.ReadLine());

            switch (respostaMenu)
            {
                case 1:
                    automovelConsole.Inserir();
                    MenuPrincipal();
                    break;
                case 2:
                    automovelConsole.Listar();
                    MenuPrincipal();
                    break;
                case 3:
                    automovelConsole.Alterar();
                    MenuPrincipal();
                    break;
                case 4:
                    automovelConsole.Deletar();
                    MenuPrincipal();
                    break;
            }
        }
    }
}
