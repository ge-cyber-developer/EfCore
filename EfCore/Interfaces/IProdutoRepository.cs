using EfCore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore.Interfaces
{
    interface IProdutoRepository
    {
        List<Produto> Listar();
        Produto BuscarPorId(Guid id);
        void Adicionar(Produto produto);
        void Editar(Produto produto);
        void Remover(Guid id);
    }
}
