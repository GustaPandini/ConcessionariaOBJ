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
        public string VerificarAlteracaoString(string update, string valorAntigo)
        {
            if (update == "")
            {
                return valorAntigo;
            }
            else
            {
                return update;
            }
        }
        public int VerificarAlteracaoInt(string update, int valorAntigo)
        {
            if (update == "")
            {
                return valorAntigo;
            }
            else
            {
                int valorAtualizadoInt = Convert.ToInt32(update);
                return valorAtualizadoInt;
            }
        }
        public decimal VerificarAlteracaoDecimal(string update, decimal valorAntigo)
        {
            if (update == "")
            {
                return valorAntigo;
            }
            else
            {
                decimal valorAtualizadoDecimal = Convert.ToDecimal(update);
                return valorAtualizadoDecimal;
            }
        }
        public bool VerificarAlteracaoBlindado(bool valorAntigo)
        {
            while (true)
            {
                string update = Console.ReadLine();
                if (update == "")
                {
                    return valorAntigo;
                }
                else
                {
                    update.ToLower();
                    if (update == "sim")
                    {
                        return true;
                    }
                    else if (update == "nao" || update == "não")
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
        public bool VerificarAnoValido(string updateAno, out int ano)
        {
            ano = 0;
            DateTime agora = DateTime.Now;

            if (!int.TryParse(updateAno, out ano))
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

    }
}
