using ConsoleApp2.Entity;
using ConsoleApp2.Interfaces;

namespace ConsoleApp2.ConsoleHelper
{
    public static class Menu
    {

        public static ICrud<Automovel> automovelConsole;

        public static void Inicializar(ICrud<Automovel> console)
        {
            automovelConsole = console;
        }
        public static void MenuPrincipal()
        {
            while(true)
            {
                Console.WriteLine("Bem vindo ao sistema de controle da concessionária Tainy");
                Console.WriteLine("");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("1 = Adicionar Automóvel");
                Console.WriteLine("2 = Ver lista de Automóveis");
                Console.WriteLine("3 = Alterar Automóvel");
                Console.WriteLine("4 = Excluir Automóvel");
                Console.WriteLine("0 = Encerrar programa");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine();

                AcessosMenuPrincipal();
            }
        }

        public static void AcessosMenuPrincipal()
        {
            
            Console.Write("Digite o numero da ação que deseja realizar = ");
            if (!int.TryParse(Console.ReadLine(), out int respostaMenu))
            {
                Console.WriteLine("Opção inválida");
                return;
            }

                switch (respostaMenu)
            {
                case 1:
                    automovelConsole.Inserir();
                    break;
                case 2:
                    automovelConsole.Listar();
                    break;
                case 3:
                    automovelConsole.Alterar();
                    break;
                case 4:
                    automovelConsole.Deletar();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;

            }
        }
    }
}
