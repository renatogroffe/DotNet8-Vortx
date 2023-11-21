using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using ConsoleAppCompositeFormat.Models;

Console.WriteLine("***** Testes com .NET 8 | Utilizando CompositeFormat *****");
Console.WriteLine($"Versao do .NET em uso: {RuntimeInformation
    .FrameworkDescription} - Ambiente: {Environment.MachineName} - Kernel: {Environment
    .OSVersion.VersionString}");

Console.WriteLine();
Console.WriteLine("Configure um formato com os seguintes placeholders:");
Console.WriteLine("  {0} = Nome do Estado (Brasil)");
Console.WriteLine("  {1} = Sigla do Estado");

string format;
bool invalidFormat;
do
{
    Console.WriteLine();
    Console.Write("Formato: ");
    format = Console.ReadLine()!;
    invalidFormat = !(format.Contains("{0}") && format.Contains("{1}"));
    if (invalidFormat)
    {
        var previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Formato invalido! Informe uma string com os placeholders {0} e {1}.");
        Console.ForegroundColor = previousColor;
    }
} while (invalidFormat);

var compositeFormat = CompositeFormat.Parse(format);
Console.WriteLine();
Console.WriteLine($"CompositeFormat: {JsonSerializer.Serialize(compositeFormat)}");

var algunsEstados = new Estado[]
{
    new() { Sigla = "BA", Nome = "Bahia" },
    new() { Sigla = "CE", Nome = "Ceara" },
    new() { Sigla = "ES", Nome = "Espirito Santo" },
    new() { Sigla = "MS", Nome = "Mato Grosso do Sul" },
    new() { Sigla = "MG", Nome = "Minas Gerais" },
    new() { Sigla = "PA", Nome = "Para" },
    new() { Sigla = "PR", Nome = "Parana" },
    new() { Sigla = "PE", Nome = "Pernambuco" },
    new() { Sigla = "RJ", Nome = "Rio de Janeiro" },
    new() { Sigla = "RS", Nome = "Rio Grande do Sul" },
    new() { Sigla = "SC", Nome = "Santa Catarina" },
    new() { Sigla = "SP", Nome = "Sao Paulo" },
};
Console.WriteLine();
Console.WriteLine("*** Valores gerados com CompositeFormat ***");
foreach (var estado in algunsEstados)
    Console.WriteLine(string.Format(provider: CultureInfo.InvariantCulture,
        format: compositeFormat, estado.Nome, estado.Sigla));