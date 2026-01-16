using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Menu
    {
        public static void MenuPrincipal()
        {
            Console.WriteLine("Bem vindo ao sistema de controle da concessionária Tainy");
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1 = Adicionar Automóvel");
            Console.WriteLine("2 = Ver lista de Automóveis");
            Console.WriteLine("3 = Realizar uma venda");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();

            AcesosMenuPrincipal();
        }

        public static void AcesosMenuPrincipal()
        {
            Automovel automovel = new Automovel();
            Console.Write("Digite o numero da ação que deseja realizar = ");
            int respostaMenu = Convert.ToInt32(Console.ReadLine());

            switch (respostaMenu)
            {
                case 1:
                    automovel.CadastrarCarro();
                    MenuPrincipal();
                    break;
                case 2:
                    automovel.MostrarAutomovel();
                    MenuPrincipal();
                    break;
                case 3:

                    break;
            }
        }

        public static void CadastrarAutomovel()
        {


            Automovel automovel = new Automovel();
            automovel.CadastrarCarro();


            Console.WriteLine("Ok seu Automovel foi cadastrado, Pressione ENTER para retornar ao Menu!");
            Console.ReadLine();
            Console.Clear();
        }

        

    }
}
