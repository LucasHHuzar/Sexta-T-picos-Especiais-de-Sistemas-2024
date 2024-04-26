//Entar no NuGet no navegador, e procurar por "EntityFrameworkCore", baixar o "dotnet add package Microsoft.
//EntityFrameworkCore.Sqlite --version 8.0.4" para o banco de dados SQLite e "dotnet add package Microsoft.
//EntityFrameworkCore.Design --version 8.0.4"

using Microsoft.EntityFrameworkCore;

namespace API.Models;

public class AppDataContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
    }

}