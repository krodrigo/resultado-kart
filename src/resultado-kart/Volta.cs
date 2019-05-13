using System;

namespace resultado_kart
{
    public class Volta
    {
        public Volta(string linha)
        {
            var dados = linha.Split("|");
            Hora = DateTime.Parse(dados[0]);
            Piloto = new Piloto(Convert.ToInt32(dados[1]), dados[2]);
            Numero = int.Parse(dados[3]);
            Duracao = new Duracao(dados[4]);
        }

        public int Numero { get; private set; }
        public DateTime Hora { get; private set; }
        public Piloto Piloto { get; private set; }
        public Duracao Duracao { get; private set; }
    }
}