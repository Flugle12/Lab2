using System;


public class nine
{

    private double _value1, _value2, _value3; //Разработать класс с тремя вещественными полями

    public nine(double value1, double value2, double value3) { _value1 = value1; _value2 = value2; _value3 = value3; }

    public nine(nine other) // конструктор копирования
    {
        _value1 = other._value1;
        _value2 = other._value2;
        _value3 = other._value3;
    }

    public void toINT() // метод для приведения к целому типу
    {
        _value1 = (int)_value1;
        _value2 = (int)_value2;
        _value3 = (int)_value3;
    }

    public override string ToString() // перегрузка ToString()
    {
        return $"\n{_value1}\n{_value2}\n{_value3}";
    }
}


public class extendNine : nine // Дочерний класс
{
    double _vector3Length; // Поля длина вектора и вектор трехмерного пространства
    private double[] _vector3;

    public extendNine(double x, double y, double z) : base(x, y, z) // Конструктор для заполнения вектора координатами и его длиной
    {
        _vector3 = new double[3] { x, y, z };
        _vector3Length = calculateLength();
    }

    private double calculateLength() // Метод поиска длины вектора
    {
        return Math.Sqrt(_vector3[0] * _vector3[0] + _vector3[1] * _vector3[1] + _vector3[2] * _vector3[2]);
    }

    public void normalize() // Метод нормализации вектора
    {
        if (_vector3Length > 0) // Проверяем, что длина больше нуля
        {
            for (int i = 0; i < _vector3.Length; i++)
            {
                _vector3[i] /= _vector3Length;
                //Console.WriteLine(_vector3[i]);
            }
        }
    }

    public override string ToString() // Перегрузка метода ToString()
    {
        return $"\n{_vector3[0]}\n{_vector3[1]}\n{_vector3[2]}";
    }

}
public class Program
{
    public static void Main(string[] args)
    {
        // Тестирование базового класса
        nine realNumbers = new nine(1.5, 2.7, 3.3);
        Console.WriteLine("Базовый класс: " + realNumbers.ToString());

        // Копирование
        nine copiedNumbers = new nine(realNumbers);
        Console.WriteLine("Копированный класс: " + copiedNumbers.ToString());

        // Приведение к целому типу
        copiedNumbers.toINT();
        Console.WriteLine("После приведения к целому: " + copiedNumbers.ToString());

        // Тестирование дочернего класса
        extendNine vector = new extendNine(3.34, 4.12, 100.909);
        Console.WriteLine("Дочерний класс: " + vector.ToString());

        // Нормализация вектора
        vector.normalize();
        Console.WriteLine("После нормализации: " + vector.ToString());
    }
}