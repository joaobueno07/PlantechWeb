using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    public interface ICrud
    {

        public void Buscar();
        public void BuscarId(int id);
        public void BuscarId(string id);

        // fazer sobrecarga ou add parametros conforme nescessario das interfaces abaixo
        public void Inserir(string nome, string email, string senha, int nivelAcesso_pk_nivel, int cargos_pk_cargos); 
        public void Editar(int pk_usuario, string nome, string email, string senha, int nivelAcesso_pk_nivel, int cargos_pk_cargos);
        public void Apagar(int pk_usuario);
        
    }
}