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
using System.Runtime.CompilerServices;

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
        public int quilometragem { get; set; }
        public double preco { get; set; }
        public bool blindado { get; set; }
        public int quantidadeDonos { get; set; }


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
            Console.Write("Digite a quilometragem desse automóvel = ");
            this.quilometragem = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite o preço desse automóvel = ");
            this.preco = Convert.ToDouble(Console.ReadLine());

            while (true)
            {
                Console.Write("Digite se esse automóvel é blindado (Sim ou Não) = ");
                string respBlindado = Console.ReadLine().ToLower();
                if (respBlindado == "sim")
                {
                    this.blindado = true;
                    break;
                }
                else if (respBlindado == "não")
                {
                    this.blindado = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Resposta inválida, digite sim ou não, tente novamente!");
                }
            }

            Console.Write("Digite quantos donos esse automóvel já teve = ");
            this.quantidadeDonos = Convert.ToInt32(Console.ReadLine());

            string sql = "INSERT INTO automovel VALUEs (NULL, @Marca, @Modelo, @Powertrain, @Versao, @Cor, @Ano, " +
                         "@AnoModelo, @quilometragem, @preco, @blindado, @quantidadeDonos)";
            Execute(sql, this);

            Console.WriteLine("Veículo cadastrado com sucesso!, pressione Enter para voltar ao menu.");
            Console.ReadLine();
            Console.Clear();
        }

        public void MostrarAutomovel()
        {
            string sql = @"SELECT 
                            ID,
                            MARCA,
                            MODELO,
                            POWERTRAIN,
                            VERSAO,
                            COR,
                            ANO,
                            ANOMODELO AS AnoModelo,
                            QUILOMETRAGEM,
                            PRECO,
                            BLINDADO,
                            QUANTIDADEDONOS AS quantidadeDonos
                            FROM automovel";

            using (MySqlConnection conexao = GetConnection())
            {
                List<Automovel> automoveis = conexao.Query<Automovel>(sql).ToList();

                Console.WriteLine("=== LISTA DE AUTOMÓVEIS ===");

                foreach (var automovel in automoveis)
                {
                    Console.WriteLine($"ID: {automovel.Id}");
                    Console.WriteLine($"Marca: {automovel.Marca}");
                    Console.WriteLine($"Modelo: {automovel.Modelo}");
                    Console.WriteLine($"Powertrain: {automovel.Powertrain}");
                    Console.WriteLine($"Versão: {automovel.Versao}");
                    Console.WriteLine($"Cor: {automovel.Cor}");
                    Console.WriteLine($"Ano: {automovel.Ano}");
                    Console.WriteLine($"Ano Modelo: {automovel.AnoModelo}");
                    Console.WriteLine($"Quilometragem: {automovel.quilometragem}");
                    Console.WriteLine($"Preço: {automovel.preco}");
                    Console.WriteLine($"Blindado: {automovel.blindado}");
                    Console.WriteLine($"Quantidade de donos: {automovel.quantidadeDonos}");
                    Console.WriteLine("---------------------------");
                }
            }
            Console.WriteLine("Pressione Enter para chamar o menu.");
            Console.ReadLine();
        }

        public void AlterarAutomovel()
        {
            Console.Write("Digite o Id do automóvel que você deseja alterar no banco = ");
            int Id = Convert.ToInt32(Console.ReadLine());
            this.Id = Id;

            Automovel automovelId = MostarAutomovelPorId(Id);

            Console.Write("Digite o novo valor para a Marca do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeMarca = Console.ReadLine();
            if(uptadeMarca == "")
            {
                this.Marca = automovelId.Marca;
            }
            else
            {
                this.Marca = uptadeMarca;
            }

            Console.Write("Digite o novo valor para o Modelo do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeModelo = Console.ReadLine();
            if (uptadeModelo == "")
            {
                this.Modelo = automovelId.Modelo;
            }
            else
            {
                this.Modelo = uptadeModelo;
            }

            Console.Write("Digite o novo valor para o Powertrain do automovel (se não quiser alterar pressione Enter) = ");
            string uptadePowertrain = Console.ReadLine();
            if (uptadePowertrain == "")
            {
                this.Powertrain = automovelId.Powertrain;
            }
            else
            {
                this.Powertrain = uptadePowertrain;
            }

            Console.Write("Digite o novo valor para a Versão do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeVersao = Console.ReadLine();
            if (uptadeVersao == "")
            {
                this.Versao = automovelId.Versao;
            }
            else
            {
                this.Versao = uptadeVersao;
            }

            Console.Write("Digite o novo valor para a Cor do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeCor = Console.ReadLine();
            if (uptadeCor == "")
            {
                this.Cor = automovelId.Cor;
            }
            else
            {
                this.Cor = uptadeCor;
            }

            Console.Write("Digite o novo valor para o Ano do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeAnoString = Console.ReadLine();
            if (uptadeAnoString == "")
            {
                this.Ano = automovelId.Ano;
            }
            else
            {
                int uptadeAno = Convert.ToInt32(uptadeAnoString);
                this.Ano = uptadeAno;
            }

            Console.Write("Digite o novo valor para o Ano/Modelo do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeAnoModeloString = Console.ReadLine();
            if (uptadeAnoModeloString == "")
            {
                this.AnoModelo = automovelId.AnoModelo;
            }
            else
            {
                int uptadeAnoModelo = Convert.ToInt32(uptadeAnoModeloString);
                this.AnoModelo = uptadeAnoModelo;
            }

            Console.Write("Digite o novo valor para a Quilometragem do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeQuilometragemString = Console.ReadLine();
            if (uptadeQuilometragemString == "")
            {
                this.quilometragem = automovelId.quilometragem;
            }
            else
            {
                int uptadeQuilometragem = Convert.ToInt32(uptadeQuilometragemString);
                this.quilometragem = uptadeQuilometragem;
            }

            Console.Write("Digite o novo valor para o Preço do automovel (se não quiser alterar pressione Enter) = ");
            string uptadePrecoString = Console.ReadLine();
            if (uptadePrecoString == "")
            {
                this.preco = automovelId.preco;
            }
            else
            {
                int uptadePreco = Convert.ToInt32(uptadePrecoString);
                this.preco = uptadePreco;
            }

            while (true)
            {
                Console.Write("Digite se esse automóvel é blindado (Sim ou Não), se não quiser alterar pressione Enter = ");
                string respBlindado = Console.ReadLine().ToLower();
                if (respBlindado == "sim")
                {
                    this.blindado = true;
                    break;
                }
                else if (respBlindado == "não")
                {
                    this.blindado = false;
                    break;
                }
                else if (respBlindado == "")
                {
                    this.blindado = automovelId.blindado;
                    break;
                }
                else
                {
                    Console.WriteLine("Resposta inválida, digite sim ou não, tente novamente!");
                }
            }

            Console.Write("Digite o novo valor para a quantidade de donos do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeQuantidadeDonosString = Console.ReadLine();
            if (uptadeQuantidadeDonosString == "")
            {
                this.quantidadeDonos = automovelId.quantidadeDonos;
            }
            else
            {
                int uptadeQuantidadeDonos = Convert.ToInt32(uptadeQuantidadeDonosString);
                this.quantidadeDonos = uptadeQuantidadeDonos;
            }

            string sql = "UPDATE automovel " +
                         "SET MARCA = @marca, MODELO = @modelo, POWERTRAIN = @powertrain, VERSAO = @versao, COR = @cor, " +
                         "ANO = @ano, ANOMODELO = @anoModelo, QUILOMETRAGEM = @quilometragem, PRECO = @preco, " +
                         "BLINDADO = @blindado, QUANTIDADEDONOS = @quantidadeDonos WHERE Id = @id";

            Execute(sql, this);

            Console.WriteLine("Veículo alterado com sucesso, pressione Enter para voltar ao menu.");
            Console.ReadLine();
            Console.Clear();
        }

        public void DeletarAutomovel()
        {
            Console.Write("Digite o Id do automóvel que você deseja deletar no banco = ");
            this.Id = Convert.ToInt32(Console.ReadLine());

            string sql = "DELETE FROM automovel WHERE ID = @Id";

            Execute(sql, this);

            Console.WriteLine("Veículo excluido com sucesso, pressione Enter para voltar ao menu.");
            Console.ReadLine();
            Console.Clear();
        }

        public Automovel MostarAutomovelPorId(int Id)
        {
            string sql = @"SELECT 
                            ID,
                            MARCA,
                            MODELO,
                            POWERTRAIN,
                            VERSAO,
                            COR,
                            ANO,
                            ANOMODELO AS AnoModelo,
                            QUILOMETRAGEM,
                            PRECO,
                            BLINDADO,
                            QUANTIDADEDONOS AS quantidadeDonos
                            FROM automovel WHERE Id = @id";
            using (MySqlConnection conexao = GetConnection())
            {
                return conexao.QuerySingleOrDefault<Automovel>(sql, new { Id });
            }
        }
    }
}
