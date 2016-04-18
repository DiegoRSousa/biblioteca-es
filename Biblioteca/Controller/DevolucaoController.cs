using Biblioteca.Model;
using Biblioteca.Repository;
using System.Collections.Generic;

namespace Biblioteca.Controller
{
    public class DevolucaoController
    {
        private DevolucaoRepository devolucaoRepository = new DevolucaoRepository();

        public void Inserir(Devolucao devolucao)
        {
            this.devolucaoRepository.Inserir(devolucao);
        }
        
        public IList<Devolucao> Todos()
        {
            return this.devolucaoRepository.Todos();
        }

    }
}
