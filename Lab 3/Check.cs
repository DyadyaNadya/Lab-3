public class Check
{
    public static int GetPositiveInt(string message)
    {
        int result;
        do
        {
            Console.Write(message);
            string input = Console.ReadLine();
            if (!int.TryParse(input, out result) || result <= 0)
            {
                Console.WriteLine("Пожалуйста, введите положительное целое число. ");
            }
        } while (result <= 0);
        return result;
    }

    public static double GetPositiveDouble(string message)
    {
        double result;
        do
        {
            Console.Write(message);
            string input = Console.ReadLine();
            if (!double.TryParse(input, out result) || result <= 0)
            {
                Console.WriteLine("Пожалуйста, введите положительное число. ");
            }
        } while (result <= 0);
        return result;
    }

    public static char GetChar()
    {
        char result;
        string input;
        do
        {
            input = Console.ReadLine();
            if (input.Length != 1 || !char.TryParse(input, out result))
            {
                Console.WriteLine("Пожалуйста, введите один символ.");
            }
        } while (input.Length != 1 || !char.TryParse(input, out result));
        return result;
    }
}
