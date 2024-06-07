using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IMedicoService
    {
        int Inserir(TbMedico medico);
        void Editar(TbMedico medico);
        TbMedico Obter(int id);
        void Remove(TbMedico id);

        IEnumerable<TbMedico> ObterPorNome(string nome);
        IEnumerable<TbMedico> ObterTodos();

    }
}
