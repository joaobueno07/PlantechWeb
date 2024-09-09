using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades.Enums;
using Entidades.Models;
using Entidades.ValueObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entidades.Interfaces
{
    public interface IFuncionario<T> where T : class
    {
        public void RegistrarPlantio(Date dataInicio);
        public void ConsumirItens(Item Item, int Quantidade);
        public bool RegistrarColheita(Produto produtos, Date DataTermino, string Lote);
        public void FazerVenda(Produto produto);
        public void FazerCompras(Produto produto);
        public bool RegistrarNovoFuncionario(Usuario usuario, Cargo cargo);
        public void Cadastro(T entidade);
    }
}