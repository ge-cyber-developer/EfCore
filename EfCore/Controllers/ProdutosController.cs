using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCore.Domains;
using EfCore.Interfaces;
using EfCore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var produtos = _produtoRepository.Listar();
            try
            {
                if (produtos.Count == 0)
                {
                    return NoContent();
                }

                return Ok(produtos);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid Id)
        {
            var produtos = _produtoRepository.BuscarPorId(Id);
            try
            {
                if (produtos == null)
                {
                    return NotFound();
                }

                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Produto produto)
        {
         
            try
            {
                _produtoRepository.Adicionar(produto);

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Post(Guid id, Produto produto)
        {

            try
            {
                produto.Id = id;
                _produtoRepository.Editar(produto);

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {

            try
            {
                var produto = _produtoRepository.BuscarPorId(id);

                if (produto == null)
                {
                    return NotFound();
                }

                _produtoRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
