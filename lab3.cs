//----------------------#1---------------------------
using System;

class Program
{
    static void Main()
    {
        // Запрашиваем количество элементов массива
        Console.Write("Введите количество элементов массива: ");
        if (!int.TryParse(Console.ReadLine(), out int size) || size <= 0)
        {
            Console.WriteLine("Введите корректное положительное число.");
            return;
        }

        // Создаем массив
        int[] array = new int[size];
        Random random = new Random();

        // Заполняем массив случайными числами в диапазоне от -30 до 45
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(-30, 46); // 46 не включается
        }

        // Выводим массив строками по 10 элементов
        Console.WriteLine("Элементы массива:");
        for (int i = 0; i < size; i++)
        {
            Console.Write(array[i] + "\t");
            if ((i + 1) % 10 == 0) // Печатаем новую строку каждые 10 элементов
            {
                Console.WriteLine();
            }
        }

        // Выводим элементы массива в обратном порядке, игнорируя отрицательные элементы
        Console.WriteLine("\nЭлементы массива в обратном порядке (игнорируя отрицательные):");
        for (int i = size - 1; i >= 0; i--)
        {
            if (array[i] >= 0) // Игнорируем отрицательные элементы
            {
                Console.Write(array[i] + "\t");
            }
        }
    }
}

//----------------------#2---------------------------------

using System;

class Program
{
    static void Main()
    {
        // Создаем и заполняем двумерный массив 7x7
        int[,] matrix = new int[7, 7];
        Random random = new Random();

        // Заполнение массива случайными числами
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                matrix[i, j] = random.Next(1, 100); // Случайные числа от 1 до 99
            }
        }

        // Вывод исходного массива
        Console.WriteLine("Исходный массив:");
        PrintMatrix(matrix);

        // Поворот массива на 90 градусов вправо
        RotateMatrix(matrix);

        // Вывод повернутого массива
        Console.WriteLine("\nПовернутый массив на 90 градусов вправо:");
        PrintMatrix(matrix);
    }

    static void RotateMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0); // Размерность массива (7)

        // Поворот на 90 градусов вправо
        for (int layer = 0; layer < n / 2; layer++)
        {
            int first = layer;
            int last = n - 1 - layer;

            for (int i = first; i < last; i++)
            {
                int offset = i - first;

                // Сохраняем верхний элемент
                int top = matrix[first, i];

                // Левый элемент становится верхним
                matrix[first, i] = matrix[last - offset, first];

                // Нижний элемент становится левым
                matrix[last - offset, first] = matrix[last, last - offset];

                // Правый элемент становится нижним
                matrix[last, last - offset] = matrix[i, last];

                // Сохраняем верхний элемент в правый
                matrix[i, last] = top;
            }
        }
    }

    static void PrintMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}

//----------------------#3------------------------

using System;

class Program
{
    static void Main()
    {
        // Пример массива
        int[] array = { 1, 2, 3, 4, 5, 6, 7 };
        int k = 3; // Количество позиций для сдвига

        Console.WriteLine("Исходный массив:");
        PrintArray(array);

        // Выполняем циклический сдвиг
        ShiftLeft(array, k);

        Console.WriteLine($"Массив после сдвига на {k} позиций влево:");
        PrintArray(array);
    }

    static void ShiftLeft(int[] array, int k)
    {
        int n = array.Length;
        // Уменьшаем k, если оно больше длины массива
        k = k % n;

        // Создаем временный массив для хранения сдвинутых значений
        int[] temp = new int[n];

        // Копируем элементы с учетом сдвига
        for (int i = 0; i < n; i++)
        {
            temp[i] = array[(i + k) % n];
        }

        // Копируем временный массив обратно в оригинальный
        Array.Copy(temp, array, n);
    }

    static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}

//------------------------#4------------------------------

using System;

class Program
{
    static void Main()
    {
        // Создаем и заполняем два двумерных массива 3x3
        int[,] array1 = new int[3, 3];
        int[,] array2 = new int[3, 3];
        Random random = new Random();

        // Заполнение массивов случайными числами
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                array1[i, j] = random.Next(1, 10); // Случайные числа от 1 до 9
                array2[i, j] = random.Next(1, 10); // Случайные числа от 1 до 9
            }
        }

        // Выводим исходные массивы
        Console.WriteLine("Массив 1:");
        PrintMatrix(array1);
        Console.WriteLine("Массив 2:");
        PrintMatrix(array2);

        // Сложение массивов
        double averageSum;
        int[,] sumResult = AddMatrices(array1, array2, out averageSum);
        Console.WriteLine("\nРезультат сложения:");
        PrintMatrix(sumResult);
        Console.WriteLine($"Среднее значение элементов: {averageSum}");

        // Вычитание массивов
        double averageDifference;
        int[,] differenceResult = SubtractMatrices(array1, array2, out averageDifference);
        Console.WriteLine("\nРезультат вычитания:");
        PrintMatrix(differenceResult);
        Console.WriteLine($"Среднее значение элементов: {averageDifference}");
    }

    static int[,] AddMatrices(int[,] matrix1, int[,] matrix2, out double average)
    {
        int[,] result = new int[3, 3];
        int sum = 0;
        int count = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
                sum += result[i, j];
                count++;
            }
        }

        average = (double)sum / count; // Вычисляем среднее значение
        return result;
    }

    static int[,] SubtractMatrices(int[,] matrix1, int[,] matrix2, out double average)
    {
        int[,] result = new int[3, 3];
        int sum = 0;
        int count = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                result[i, j] = matrix1[i, j] - matrix2[i, j];
                sum += result[i, j];
                count++;
            }
        }

        average = (double)sum / count; // Вычисляем среднее значение
        return result;
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}

//--------------------------#5----------------------------
using System;

