using ConsoleApp2.ConsoleHelper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Dapper;
using Mysqlx.Prepare;

namespace ConsoleApp2
{
    internal class Automovel : Database
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Powertrain { get; set; }
        public string Versao { get; set; }
        public string Cor { get; set; }
        public int Ano { get; set; }
        public int AnoModelo { get; set; }
        public int EstadoAutomovelId { get; set; }


        public void CadastrarCarro()
        {
            Console.Write("Digite a Marca = ");
            this.Marca = Console.ReadLine();
            Console.Write("Digite o Modelo = ");
            this.Modelo = Console.ReadLine();
            Console.Write("Digite o PowerTrain = ");
            this.Powertrain = Console.ReadLine();
            Console.Write("Digite a Versão = ");
            this.Versao = Console.ReadLine();
            Console.Write("Digite a Cor = ");
            this.Cor = Console.ReadLine();
            Console.Write("Digite o Ano = ");
            this.Ano = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite o Ano Modelo = ");
            this.AnoModelo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite ID do Estado do Automovel = ");
            this.EstadoAutomovelId = Convert.ToInt32(Console.ReadLine());

            string sql = "INSERT INTO automovel VALUEs (NULL, @Marca, @Modelo, @Powertrain, @Versao, @Cor, @Ano, @AnoModelo, @EstadoAutomovelId)";
            int linhas = Execute(sql, this);
        }

        public void MostrarAutomovel()
        {
            string sql = @"SELECT 
                            MARCA,
                            MODELO,
                            POWERTRAIN,
                            VERSAO,
                            COR,
                            ANO,
                            ANOMODELO AS AnoModelo
                            FROM automovel";

            using (MySqlConnection conexao = GetConnection())
            {
                List<Automovel> automoveis = conexao.Query<Automovel>(sql).ToList();

                Console.WriteLine("=== LISTA DE AUTOMÓVEIS ===");

                foreach (var automovel in automoveis)
                {
                    Console.WriteLine($"Marca: {automovel.Marca}");
                    Console.WriteLine($"Modelo: {automovel.Modelo}");
                    Console.WriteLine($"Powertrain: {automovel.Powertrain}");
                    Console.WriteLine($"Versão: {automovel.Versao}");
                    Console.WriteLine($"Cor: {automovel.Cor}");
                    Console.WriteLine($"Ano: {automovel.Ano}");
                    Console.WriteLine($"Ano Modelo: {automovel.AnoModelo}");
                    Console.WriteLine("---------------------------");
                }
            }
        }

        public void AlterarAutomovel()
        {
            Console.WriteLine("Digite o Id do automóvel que você deseja alterar no banco");
            this.Id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite a Marca do automóvel");
            this.Marca = Console.ReadLine();

            Console.WriteLine("Digite o Modelo do automóvel");
            this.Modelo = Console.ReadLine();

            Console.WriteLine("Digite o Powertrain do automóvel");
            this.Powertrain = Console.ReadLine();

            Console.WriteLine("Digite a Versão do automóvel");
            this.Versao = Console.ReadLine();

            Console.WriteLine("Digite a Cor do automóvel");
            this.Cor = Console.ReadLine();

            Console.WriteLine("Digite o Ano do automóvel");
            this.Ano = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o Ano/Modelo do automóvel");
            this.AnoModelo = Convert.ToInt32(Console.ReadLine());

            string sql = "UPDATE automovel " +
                         "SET MARCA = @marca, MODELO = @modelo, POWERTRAIN = @powertrain, VERSAO = @versao, COR = @cor, " +
                         "ANO = @ano, ANOMODELO = @anoModelo WHERE Id = @id";

            Execute(sql, this);
        }

        public void DeletarAutomovel()
        {
            Console.WriteLine("Digite o Id do automóvel que você deseja deletar no banco");
            this.Id = Convert.ToInt32(Console.ReadLine());

            string sql = "DELETE FROM automovel WHERE ID = @Id";

            Execute(sql, this);
        }
    }
}
