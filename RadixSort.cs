using System;
using System.Diagnostics;

class RadixSortTest
{
    static void RadixSort(int[] arr)
    {
        int max = GetMax(arr);

        for (int exp = 1; max / exp > 0; exp *= 10)
            CountingSort(arr, exp);
    }

    static int GetMax(int[] arr)
    {
        int max = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
                max = arr[i];
        }

        return max;
    }

    static void CountingSort(int[] arr, int exp)
    {
        int n = arr.Length;
        int[] output = new int[n];
        int[] count = new int[10];

        for (int i = 0; i < n; i++)
            count[(arr[i] / exp) % 10]++;

        for (int i = 1; i < 10; i++)
            count[i] += count[i - 1];

        for (int i = n - 1; i >= 0; i--)
        {
            int digit = (arr[i] / exp) % 10;
            output[count[digit] - 1] = arr[i];
            count[digit]--;
        }

        for (int i = 0; i < n; i++)
            arr[i] = output[i];
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

    static void Testar(string nome, int[] vetor)
    {
        Stopwatch sw = new Stopwatch();

        sw.Start();
        RadixSort(vetor);
        sw.Stop();

        Console.WriteLine($"{nome,-25}: {sw.ElapsedMilliseconds} ms");
    }

    static void Main()
    {
        int[] tamanhos = { 1000, 10000, 100000, 1000000 };

        foreach (int tamanho in tamanhos)
        {
            Console.WriteLine($"\nTESTE COM {tamanho:N0} ELEMENTOS \n");

            Testar("Aleatório", GerarAleatorio(tamanho));
            Testar("Ordenado", GerarOrdenado(tamanho));
            Testar("Invertido", GerarInvertido(tamanho));
            Testar("Muitos Repetidos", GerarRepetidos(tamanho));
        }

        Console.ReadKey();
    }
}

