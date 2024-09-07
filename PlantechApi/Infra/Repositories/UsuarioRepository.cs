using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades.Interfaces;

namespace Infra.Repositories
{
    public class UsuarioRepository : ICrud
    {
        public void Apagar(int pk_usuario)
        {
            throw new NotImplementedException();
        }

        public void Buscar()
        {
            throw new NotImplementedException();
        }

        public void BuscarId(int id)
        {
            throw new NotImplementedException();
        }

        public void BuscarId(string id)
        {
            throw new NotImplementedException();
        }

        public void Editar(int pk_usuario, string nome, string email, string senha, int nivelAcesso_pk_nivel, int cargos_pk_cargos)
        {
            throw new NotImplementedException();
        }

        public void Inserir(string nome, string email, string senha, int nivelAcesso_pk_nivel, int cargos_pk_cargos)
        {
            throw new NotImplementedException();
        }
    }
}