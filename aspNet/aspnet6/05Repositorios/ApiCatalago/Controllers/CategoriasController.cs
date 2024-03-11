using ApiCatalago.Context;
using ApiCatalago.DTO;
using ApiCatalago.Model;
using ApiCatalago.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public ActionResult<IEnumerable<CategoriaDTO>> Get() // o actionresult permite ter varios tipo de reposta como notfound ok...
    {
        try
        {
            var categorias = _uow.CategoriaRepository.Get().ToList();
            var categoriasDTO = _mapper.Map<List<CategoriaDTO>>(categorias);

            return categoriasDTO;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }

    [HttpGet("produtos")] // /categorias/produtos
    public ActionResult<IEnumerable<CategoriaDTO>> GetCategoriasEProdutos()
    {
        try
        {
            var categorias = _uow.CategoriaRepository.GetCategoriasProdutos().ToList(); // incluí os produtos relacionado
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
    public ActionResult<CategoriaDTO> Get(int id)
    {
        try
        {
            var categoria = _uow.CategoriaRepository.GetById(p => p.CategoriaId == id);

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
    public ActionResult Post(CategoriaDTO categoriaDto)
    {
        try
        {
            if (categoriaDto is null)
            {
                return BadRequest("Dados inválido.");
            }

            var categoria = _mapper.Map<Categoria>(categoriaDto);

            _uow.CategoriaRepository.Add(categoria); // chama o contexto a tabela produtos e adiciona
            _uow.Commit(); // persiste os dado na DB

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
    public ActionResult Put(int id, CategoriaDTO categoriaDto)
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
            _uow.Commit();

            return Ok(categoria);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult<CategoriaDTO> Delete(int id)
    {
        try
        {
            // busca no banco o id
            var categoria = _uow.CategoriaRepository.GetById(c => c.CategoriaId == id);

            if (categoria is null)
            {
                return NotFound("Produto não encontrado.");
            }

            _uow.CategoriaRepository.Delete(categoria);
            _uow.Commit();

            var categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);

            return Ok(categoriaDTO);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }
}
