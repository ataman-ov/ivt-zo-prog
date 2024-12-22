//------------------#1----------------------

using System;

class Program
{
    static void Main()
    {
        // Ввод коэффициентов a, b и c
        Console.WriteLine("Введите коэффициент a:");
        double a = double.Parse(Console.ReadLine());

        Console.WriteLine("Введите коэффициент b:");
        double b = double.Parse(Console.ReadLine());

        Console.WriteLine("Введите коэффициент c:");
        double c = double.Parse(Console.ReadLine());

        // Проверка, что a не равно 0
        if (a == 0)
        {
            Console.WriteLine("Коэффициент a не может быть равен 0 для квадратного уравнения.");
            return;
        }

        // Вычисление дискриминанта
        double D = b * b - 4 * a * c;

        // Определение корней в зависимости от значения дискриминанта
        if (D > 0)
        {
            // Два действительных корня
            double x1 = (-b + Math.Sqrt(D)) / (2 * a);
            double x2 = (-b - Math.Sqrt(D)) / (2 * a);
            Console.WriteLine($"Два действительных корня: x1 = {x1}, x2 = {x2}");
        }
        else if (D == 0)
        {
            // Один действительный корень
            double x = -b / (2 * a);
            Console.WriteLine($"Один действительный корень: x = {x}");
        }
        else
        {
            // Два комплексных корня
            double realPart = -b / (2 * a);
            double imaginaryPart = Math.Sqrt(-D) / (2 * a);
            Console.WriteLine($"Комплексные корни: x1 = {realPart} + {imaginaryPart}i, x2 = {realPart} - {imaginaryPart}i");
        }
    }
}

//-------------------#2--------------------------------

using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество слагаемых: ");
        if (int.TryParse(Console.ReadLine(), out int terms) && terms > 0)
        {
            double piApproximation = 0.0;
            for (int i = 0; i < terms; i++)
            {
                double term = Math.Pow(-1, i) / (2 * i + 1); // Чередующиеся члены ряда
                piApproximation += term;
            }

            piApproximation *= 4; // Умножаем результат на 4 для приближения числа π
            Console.WriteLine($"Приближённое значение числа п: {piApproximation}");
        }
        else
        {
            Console.WriteLine("Пожалуйста, введите положительное целое число.");
        }
    }
}

//-------------------#3--------------------------------

using System;

class Program
{
    static void Main()
    {
        int count = 0;
        int a = 1; // f0
        int b = 1; // f1
        int c = 2; // f2

        // Генерируем числа Фибоначчи до тех пор, пока не достигнем четырехзначного числа
        while (c < 10000)
        {
            c = a + b; // f2 = f0 + f1
            a = b;     // f0 = f1
            b = c;     // f1 = f2

            // Проверяем, является ли текущее число четырехзначным
            if (c >= 1000 && c < 10000)
            {
                count++;
            }
        }

        Console.WriteLine("Количество четырехзначных чисел в ряде Фибоначчи: " + count);
    }
}

//----------------------#4--------------------------

using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите значение x (в радианах): ");
        if (!double.TryParse(Console.ReadLine(), out double x))
        {
            Console.WriteLine("Ошибка: некорректное значение x.");
            return;
        }

        Console.Write("Введите значение q (точность): ");
        if (!double.TryParse(Console.ReadLine(), out double q) || q <= 0)
        {
            Console.WriteLine("Ошибка: q должно быть положительным числом.");
            return;
        }

        double term = 1; // Первое слагаемое
        double sum = term; // Начинаем с первого члена ряда
        int count = 1; // Счётчик учтённых слагаемых
        int n = 2; // Начальное значение факториала (2!)

        while (Math.Abs(term) >= q)
        {
            term *= -x * x / (n * (n - 1)); // Вычисляем текущее слагаемое
            sum += term; // Добавляем его к сумме
            count++; // Увеличиваем счётчик
            n += 2; // Переходим к следующему факториалу
        }

        Console.WriteLine($"Приближённое значение cos({x}): {sum}");
        Console.WriteLine($"Количество учтённых слагаемых: {count}");
    }
}

//--------------------#5-------------------------

using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите натуральное число N: ");
        if (!int.TryParse(Console.ReadLine(), out int N) || N <= 0)
        {
            Console.WriteLine("Введите корректное натуральное число.");
            return;
        }

        bool foundCombination = false;

        // Перебираем все возможные значения x, y, z
        for (int x = 1; x <= Math.Cbrt(N); x++)
        {
            for (int y = x; y <= Math.Cbrt(N); y++) // y >= x для уникальности комбинаций
            {
                for (int z = y; z <= Math.Cbrt(N); z++) // z >= y для уникальности комбинаций
                {
                    if (x * x * x + y * y * y + z * z * z == N)
                    {
                        Console.WriteLine($"Комбинация: x = {x}, y = {y}, z = {z}");
                        foundCombination = true;
                    }
                }
            }
        }

        if (!foundCombination)
        {
            Console.WriteLine("No such combinations!");
        }
    }
}

//-----------------------#6----------------------------

using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите число от 1 до 100: ");

        if (!int.TryParse(Console.ReadLine(), out int N) || N < 1 || N > 100)
        {
            Console.WriteLine("Введите корректное число от 1 до 100.");
            return;
        }

        string wordForm;

        // Определяем правильную форму слова в зависимости от значения N
        if (N % 10 == 1 && N % 100 != 11)
        {
            wordForm = "год";
        }
        else if ((N % 10 >= 2 && N % 10 <= 4) && (N % 100 < 12 || N % 100 > 14))
        {
            wordForm = "года";
        }
        else
        {
            wordForm = "лет";
        }

        Console.WriteLine($"{N} {wordForm}");
    }
}

//---------------ИНДИВИДУААЛЬНОЕ ЗАДАНИЕ №1--------------------------

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите координаты точки A (x1, y1):");
        double x1 = Convert.ToDouble(Console.ReadLine());
        double y1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите координаты точки B (x2, y2):");
        double x2 = Convert.ToDouble(Console.ReadLine());
        double y2 = Convert.ToDouble(Console.ReadLine());

        // Проверка на нулевые координаты
        if (x1 == 0 || y1 == 0 || x2 == 0 || y2 == 0)
        {
            Console.WriteLine("Zero coord");
            return;
        }

        // Определяем четверти
        bool sameQuadrant = (x1 > 0 && y1 > 0 && x2 > 0 && y2 > 0) || // Первая четверть
                            (x1 < 0 && y1 > 0 && x2 < 0 && y2 > 0) || // Вторая четверть
                            (x1 < 0 && y1 < 0 && x2 < 0 && y2 < 0) || // Третья четверть
                            (x1 > 0 && y1 < 0 && x2 > 0 && y2 < 0);   // Четвертая четверть

        Console.WriteLine(sameQuadrant);
    }
}

//---------------ИНДИВИДУААЛЬНОЕ ЗАДАНИЕ №2--------------------------

using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите число от 1 до 100000: ");
        if (!int.TryParse(Console.ReadLine(), out int number) || number < 1 || number > 100000)
        {
            Console.WriteLine("Введите корректное число от 1 до 100000.");
            return;
        }

        bool isPowerOfThree = false;
        int power = 1;

        // Проверяем, является ли число степенью тройки
        while (power < number)
        {
            power *= 3;
        }

        if (power == number)
        {
            isPowerOfThree = true;
        }

        Console.WriteLine(isPowerOfThree);
    }
}
