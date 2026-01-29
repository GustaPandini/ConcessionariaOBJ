using ConsoleApp2.Entity;
using ConsoleApp2.Repository;
using ConsoleApp2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.ConsoleHelper
{
    internal class AutomovelConsole
    {
        private readonly AutomovelService _service;
        private readonly AutomovelRepository _repository;

        public AutomovelConsole()
        {
            _service = new AutomovelService();
            _repository = new AutomovelRepository();
        }

        public void Cadastrar(Automovel automovel)
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
            _service.Cadastrar(automovel);
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
                if (automovel.Blindado == true) { Console.WriteLine("Blindado: Sim"); }
                else { Console.WriteLine("Blindado: Não"); }
                Console.WriteLine($"Quantidade de donos: {automovel.QuantidadeDonos}");
                Console.WriteLine("---------------------------");
            }
        }
    }
}
