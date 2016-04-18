using System;

namespace Biblioteca.Model
{
    public class Emprestimo
    {   
        public Guid Id { get; set; }
        public Usuario Usuario { get; set; }
        public Livro Livro { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime DataPrevista { get; set; }
        public bool Finalizado { get; set; }

        protected bool Equals(Emprestimo other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Emprestimo)) return false;
            return Equals((Emprestimo)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
