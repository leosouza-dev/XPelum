using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XPelum.Data;
using XPelum.Models;

namespace XPelum.Repository
{
    public class AcessoriaRepository
    {

        private readonly MeuDbContext _context;
        public AcessoriaRepository(MeuDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Acessoria> ListarTodas()
        {
            return _context.Acessoria.ToList();
        }

        public void Salvar(Acessoria acessoria)
        {
            _context.Add(acessoria);
            _context.SaveChanges();
        }
    }
}