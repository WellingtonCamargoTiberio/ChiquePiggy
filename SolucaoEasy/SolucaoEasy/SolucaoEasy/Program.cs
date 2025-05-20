
int[] numsExemploUm = { 23, 2, 4, 6, 7 };
int kExemploUm = 6;
int[] numsExemploDois = [23, 2, 6, 4, 7];
int kExemploDois = 6;
int[] numsExepmloTres = [23, 2, 6, 4, 7];
int kExemploTres = 13;

bool resultadoUm = ExemploUmSubArray(numsExemploUm, kExemploUm);
bool resultdoDois = ExemploDoisSubArray(numsExemploDois, kExemploDois);
bool resultadoTres = ExemploTresSubArray(numsExepmloTres, kExemploTres);

Console.WriteLine("Exemplo Um = " +  resultadoUm);
Console.WriteLine("Exemplo Dois = " + resultdoDois);
Console.WriteLine("Exemplo Tres = " + resultadoTres + "\n");

Console.WriteLine("Agora um Exemplo com valores Dinamicos");
Console.WriteLine("Digite os números separados por vírgula:");
int[] nums = Console.ReadLine()
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();

Console.WriteLine("Digite o valor de k:");
int k = int.Parse(Console.ReadLine());
bool resultoDinamico = ExemploSubArrayDinamico(nums, k);

Console.WriteLine("Exemplo Dinamico = " + resultoDinamico);

static bool ExemploUmSubArray(int[] nums, int k)
{
    for (int inicio = 0; inicio < nums.Length; inicio++)
    {
        int soma = 0;
        for (int fim = inicio; fim < nums.Length; fim++)
        {
            soma += nums[fim];

            if (fim - inicio + 1 >= 2 && soma % k == 0)
            {
                return true;
            }
        }
    }

    return false;
}

static bool ExemploDoisSubArray(int[] nums, int k)
{
    for (int inicio = 0; inicio < nums.Length; inicio++)
    {
        int soma = 0;
        for (int fim = inicio; fim < nums.Length; fim++)
        {
            soma += nums[fim];

            if (fim - inicio + 1 >= 2 && soma % k == 0)
            {
                return true;
            }
        }
    }

    return false;
}

static bool ExemploTresSubArray(int[] nums, int k)
{
    for (int inicio = 0; inicio < nums.Length; inicio++)
    {
        int soma = 0;
        for (int fim = inicio; fim < nums.Length; fim++)
        {
            soma += nums[fim];

            if (fim - inicio + 1 >= 2 && soma % k == 0)
            {
                return true;
            }
        }
    }

    return false;
}

static bool ExemploSubArrayDinamico(int[] nums, int k)
{
    for (int inicio = 0; inicio < nums.Length; inicio++)
    {
        int soma = 0;
        for (int fim = inicio; fim < nums.Length; fim++)
        {
            soma += nums[fim];

            if (fim - inicio + 1 >= 2 && soma % k == 0)
            {
                return true;
            }
        }
    }

    return false;
}