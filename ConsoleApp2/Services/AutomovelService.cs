using ConsoleApp2.Entity;
using ConsoleApp2.Repository;
using Google.Protobuf.WellKnownTypes;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Services
{
    internal class AutomovelService
    {
        private readonly AutomovelRepository _repository;

        public AutomovelService()
        {
            _repository = new AutomovelRepository();
        }
        
        public bool LerBlindagem()
        {
            while (true)
            {
                string resp = Console.ReadLine().ToLower();
                if (resp == "sim")
                {
                    return true;
                }
                else if (resp == "não" || resp == "nao")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Resposta inválida, digite sim ou não, tente novamente!");
                }
            }
        }
        public int LerAno()
        {
            while(true)
            {
                int ano = Convert.ToInt32(Console.ReadLine());
                DateTime agora = DateTime.Now;
                if (ano < 1886)
                {
                    Console.WriteLine("O ano do automóvel não pode ser menor que 1886, pois não existiam automóveis antes dessa data, digite novamente o ano!");
                }
                else if (ano > agora.Year)
                {
                    Console.WriteLine("Não tem como um automóvel ter um ano maior que o ano presente, digite novamente o ano!");
                }
                else
                {
                    return ano;
                }
            }
        }
        public string MostrarBlindagem(Automovel automovel)
        {
            string blindado;
            if (automovel.Blindado == true) 
            {
                blindado = "Sim";
                return blindado;
            }
            else 
            {
                blindado = "Não";
                return blindado;
            }
        }
        public string VerificarAlteracaoString(string uptade, string valorAntigo)
        {
            if (uptade == "")
            {
                return valorAntigo;
            }
            else
            {
                return uptade;
            }
        }
        public int VerificarAlteracaoInt(string uptade, int valorAntigo)
        {
            if (uptade == "")
            {
                return valorAntigo;
            }
            else
            {
                int valorAtualizadoInt = Convert.ToInt32(uptade);
                return valorAtualizadoInt;
            }
        }
        public decimal VerificarAlteracaoDecimal(string uptade, decimal valorAntigo)
        {
            if (uptade == "")
            {
                return valorAntigo;
            }
            else
            {
                decimal valorAtualizadoDecimal = Convert.ToDecimal(uptade);
                return valorAtualizadoDecimal;
            }
        }
        public bool VerificarAlteracaoBool(bool uptade, bool valorAntigo)
        {
            if (uptade == null)
            {
                return valorAntigo;
            }
            else
            {
                return uptade;
            }
        }
    }
}
