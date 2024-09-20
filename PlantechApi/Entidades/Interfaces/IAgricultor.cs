using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    public interface IAgricultor<T> where T : class
    {
        // +RegistrarPlantio(dataInicio:date):void
        // +ConsumirItens(item:Item,Quantidade:int):void
        // +RegistrarColheita(produtos:Produtos,DataTermino:date,Lote:string):bool
    }
}