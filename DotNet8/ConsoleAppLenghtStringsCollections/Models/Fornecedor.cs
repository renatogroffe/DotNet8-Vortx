using System.ComponentModel.DataAnnotations;

namespace ConsoleAppLenghtStringsCollections.Models;

public class Fornecedor
{
    [Required]
    public string? RazaoSocial { get; set; }
    
    [Length(10, 11, ErrorMessage = "Numero do Telefone deve possuir 10 ou 11 caracteres")]
    public string? Telefone { get; set; }

    [Length(2, 4, ErrorMessage = "Devem ser definidos de 2 a 4 contatos")]
    public string[]? Contatos { get; set; }

    [Length(1, 3, ErrorMessage = "Devem ser definidos de 1 a 3 produtos")]
    public List<string>? Produtos { get; set; }
}