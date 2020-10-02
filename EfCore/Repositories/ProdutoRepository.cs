using EfCore.Contexts;
using EfCore.Domains;
using EfCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PedidoContext ctx;

        public ProdutoRepository()
        {
            ctx = new PedidoContext();
        }

        void IProdutoRepository.Adicionar(Produto produto)
        {
            try
            {
                ctx.Add(produto);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        Produto IProdutoRepository.BuscarPorId(Guid id)
        {
            try
            {
                return ctx.Produtos.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void IProdutoRepository.Editar(Produto produto)
        {
            try
            {
                var produtoTemp = ctx.Produtos.Find(produto.Id);
                produtoTemp.NomeProduto = produto.NomeProduto;
                produtoTemp.Preco = produto.Preco;

                ctx.Update(produtoTemp);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        List<Produto> IProdutoRepository.Listar()
        {
            try
            {
                return ctx.Produtos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void IProdutoRepository.Remover(Guid id)
        {
            try
            {
                var produtoTemp = ctx.Produtos.Find(id);
                ctx.Remove(produtoTemp);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
