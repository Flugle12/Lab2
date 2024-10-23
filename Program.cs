using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("\nSecond\n");


        void threeInput(out double a, out double b)
        {
            Console.WriteLine("Enter three double nums separetad by space: ");
            string input = Console.ReadLine();
            string[] parts = input.Split(' ');

            if (parts.Length < 2)
            {
                throw new ArgumentException("Need to two nums");
            }
            if (!double.TryParse(parts[0], out a) || !double.TryParse(parts[1], out b))
            {
                throw new ArgumentException("Need to nums");
            }
            else
            {
                a = double.Parse(parts[0]); 
                b = double.Parse(parts[1]);
            }
        }

        try
        {
            double input1, input2;
            threeInput(out input1, out input2);


            Point newPoint = new Point(input1, input2);
            Console.WriteLine(newPoint.ToString());

            Console.WriteLine("длинна вектора: " + newPoint.GetLength());
            Console.WriteLine("--: " + newPoint--);
            Console.WriteLine("~: " + ~newPoint);
            Console.WriteLine("int: " + (int)newPoint);
            Console.WriteLine("double: " + (double)newPoint);

            Console.WriteLine("введите число на которое хотите уменьшить x: ");
            string inputstr = Console.ReadLine();
            if (int.TryParse(inputstr, out int n)) // Пробуем преобразовать строку в int
            {
                Console.WriteLine(newPoint + "\nleft -: " + (newPoint - n));
            }
            else
            {
                throw new ArgumentException("not a num");
            }

            Console.WriteLine("введите число на которое хотите уменьшить y: ");
            string inputstr1 = Console.ReadLine();
            if (int.TryParse(inputstr1, out int n1)) // Пробуем преобразовать строку в int
            {
                Console.WriteLine(newPoint + "\nleft -: " + (newPoint - n));
            }
            else
            {
                throw new ArgumentException("not a num");
            }

            Console.WriteLine("введите координаты второй точки: ");
            double input3, input4;
            threeInput(out input3, out input4);
            Point newPoint1 = new Point(input3, input4);
            Console.WriteLine(newPoint1.ToString());

            Console.WriteLine("Point1 - Point2: " + (newPoint - newPoint1));
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }
        

    }
}