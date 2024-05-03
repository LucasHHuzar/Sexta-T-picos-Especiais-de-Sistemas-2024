using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

//Registrar o serviço de banco de dados da aplicação
builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();

Produto produto = new Produto();
// produto.setNome("Bolacha");
produto.Nome = "Bolacha";
// Console.WriteLine(produto.getNome());
Console.WriteLine(produto.Nome);

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

//GET: http://localhost:5134/api/produto/buscar/
app.MapGet("/api/produto/buscar/{id}", ([FromRoute] string id, [FromServices] AppDataContext ctx) =>
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

//POST: http://localhost:5134/api/produto/cadastrar/
app.MapPost("/api/produto/cadastrar", ([FromBody] Produto produto, [FromServices] AppDataContext ctx) =>
{
    //Valdação dos atributos do produto
    List<ValidationResult> erros = new List<ValidationResult>();

    if(!Validator.TryValidateObject(produto, new ValidationContext(produto), erros, true))
    {
        return Results.BadRequest(erros);
    }

    //Regra de Negócio - Não permitir produtos com o mesmo nome
    Produto? produtoBuscado = ctx.Produtos.FirstOrDefault(x => x.Nome == produto.Nome);

    if(produtoBuscado is not null)
    {
        return Results.BadRequest("Já existe um produto com o mesmo nome");
    }

    //Adicionar o produto dentro do banco de dados
    ctx.Produtos.Add(produto);
    ctx.SaveChanges();

    return Results.Created("", produto);

});

//DELETE: http://localhost:5134/api/produto/deletar/
app.MapDelete("/api/produto/deletar/{id}", ([FromRoute] string id, [FromServices] AppDataContext ctx) => 
{
    Produto? produto = ctx.Produtos.Find(id);

    if(produto is null)
    {
        return Results.NotFound("Produto não encontrado!"); 
    }
    
    ctx.Produtos.Remove(produto);
    ctx.SaveChanges();

    return Results.Ok("Produto removido com sucesso!");

});

//PUT: http://localhost:5134/api/produto/alterar/
app.MapPut("/api/produto/alterar/{id}", ([FromRoute] string id,[FromBody] Produto produtoAlterado, 
[FromServices] AppDataContext ctx) => 
{
    Produto? produto = ctx.Produtos.Find(id);

    if(produto is null)
    {
        return Results.NotFound("Produto não encontrado!"); 
    }
    
    produto.Nome = produtoAlterado.Nome;
    produto.Descricao = produtoAlterado.Descricao;
    produto.Quantidade = produtoAlterado.Quantidade;
    produto.Valor = produtoAlterado.Valor;
    
    ctx.Produtos.Update(produto);
    ctx.SaveChanges();

    return Results.Ok("Produto alterado com sucesso!");

});

app.Run();

//EXERCÍCIOS:
//Receber os dados do produto pela URL da req
//Receber os dados do produto pelo corpo da req
//Criar um produto com os dados 
//Adicionar o prouto na lista

//1) Cadastrar um produto
//a) Pela URL
//b) Pelo corpo da requisição

//2) Remover um produto 

//3) Alterar produto