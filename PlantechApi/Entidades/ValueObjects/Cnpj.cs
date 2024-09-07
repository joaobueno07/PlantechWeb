using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades.ValueObjects
{
    public class Cnpj
    {
        public string Numero { get; }

        public Cnpj(string numero)
        {
            if (!IsValid(numero))
                throw new ArgumentException("CNPJ inválido");

            Numero = numero;
        }

        private bool IsValid(string numero)
        {
            // Lógica de validação de CNPJ
            return true; // Simplificação para o exemplo
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Cnpj other = (Cnpj)obj;
            return Numero == other.Numero;
        }

        public override int GetHashCode()
        {
            return Numero.GetHashCode();
        }
    }
}