using System.Runtime.CompilerServices;
using System.Text;

var precoPromo = 10.2;
var precoReal = 25.99;
var textoUm = "O preço do produto na promoção é " + precoPromo + " \n caso contrario o preço é " + precoReal;

UsandoGuid();
Console.WriteLine("\nConcatenacaoStrings\n");
ConcatenacaoStrings();
Console.WriteLine("\nComparandoStringUsandoContains\n");
ComparandoStringUsandoContains(textoUm);
Console.WriteLine("\nComparandoStringUsandoCompareTo\n");
ComparandoStringUsandoCompareTo(textoUm);
Console.WriteLine("\nUsandoStartsWithAndEndsWith\n");
UsandoStartsWithAndEndsWith(textoUm);
Console.WriteLine("\nComparacaoUsandoEquals\n");
ComparacaoUsandoEquals(textoUm);
Console.WriteLine("\nComparacaoUsadoIndex\n");
ComparacaoUsadoIndex(textoUm);
Console.WriteLine("\nUsandoLowerUpperInsertRemoveLength\n");
UsandoLowerUpperInsertRemoveLength(textoUm);
Console.WriteLine("\nUsandoReplace\n");
UsandoReplace(textoUm);
Console.WriteLine("\nUsandoSplit\n");
UsandoSplit(textoUm);
Console.WriteLine("\nUsandoSubString\n");
UsandoSubString(textoUm);
Console.WriteLine("\nUsandoTrim\n");
UsandoTrim(textoUm);
Console.WriteLine("\nUsandoStringBuilder\n");
UsandoStringBuilder();

static void UsandoGuid()
{
    var id = Guid.NewGuid();
    Console.WriteLine(id);
    id.ToString();

    if (id != new Guid())
    {
        id = new Guid();
    }

    Console.WriteLine(id);
}
static void ConcatenacaoStrings()
{
    var precoPromo = 10.2;
    var precoReal = 25.99;

    var textoUm = "O preço do produto na promoção é " + precoPromo + " \n caso contrario o preço é " + precoReal;
    var textoDois = string.Format("O preço do produto na promoção é {0} \n caso contrario o preço é {1}", precoPromo, precoReal);
    var textoTres = $"O preço do produto na promoção é {precoPromo} \n caso contrario o preço é {precoReal}";

    Console.WriteLine(textoUm);
    Console.WriteLine(textoDois);
    Console.WriteLine(textoTres);
}
static void ComparandoStringUsandoContains(string texto)
{
    if (texto.Contains("preço", StringComparison.OrdinalIgnoreCase))
        Console.WriteLine("Deu certo");
}

static void ComparandoStringUsandoCompareTo(string texto)
{
    var text = texto.CompareTo("Preço");
    if (text == -1)
        Console.WriteLine("falhou");

}

static void UsandoStartsWithAndEndsWith(string texto)
{
    Console.WriteLine(texto.StartsWith("O preço do produto"));
    Console.WriteLine(texto.StartsWith("o Preço do  "));
    Console.WriteLine(texto.StartsWith("15,99"));

    Console.WriteLine(texto.EndsWith("14"));
    Console.WriteLine(texto.EndsWith("20"));
    Console.WriteLine(texto.EndsWith("25,99"));
}

static void ComparacaoUsandoEquals(string texto)
{
    Console.WriteLine(texto.Equals("O preço do produto na promoção é 10,2 \n caso contrario o preço é 25,99"));
    Console.WriteLine(texto.Equals("O PREÇO DO PRODUTO"));
    Console.WriteLine(texto.Equals("o preço do produto na promoção é 10,2\r\n caso contrario o preço é 25,99", StringComparison.OrdinalIgnoreCase));
}

static void ComparacaoUsadoIndex(string texto)
{
    Console.WriteLine(texto.IndexOf("preço"));
    Console.WriteLine(texto.LastIndexOf("preço"));

}

static void UsandoLowerUpperInsertRemoveLength(string texto)
{
    Console.WriteLine(texto.ToLower());
    Console.WriteLine(texto.ToUpper());
    Console.WriteLine(texto.Length);
    Console.WriteLine(texto.Insert(2, "real "));
    Console.WriteLine(texto.Remove(2, 5));
}

static void UsandoReplace(string texto)
{
    Console.WriteLine(texto.Replace("preço", "Preço"));
}

static void UsandoSplit(string texto)
{
    var resultado = texto.Split(" ");
    Console.WriteLine(resultado[0]);
    Console.WriteLine(resultado[1]);
    Console.WriteLine(resultado[2]);
    Console.WriteLine(resultado[3]);
    Console.WriteLine(resultado[4]);
    Console.WriteLine(resultado[5]);
    Console.WriteLine(resultado[6]);
}

static void UsandoSubString(string texto)
{
    var resultado = texto.Substring(2, 5);
    var resultadoUm = texto.Substring(5, texto.LastIndexOf("p"));

    Console.WriteLine(resultado);
    Console.WriteLine(resultadoUm);
}

static void UsandoTrim(string texto)
{
    Console.WriteLine(texto.Trim());
}
static void UsandoStringBuilder()
{
    var texto = new StringBuilder();
    texto.Append("Este é ");
    texto.Append("um teste ");
    texto.Append("para eu ");
    texto.Append("testar");

    Console.WriteLine(texto);
}