class Program
{
    static void Main()
    {
        // Создаем и заполняем две матрицы 5x5
        int[,] matrix1 = new int[5, 5];
        int[,] matrix2 = new int[5, 5];
        int[,] resultMatrix = new int[5, 5];
        Random random = new Random();

        // Заполнение первой матрицы случайными числами
        Console.WriteLine("Матрица 1:");
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                matrix1[i, j] = random.Next(1, 10); // Случайные числа от 1 до 9
                Console.Write(matrix1[i, j] + "\t");
            }
            Console.WriteLine();
        }

        // Заполнение второй матрицы случайными числами
        Console.WriteLine("\nМатрица 2:");
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                matrix2[i, j] = random.Next(1, 10); // Случайные числа от 1 до 9
                Console.Write(matrix2[i, j] + "\t");
            }
            Console.WriteLine();
        }

        // Перемножение матриц
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                resultMatrix[i, j] = 0; // Инициализация элемента результирующей матрицы
                for (int k = 0; k < 5; k++)
                {
                    resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }

        // Вывод результирующей матрицы
        Console.WriteLine("\nРезультат перемножения матриц:");
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write(resultMatrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
//-----------------------#6---------------------------

using System;

class Program
{
    static void Main()
    {
        // Создаем и заполняем массив случайными числами
        int[] array = new int[10];
        Random random = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(1, 100); // Случайные числа от 1 до 99
        }

        // Выводим массив
        Console.WriteLine("Массив:");
        PrintArray(array);

        // Итеративное вычисление суммы
        int sumIter = sumIterative(array);
        Console.WriteLine($"Итеративная сумма элементов: {sumIter}");

        // Рекурсивное вычисление суммы
        int sumRec = sumRecursive(array, array.Length);
        Console.WriteLine($"Рекурсивная сумма элементов: {sumRec}");

        // Итеративное вычисление минимального элемента
        int minIter = minIterative(array);
        Console.WriteLine($"Итеративный минимальный элемент: {minIter}");

        // Рекурсивное вычисление минимального элемента
        int minRec = minRecursive(array, array.Length);
        Console.WriteLine($"Рекурсивный минимальный элемент: {minRec}");
    }

    // Итеративная функция для вычисления суммы элементов массива
    static int sumIterative(int[] array)
    {
        int sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }
        return sum;
    }

    // Рекурсивная функция для вычисления суммы элементов массива
    static int sumRecursive(int[] array, int n)
    {
        if (n == 0) // Базовый случай
            return 0;
        return array[n - 1] + sumRecursive(array, n - 1); // Рекурсивный случай
    }

    // Итеративная функция для нахождения минимального элемента массива
    static int minIterative(int[] array)
    {
        int min = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }
        }
        return min;
    }

    // Рекурсивная функция для нахождения минимального элемента массива
    static int minRecursive(int[] array, int n)
    {
        if (n == 1) // Базовый случай
            return array[0];
        return Math.Min(array[n - 1], minRecursive(array, n - 1)); // Рекурсивный случай
    }

    // Функция для вывода массива
    static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}

//-------------------------#7----------------------------------

using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите номер члена ряда Фибоначчи (n): ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n < 0)
        {
            Console.WriteLine("Введите корректное неотрицательное число.");
            return;
        }

        // Вычисляем n-ый член ряда Фибоначчи
        int fibonacciNumber = Fibonacci(n);
        Console.WriteLine($"Член ряда Фибоначчи с номером {n} равен: {fibonacciNumber}");
    }

    // Рекурсивная функция для нахождения n-ого члена ряда Фибоначчи
    static int Fibonacci(int n)
    {
        if (n == 0 || n == 1) // Базовые случаи
        {
            return 1;
        }
        return Fibonacci(n - 1) + Fibonacci(n - 2); // Рекурсивный случай
    }
}

//------------------------------ #8 ------------------------

using System;

class Program
{
    static void Main()
    {
        // Пример матрицы 3x3
        double[,] matrix = {
            { 6, 1, 1 },
            { 4, -2, 5 },
            { 2, 8, 7 }
        };

        Console.WriteLine("Исходная матрица:");
        PrintMatrix(matrix);

        double determinant = CalculateDeterminant(matrix);
        Console.WriteLine($"\nОпределитель матрицы: {determinant}");
    }

    // Рекурсивная функция для вычисления определителя
    static double CalculateDeterminant(double[,] matrix)
    {
        int size = matrix.GetLength(0);

        // Базовый случай для матрицы 1x1
        if (size == 1)
        {
            return matrix[0, 0];
        }

        // Базовый случай для матрицы 2x2
        if (size == 2)
        {
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }

        double determinant = 0;

        // Вычисление определителя через разложение по первой строке
        for (int j = 0; j < size; j++)
        {
            double[,] minor = GetMinor(matrix, 0, j); // Получаем дополнительный минор
            determinant += Math.Pow(-1, j) * matrix[0, j] * CalculateDeterminant(minor);
        }

        return determinant;
    }

    // Функция для получения минора (вычеркивание i-й строки и j-го столбца)
    static double[,] GetMinor(double[,] matrix, int rowToRemove, int colToRemove)
    {
        int size = matrix.GetLength(0);
        double[,] minor = new double[size - 1, size - 1];
        int minorRow = 0, minorCol;

        for (int i = 0; i < size; i++)
        {
            if (i == rowToRemove)
                continue;

            minorCol = 0;
            for (int j = 0; j < size; j++)
            {
                if (j == colToRemove)
                    continue;

                minor[minorRow, minorCol] = matrix[i, j];
                minorCol++;
            }

            minorRow++;
        }

        return minor;
    }

    // Функция для вывода матрицы на экран
    static void PrintMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j],6:F2} ");
            }
            Console.WriteLine();
        }
    }
}

