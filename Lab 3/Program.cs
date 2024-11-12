using System;
using System.Data;
using static Files;
public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            
            int n = Check.GetPositiveInt("Введите число строк n: ");
            int m = Check.GetPositiveInt("Введите число строк m: ");

            //Первый массив
            Matrix matrixone = new Matrix(n, m, true);
            Console.WriteLine("\nПервый массив: ");
            matrixone.display();

            Console.WriteLine();

            //Второй массив
            Matrix matrixtwo = new Matrix(n);
            Console.WriteLine("Второй массив: ");
            matrixtwo.display();

            Console.WriteLine();

            //Третий массив (не работает корректно)
            Matrix matrixthree = new Matrix(n, true);
            Console.WriteLine("Третий массив (не выводится корректно): ");
            matrixthree.display();

            Console.WriteLine("\n------Задание 2------");
            //Задание 2
            Console.WriteLine("\n!!!!!Банк определяется по строкам!!!!!\n");
            Matrix task2 = new Matrix(m, m, true);
            task2.display();
            task2.debt();


            //Задание 3
            Console.WriteLine("\n------Задание 3------\n");
            Matrix A = new Matrix();
            Matrix B = new Matrix();
            Matrix C = new Matrix();
            double[,] matrix1 = { { 4, 3, 5 }, { 1, 7, 3 }, { -4, 2, 5 } };
            A.Arr = matrix1;
            double[,] matrix2 = { { 0, 3, -2 }, { 0, 5, 4 }, { 1, 2, 3 } };
            B.Arr = matrix2;
            double[,] m3 = { { 10, 4, 2 }, { 5, 6, 1 }, { 3, 4, 0 } };
            C.Arr = m3;


            Matrix result = (2 * A) - (B.Transponse() * C);
            A.display();
            Console.WriteLine();
            B.display();
            Console.WriteLine();
            C.display();
            Console.WriteLine();
            Console.WriteLine("Результат выражения: ");
            result.display();



            //4 задание
            string filePath = "digits.bin";
            Console.WriteLine("\n------3адание 4------ \n");
            Files.Filler(filePath);
            Console.WriteLine();
            int count = Files.CountOppositePairs(filePath);
            Console.WriteLine($"Количество пар противоположных чисел: {count}\n");


            //5 задание
            Console.WriteLine("------Задание 5------");
            BaggageItem[] baggage = FillBaggageArray();
            SerializeBaggageToFile(filePath, baggage);
            BaggageItem[] desiralizedBaggage = DeserializeBaggageFromFile(filePath);
            double massDifference = Difference(desiralizedBaggage);
            Console.WriteLine($"\nРазница между маскимальной и минимальной массой багажа: {massDifference} кг");

            //Задание 6
            string filepath2 = "file.txt";
            Console.WriteLine("\n------Задание 6------");
            FillTheFile(filepath2);
            bool zero = ContainsZero(filepath2);
            string answer;
            if (zero)
            {
                answer = "Нет, не содержит";
            }
            else
            {
                answer = "Да, содержит";
            }
            Console.WriteLine($"Содержит ли файл ноль? {answer}");

            //Задание 7
            string filepath3 = "file3.txt";
            Console.WriteLine("\n------Задание 7------");
            FillTheFileLine(filepath3);
            int max = FindMax(filepath3);
            Console.WriteLine($"Максимальное число в файле: {max} ");

            //Задание 8
            string filename4 = "text.txt";
            string output = "output.txt";
            Console.WriteLine("\n------Задание 8------");
            Console.Write("Введите символ, на который должны заканчиваться строки: ");
            char letter = Check.GetChar();
            LinesWithChar(filename4, output, letter);
            Console.WriteLine("Файл перезаписан");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

    }
}