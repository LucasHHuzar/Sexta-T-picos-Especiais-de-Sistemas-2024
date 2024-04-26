using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//Registrar o serviço de banco de dados da aplicação
builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();

Produto produto = new Produto();
// produto.setNome("Bolacha");
produto.Nome = "Bolacha";
// Console.WriteLine(produto.getNome());
Console.WriteLine(produto.Nome);

List<Produto> produtos = new List<Produto>();
produtos.Add(new Produto("Celular", "IOS", 4000));
produtos.Add(new Produto("Celular", "Android", 2500));
produtos.Add(new Produto("Televisão", "LG", 2000));
produtos.Add(new Produto("Notebook", "Avell", 5000));

//EndPoint - Funcionalidades
//GET: http://localhost:5134/
app.MapGet("/", () => "Minha primeira API com C# com Watch!");

//GET: http://localhost:5134/api/produto/listar
app.MapGet("/api/produto/listar", ([FromServices] AppDataContext ctx) =>
{

    if (ctx.Produtos.Any())
    {
        return Results.Ok(ctx.Produtos.ToList());
    }

    return Results.NotFound("Tabela vazia!");

});

//GET: http://localhost:5134/api/produto/buscar/id_do_produto
app.MapGet("/api/produto/buscar/{id}", (string id, [FromServices] AppDataContext ctx) =>
{
    //Expressão lambda em C#
    Produto? produto = ctx.Produtos.FirstOrDefault(x => x.Id == id);
    
    if(produto is null)
    {
        return Results.NotFound("Produto não encontrado!");
    }

    //Produto não encontrado é após o laço de repetição
    return Results.Ok(produto);
});

//POST: http://localhost:5134/api/produto/cadastrar
app.MapPost("/api/produto/cadastrar", ([FromBody] Produto produto, [FromServices] AppDataContext ctx) =>
{

    //Adicionar o produto dentro do banco de dados
    ctx.Produtos.Add(produto);
    ctx.SaveChanges();

    return Results.Created("", produto);
});

//EXERCÍCIOS:
//Receber os dados do produto pela URL da req
//Receber os dados do produto pelo corpo da req
//Criar um produto com os dados 
//Adicionar o prouto na lista

app.Run();

//1) Cadastrar um produto
//a) Pela URL
//b) Pelo corpo da requisição

//2) Remover um produto 

//3) Alterar produto