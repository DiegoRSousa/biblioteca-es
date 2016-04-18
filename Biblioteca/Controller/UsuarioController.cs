using Biblioteca.Model;
using Biblioteca.Repository;
using System.Collections.Generic;

namespace Biblioteca.Controller
{
    public class UsuarioController
    {
        private UsuarioRepository usuarioRepository = new UsuarioRepository();

        public void Inserir(Usuario usuario)
        {
            this.usuarioRepository.Inserir(usuario);
        }

        public void Remover(Usuario usuario)
        {
            this.usuarioRepository.Remover(usuario);
        }

        public IList<Usuario> Todos()
        {
            return this.usuarioRepository.Todos();
        }

        public void Atualizar(Usuario usuario)
        {
            this.usuarioRepository.Atualizar(usuario);
        }

        public Usuario PorMatricula(string matricula)
        {
            return this.usuarioRepository.PorMatricula(matricula);
        }
    }
}
