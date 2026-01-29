using ConsoleApp2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.ConsoleHelper;
using ConsoleApp2.Services;
using MySql.Data.MySqlClient;
using Dapper;

namespace ConsoleApp2.Repository
{
    internal class AutomovelRepository : Database
    {
        public void Inserir(Automovel automovel)
        {
            string sql = "INSERT INTO automovel VALUEs (NULL, @Marca, @Modelo, @Powertrain, @Versao, @Cor, @Ano, " +
                         "@AnoModelo, @Quilometragem, @Preco, @Blindado, @QuantidadeDonos)";
            Execute(sql, automovel);
        }
        public List<Automovel> Listar()
        {
            string sql = @"SELECT * FROM automovel";

            using (MySqlConnection conexao = GetConnection())
            {
                List<Automovel >automoveis = conexao.Query<Automovel>(sql).ToList();
                return automoveis;
            }
        }
    }
}
