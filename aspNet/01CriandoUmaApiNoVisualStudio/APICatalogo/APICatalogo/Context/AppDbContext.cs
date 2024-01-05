﻿using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) //construtor
    {}

    //mapeando as entidades
    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Produto>? Produtos { get; set; }
}
