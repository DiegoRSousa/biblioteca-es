using System;

namespace Biblioteca.Model
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        protected bool Equals(Usuario other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Usuario)) return false;
            return Equals((Usuario)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.Matricula;
        }
    }
}
