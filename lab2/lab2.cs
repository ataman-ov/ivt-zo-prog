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
