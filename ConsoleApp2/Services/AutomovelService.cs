using ConsoleApp2.Entity;
using ConsoleApp2.Repository;
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
        public void Inserir(Automovel automovel)
        {
            _repository.Inserir(automovel);
        }
    }
}
