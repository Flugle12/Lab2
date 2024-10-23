using System;
using System.Runtime.Remoting.Messaging;

public class Nine
{
    private double _value1, _value2, _value3; // три вещественными полями

    public Nine(double value1, double value2, double value3)
    {
        if (double.IsNaN(value1) || double.IsNaN(value2) || double.IsNaN(value3))
            throw new ArgumentException("Values cannot be NaN.");

        _value1 = value1;
        _value2 = value2;
        _value3 = value3;
    }

    public Nine(Nine other) // Конструктор копирования
    {
        _value1 = other._value1;
        _value2 = other._value2;
        _value3 = other._value3;
    }

    public void ToInt() // Метод для приведения к целому типу
    {
        _value1 = (int)_value1;
        _value2 = (int)_value2;
        _value3 = (int)_value3;
    }

    public override string ToString() // Перегрузка ToString()
    {
        return $"\nValue1: {_value1}\nValue2: {_value2}\nValue3: {_value3}";
    }
}

public class ExtendNine : Nine // Дочерний класс
{
    private double _vector3Length; // Поля длина вектора и вектор трехмерного пространства
    private double[] _vector3;

    public ExtendNine(double x, double y, double z) : base(x, y, z) // Конструктор для заполнения вектора координатами и длины
    {
        _vector3 = new double[3] { x, y, z };
        _vector3Length = CalculateLength();
    }

    private double CalculateLength() // Метод поиска длины вектора
    {
        return Math.Sqrt(_vector3[0] * _vector3[0] + _vector3[1] * _vector3[1] + _vector3[2] * _vector3[2]);
    }

    public void Normalize() // Метод нормализации вектора
    {
        if (_vector3Length > 0) // Проверяем, что длина больше нуля
        {
            for (int i = 0; i < _vector3.Length; i++)
            {
                _vector3[i] /= _vector3Length;
            }
        }
        else
        {
            throw new InvalidOperationException("Cannot normalize a zero-length vector.");
        }
    }

    public override string ToString() // Перегрузка метода ToString()
    {
        return $"\nVector: [{_vector3[0]}, {_vector3[1]}, {_vector3[2]}]";
    }
}


class Point
{
    private double _x, _y;

    public double X
    {
        get { return _x; }
        set
        {
            if (double.IsNaN(value))
            {
                throw new ArgumentException("Values cannot be NaN.");
            }
            _x = value;
        }
    }

    public double Y
    {
        get { return _y; }
        set
        {
            if (double.IsNaN(value))
            {
                throw new ArgumentException("Values cannot be NaN.");
            }
            _y = value;
        }
    }

    public Point() // конструктор по умолчанию 
    {
        _x = 0;
        _y = 0;
    }

    public Point(double x, double y) // конструктор с параметрами
    {
        X = x; Y = y;
    }

    public double GetLength() // вычисление длинны вектора
    {
        return Math.Sqrt(X * X + Y * Y);
    }

    // Перегрузка ToString()
    public override string ToString()
    {
        return $"Point({X}, {Y})";
    }

    // Унарная операция: уменьшить координаты x и y на 1
    public static Point operator --(Point p)
    {
        p.X -= 1;
        p.Y -= 1;
        return p;
    }

    // Унарная операция: поменять координаты x и y местами
    public static Point operator ~(Point p)
    {
        double temp = p.X;
        p.X = p.Y;
        p.Y = temp;
        return p;
    }

    // Приведение типа: неявное к int x
    public static implicit operator int(Point p)
    {
        return (int)p.X;
    }

    // Приведение типа: явное к double (y)
    public static explicit operator double(Point p)
    {
        return p.Y;
    }

    // Бинарная операция: Point p - целое число (уменьшается x)
    public static Point operator -(Point p, int value)
    {
        p.X -= value;
        return p;
    }

    // Бинарная операция: целое число - Point p (уменьшается y)
    public static Point operator -(int value, Point p)
    {
        p.Y -= value;
        return p;
    }

    // Метод для вычисления расстояния до другой точки
    public static double operator -(Point p1, Point p2)
    {
        return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Тестирование базового класса
            Nine baseObj = new Nine(1.5, 2.8, 3.9);
            Console.WriteLine("Base Class:");
            Console.WriteLine(baseObj);
            baseObj.ToInt();
            Console.WriteLine("After ToInt:");
            Console.WriteLine(baseObj);

            // Тестирование дочернего класса
            ExtendNine derivedObj = new ExtendNine(4.0, 5.0, 6.0);
            Console.WriteLine("\nDerived Class:");
            Console.WriteLine(derivedObj);
            derivedObj.Normalize();
            Console.WriteLine("After normalization:");
            Console.WriteLine(derivedObj);

            // Тестирование исключений
            try
            {
                ExtendNine invalidVector = new ExtendNine(0, 0, 0);
                invalidVector.Normalize(); // Это вызовет исключение
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            // Проверка на NaN
            try
            {
                Nine nanTest = new Nine(double.NaN, 1.0, 2.0);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unhandled Exception: {ex.Message}");
        }

        Console.WriteLine();

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

        Console.WriteLine();

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