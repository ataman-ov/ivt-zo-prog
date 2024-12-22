//----------------------#1---------------------------

using System;

class Program
{
    static void Main()
    {
        // Пример положительного вещественного числа
        double x = 21.3198;

        // Преобразуем число в строку
        string xString = x.ToString();

        // Находим позицию запятой или точки
        int decimalPointIndex = xString.IndexOf(',');

        // Проверяем, что дробная часть существует
        if (decimalPointIndex != -1 && decimalPointIndex < xString.Length - 1)
        {
            // Извлекаем первую цифру дробной части
            char firstDecimalDigit = xString[decimalPointIndex + 1];

            // Преобразуем символ в целое число
            int d = (int)char.GetNumericValue(firstDecimalDigit);

            // Выводим результат
            Console.WriteLine($"Первая цифра дробной части: {d}");
        }
        else
        {
            Console.WriteLine($"Дробная часть отсутствует. ");
        } 
    }
}
//------------------ #2 -----------------------

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("В 1ч = 3600сек ");
        Console.WriteLine("В 24ч = 86400сек ");
        // Ввод количества секунд
        Console.Write("Введите количество секунд, прошедших с начала суток: ");
        int totalSeconds;
        
        // Проверка корректности ввода
        while (!int.TryParse(Console.ReadLine(), out totalSeconds) || totalSeconds < 0)
        {
            Console.Write("Пожалуйста, введите неотрицательное целое число: ");
        }

        // Вычисление количества часов и минут
        int hours = totalSeconds / 3600; // 1 час = 3600 секунд
        int minutes = (totalSeconds % 3600) / 60; // 1 минута = 60 секунд

        // Вывод результата
        Console.WriteLine($"Прошло {hours} часов и {minutes} минут.");
    }
}

//-------------------------#3----------------------------

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите часы (0-11):");
        int h = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите минуты (0-59):");
        int m = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите секунды (0-59):");
        int s = int.Parse(Console.ReadLine());

        // Проверка корректности введенных данных
        if (h < 0 || h > 11 || m < 0 || m > 59 || s < 0 || s > 59)
        {
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите значения в допустимых диапазонах.");
            return;
        }

        // Вычисление угла
        double hourAngle = (h * 30) + (m * 0.5) + (s * (0.5 / 60));
        double minuteAngle = m * 6 + s * 0.1; // Угол минутной стрелки (не используется, но для полноты картины)

        // Угол между часовыми стрелками
        double angle = hourAngle;

        // Убедимся, что угол не превышает 360 градусов
        if (angle > 360)
        {
            angle -= 360;
        }

        // Угол между положением часовой стрелки и началом суток
        Console.WriteLine($"Угол между положением часовой стрелки в начале суток и в {h} часов, {m} минут и {s} секунд: {angle} градусов.");
    }
}

//----------------------#4----------------------

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите первое целое число (a):");
        int a = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите второе целое число (b):");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine($"До обмена: a = {a}, b = {b}");

        // Обмен значениями без использования дополнительных переменных
        a = a + b; // Суммируем a и b
        b = a - b; // Теперь b становится равным первоначальному a
        a = a - b; // Теперь a становится равным первоначальному b

        Console.WriteLine($"После обмена: a = {a}, b = {b}");
    }
}
//------------------#5-------------------------
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите длину первого катета (a):");
        double a = double.Parse(Console.ReadLine());

        Console.WriteLine("Введите длину второго катета (b):");
        double b = double.Parse(Console.ReadLine());

        // Вычисление площади
        double area = 0.5 * a * b;

        // Вычисление длины гипотенузы
        double c = Math.Sqrt(a * a + b * b);

        // Вычисление периметра
        double perimeter = a + b + c;

        // Вывод результатов
        Console.WriteLine($"Площадь треугольника: {area}");
        Console.WriteLine($"Периметр треугольника: {perimeter}");
    }
}
//----------------#6-------------------------
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите четырехзначное число:");
        string input = Console.ReadLine();

        // Проверка, что введенное число является четырехзначным
        if (input.Length != 4 || !int.TryParse(input, out int number))
        {
            Console.WriteLine("Ошибка: Введите корректное четырехзначное число.");
            return;
        }

        // Инициализация переменной для произведения
        int product = 1;

        // Проход по каждой цифре числа
        foreach (char digit in input)
        {
            // Преобразование символа в цифру и умножение на произведение
            product *= (digit - '0'); // '0' - это символ, который соответствует 0 в ASCII
        }

        // Вывод результата
        Console.WriteLine($"Произведение цифр числа {input} равно {product}.");
    }
}
//------------------#7--------------------------
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите трехзначное число:");
        string input = Console.ReadLine();

        // Проверка, что введенное число является трехзначным
        if (input.Length != 3 || !int.TryParse(input, out int number))
        {
            Console.WriteLine("Ошибка: Введите корректное трехзначное число.");
            return;
        }

        // Переворот строки
        string reversed = new string(input.ToCharArray().Reverse().ToArray());

        // Вывод результата
        Console.WriteLine($"Число {input} в обратном порядке: {reversed}");
    }
}
//------------------#8-----------------------
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите действительное число x:");
        double x = double.Parse(Console.ReadLine());

        // Вычисление x^2
        double x2 = x * x; // 1 умножение

        // Вычисление x^3
        double x3 = x * x2; // 2 умножение

        // Вычисление x^4
        double x4 = x * x3; // 3 умножение

        // Теперь вычисляем выражение
        double result = 3 * x4 - 5 * x3 + 2 * x2 - x + 7; // 4 умножение

        // Вывод результата
        Console.WriteLine($"Результат выражения 3x^4 - 5x^3 + 2x^2 - x + 7: {result}");
    }
}
//-----------------#9---------------------
using System;

