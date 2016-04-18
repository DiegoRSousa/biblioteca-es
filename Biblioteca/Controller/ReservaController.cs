using Biblioteca.Model;
using Biblioteca.Repository;
using System.Collections.Generic;

namespace Biblioteca.Controller
{
    public class ReservaController
    {
        private ReservaRepository reservaRepository = new ReservaRepository();

        public void Inserir(Reserva reserva)
        {
            this.reservaRepository.Inserir(reserva);
        }

        public void Remover(Reserva reserva)
        {
            this.reservaRepository.Remover(reserva);
        }

        public IList<Reserva> Todos()
        {
            return this.reservaRepository.Todos();
        }
    }
}
