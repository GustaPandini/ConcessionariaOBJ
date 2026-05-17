
namespace ConsoleApp2.Interfaces
{
    public interface ICrud<T>
    {
        void Inserir();
        void Listar();
        void Alterar();
        void Deletar();
    }
}
