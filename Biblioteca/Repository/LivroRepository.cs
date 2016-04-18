using Biblioteca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Biblioteca.Repository
{
    public class LivroRepository
    {
        private const string arquivo = "Livros.xml";
        private XElement elemento;
        private XElement xml;

        public void Inserir(Livro livro)
        {
            this.elemento = new XElement("livro");
            elemento.Add(new XAttribute("id", livro.Id.ToString()));
            elemento.Add(new XAttribute("codigo", livro.Codigo.ToString()));
            elemento.Add(new XAttribute("titulo", livro.Titulo.ToString()));
            elemento.Add(new XAttribute("edicao", livro.Edicao.ToString()));
            elemento.Add(new XAttribute("autor", livro.Autor.ToString()));

            this.xml = XElement.Load(arquivo);
            this.xml.Add(elemento);
            this.xml.Save(arquivo);
        }

        public IList<Livro> Todos()
        {
            List<Livro> livros = new List<Livro>();
            this.xml = XElement.Load(arquivo);
            foreach (var elemento in xml.Elements())
            {
                Livro livro = new Livro()
                {
                    Id = new Guid(elemento.Attribute("id").Value),
                    Codigo = elemento.Attribute("codigo").Value,
                    Titulo = elemento.Attribute("titulo").Value,
                    Edicao = elemento.Attribute("edicao").Value,
                    Autor = elemento.Attribute("autor").Value,
                    Reservado = Convert.ToBoolean(elemento.Attribute("reservado").Value)

                };
                livros.Add(livro);
            }
            return livros;
        }

        public void Remover(Livro livro)
        {
            this.xml = XElement.Load(arquivo);
            this.elemento = xml.Elements().Where(p => p.Attribute("id").Value.Equals(livro.Id.ToString())).First();
            if (elemento != null)
            {
                elemento.Remove();
            }
            this.xml.Save(arquivo);
        }

        public void Atualizar(Livro livro)
        {
            this.xml = XElement.Load(arquivo);
            this.elemento = xml.Elements().Where(p => p.Attribute("id").Value.Equals(livro.Id.ToString())).First();
            if (elemento != null)
            {
                elemento.Attribute("codigo").SetValue(livro.Codigo);
                elemento.Attribute("titulo").SetValue(livro.Titulo);
                elemento.Attribute("edicao").SetValue(livro.Edicao);
                elemento.Attribute("autor").SetValue(livro.Autor);
                elemento.Attribute("reservado").SetValue(livro.Reservado);
            }
            xml.Save(arquivo);
        }

        //gambiarra: tive que adionar numa lista para então fazer a busca por titulo e código na lista
        public IList<Livro> PorTitulo(String titulo)
        {
            List<Livro> livros = new List<Livro>();
            this.xml = XElement.Load(arquivo);
            foreach (var elemento in xml.Elements())
            {
                Livro livro = new Livro()
                {
                    Id = new Guid(elemento.Attribute("id").Value),
                    Codigo = elemento.Attribute("codigo").Value,
                    Titulo = elemento.Attribute("titulo").Value,
                    Edicao = elemento.Attribute("edicao").Value,
                    Autor = elemento.Attribute("autor").Value,
                    Reservado = Convert.ToBoolean(elemento.Attribute("reservado").Value)

                };
                livros.Add(livro);
            }
            return livros.FindAll(x => x.Titulo.Contains(titulo));
        }

        
        public Livro PorCodigo(string codigo)
        {

            List<Livro> livros = new List<Livro>();
            this.xml = XElement.Load(arquivo);
            foreach (var elemento in xml.Elements())
            {
                Livro livro = new Livro()
                {
                    Id = new Guid(elemento.Attribute("id").Value),
                    Codigo = elemento.Attribute("codigo").Value,
                    Titulo = elemento.Attribute("titulo").Value,
                    Edicao = elemento.Attribute("edicao").Value,
                    Autor = elemento.Attribute("autor").Value

                };
                livros.Add(livro);
            }
            return livros.Find(x => x.Codigo.Contains(codigo));
        }

        internal Livro PorId(string id)
        {
            this.xml = XElement.Load(arquivo);
            this.elemento = xml.Elements().Where(p => p.Attribute("id").Value.Equals(id.ToString())).First();
            if (elemento != null)
            {
                return new Livro()
                {
                    Id = new Guid(elemento.Attribute("id").Value),
                    Codigo = elemento.Attribute("codigo").Value,
                    Titulo = elemento.Attribute("titulo").Value,
                    Edicao = elemento.Attribute("edicao").Value,
                    Autor = elemento.Attribute("autor").Value,
                    Reservado = Convert.ToBoolean(elemento.Attribute("reservado").Value)
                };
            }
            return null;
        }
    }
}
