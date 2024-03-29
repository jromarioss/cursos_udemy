﻿using ApiCatalago.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalago.Context;

public class AppDbContext : IdentityDbContext //herda da classe dbContext
{
    //configura o contexto no construtor
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}

    //define o mapeamento da entidade
    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Produto>? Produtos { get; set; }
}
