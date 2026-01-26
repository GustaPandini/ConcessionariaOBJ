using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Interfaces
{
    internal interface Icrud<T>
    {
        void Cadastrar();
        void Listar();
        void Alterar();
        void Deletar();
    }
}
