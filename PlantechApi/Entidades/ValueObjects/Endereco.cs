using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades.ValueObjects
{
    public class Endereco(string rua, string cidade, string estado, string cep)
    {
        public string Rua { get; } = rua;
        public string Cidade { get; } = cidade;
        public string Estado { get; } = estado;
        public string CEP { get; } = cep;

        // Override Equals and GetHashCode for value equality
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Endereco other = (Endereco)obj;
            return Rua == other.Rua && Cidade == other.Cidade && Estado == other.Estado && CEP == other.CEP;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Rua, Cidade, Estado, CEP);
        }
    }
}