using System;

namespace Biblioteca.Model
{
    public class Reserva
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public Usuario Usuario { get; set; }
        public Livro Livro { get; set; }

        protected bool Equals(Reserva other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Reserva)) return false;
            return Equals((Reserva)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
