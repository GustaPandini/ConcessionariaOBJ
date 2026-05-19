using ConsoleApp2.Entity;
using ConsoleApp2.Interfaces;

namespace ConsoleApp2.ConsoleHelper
{
    public static class Menu
    {

        public static void MenuPrincipal(ICrud<Automovel> console)
        {
            while (true)
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

                AcessosMenuPrincipal(console);
            }
        }

        public static void AcessosMenuPrincipal(ICrud<Automovel> console)
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
                    console.Inserir();
                    break;
                case 2:
                    console.Listar();
                    break;
                case 3:
                    console.Alterar();
                    break;
                case 4:
                    console.Deletar();
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
