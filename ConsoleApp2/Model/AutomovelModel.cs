using ConsoleApp2.ConsoleHelper;
using ConsoleApp2.Entity;
using Google.Protobuf.Compiler;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dapper;
using ConsoleApp2.Interfaces;

namespace ConsoleApp2.Model
{
    internal class AutomovelModel : Database, Icrud<Automovel> 
    {   
        Automovel automovel = new Automovel();
        public void Cadastrar()
        {
            Console.Write("Digite a Marca = ");
            automovel.Marca = Console.ReadLine();
            Console.Write("Digite o Modelo = ");
            automovel.Modelo = Console.ReadLine();
            Console.Write("Digite o PowerTrain = ");
            automovel.Powertrain = Console.ReadLine();
            Console.Write("Digite a Versão = ");
            automovel.Versao = Console.ReadLine();
            Console.Write("Digite a Cor = ");
            automovel.Cor = Console.ReadLine();
            Console.Write("Digite o Ano = ");
            automovel.Ano = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite o Ano Modelo = ");
            automovel.AnoModelo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite a quilometragem desse automóvel = ");
            automovel.Quilometragem = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite o preço desse automóvel = ");
            automovel.Preco = Convert.ToDecimal(Console.ReadLine());

            while (true)
            {
                Console.Write("Digite se esse automóvel é blindado (Sim ou Não) = ");
                string respBlindado = Console.ReadLine().ToLower();
                if (respBlindado == "sim")
                {
                    automovel.Blindado = true;
                    break;
                }
                else if (respBlindado == "não" || respBlindado == "nao")
                {
                    automovel.Blindado = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Resposta inválida, digite sim ou não, tente novamente!");
                }
            }

            Console.Write("Digite quantos donos esse automóvel já teve = ");
            automovel.QuantidadeDonos = Convert.ToInt32(Console.ReadLine());

            string sql = "INSERT INTO automovel VALUEs (NULL, @Marca, @Modelo, @Powertrain, @Versao, @Cor, @Ano, " +
                         "@AnoModelo, @Quilometragem, @Preco, @Blindado, @QuantidadeDonos)";
            Execute(sql, automovel);

            Console.WriteLine("Veículo cadastrado com sucesso!, pressione Enter para voltar ao menu.");
            Console.ReadLine();
            Console.Clear();
        }

