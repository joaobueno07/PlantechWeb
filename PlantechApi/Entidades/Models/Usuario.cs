using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades.Enums;

namespace Entidades.Models
{
    public class Usuario
    {
        //public int Id { get; set;}

        public string Nome { get; set; }
        public string Email { get; set;}
        public string Senha { get; set;}
        public string TipoUsuario { get; set;}
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public Status status { get; set; }
        public NivelAcesso nivelAcesso { get; set; }
        public Cargo cargo { get; set; }

        // -Nome:string
        // -Email:string
        // -Senha:string
        // -TipoUsuario: string
        // -DataNascimento:date
        // -Endereço:string
        // -Telefone:string
        // -Status : ENUM{admitido, demitido}
        // -nivelAcesso:NivelAcesso
        // - cargo : Cargo
    }
}