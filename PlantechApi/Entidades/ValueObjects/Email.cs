using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades.ValueObjects
{
    public class Email
    {
        public string Endereco { get; }

        public Email(string endereco)
        {
            if (!IsValid(endereco))
                throw new ArgumentException("Endereço de email inválido");

            Endereco = endereco;
        }

        private bool IsValid(string endereco)
        {
            // Lógica de validação de email
            return true; // Simplificação para o exemplo
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Email other = (Email)obj;
            return Endereco == other.Endereco;
        }

        public override int GetHashCode()
        {
            return Endereco.GetHashCode();
        }
    }
}