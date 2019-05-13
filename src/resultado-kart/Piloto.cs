using System;
using System.Collections.Generic;

namespace resultado_kart
{
    public class Piloto : IEquatable<Piloto>
    {
        public Piloto(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

        public int Codigo { get; private set; }
        public string Nome { get; private set; }
        public IEnumerable<Volta> Voltas { get; set; }

        public bool Equals(Piloto other)
        {
            return Codigo == other.Codigo;
        }

        public override int GetHashCode()
        {
            return Codigo.GetHashCode();
        }
    }
}