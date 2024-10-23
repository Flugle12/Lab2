using System;




class Program
{
    static void Main()
    {
        Console.WriteLine("\nSecond\n");

        try
        {
            Point point1 = new Point();
            Console.WriteLine(point1.ToString());
            Console.WriteLine($"Distance from origin: {point1.GetLength()}");

            Point point2 = new Point(double.NaN, 4);
            Console.WriteLine(point2.ToString());
            Console.WriteLine($"Distance from origin: {point2.GetLength()}");

            // Тестирование валидации
            point2.X = double.NaN; // Это вызовет исключение
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\nThird\n");

        try
        {
            Point point1 = new Point(3, 4);
            Point point2 = new Point(6, 8);

            Console.WriteLine($"Point 1: {point1}");
            Console.WriteLine($"Point 2: {point2}");

            // Унарная операция: уменьшение координат
            --point1;
            Console.WriteLine($"Point 1 после уменьшения: {point1}");

            // Унарная операция: поменять координаты
            Point swappedPoint = ~point1;
            Console.WriteLine($"Point 1 после смены координат: {swappedPoint}");

            // Операция приведения типа
            int intPart = (int)point1; // неявное приведение
            double doublePart = (double)point1; // явное приведение
            Console.WriteLine($"Целая часть X: {intPart}");
            Console.WriteLine($"Координата Y: {doublePart}");

            // Бинарные операции
            point1 = point1 - 2; // уменьшение X на 2
            Console.WriteLine($"Point 1 после уменьшения X на 2: {point1}");

            point2 = 3 - point2; // уменьшение Y на 3
            Console.WriteLine($"Point 2 после уменьшения Y на 3: {point2}");

            // Расстояние между двумя точками
            double distance = point1 - point2;
            Console.WriteLine($"Расстояние между Point 1 и Point 2: {distance}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    
    }
}