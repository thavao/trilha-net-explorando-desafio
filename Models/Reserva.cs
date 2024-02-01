using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            int numeroDeHospedes = hospedes.Count();
            if (numeroDeHospedes <= this.Suite.Capacidade && numeroDeHospedes > 0)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("Numero de hospedes não pode ultrapassar o limite da Suite e nem ser menor que 1");
            }

        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return this.Hospedes.Count(); ;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados > 10)
            {
                valor = valor - (0.1M * valor);
            }

            return valor;
        }
    }
}