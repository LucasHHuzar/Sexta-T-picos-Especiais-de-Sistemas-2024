using System.ComponentModel.DataAnnotations;

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
    //Validação - Data Annotations em C#
    public string? Id { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório!")]
    public string? Nome { get; set; } //--> Comando de get e set em C#

    [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres!")]
    [MaxLength(10, ErrorMessage = "Máximo de 10 caracteres!")]
    public string? Descricao { get; set; }

    [Range(1, 1000, ErrorMessage = "Valor entre 1 e 1000!")]
    public double Valor { get; set; }
    public DateTime CriadoEm { get; set; }
    public int Quantidade { get; set; }

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