class Program
{
    static void Main()
    {
        // Ввод коэффициентов
        Console.WriteLine("Введите коэффициенты для первого уравнения (a1, b1, c1, d1):");
        double a1 = double.Parse(Console.ReadLine());
        double b1 = double.Parse(Console.ReadLine());
        double c1 = double.Parse(Console.ReadLine());
        double d1 = double.Parse(Console.ReadLine());

        Console.WriteLine("Введите коэффициенты для второго уравнения (a2, b2, c2, d2):");
        double a2 = double.Parse(Console.ReadLine());
        double b2 = double.Parse(Console.ReadLine());
        double c2 = double.Parse(Console.ReadLine());
        double d2 = double.Parse(Console.ReadLine());

        Console.WriteLine("Введите коэффициенты для третьего уравнения (a3, b3, c3, d3):");
        double a3 = double.Parse(Console.ReadLine());
        double b3 = double.Parse(Console.ReadLine());
        double c3 = double.Parse(Console.ReadLine());
        double d3 = double.Parse(Console.ReadLine());

        // Вычисление определителя D
        double D = a1 * (b2 * c3 - b3 * c2) - b1 * (a2 * c3 - a3 * c2) + c1 * (a2 * b3 - a3 * b2);

        // Проверка, что определитель не равен 0
        if (D == 0)
        {
            Console.WriteLine("Определитель системы равен 0. Система не имеет единственного решения.");
            return;
        }

        // Вычисление определителей для x, y, z
        double Dx = d1 * (b2 * c3 - b3 * c2) - b1 * (d2 * c3 - d3 * c2) + c1 * (d2 * b3 - d3 * b2);
        double Dy = a1 * (d2 * c3 - d3 * c2) - d1 * (a2 * c3 - a3 * c2) + c1 * (a2 * d3 - a3 * d2);
        double Dz = a1 * (b2 * d3 - b3 * d2) - b1 * (a2 * d3 - a3 * d2) + d1 * (a2 * b3 - a3 * b2);

        // Вычисление значений переменных
        double x = Dx / D;
        double y = Dy / D;
        double z = Dz / D;

        // Вывод результатов
        Console.WriteLine($"Решение системы уравнений:");
        Console.WriteLine($"x = {x}");
        Console.WriteLine($"y = {y}");
        Console.WriteLine($"z = {z}");
    }
}
//---------------------#10---------------------
using System;

class Program
{
    static void Main()
    {
        // Заголовок таблицы
        Console.WriteLine("Таблица данных");
        Console.WriteLine("=====================================");
        Console.WriteLine("|  ID  |   Name   |   Value   |");
        Console.WriteLine("=====================================");

        // Ввод данных
        Console.WriteLine("Введите количество записей:");
        int n = int.Parse(Console.ReadLine());

        // Массивы для хранения данных
        int[] ids = new int[n];
        string[] names = new string[n];
        double[] values = new double[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите данные для записи {i + 1}:");

            Console.Write("ID (целое число): ");
            ids[i] = int.Parse(Console.ReadLine());

            Console.Write("Name (строка): ");
            names[i] = Console.ReadLine();

            Console.Write("Value (вещественное число): ");
            values[i] = double.Parse(Console.ReadLine());
        }

        // Вывод данных в формате таблицы
        Console.WriteLine("=====================================");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"| {ids[i],-4} | {names[i],-8} | {values[i],-9:F2} |");
        }
        Console.WriteLine("=====================================");

        // Примечания
        Console.WriteLine("Примечания:");
        Console.WriteLine("1. ID - уникальный идентификатор записи.");
        Console.WriteLine("2. Name - название или описание.");
        Console.WriteLine("3. Value - числовое значение, связанное с записью.");
    }
}
//------------------#11---------------------
using System;

class Program
{
    static void Main()
    {
        // Ввод значений параметров
        Console.WriteLine("Введите значение a (a >= 0):");
        double a = double.Parse(Console.ReadLine());

        Console.WriteLine("Введите значение b (b > 0):");
        double b = double.Parse(Console.ReadLine());

        Console.WriteLine("Введите значение c (c != 0):");
        double c = double.Parse(Console.ReadLine());

        // Проверка допустимых значений
        if (a < 0)
        {
            Console.WriteLine("Ошибка: a должно быть неотрицательным.");
            return;
        }

        if (b <= 0)
        {
            Console.WriteLine("Ошибка: b должно быть положительным.");
            return;
        }

        if (c == 0)
        {
            Console.WriteLine("Ошибка: c не должно быть равно нулю.");
            return;
        }

        // Вычисление значений по формулам
        double y1 = (a * a + b * b) / c;
        double y2 = Math.Sqrt(a) + Math.Log(b);

        // Вывод результатов
        Console.WriteLine($"Результат по первой формуле (y1): {y1}");
        Console.WriteLine($"Результат по второй формуле (y2): {y2}");
    }
}
