using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal class MedicoService : IMedicoService
    {
        private readonly ConsultaFacilContext _context;

        public MedicoService(ConsultaFacilContext context)
        {
            _context = context;
        }
        public void Remove(TbMedico id)
        {
            var _medico = _context.TbMedicos.Find(id);
            _context.TbMedicos.Remove(_medico);
            _context.SaveChanges();
        }

        public void Editar(TbMedico medico)
        {
            _context.Update(medico);
            _context.SaveChanges();
        }

        public int Inserir(TbMedico medico)
        {
            _context.Add(medico);
            _context.SaveChanges();
            return medico.IdMedico;
        }

        public TbMedico Obter(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbMedico> ObterPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbMedico> ObterTodos()
        {
            return GetQuery();
        }

        private IQueryable<TbMedico> GetQuery()
        {
            IQueryable<TbMedico> tb_medico = _context.TbMedicos;
            var query = from medico in tb_medico
                        select medico;
            return query;
        }
    }
}
