using System;

namespace Biblioteca.Service
{
    public class Calculadora
    {
        public static DateTime DataPrevista(DateTime dataRetirada)
        {
            return dataRetirada.AddDays(22);
        }

        public static int DiasAtrasado(DateTime dataPrevista)
        {
            return ((DateTime.Now - dataPrevista).Days < 0) ?
                0 : (DateTime.Now - dataPrevista).Days;
        }

        public static double Multa(DateTime dataPrevista)
        {
            return DiasAtrasado(dataPrevista) * 0.50;
        }
    }
}
