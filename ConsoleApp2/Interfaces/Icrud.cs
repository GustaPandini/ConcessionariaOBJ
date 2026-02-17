
namespace ConsoleApp2.Interfaces
{
    internal interface Icrud<T>
    {
        void Inserir();
        void Listar();
        void Alterar();
        void Deletar();
    }
}
