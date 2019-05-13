using System;

namespace resultado_kart
{
    public class Posicao
    {
        public Posicao(Piloto piloto, int voltasCompletadas,  TimeSpan tempoProva, Volta ultimaVolta, Volta melhorVolta)
        {
            Piloto = piloto;
            VoltasCompletadas = voltasCompletadas;
            TempoProva = tempoProva;
            UltimaVolta = ultimaVolta;
            MelhorVolta = melhorVolta;
        }

        public int? Numero { get; set; }
        public Piloto Piloto { get; private set; }
        public int VoltasCompletadas { get; private set; }
        public TimeSpan TempoProva { get; private set; }
        public Volta UltimaVolta { get; private set; }
        public Volta MelhorVolta { get; private set; }
    }
}
