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
    public ActionResult<IEnumerable<ProdutoDTO>> Get() // o actionresult permite ter varios tipo de reposta como notfound ok...
    {
        try
        {
            var produtos = _uow.ProdutoRepository.Get().ToList();
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
    public ActionResult<ProdutoDTO> Get(int id)
    {
        try
        {
            var produto = _uow.ProdutoRepository.GetById(p => p.ProdutoId == id);

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
    public ActionResult<IEnumerable<ProdutoDTO>> GetProdutosPeloPreco()
    {
        try
        {
            var produtos = _uow.ProdutoRepository.GetProdutosPeloPreco().ToList();
            var produtosDTO = _mapper.Map<List<ProdutoDTO>>(produtos); // mapea os produtosdto

            return produtosDTO;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }

    [HttpPost]
    public ActionResult Post(ProdutoDTO produtoDto)
    {
        try
        {
            if (produtoDto is null)
            {
                return BadRequest("Dados inválido.");
            }

            var produto = _mapper.Map<Produto>(produtoDto); // mapea para produto

            _uow.ProdutoRepository.Add(produto); // chama o contexto a tabela produtos e adiciona
            _uow.Commit(); // persiste os dado na DB

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
    public ActionResult Put(int id, ProdutoDTO produtoDto)
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
            _uow.Commit();

            return Ok(produto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult<ProdutoDTO> Delete(int id)
    {
        try
        {
            // busca no banco o id
            var produto = _uow.ProdutoRepository.GetById(p => p.ProdutoId == id);

            if (produto is null)
            {
                return NotFound("Produto não encontrado.");
            }

            _uow.ProdutoRepository.Delete(produto);
            _uow.Commit();

            var produtoDTO = _mapper.Map<ProdutoDTO>(produto);

            return Ok(produtoDTO);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }
}
