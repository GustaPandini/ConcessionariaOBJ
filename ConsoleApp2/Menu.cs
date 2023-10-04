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
            Console.Write("Digite o numero da ação que deseja realizar = ");
            int respostaMenu = Convert.ToInt32(Console.ReadLine());

            switch (respostaMenu)
            {
                case 1:
                    CadastrarAutomovel();
                    MenuPrincipal();
                    break;
                case 2:
                    MostrarEstoque();
                    MenuPrincipal();
                    break;
                case 3:

                    break;
            }
        }

        public static void CadastrarAutomovel()
        {

            Automovel.LerArquivo();

            Automovel.CadastrarCarro();

            Automovel.EscreverArquivo();

            Console.WriteLine("Ok seu Automovel foi cadastrado, Pressione ENTER para retornar ao Menu!");
            Console.ReadLine();
            Console.Clear();
        }

        public static void MostrarEstoque()
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
