/* Задача 73: Есть число N. Сколько групп M, можно получить при разбиении всех
чисел на группы, так чтобы в одной группе все числа были взаимно просты (все
числа в группе друг на друга не делятся)? Найдите M при заданном N и получите
одно из разбиений на группы N ≤ 10²⁰.*/

int numberNatRequery()
{
    int number = 0;
    while (number < 1)
    {
        Console.WriteLine("Please, enter a natural number:");
        number = int.Parse(Console.ReadLine());
    }
    return number;
}

int[] FillArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = i + 1;
    }
    return array;
}

void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        if(array[i] != 0) Console.Write(array[i] + " ");
    }
    Console.WriteLine();
}

void PrintGroups(int[] array)
{
    int[] dictionary = new int[array.Length];
    int count;
    bool primeNumb;
    int group = 1;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] != 0)
        {
            Array.Clear(dictionary);
            dictionary[0] = array[i];
            array[i] = 0;
            count = 1;
            Console.Write($"Group {group++}: ");
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] != 0)
                {
                    primeNumb = true;
                    for (int k = 0; k < count; k++)
                    {
                        if (array[j] % dictionary[k] == 0) primeNumb = false;
                    }
                    if (primeNumb)
                    {
                        dictionary[count] = array[j];
                        count++;
                        array[j] = 0;
                    }
                }
            }
            PrintArray(dictionary);
        }
    }
}

int N = numberNatRequery();
int[] array = FillArray(new int[N]);
Console.WriteLine($"The numbers from 1 to {N} are subdivided into the following groups of relative primes: ");
PrintGroups(array);

