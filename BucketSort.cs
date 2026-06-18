using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void BucketSort(int[] arr)
    {
        int n = arr.Length;

        if (n <= 1)
            return;

        int min = arr[0];
        int max = arr[0];

        foreach (int value in arr)
        {
            if (value < min) min = value;
            if (value > max) max = value;
        }

        int bucketCount = (int)Math.Sqrt(n);

        List<int>[] buckets = new List<int>[bucketCount];

        for (int i = 0; i < bucketCount; i++)
            buckets[i] = new List<int>();

        foreach (int value in arr)
        {
            int bucketIndex =
                (int)((long)(value - min) * bucketCount / (max - min + 1));

            buckets[bucketIndex].Add(value);
        }

        foreach (List<int> bucket in buckets)
            bucket.Sort();

        int index = 0;

        foreach (List<int> bucket in buckets)
        {
            foreach (int value in bucket)
            {
                arr[index++] = value;
            }
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

            BucketSort(vetor);

            sw.Stop();

            soma += sw.Elapsed.TotalMilliseconds;
        }

        Console.WriteLine($"{nome,-25}: {soma / 10:F2} ms");
    }

    static void Main()
    {
        int[] tamanhos = { 1000, 10000, 100000, 1000000 };

        Console.WriteLine("TESTES DO BUCKET SORT");

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
