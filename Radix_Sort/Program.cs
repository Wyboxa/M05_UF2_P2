using System;

class MyProgram
{
    //Función para ordenar radix
    static void radixsort(int[] Array)
    {
        int n = Array.Length;
        int max = Array[0];

        //Encontrar el elemento más grande en la array
        for (int i = 1; i < n; i++)
        {
            if (max < Array[i])
                max = Array[i];
        }
        //La clasificación de conteo se realiza en función del lugar.        
        for (int place = 1; max / place > 0; place *= 10)
            countingsort(Array, place);
    }

    static void countingsort(int[] Array, int place)
    {
        int n = Array.Length;
        int[] output = new int[n];
        //El rango del número es 0-9 para cada lugar considerado.
        int[] freq = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        //contar el número de ocurrencias en la array
        for (int i = 0; i < n; i++)
            freq[(Array[i] / place) % 10]++;

        //Cambie count[i] para que count[i] ahora contenga 
        //posición de este dígito en el output[] 
        for (int i = 1; i < 10; i++)
            freq[i] += freq[i - 1];

        //Construya la matriz de salida 
        for (int i = n - 1; i >= 0; i--)
        {
            output[freq[(Array[i] / place) % 10] - 1] = Array[i];
            freq[(Array[i] / place) % 10]--;
        }

        //Copie la matriz de salida en la matriz de entrada, ahora la array
        //contiene una array ordenada basada en el dígito en el lugar especificado
        for (int i = 0; i < n; i++)
            Array[i] = output[i];
    }

    // Función para imprimir array
    static void PrintArray(int[] Array)
    {
        int n = Array.Length;
        for (int i = 0; i < n; i++)
            Console.Write(Array[i] + " ");
        Console.Write("\n");
    }

    // Testeo del codgio
    static void Main(string[] args)
    {
        int[] MyArray = { 101, 1, 20, 50, 9, 98, 27, 153, 35, 899 };
        Console.Write("Original Array\n");
        PrintArray(MyArray);

        radixsort(MyArray);
        Console.Write("\nSorted Array\n");
        PrintArray(MyArray);
    }
}