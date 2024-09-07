using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades.ValueObjects
{
    public class Telefone
    {
        public string Numero { get; }

        public Telefone(string numero)
        {
            if (!IsValid(numero))
                throw new ArgumentException("Número de telefone inválido");

            Numero = numero;
        }

        private bool IsValid(string numero)
        {
            // Lógica de validação de telefone
            return true; // Simplificação para o exemplo
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Telefone other = (Telefone)obj;
            return Numero == other.Numero;
        }

        public override int GetHashCode()
        {
            return Numero.GetHashCode();
        }
    }
}