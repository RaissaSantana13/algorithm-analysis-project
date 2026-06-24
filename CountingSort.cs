using System;
using System.Diagnostics;

class CountingSortTest
{
    static void CountingSort(int[] arr)
    {
        int n = arr.Length;
        
        if (n <= 1) 
            return;

        int max = arr[0];
        
        for (int i = 1; i < n; i++)
        {
            if (arr[i] > max)
                max = arr[i];
        }

        int[] count = new int[max + 1];
        int[] output = new int[n];

        for (int i = 0; i < n; i++)
        {
            count[arr[i]]++;
        }

        for (int i = 1; i <= max; i++)
        {
            count[i] += count[i - 1];
        }

        for (int i = n - 1; i >= 0; i--)
        {
            output[count[arr[i]] - 1] = arr[i];
            count[arr[i]]--;
        }

        for (int i = 0; i < n; i++)
        {
            arr[i] = output[i];
        }
    }

    static int[] GerarAleatorio(int tamanho)
    {
        Random rnd = new Random();
        int[] arr = new int[tamanho];

        for (int i = 0; i < tamanho; i++)
            arr[i] = rnd.Next(0, 1000000);

        return arr;
    }

    static int[] GerarOrdenado(int tamanho)
    {
        int[] arr = new int[tamanho];

        for (int i = 0; i < tamanho; i++)
            arr[i] = i;

        return arr;
    }

    static int[] GerarInvertido(int tamanho)
    {
        int[] arr = new int[tamanho];

        for (int i = 0; i < tamanho; i++)
            arr[i] = tamanho - i;

        return arr;
    }

    static int[] GerarRepetidos(int tamanho)
    {
        Random rnd = new Random();
        int[] arr = new int[tamanho];

        for (int i = 0; i < tamanho; i++)
            arr[i] = rnd.Next(0, 100);

        return arr;
    }

    static void Testar(string nome, Func<int[]> gerador)
    {
        double soma = 0;

        for (int i = 0; i < 10; i++)
        {
            int[] vetor = gerador();

            Stopwatch sw = Stopwatch.StartNew();

            CountingSort(vetor);

            sw.Stop();

            soma += sw.Elapsed.TotalMilliseconds;
        }

        Console.WriteLine($"{nome,-25}: {soma / 10:F2} ms");
    }

    static void Main()
    {
        int[] tamanhos = { 1000, 10000, 100000, 1000000 };

        Console.WriteLine("TESTES DO COUNTING SORT");

        foreach (int tamanho in tamanhos)
        {
            Console.WriteLine($"\nTESTE COM {tamanho:N0} ELEMENTOS\n");

            Testar("Aleatório", () => GerarAleatorio(tamanho));
            Testar("Ordenado", () => GerarOrdenado(tamanho));
            Testar("Invertido", () => GerarInvertido(tamanho));
            Testar("Muitos Repetidos", () => GerarRepetidos(tamanho));
        }

        Console.ReadKey();
    }
}
