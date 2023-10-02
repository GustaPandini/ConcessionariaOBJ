using System;
using System.Collections;
using System.IO.Pipes;
using System.Reflection;
using System.Text.Json;

namespace ConsoleApp2
{
    internal class Program
    {
        int id = 1;

        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        static void MenuPrincipal()
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

        static void AcesosMenuPrincipal()
        {
            Console.Write("Digite o numero da ação que deseja realizar = ");
            int respostaMenu = Convert.ToInt32(Console.ReadLine());

            switch (respostaMenu)
            {
                case 1:
                    CadastrarAutomovel();
                    break;
            }
        }

        static void CadastrarAutomovel()
        {
            Automovel automovel1 = new Automovel();
            Console.Write("Digite a Marca = ");
            automovel1.Marca = Console.ReadLine();
            Console.Write("Digite o Modelo = ");
            automovel1.Modelo = Console.ReadLine();
            Console.Write("Digite o PowerTrain = ");
            automovel1.Powertrain = Console.ReadLine();
            Console.Write("Digite a Versão = ");
            automovel1.Versao = Console.ReadLine();
            Console.Write("Digite a Cor = ");
            automovel1.Cor = Console.ReadLine();
            Console.Write("Digite o Ano = ");
            automovel1.Ano = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite o Ano Modelo = ");
            automovel1.AnoModelo = Convert.ToInt32(Console.ReadLine());


            List<Automovel> Lista_Automovel = new List<Automovel>();
            Lista_Automovel.Add(automovel1);

            foreach (Automovel automovel in Lista_Automovel)
            {
                Console.WriteLine(automovel.Marca);
                Console.WriteLine(automovel.Modelo);
                Console.WriteLine(automovel.Powertrain);
                Console.WriteLine(automovel.Versao);
                Console.WriteLine(automovel.Cor);
                Console.WriteLine(automovel.Ano);
                Console.WriteLine(automovel.AnoModelo);
            }

            string json = JsonSerializer.Serialize(Lista_Automovel);
            StreamWriter x;
            StreamReader y;
            String caminho = "C:\\Users\\Public\\CadastroAutomovel";


        }
    }
}