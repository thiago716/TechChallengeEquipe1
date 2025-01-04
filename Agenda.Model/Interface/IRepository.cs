using Agenda.Model.Entity;

namespace Agenda.Model.Interface
{
    public interface IRepository
    {
        IList<Contato> ObterTodos();
        Contato ObterPorId(int id);
        IList<Contato> BuscarPorDdd(int Ddd);
        void Cadastrar(Contato entidade);
        void Alterar(Contato entidade);
        void Deletar(int id);
    }
}
