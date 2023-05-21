using System.Data;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Runtime.ExceptionServices;

int[] array = new int[50000];

Random randGenerator = new();
Stopwatch stopwatch = new();

Console.WriteLine("Wybierz opcje:");
Console.WriteLine("1. Optymalny zestaw danych");
Console.WriteLine("2. Losowy zestaw danych");
Console.WriteLine("3. Nieoptymalny zestaw danych");

int number = int.Parse(Console.ReadLine());

switch (number)
{
    case 1:
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i;
        }
        break;

    case 2:
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = randGenerator.Next(1, 50001);
        }
        break;
    
    case 3:
        int j = 0;
        for (int i = array.Length-1; i >= 0; i--)
        {
            array[j] = i;
            j++;
        }
        break;
}; //Wybranie zestawu danych

Console.WriteLine("SORTOWANIE BĄBELKOWE");
Console.WriteLine("--------------------");
int[] bubbleSortArray = new int[array.Length];
for (int i = 0; i < bubbleSortArray.Length; i++)
{
    bubbleSortArray[i] = array[i];
} //kopiowanie tablicy

BubbleSort(bubbleSortArray);

Console.WriteLine("\nSORTOWANIE PRZEZ WSTAWIANIE");
Console.WriteLine("---------------------------");

int[] insertionSortArray = new int[array.Length];
for (int i = 0; i < insertionSortArray.Length; i++)
{
    insertionSortArray[i] = array[i];
} //kopiowanie tablicy

InsertionSort(array);

#region metody
void BubbleSort(int[] array)
{
    int zamiana = 0;
    int porownania = 0;

    stopwatch.Reset();
    stopwatch.Start();
    for (int i = 0; i < array.Length; i++)
    {
        for (int j = 0; j < array.Length; j++)
        {
            if (i == j)
                break;

            porownania++;
            if (array[j] > array[i])
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                zamiana++;
            }
        }
    }
    stopwatch.Stop();

    Console.WriteLine($"Ilość porównań: {porownania}");
    Console.WriteLine($"Ilość zamian: {zamiana}");

    TimeSpan ts = stopwatch.Elapsed;
    Console.WriteLine("Elapsed Time is {0:00}:{1:00}:{2:00}.{3}",
                    ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
} //metoda sortowanie bąbelkowego
void InsertionSort(int[] array)
{
    double zamiana = 0;
    double porownania = 0;

    stopwatch.Reset();
    stopwatch.Start();
    for (int i = 1; i < array.Length; i++)
    {
        int j = i;
        int temp = array[j];
        while (j > 0 && array[j-1] > temp)
        {
            array[j] = array[j-1];
            j--;
            zamiana++;
            porownania++;
        }
        array[j] = temp;

        if (j > 0 && array[j-1] < temp)
        porownania++;
    }
    stopwatch.Stop();

    Console.WriteLine($"Ilość porównań: {porownania}");
    Console.WriteLine($"Ilość zamian: {zamiana}");

    TimeSpan ts = stopwatch.Elapsed;
    Console.WriteLine("Elapsed Time is {0:00}:{1:00}:{2:00}.{3}",
                    ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
} //metoda sortowania przez wstawianie

#endregion