using Biblioteca.Model;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Biblioteca.Repository
{
    public class DevolucaoRepository
    {
        private const string arquivo = "Devolucoes.xml";
        private XElement elemento;
        private XElement xml;
        EmprestimoRepository emprestimoRepository = new EmprestimoRepository();

        public void Inserir(Devolucao devolucao)
        {
            this.elemento = new XElement("devolucao");
            elemento.Add(new XAttribute("id", devolucao.Id.ToString()));
            elemento.Add(new XAttribute("emprestimo", devolucao.Emprestimo.Id.ToString()));
            elemento.Add(new XAttribute("data", devolucao.Data.ToString()));
            elemento.Add(new XAttribute("dias-atrasado", devolucao.DiasAtrasado.ToString()));
            elemento.Add(new XAttribute("multa", devolucao.Multa.ToString()));
            this.xml = XElement.Load(arquivo);
            this.xml.Add(elemento);
            this.xml.Save(arquivo);
        }

        public IList<Devolucao> Todos()
        {
            IList<Devolucao> devolucoes = new List<Devolucao>();
            this.xml = XElement.Load(arquivo);
            foreach (var elemento in xml.Elements())
            {
                Devolucao devolucao = new Devolucao()
                {
                    Id = new Guid(elemento.Attribute("id").Value),
                    Emprestimo = emprestimoRepository.PorId(elemento.Attribute("emprestimo").Value),
                    Data = Convert.ToDateTime(elemento.Attribute("data").Value),
                    DiasAtrasado = Convert.ToInt16(elemento.Attribute("dias-atrasado").Value),
                    Multa = Convert.ToDouble(elemento.Attribute("multa").Value)
                };
                devolucoes.Add(devolucao);
            }
            return devolucoes;
        }

    }
}
