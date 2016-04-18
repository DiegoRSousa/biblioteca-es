using System;

namespace Biblioteca.Model
{
    public class Devolucao
    {
        public Guid  Id { get; set; }
        public Emprestimo Emprestimo { get; set; }
        public DateTime Data { get; set; }
        public int DiasAtrasado { get; set; }
        public double Multa { get; set; }


        protected bool Equals(Devolucao other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Devolucao)) return false;
            return Equals((Devolucao)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
