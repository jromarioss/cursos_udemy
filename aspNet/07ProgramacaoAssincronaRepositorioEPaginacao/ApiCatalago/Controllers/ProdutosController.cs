﻿using ApiCatalago.DTO;
using ApiCatalago.Model;
using ApiCatalago.Pagination;
using ApiCatalago.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiCatalago.Controllers;

// rota /produtos
[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IUnitOfWork _uow; // implementa o unit of work
    private readonly IMapper _mapper; // implementa o mapper

    public ProdutosController(IUnitOfWork context, IMapper mapper) // instância o contexto
    {
        _uow = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get([FromQuery] ProdutosParameters produtosParameters) // o actionresult permite ter varios tipo de reposta como notfound ok...
    {
        try
        {
            //var produtos = _uow.ProdutoRepository.Get().ToList();
            var produtos = await _uow.ProdutoRepository.GetProdutos(produtosParameters);

            var metadata = new //inclui as informações no metadata
            {
                produtos.TotalCount,
                produtos.PageSize,
                produtos.CurrentPage,
                produtos.TotalPages,
                produtos.HasNext,
                produtos.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata)); // e coloca no headers

            var produtosDTO = _mapper.Map<List<ProdutoDTO>>(produtos); // mapea os produtosdto

            return produtosDTO;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }

    // /produtos/id
    [HttpGet("{id:int}", Name= "obter-produto")] // rota nomeada /produtos/obter-produto
    public async Task<ActionResult<ProdutoDTO>> Get(int id)
    {
        try
        {
            var produto = await _uow.ProdutoRepository.GetById(p => p.ProdutoId == id);

            if (produto is null)
            {
                return NotFound("Produto não encontrado.");
            }

            var produtoDTO = _mapper.Map<ProdutoDTO>(produto);

            return produtoDTO;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }

    [HttpGet("menor-preco")]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetProdutosPeloPreco()
    {
        try
        {
            var produtos = await _uow.ProdutoRepository.GetProdutosPeloPreco();
            var produtosDTO = _mapper.Map<List<ProdutoDTO>>(produtos); // mapea os produtosdto

            return produtosDTO;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post(ProdutoDTO produtoDto)
    {
        try
        {
            if (produtoDto is null)
            {
                return BadRequest("Dados inválido.");
            }

            var produto = _mapper.Map<Produto>(produtoDto); // mapea para produto

            _uow.ProdutoRepository.Add(produto); // chama o contexto a tabela produtos e adiciona
            await _uow.Commit(); // persiste os dado na DB

            var produtoDTO = _mapper.Map<ProdutoDTO>(produto);

            // chama a rota e com o produto criado
            return new CreatedAtRouteResult("obter-produto",
                new { id = produtoDTO.ProdutoId }, produtoDTO);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, ProdutoDTO produtoDto)
    {
        try
        {
            if (id != produtoDto.ProdutoId)
            {
                return BadRequest("Produto inválido.");
            }

            var produto = _mapper.Map<Produto>(produtoDto);

            // usa o entry e define o estado para modificado
            _uow.ProdutoRepository.Update(produto);
            await _uow.Commit();

            return Ok(produto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ProdutoDTO>> Delete(int id)
    {
        try
        {
            // busca no banco o id
            var produto = await _uow.ProdutoRepository.GetById(p => p.ProdutoId == id);

            if (produto is null)
            {
                return NotFound("Produto não encontrado.");
            }

            _uow.ProdutoRepository.Delete(produto);
            await _uow.Commit();

            var produtoDTO = _mapper.Map<ProdutoDTO>(produto);

            return Ok(produtoDTO);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }
}
