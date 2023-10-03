using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Automovel
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Powertrain { get; set; }
        public string Versao { get; set; }
        public string Cor { get; set; }
        public int Ano { get; set; }
        public int AnoModelo { get; set; }

        private List<Automovel> Lista_Automovel;
            

        public static void LerArquivo()
        {
            String caminho = "C:\\Users\\Public\\CadastroAutomovel";
            StreamReader y;
            y = File.OpenText(caminho);
            string json = y.ReadLine();
            Lista_Automovel = JsonSerializer.Deserialize<List<Automovel>>(json);
            y.Close();
        }
        
        public static void CadastrarCarro()
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

            Lista_Automovel.Add(automovel1);
        }
    }
}
