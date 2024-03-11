using ApiCatalago.Context;
using ApiCatalago.DTO;
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
public class CategoriasController : ControllerBase
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CategoriasController(IUnitOfWork context, IMapper mapper) // instância o contexto
    {
        _uow = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get([FromQuery] CategoriasParameters categoriasParameters) // o actionresult permite ter varios tipo de reposta como notfound ok...
    {
        try
        {
            //var categorias = _uow.CategoriaRepository.Get().ToList();
            var categorias = await _uow.CategoriaRepository.GetCategorias(categoriasParameters);

            var metadata = new
            {
                categorias.TotalCount,
                categorias.PageSize,
                categorias.CurrentPage,
                categorias.TotalPages,
                categorias.HasNext,
                categorias.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata)); // e coloca no headers

            var categoriasDTO = _mapper.Map<List<CategoriaDTO>>(categorias);

            return categoriasDTO;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }

    [HttpGet("produtos")] // /categorias/produtos
    public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategoriasEProdutos()
    {
        try
        {
            var categorias = await _uow.CategoriaRepository.GetCategoriasProdutos(); // incluí os produtos relacionado
            var categoriasDTO = _mapper.Map<List<CategoriaDTO>>(categorias);

            return categoriasDTO;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }  
    }

    // /produtos/id
    [HttpGet("{id:int}", Name = "obter-categoria")] // rota nomeada /produtos/obter-produto
    public async Task<ActionResult<CategoriaDTO>> Get(int id)
    {
        try
        {
            var categoria = await _uow.CategoriaRepository.GetById(p => p.CategoriaId == id);

            if (categoria is null)
            {
                return NotFound("Categoria não encontrado.");
            }

            var categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);

            return categoriaDTO;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post(CategoriaDTO categoriaDto)
    {
        try
        {
            if (categoriaDto is null)
            {
                return BadRequest("Dados inválido.");
            }

            var categoria = _mapper.Map<Categoria>(categoriaDto);

            _uow.CategoriaRepository.Add(categoria); // chama o contexto a tabela produtos e adiciona
            await _uow.Commit(); // persiste os dado na DB

            var categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);

            // chama a rota e com o produto criado
            return new CreatedAtRouteResult("obter-categoria",
                new { id = categoriaDTO.CategoriaId }, categoriaDTO);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, CategoriaDTO categoriaDto)
    {
        try
        {
            if (id != categoriaDto.CategoriaId)
            {
                return BadRequest("Produto inválido.");
            }

            var categoria = _mapper.Map<Categoria>(categoriaDto);

            // usa o entry e define o estado para modificado
            _uow.CategoriaRepository.Update(categoria);
            await _uow.Commit();

            return Ok(categoria);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<CategoriaDTO>> Delete(int id)
    {
        try
        {
            // busca no banco o id
            var categoria = await _uow.CategoriaRepository.GetById(c => c.CategoriaId == id);

            if (categoria is null)
            {
                return NotFound("Produto não encontrado.");
            }

            _uow.CategoriaRepository.Delete(categoria);
            await _uow.Commit();

            var categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);

            return Ok(categoriaDTO);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }
}
