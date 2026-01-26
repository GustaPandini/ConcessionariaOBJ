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

namespace ConsoleApp2.Entity
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
        public int Quilometragem { get; set; }
        public decimal Preco { get; set; }
        public bool Blindado { get; set; }
        public int QuantidadeDonos { get; set; }
    }
}
