using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleApp2.Entity;
using ConsoleApp2.Model;
using ConsoleApp2.Entity;
using ConsoleApp2.Interfaces;

namespace ConsoleApp2.ConsoleHelper
{
    public class Menu
    {
        
        private static Icrud<Automovel> automovel2 = new AutomovelModel();
        //public static AutomovelConsole automovel = new AutomovelConsole();
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
            AutomovelConsole automovel1 = new AutomovelConsole();
            Automovel automovel = new Automovel();
            Console.Write("Digite o numero da ação que deseja realizar = ");
            int respostaMenu = Convert.ToInt32(Console.ReadLine());

            switch (respostaMenu)
            {
                case 1:
                    automovel1.Cadastrar(automovel);
                    Console.WriteLine("Veículo cadastrado com sucesso!, pressione Enter para voltar ao menu.");
                    Console.ReadLine();
                    Console.Clear();
                    MenuPrincipal();
                    break;
                case 2:
                    automovel1.Listar();
                    MenuPrincipal();
                    break;
                case 3:
                    automovel2.Alterar();
                    MenuPrincipal();
                    break;
                case 4:
                    automovel2.Deletar();
                    MenuPrincipal();
                    break;
            }
        }
    }
}
