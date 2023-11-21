using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text.Json;
using ConsoleAppLenghtStringsCollections.Models;

Console.WriteLine("***** Testes com .NET 8 | LengthAttribute *****");
Console.WriteLine($"Versao do .NET em uso: {RuntimeInformation
    .FrameworkDescription} - Ambiente: {Environment.MachineName} - Kernel: {Environment
    .OSVersion.VersionString}");

var fornecedores = new List<Fornecedor>();

fornecedores.Add(new Fornecedor
{
    RazaoSocial = "Acme Produtos de Limpeza Ltda",
    Telefone = "1134567890",
    Contatos = new [] {"Joao Silva", "Maria Oliveira", "Joaquim Martins", "Pedro Silva" },
    Produtos = new() { "Vassoura", "Desinfetante", "Detergente" }
});

fornecedores.Add(new Fornecedor
{
    RazaoSocial = "XYZ Limpeza Ltda",
    Telefone = "11",
    Contatos = new[] { "Joao Oliveira", "Maria Silva" },
    Produtos = new() { }
});

fornecedores.Add(new Fornecedor
{
    RazaoSocial = "ABC Produtos de Limpeza Ltda",
    Telefone = "11987654321",
    Contatos = new[] { "Joao Almeida" },
    Produtos = new() { "Sabao em Po", "Alcool 70", "Detergente" }
});

fornecedores.Add(new Fornecedor
{
    RazaoSocial = "FGH Limpeza Ltda",
    Telefone = "119123456789",
    Contatos = new[] { "Adao Silva", "Fabiio Oliveira", "Joao Martins", "Maria Freitas", "Pedro Martins" },
    Produtos = new() { "Sabao em Po", "Vassoura", "Desinfetante", "Detergente" }
});

foreach (var item in fornecedores)
{
    Console.WriteLine();
    Console.WriteLine(JsonSerializer.Serialize(item));
    var validationResults = new List<ValidationResult>();
    if (!Validator.TryValidateObject(item, new ValidationContext(item),
        validationResults, validateAllProperties: true))
    {
        Console.WriteLine("Dados invalidos para essa instancia...");
        foreach (var validationResult in validationResults)
            Console.WriteLine($"ErrorMessage = {validationResult.ErrorMessage}");
    }
}