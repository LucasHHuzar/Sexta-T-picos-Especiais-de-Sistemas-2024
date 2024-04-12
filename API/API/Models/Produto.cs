namespace API.Models;

public class Produto
{
    //Construtores 
    public Produto()
    {
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
    }

    public Produto(string nome, string descricao, double valor)
    {
        Nome = nome;
        Descricao = descricao;
        Valor = valor;
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
    }

    //Características - Atributos e propriedades
    public string? Id { get; set; }
    public string? Nome { get; set; } //--> Comando de get e set em C#
    public string? Descricao { get; set; }
    public double Valor { get; set; }
    public DateTime CriadoEm { get; set; }

    // private string nome;

    // public void setNome(string nome)
    // {
    //     this.nome = nome;
    // }

    // public string getNome()
    // {
    //     return this.nome;
    // }

}

//record Produto(string Nome, string Descricao);