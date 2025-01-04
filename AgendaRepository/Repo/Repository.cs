using Agenda.Model.Entity;
using Agenda.Model.Interface;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Dados.Repo
{
    public class Repository : IRepository
    {
        protected AgendaDbContext _context;
        protected DbSet<Contato> _dbContato;

        public Repository(AgendaDbContext context)
        {
            _context = context;
            _dbContato = _context.Set<Contato>();
        }

        public void Alterar(Contato entidade)
        {
            _dbContato.Update(entidade);
            _context.SaveChanges();
        }

        public IList<Contato> BuscarPorDdd(int Ddd)
            => _dbContato.AsNoTracking().Include(x => x.Ddd).Where(x => x.Ddd == Ddd).ToList();

        public void Cadastrar(Contato entidade)
        {
            _dbContato.Add(entidade);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            _dbContato.Remove(ObterPorId(id));
            _context.SaveChanges();
        }

        public Contato ObterPorId(int id)
          => _dbContato.FirstOrDefault(e => e.IdContato == id);


        public IList<Contato> ObterTodos()
            => _dbContato.ToList();

    }
}
