using System;

namespace Biblioteca.Model
{
    public class Livro
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Edicao { get; set; }
        public bool Reservado { get; set; }

        public Livro()
        {
            Reservado = false;
        }
        protected bool Equals(Livro other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Livro)) return false;
            return Equals((Livro)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.Titulo + " Autor: " + this.Autor;
        } 
    }
}
