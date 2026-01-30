using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleApp2.Entity;
using ConsoleApp2.Interfaces;
using ConsoleApp2.Repository;

namespace ConsoleApp2.ConsoleHelper
{
    public class Menu
    {
        
        private static Icrud<Automovel> automovel1 = new AutomovelConsole();
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
            
            Automovel automovel = new Automovel();
            Console.Write("Digite o numero da ação que deseja realizar = ");
            int respostaMenu = Convert.ToInt32(Console.ReadLine());

            switch (respostaMenu)
            {
                case 1:
                    automovel1.Inserir(automovel);
                    MenuPrincipal();
                    break;
                case 2:
                    automovel1.Listar();
                    MenuPrincipal();
                    break;
                case 3:
                    automovel1.Alterar(automovel);
                    MenuPrincipal();
                    break;
                case 4:
                    automovel1.Deletar(automovel);
                    MenuPrincipal();
                    break;
            }
        }
    }
}
