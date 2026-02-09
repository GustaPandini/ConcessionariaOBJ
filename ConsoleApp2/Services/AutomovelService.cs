using ConsoleApp2.ConsoleHelper;
using ConsoleApp2.Entity;
using ConsoleApp2.Repository;
using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualBasic;
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
        
        public bool LerValidacaoBlindado(string input, out bool blindado)
        {
            blindado = false;
            if (input == "sim")
            {
                blindado = true;
                return true;
            }
            else if (input == "não" || input == "nao")
            {
                blindado = false;
                return true;
            }
            return blindado;
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
        public string VerificarAlteracaoString(string input, string valorAntigo)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return valorAntigo;
            }
            else
            {
                return input;
            }
        }
        public int VerificarAlteracaoInt(string input, int valorAntigo)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return valorAntigo;
            }
            else
            {
                int valorAtualizadoInt = Convert.ToInt32(input);
                return valorAtualizadoInt;
            }
        }
        public decimal VerificarAlteracaoDecimal(string input, decimal valorAntigo)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return valorAntigo;
            }
            else
            {
                decimal valorAtualizadoDecimal = Convert.ToDecimal(input);
                return valorAtualizadoDecimal;
            }
        }
        public bool VerificarAlteracaoBlindado(bool valorAntigo)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "")
                {
                    return valorAntigo;
                }
                else
                {
                    input.ToLower();
                    if (input == "sim")
                    {
                        return true;
                    }
                    else if (input == "nao" || input == "não")
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("Resposta inválida, digite sim, não ou apenas pressione Enter, tente novamente!");
                    }
                }
            }
        }
        public bool VerificarAnoValido(string input, out int ano)
        {
            ano = 0;
            DateTime agora = DateTime.Now;

            if (!int.TryParse(input, out ano))
            {
                return false;
            }

            if (ano < 1886 || ano > agora.Year)
            {
                return false;
            }

            return true;
        }
        public bool VerificarAnoModeloValido(string input, out int anoModelo, int ano)
        {
            anoModelo = 0;

            if (!int.TryParse(input, out anoModelo))
            {
                return false;
            }

            if (anoModelo < ano || anoModelo > ano+1)
            {
                return false;
            }

            return true;
        }
        public bool VerificarBlindadoValido(string input, out bool blindado)
        {
            input.ToLower();
            blindado = false;
            if (input == "sim")
            {
                blindado = true;
                return true;
            }
            else if (input == "nao" || input == "não")
            {
                blindado = false;
                return true;
            }
            
            return false;
        }

    }
}
