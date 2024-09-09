using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    public interface ICrud<T> where T : class
    {

        public void Buscar();
        public void BuscarId(T entidade);
        public void Inserir(T entidade); 
        public void Editar(T entidade);
        public void Apagar(T entidade);
        
    }
}