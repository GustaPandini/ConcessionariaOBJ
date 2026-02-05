using ConsoleApp2.Entity;
using ConsoleApp2.Interfaces;
using ConsoleApp2.Repository;
using ConsoleApp2.Services;
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

        public void Inserir(Automovel automovel)
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
        public void Alterar(Automovel automovel)
        {
            Console.Write("Digite o Id do automóvel que você deseja alterar no banco = ");
            int Id = Convert.ToInt32(Console.ReadLine());
            automovel.Id = Id;
            Automovel automovelId = _repository.MostarAutomovelPorId(Id);

            Console.Write("Digite o novo valor para a Marca do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeMarca = Console.ReadLine();
            string valorAntigoMarca = automovelId.Marca;
            automovel.Marca = _service.VerificarAlteracaoString(uptadeMarca, valorAntigoMarca);

            Console.Write("Digite o novo valor para o Modelo do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeModelo = Console.ReadLine();
            string valorAntigoModelo = automovelId.Modelo;
            automovel.Modelo = _service.VerificarAlteracaoString(uptadeModelo, valorAntigoModelo);

            Console.Write("Digite o novo valor para o Powertrain do automovel (se não quiser alterar pressione Enter) = ");
            string uptadePowertrain = Console.ReadLine();
            string valorAntigoPowertrain = automovelId.Powertrain;
            automovel.Powertrain = _service.VerificarAlteracaoString(uptadePowertrain, valorAntigoPowertrain);

            Console.Write("Digite o novo valor para a Versão do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeVersao = Console.ReadLine();
            string valorAntigoVersao = automovel.Versao;
            automovel.Versao = _service.VerificarAlteracaoString(uptadeVersao, valorAntigoVersao);

            Console.Write("Digite o novo valor para a Cor do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeCor = Console.ReadLine();
            string valorAntigoCor = automovelId.Cor;
            automovel.Cor = _service.VerificarAlteracaoString(uptadeCor, valorAntigoCor);

            Console.Write("Digite o novo valor para o Ano do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeAnoString = Console.ReadLine();
            int valorAntigoAno = automovelId.Ano;
            automovel.Ano = _service.VerificarAlteracaoInt(uptadeAnoString, valorAntigoAno);

            Console.Write("Digite o novo valor para o Ano/Modelo do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeAnoModeloString = Console.ReadLine();
            int valorAntigoAnoModelo = automovelId.AnoModelo;
            automovel.AnoModelo = _service.VerificarAlteracaoInt(uptadeAnoModeloString, valorAntigoAnoModelo);

            Console.Write("Digite o novo valor para a Quilometragem do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeQuilometragemString = Console.ReadLine();
            int valorAntigoQuilometragem = automovelId.Quilometragem;
            automovel.Quilometragem = _service.VerificarAlteracaoInt(uptadeQuilometragemString, valorAntigoQuilometragem);

            Console.Write("Digite o novo valor para o Preço do automovel (se não quiser alterar pressione Enter) = ");
            string uptadePrecoString = Console.ReadLine();
            decimal valorAntigoPreco = automovelId.Preco;
            automovel.Preco = _service.VerificarAlteracaoDecimal(uptadePrecoString, valorAntigoPreco);

            
            Console.Write("Digite se esse automóvel é blindado (Sim ou Não), se não quiser alterar pressione Enter = ");
            bool respBlindado = _service.LerBlindagem();
            bool valorAntigoBlindado = automovelId.Blindado;
            automovel.Blindado = _service.VerificarAlteracaoBool(respBlindado, valorAntigoBlindado);
            

            Console.Write("Digite o novo valor para a quantidade de donos do automovel (se não quiser alterar pressione Enter) = ");
            string uptadeQuantidadeDonosString = Console.ReadLine();
            int valorAntigoQuantidadeDonos = automovelId.QuantidadeDonos;
            automovel.QuantidadeDonos = _service.VerificarAlteracaoInt(uptadeQuantidadeDonosString, valorAntigoQuantidadeDonos);

            _repository.Alterar(automovel);
            Console.WriteLine("Veículo alterado com sucesso, pressione Enter para voltar ao menu.");
            Console.ReadLine();
            Console.Clear();
        }
        public void Deletar(Automovel automovel)
        {
            Console.Write("Digite o Id do automóvel que você deseja deletar no banco = ");
            automovel.Id = Convert.ToInt32(Console.ReadLine());

            _repository.Deletar(automovel);

            Console.WriteLine("Veículo excluido com sucesso, pressione Enter para voltar ao menu.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
