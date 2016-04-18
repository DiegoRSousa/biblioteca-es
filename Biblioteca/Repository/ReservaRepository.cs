using Biblioteca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Biblioteca.Repository
{
    public class ReservaRepository
    {
        private const string arquivo = "Reservas.xml";
        private XElement elemento;
        private XElement xml;
        private UsuarioRepository usuarioRepository = new UsuarioRepository();
        private LivroRepository livroRepository = new LivroRepository();

        public void Inserir(Reserva reserva)
        {
            this.elemento = new XElement("reserva");
            elemento.Add(new XAttribute("id", reserva.Id.ToString()));
            elemento.Add(new XAttribute("data", reserva.Data.ToString()));
            elemento.Add(new XAttribute("usuario", reserva.Usuario.Id.ToString()));
            elemento.Add(new XAttribute("livro", reserva.Livro.Id.ToString()));

            this.xml = XElement.Load(arquivo);
            this.xml.Add(elemento);
            this.xml.Save(arquivo);
        }

        public IList<Reserva> Todos()
        {
            IList<Reserva> reservas = new List<Reserva>();
            this.xml = XElement.Load(arquivo);
            foreach (var elemento in xml.Elements())
            {
                Reserva reserva = new Reserva()
                {
                    Id = new Guid(elemento.Attribute("id").Value),
                    Data = Convert.ToDateTime(elemento.Attribute("data").Value),
                    Usuario = usuarioRepository.PorId(elemento.Attribute("usuario").Value),
                    Livro = livroRepository.PorId(elemento.Attribute("livro").Value)
                    
                };
                reservas.Add(reserva);
            }
            return reservas;
        }

        public void Remover(Reserva reserva)
        {
            this.xml = XElement.Load(arquivo);
            this.elemento = xml.Elements().Where(p => p.Attribute("id").Value.Equals(reserva.Id.ToString())).First();
            if (elemento != null)
            {
                elemento.Remove();
            }
            xml.Save(arquivo);
        }
    }
}
