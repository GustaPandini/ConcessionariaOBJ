using System;
using System.Collections;
using System.IO.Pipes;
using System.Reflection;
using System.Text.Json;

namespace ConsoleApp2
{
    internal class Program
    {
        int AUTid = 1;
        List<Automovel> Lista_Automovel = new List<Automovel>();

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
                case 2:
                    MostrarEstoque();
                    break;
                case 3:

                    break;
            }
        }

        static void CadastrarAutomovel()
        {

            Automovel.LerArquivo();

            Automovel.CadastrarCarro();

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

            StreamWriter x;
            x = File.CreateText(caminho);
            json = JsonSerializer.Serialize(Lista_Automovel);
            x.Write(json);
            x.Close();
        }

        static void MostrarEstoque()
        {
            String caminho = "C:\\Users\\Public\\CadastroAutomovel";
            List<Automovel> Lista_Automovel = new List<Automovel>();
            StreamReader y;
            y = File.OpenText(caminho);
            string json = y.ReadLine();
            Lista_Automovel = JsonSerializer.Deserialize<List<Automovel>>(json);
            y.Close();
            Console.WriteLine("Aqui está o estoque de Automoveis disponiveis!");
            Console.WriteLine();

            foreach (Automovel automovel in Lista_Automovel)
            {
                Console.Write($"{automovel.Marca} ");
                Console.WriteLine(automovel.Modelo);
                Console.WriteLine($"{automovel.Powertrain}");
                Console.Write($"{automovel.Versao}    Cor = ");
                Console.WriteLine(automovel.Cor);
                Console.Write($"{automovel.Ano}/");
                Console.WriteLine(automovel.AnoModelo);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}