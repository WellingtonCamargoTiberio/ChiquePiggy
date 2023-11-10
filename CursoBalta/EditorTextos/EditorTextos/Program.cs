Menu();


static void Menu()
{
    Console.Clear();
    Console.WriteLine("O que voce deseja fazer?");
    Console.WriteLine("Digite 1 para Abrir Arquivo");
    Console.WriteLine("Digite 2 para Editar Arquivo");
    Console.WriteLine("Digite 0 para Sair");

    short opcao = short.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 0: Environment.Exit(0); break;
        case 1: Abrir(); break;
        case 2: Editar(); break;
        default: Menu(); break;
    }
}

static void Abrir()
{
    Console.Clear();
    Console.WriteLine("Qual o arquivo que deseja abrir?");
    var caminhoPasta = Console.ReadLine();

    using(var arquivo = new StreamReader(caminhoPasta))
    {
        string texto = arquivo.ReadToEnd();
        Console.WriteLine(texto);
    }

    Console.WriteLine("");
    Console.ReadLine();
    Menu();
}

static void Editar()
{
    Console.Clear();
    Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
    Console.WriteLine("---------------------------------------");
    string texto = "";

    do
    {
        texto += Console.ReadLine();
        texto += Environment.NewLine;
    }
    while (Console.ReadKey().Key != ConsoleKey.Escape);

    Salvar(texto);
}
static void Salvar(string texto)
{
    Console.Clear();
    Console.WriteLine("Onde deseja salvar o arquivo?");
    var caminhoPasta = Console.ReadLine();

    using(var arquivo = new StreamWriter(caminhoPasta))
    {
        arquivo.Write(texto);
    }

    Console.WriteLine($"Arquivo {caminhoPasta} foi salvo com sucesso");
    Console.ReadLine();
    Menu();
}