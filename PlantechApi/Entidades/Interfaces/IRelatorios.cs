using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    public interface IRelatorios
    {
        //Funcionario

        public void GerarRelatorioProducao(); // agricultor
        public void GerarRelatorioCompra();
        public void GerarRelatorioVenda();

        
    }
}