using ConsoleApp2.Entity;
using ConsoleApp2.Interfaces;
using ConsoleApp2.Repository;
using ConsoleApp2.Services;
using Org.BouncyCastle.Asn1.IsisMtt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.ConsoleHelper
{
    internal class AutomovelConsole : Icrud<Automovel>
    {
        private readonly AutomovelService _service;
        private readonly AutomovelRepository _repository;

        public AutomovelConsole()
        {
            _service = new AutomovelService();
            _repository = new AutomovelRepository();
        }

        public void Inserir()
        {
            Automovel automovel = new Automovel();
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
            automovel.Ano = _service.LerAno();
            Console.Write("Digite o Ano Modelo = ");
            automovel.AnoModelo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite a quilometragem desse automóvel = ");
            automovel.Quilometragem = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite o preço desse automóvel = ");
            automovel.Preco = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Digite se esse automóvel é blindado (Sim ou Não) = ");
            automovel.Blindado = _service.LerBlindagem();  
            Console.Write("Digite quantos donos esse automóvel já teve = ");
            automovel.QuantidadeDonos = Convert.ToInt32(Console.ReadLine());

            _repository.Inserir(automovel);

            Console.WriteLine("Veículo cadastrado com sucesso!, pressione Enter para voltar ao menu.");
            Console.ReadLine();
            Console.Clear();
        }
        public void Listar()
        {
            List<Automovel> automoveis = _repository.Listar();
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
                Console.WriteLine($"Blindado: " + _service.MostrarBlindagem(automovel));
                Console.WriteLine($"Quantidade de donos: {automovel.QuantidadeDonos}");
                Console.WriteLine("---------------------------");
            }
        }
        public void Alterar()
        {
            Automovel automovel = new Automovel();
            Console.Write("Digite o Id do automóvel que você deseja alterar no banco = ");
            int Id = Convert.ToInt32(Console.ReadLine());
            automovel.Id = Id;
            Automovel automovelId = _repository.MostarAutomovelPorId(Id);

            Console.Write("Digite o novo valor para a Marca do automovel (se não quiser alterar pressione Enter) = ");
            string updateMarca = Console.ReadLine();
            string valorAntigoMarca = automovelId.Marca;
            automovel.Marca = _service.VerificarAlteracaoString(updateMarca, valorAntigoMarca);

            Console.Write("Digite o novo valor para o Modelo do automovel (se não quiser alterar pressione Enter) = ");
            string updateModelo = Console.ReadLine();
            string valorAntigoModelo = automovelId.Modelo;
            automovel.Modelo = _service.VerificarAlteracaoString(updateModelo, valorAntigoModelo);

            Console.Write("Digite o novo valor para o Powertrain do automovel (se não quiser alterar pressione Enter) = ");
            string updatePowertrain = Console.ReadLine();
            string valorAntigoPowertrain = automovelId.Powertrain;
            automovel.Powertrain = _service.VerificarAlteracaoString(updatePowertrain, valorAntigoPowertrain);

            Console.Write("Digite o novo valor para a Versão do automovel (se não quiser alterar pressione Enter) = ");
            string updateVersao = Console.ReadLine();
            string valorAntigoVersao = automovelId.Versao;
            automovel.Versao = _service.VerificarAlteracaoString(updateVersao, valorAntigoVersao);

            Console.Write("Digite o novo valor para a Cor do automovel (se não quiser alterar pressione Enter) = ");
            string updateCor = Console.ReadLine();
            string valorAntigoCor = automovelId.Cor;
            automovel.Cor = _service.VerificarAlteracaoString(updateCor, valorAntigoCor);

            Console.Write("Digite o novo valor para o Ano do automovel (se não quiser alterar pressione Enter) = ");
            int valorAntigoAno = automovelId.Ano;
            automovel.Ano = LerAnoAlteracao(valorAntigoAno);

            Console.Write("Digite o novo valor para o Ano/Modelo do automovel (se não quiser alterar pressione Enter) = ");
            int valorAntigoAnoModelo = automovelId.AnoModelo;
            int ano = automovel.Ano;
            automovel.AnoModelo = LerAnoModeloAlteracao(valorAntigoAnoModelo, ano);

            Console.Write("Digite o novo valor para a Quilometragem do automovel (se não quiser alterar pressione Enter) = ");
            string updateQuilometragem = Console.ReadLine();
            int valorAntigoQuilometragem = automovelId.Quilometragem;
            automovel.Quilometragem = _service.VerificarAlteracaoInt(updateQuilometragem, valorAntigoQuilometragem);

            Console.Write("Digite o novo valor para o Preço do automovel (se não quiser alterar pressione Enter) = ");
            string updatePreco = Console.ReadLine();
            decimal valorAntigoPreco = automovelId.Preco;
            automovel.Preco = _service.VerificarAlteracaoDecimal(updatePreco, valorAntigoPreco);

            
            Console.Write("Digite se esse automóvel é blindado (Sim ou Não), se não quiser alterar pressione Enter = ");
            bool valorAntigoBlindado = automovelId.Blindado;
            automovel.Blindado = _service.VerificarAlteracaoBlindado(valorAntigoBlindado);
            

            Console.Write("Digite o novo valor para a quantidade de donos do automovel (se não quiser alterar pressione Enter) = ");
            string updateQuantidadeDonos = Console.ReadLine();
            int valorAntigoQuantidadeDonos = automovelId.QuantidadeDonos;
            automovel.QuantidadeDonos = _service.VerificarAlteracaoInt(updateQuantidadeDonos, valorAntigoQuantidadeDonos);

            _repository.Alterar(automovel);

            Console.WriteLine("Veículo alterado com sucesso, pressione Enter para voltar ao menu.");
            Console.ReadLine();
            Console.Clear();
        }
        public void Deletar()
        {
            Automovel automovel = new Automovel();
            Console.Write("Digite o Id do automóvel que você deseja deletar no banco = ");
            automovel.Id = Convert.ToInt32(Console.ReadLine());

            _repository.Deletar(automovel);

            Console.WriteLine("Veículo excluido com sucesso, pressione Enter para voltar ao menu.");
            Console.ReadLine();
            Console.Clear();
        }
        public int LerAnoAlteracao(int valorAntigo)
        {
            while (true)
            {
                string updateAno = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(updateAno))
                {
                    return valorAntigo;
                }

                if (_service.VerificarAnoValido(updateAno, out int ano))
                {
                    return ano;
                }

                Console.Write("Ano inválido. Digite novamente: ");
            }
        }
        public int LerAnoModeloAlteracao(int valorAntigo, int ano)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    return valorAntigo;
                }

                if (_service.VerificarAnoModeloValido(input, out int anoModelo, ano))
                {
                    return anoModelo;
                }

                Console.Write("Ano-Modelo inválido. Digite novamente: ");
            }
        }
    }
}
