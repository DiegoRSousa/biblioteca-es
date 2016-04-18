using Biblioteca.Model;
using Biblioteca.Repository;
using System.Collections.Generic;

namespace Biblioteca.Controller
{
    public class LivroController
    {
        private LivroRepository livroRepository = new LivroRepository();

        public void Inserir(Livro livro) 
        {
            this.livroRepository.Inserir(livro);
        }

        public void Remover(Livro livro)
        {
            this.livroRepository.Remover(livro);
        }

        public IList<Livro> Todos()
        {
            return this.livroRepository.Todos();
        }

        public void Atualizar(Livro livro)
        {
            this.livroRepository.Atualizar(livro);
            
        }

        public IList<Livro> PorTitulo(string titulo)
        {
            return this.livroRepository.PorTitulo(titulo);
        }

    }
}