        public void Listar()
        {
            string sql = @"SELECT * FROM automovel";

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
                    Console.WriteLine($"Quilometragem: {automovel.Quilometragem}");
                    Console.WriteLine($"Preço: {automovel.Preco}");
                    if (automovel.Blindado == true) { Console.WriteLine("Blindado: Sim"); }
                    else { Console.WriteLine("Blindado: Não"); }
                    Console.WriteLine($"Quantidade de donos: {automovel.QuantidadeDonos}");
                    Console.WriteLine("---------------------------");
                }
            }
            Console.WriteLine("Pressione Enter para chamar o menu.");
            Console.ReadLine();
        }

        public void Alterar()
        {
            Console.Write("Digite o Id do automóvel que você deseja alterar no banco = ");
            int Id = Convert.ToInt32(Console.ReadLine());
            automovel.Id = Id;

            Automovel automovelId = MostarAutomovelPorId(Id);

            Console.Write("Digite o novo valor para a Marca do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeMarca = Console.ReadLine();
            if (uptadeMarca == "")
            {
                automovel.Marca = automovelId.Marca;
            }
            else
            {
                automovel.Marca = uptadeMarca;
            }

            Console.Write("Digite o novo valor para o Modelo do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeModelo = Console.ReadLine();
            if (uptadeModelo == "")
            {
                automovel.Modelo = automovelId.Modelo;
            }
            else
            {
                automovel.Modelo = uptadeModelo;
            }

            Console.Write("Digite o novo valor para o Powertrain do automovel (se não quiser alterar pressione Enter) = ");
            string uptadePowertrain = Console.ReadLine();
            if (uptadePowertrain == "")
            {
                automovel.Powertrain = automovelId.Powertrain;
            }
            else
            {
                automovel.Powertrain = uptadePowertrain;
            }

            Console.Write("Digite o novo valor para a Versão do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeVersao = Console.ReadLine();
            if (uptadeVersao == "")
            {
                automovel.Versao = automovelId.Versao;
            }
            else
            {
                automovel.Versao = uptadeVersao;
            }

            Console.Write("Digite o novo valor para a Cor do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeCor = Console.ReadLine();
            if (uptadeCor == "")
            {
                automovel.Cor = automovelId.Cor;
            }
            else
            {
                automovel.Cor = uptadeCor;
            }

            Console.Write("Digite o novo valor para o Ano do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeAnoString = Console.ReadLine();
            if (uptadeAnoString == "")
            {
                automovel.Ano = automovelId.Ano;
            }
            else
            {
                int uptadeAno = Convert.ToInt32(uptadeAnoString);
                automovel.Ano = uptadeAno;
            }

            Console.Write("Digite o novo valor para o Ano/Modelo do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeAnoModeloString = Console.ReadLine();
            if (uptadeAnoModeloString == "")
            {
                automovel.AnoModelo = automovelId.AnoModelo;
            }
            else
            {
                int uptadeAnoModelo = Convert.ToInt32(uptadeAnoModeloString);
                automovel.AnoModelo = uptadeAnoModelo;
            }

            Console.Write("Digite o novo valor para a Quilometragem do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeQuilometragemString = Console.ReadLine();
            if (uptadeQuilometragemString == "")
            {
                automovel.Quilometragem = automovelId.Quilometragem;
            }
            else
            {
                int uptadeQuilometragem = Convert.ToInt32(uptadeQuilometragemString);
                automovel.Quilometragem = uptadeQuilometragem;
            }

            Console.Write("Digite o novo valor para o Preço do automovel (se não quiser alterar pressione Enter) = ");
            string uptadePrecoString = Console.ReadLine();
            if (uptadePrecoString == "")
            {
                automovel.Preco = automovelId.Preco;
            }
            else
            {
                decimal uptadePreco = Convert.ToDecimal(uptadePrecoString);
                automovel.Preco = uptadePreco;
            }

            while (true)
            {
                Console.Write("Digite se esse automóvel é blindado (Sim ou Não), se não quiser alterar pressione Enter = ");
                string respBlindado = Console.ReadLine().ToLower();
                if (respBlindado == "sim")
                {
                    automovel.Blindado = true;
                    break;
                }
                else if (respBlindado == "não" || respBlindado == "nao")
                {
                    automovel.Blindado = false;
                    break;
                }
                else if (respBlindado == "")
                {
                    automovel.Blindado = automovelId.Blindado;
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
                automovel.QuantidadeDonos = automovelId.QuantidadeDonos;
            }
            else
            {
                int uptadeQuantidadeDonos = Convert.ToInt32(uptadeQuantidadeDonosString);
                automovel.QuantidadeDonos = uptadeQuantidadeDonos;
            }

            string sql = "UPDATE automovel " +
                         "SET MARCA = @marca, MODELO = @modelo, POWERTRAIN = @powertrain, VERSAO = @versao, COR = @cor, " +
                         "ANO = @ano, ANOMODELO = @anoModelo, QUILOMETRAGEM = @quilometragem, PRECO = @preco, " +
                         "BLINDADO = @blindado, QUANTIDADEDONOS = @quantidadeDonos WHERE Id = @id";

            Execute(sql, automovel);

            Console.WriteLine("Veículo alterado com sucesso, pressione Enter para voltar ao menu.");
            Console.ReadLine();
            Console.Clear();
        }

        public void Deletar()
        {
            Console.Write("Digite o Id do automóvel que você deseja deletar no banco = ");
            automovel.Id = Convert.ToInt32(Console.ReadLine());

            string sql = "DELETE FROM automovel WHERE ID = @Id";

            Execute(sql, automovel);

            Console.WriteLine("Veículo excluido com sucesso, pressione Enter para voltar ao menu.");
            Console.ReadLine();
            Console.Clear();
        }

        public Automovel MostarAutomovelPorId(int Id)
        {
            string sql = @"SELECT * FROM automovel WHERE Id = @id";
            using (MySqlConnection conexao = GetConnection())
            {
                return conexao.QuerySingleOrDefault<Automovel>(sql, new { Id });
            }
        }
    }
}
