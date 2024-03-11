using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Dataflow;

namespace APICatalogo.Controllers;

[Route("[controller]")] //definindo a rota e ela usa o nome do controlador que no caso é /produtos
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    //injetar a instância do contexto
    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    //método assincrono
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> Get2() 
    {
        return await _context.Produtos.AsNoTracking().ToListAsync();
    }

    //iniciando os metodos actions
    [HttpGet("primeiro")] //definindo um parâmetro /produtos/primeiro
    public ActionResult<Produto> GetPrimeiro()
    {
        var produtos = _context.Produtos.FirstOrDefault();

        if (produtos is null)
        {
            return NotFound("Produtos não encontrados");
        }

        return produtos;
    }

    //iniciando os metodos actions
    [HttpGet] // método que retorna todos produtos /produtos
    public ActionResult<IEnumerable<Produto>> Get() //actionresult tem todos os método de retorno
    {
        var produtos = _context.Produtos.AsNoTracking().ToList(); //tornar a consulta não rastreada

        if (produtos is null)
        {
            return NotFound("Produtos não encontrados");
        }

        return produtos;
    }

    //definir restrição na rota coloca o :int:min(1) ai ele sera do tipo inteiro e com valor minimo maior q 1
    [HttpGet("{id:int}", Name="ObterProduto")] // método que retorna produto por id, o id vem por parâmetro /produtos/id
    //[HttpGet("{id:int}/{param2}", Name="ObterProduto")] definir parâmetro, e com valor padrão nome=padrão
    public async Task<ActionResult<Produto>> Get(int id, [BindRequired] string nome)//aí passa o parâmetro aqui e o tipo no caso(int id, string param2)
    {
        // se colocar [FromQuery] o id tem que passar na query
        //o Bindrequired obriga a passar o nome na query
        var nomeProduto = nome;
        var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.ProdutoId == id); //se não achar retorna null

        if (produto is null)
        {
            return NotFound("Produto não encontrado.");
        }

        return produto;
    }

    [HttpPost] //criar um produto /produtos
    public ActionResult Post(Produto produto) //vem do body o produto do tipo produto
    {
        if (produto is null)
        {
            return BadRequest("Dados inválido.");
        }

        _context.Produtos.Add(produto); //recebe o produto na memoria
        _context.SaveChanges(); //persiste os dados n tabela

        //depois de criar aciona a rota obterProduto com o id do produto e retorna ele
        return new CreatedAtRouteResult("ObterProduto",
            new { id = produto.ProdutoId }, produto);
    }

    [HttpPut("{id:int}")] //atualização completa
    public ActionResult Put(int id, Produto produto) //pegar o id do produto e recebe pelo body
    {
        if (id != produto.ProdutoId)
        {
            return BadRequest("Dados inválido.");
        }

        _context.Entry(produto).State = EntityState.Modified; //pega o contexto usa o entry e pega o estado modificado
        _context.SaveChanges();

        return Ok(produto);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

        if (produto is null)
        {
            return NotFound("Produto não encontrado.");
        }

        _context.Produtos.Remove(produto);
        _context.SaveChanges();

        return Ok(produto);
    }
}
