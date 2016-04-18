using Biblioteca.Model;
using Biblioteca.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Biblioteca.Repository
{
    public class EmprestimoRepository
    {
        private const string arquivo = "Emprestimos.xml";
        private XElement elemento;
        private XElement xml;
        private UsuarioRepository usuarioRepository = new UsuarioRepository();
        private LivroRepository livroRepository = new LivroRepository();

        public void Inserir(Emprestimo emprestimo)
        {
            this.elemento = new XElement("emprestimo");
            elemento.Add(new XAttribute("id", emprestimo.Id.ToString()));
            elemento.Add(new XAttribute("usuario", emprestimo.Usuario.Id.ToString()));
            elemento.Add(new XAttribute("livro", emprestimo.Livro.Id.ToString()));
            elemento.Add(new XAttribute("data-retirada", emprestimo.DataRetirada.ToString()));
            elemento.Add(new XAttribute("data-prevista", emprestimo.DataPrevista.ToString()));
            elemento.Add(new XAttribute("finalizado", emprestimo.Finalizado.ToString()));

            this.xml = XElement.Load(arquivo);
            this.xml.Add(elemento);
            this.xml.Save(arquivo);
        }

        public IList<Emprestimo> Todos()
        {
            IList<Emprestimo> emprestimos = new List<Emprestimo>();
            this.xml = XElement.Load(arquivo);
            foreach (var elemento in xml.Elements())
            {
                Emprestimo emprestimo = new Emprestimo()
                {
                    Id = new Guid(elemento.Attribute("id").Value),
                    Usuario = usuarioRepository.PorId(elemento.Attribute("usuario").Value),
                    Livro = livroRepository.PorId(elemento.Attribute("livro").Value),
                    DataRetirada = Convert.ToDateTime(elemento.Attribute("data-retirada").Value),
                    DataPrevista = Convert.ToDateTime(elemento.Attribute("data-prevista").Value),
                    Finalizado = Convert.ToBoolean(elemento.Attribute("finalizado").Value)
                };
                emprestimos.Add(emprestimo);
            }
            return emprestimos;
        }

        public void Atualizar(Emprestimo emprestimo)
        {
            this.xml = XElement.Load(arquivo);
            elemento = xml.Elements().Where(p => p.Attribute("id").Value.Equals(emprestimo.Id.ToString())).First();
            if (elemento != null)
            {
                elemento.Attribute("finalizado").SetValue(emprestimo.Finalizado);
            }
            this.xml.Save(arquivo);
        }


        public Emprestimo PorId(string id)
        {
            this.xml = XElement.Load(arquivo);
            this.elemento = xml.Elements().Where(p => p.Attribute("id").Value.Equals(id.ToString())).First();
            if (elemento != null)
            {
                return new Emprestimo()
                {
                    Id = new Guid(elemento.Attribute("id").Value),
                    Usuario = usuarioRepository.PorId(elemento.Attribute("usuario").Value),
                    Livro = livroRepository.PorId(elemento.Attribute("livro").Value),
                    DataRetirada = Convert.ToDateTime(elemento.Attribute("data-retirada").Value),
                    DataPrevista = Convert.ToDateTime(elemento.Attribute("data-prevista").Value),
                    Finalizado = Convert.ToBoolean(elemento.Attribute("finalizado").Value)
                };
            }
            return null;
        }
    }
}
