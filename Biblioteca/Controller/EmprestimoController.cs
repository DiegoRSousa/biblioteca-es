using Biblioteca.Model;
using Biblioteca.Repository;
using System;
using System.Collections.Generic;

namespace Biblioteca.Controller
{
    public class EmprestimoController
    {
        private EmprestimoRepository emprestimoRepository = new EmprestimoRepository();


        public void Inserir(Emprestimo emprestimo)
        {
            this.emprestimoRepository.Inserir(emprestimo);
        }

        public IList<Emprestimo> Todos()
        {
            return this.emprestimoRepository.Todos();
        }

        public Emprestimo PorId(string id)
        {
            return emprestimoRepository.PorId(id);
        }

        public void Atualizar(Emprestimo emprestimo)
        {
            this.emprestimoRepository.Atualizar(emprestimo);
        }

    }
}
