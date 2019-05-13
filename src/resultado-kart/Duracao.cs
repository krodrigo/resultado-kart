using System;

namespace resultado_kart
{
    public class Duracao
    {
        public Duracao(string dado)
        {
            Minutos = int.Parse(dado.Split(':')[0]);
            Segundos = int.Parse(dado.Split(':')[1].Split('.')[0]);
            Milisegundos = int.Parse(dado.Split(':')[1].Split('.')[1]);
            TimeSpan = new TimeSpan(0, 0, Minutos, Segundos, Milisegundos);
        }

        public int Minutos { get; private set; }
        public int Segundos { get; private set; }
        public int Milisegundos { get; private set; }
        public TimeSpan TimeSpan { get; private set; }
    }
}
