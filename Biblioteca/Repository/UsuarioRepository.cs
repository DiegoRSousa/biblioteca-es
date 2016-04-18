using Biblioteca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Biblioteca.Repository
{
    public class UsuarioRepository
    {
        private const string arquivo = "Usuarios.xml";
        private XElement elemento;
        private XElement xml;
        
        public void Inserir(Usuario usuario)
        {
            elemento = new XElement("usuario");
            elemento.Add(new XAttribute("id", usuario.Id.ToString()));
            elemento.Add(new XAttribute("matricula", usuario.Matricula.ToString()));
            elemento.Add(new XAttribute("nome", usuario.Nome.ToString()));
            elemento.Add(new XAttribute("senha", usuario.Senha.ToString()));
            elemento.Add(new XAttribute("telefone", usuario.Telefone.ToString()));
            elemento.Add(new XAttribute("email", usuario.Email.ToString()));

            XElement xml = XElement.Load(arquivo);
            xml.Add(elemento);
            xml.Save(arquivo);
        }

        public IList<Usuario> Todos()
        {
            IList<Usuario> usuarios = new List<Usuario>();
            xml = XElement.Load(arquivo);
            foreach (var elemento in xml.Elements())
            {
                Usuario usuario = new Usuario()
                {
                    Id = new Guid(elemento.Attribute("id").Value),
                    Matricula = elemento.Attribute("matricula").Value,
                    Nome = elemento.Attribute("nome").Value,
                    Senha = elemento.Attribute("senha").Value,
                    Telefone = elemento.Attribute("telefone").Value,
                    Email = elemento.Attribute("email").Value,
                };
                usuarios.Add(usuario);
            }
            return usuarios;
        }

        public void Remover(Usuario usuario)
        {
            xml = XElement.Load(arquivo);
            elemento = xml.Elements().Where(p => p.Attribute("id").Value.Equals(usuario.Id.ToString())).First();
            if (elemento != null)
            {
                elemento.Remove();
            }
            xml.Save(arquivo);
        }

        

        public void Atualizar(Usuario usuario)
        {
            xml = XElement.Load(arquivo);
            elemento = xml.Elements().Where(p => p.Attribute("id").Value.Equals(usuario.Id.ToString())).First();
            if (elemento != null)
            {
                elemento.Attribute("matricula").SetValue(usuario.Matricula);
                elemento.Attribute("nome").SetValue(usuario.Nome);
                elemento.Attribute("senha").SetValue(usuario.Senha);
                elemento.Attribute("telefone").SetValue(usuario.Telefone);
                elemento.Attribute("email").SetValue(usuario.Email);
                
            }
            xml.Save(arquivo);
        }

        public Usuario PorMatricula(string matricula)
        {
            xml = XElement.Load(arquivo);
            elemento = xml.Elements().Where(p => p.Attribute("matricula").Value.Equals(matricula.ToString())).First();
            if (elemento != null)
            {
                return new Usuario()
                {
                    Id = new Guid(elemento.Attribute("id").Value),
                    Matricula = elemento.Attribute("matricula").Value,
                    Nome = elemento.Attribute("nome").Value,
                    Senha = elemento.Attribute("senha").Value,
                    Telefone = elemento.Attribute("telefone").Value,
                    Email = elemento.Attribute("email").Value,
                };
            }
            return null;
        }

        internal Usuario PorId(string id)
        {
            xml = XElement.Load(arquivo);
            elemento = xml.Elements().Where(p => p.Attribute("id").Value.Equals(id.ToString())).First();
            if(elemento != null) 
            {
                return new Usuario()
                {
                    Id = new Guid(elemento.Attribute("id").Value),
                    Matricula = elemento.Attribute("matricula").Value,
                    Nome = elemento.Attribute("nome").Value,
                    Senha = elemento.Attribute("senha").Value,
                    Telefone = elemento.Attribute("telefone").Value,
                    Email = elemento.Attribute("email").Value,
                };
            }
            return null;
        }
    }
}
