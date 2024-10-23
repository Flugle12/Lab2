using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



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
        return $"Point {X}, {Y}";
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