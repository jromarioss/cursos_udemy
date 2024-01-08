using ApiCatalago.Context;
using ApiCatalago.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalago.Controllers;

// rota /produtos
[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context) // instância o contexto
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get() // o actionresult permite ter varios tipo de reposta como notfound ok...
    {
        try
        {
            var produtos = _context.Produtos.AsNoTracking().ToList();

            if (produtos is null)
            {
                return NotFound();
            }

            return produtos;
        }
        catch (Exception)
        {
            
        }
    }

    // /produtos/id
    [HttpGet("{id:int}", Name= "obter-produto")] // rota nomeada /produtos/obter-produto
    public ActionResult<Produto> Get(int id)
    {
        try
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if (produto is null)
            {
                return NotFound("Produto não encontrado.");
            }

            return produto;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }

    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        try
        {
            if (produto is null)
            {
                return BadRequest("Dados inválido.");
            }

            _context.Produtos.Add(produto); // chama o contexto a tabela produtos e adiciona
            _context.SaveChanges(); // persiste os dado na DB

            // chama a rota e com o produto criado
            return new CreatedAtRouteResult("obter-produto",
                new { id = produto.ProdutoId }, produto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Produto produto)
    {
        try
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest("Produto inválido.");
            }

            // usa o entry e define o estado para modificado
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        try
        {
            // busca no banco o id
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if (produto is null)
            {
                return NotFound("Produto não encontrado.");
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }
}
