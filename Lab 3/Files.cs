using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

public static class Files
{
    //4 задание
    public static int CountOppositePairs(string file)
    {
        if (!File.Exists(file))
        {
            throw new FileNotFoundException("Файл не найден");
        }

        HashSet<string> pairs = new HashSet<string>();
        int count = 0;

        try
        {
            using (BinaryReader reader = new BinaryReader(File.Open(file, FileMode.Open)))
            {
                long filelength = reader.BaseStream.Length;
                int[] numbers = new int[filelength / sizeof(int)];

                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = reader.ReadInt32();
                }


                HashSet<string> checkedPairs = new HashSet<string>();
                for (int i = 0; i < numbers.Length; i++)
                {
                    for (int j = i + 1; j < numbers.Length; j++)
                    {
                        if (numbers[i] == -numbers[j])
                        {
                            string pairkey = $"{Math.Min(numbers[i], numbers[j])},{Math.Max(numbers[i], numbers[j])}";
                            if (!checkedPairs.Contains(pairkey))
                            {
                                count++;
                                checkedPairs.Add(pairkey);
                                Console.WriteLine($"Пара ({numbers[i]}, {numbers[j]}) проверена.");
                            }
                        }
                    }
                }
            }
        }
        catch
        {
            Exception ex;
        }
        return count;
    }


    public static void Filler(string file)
    {
        int n = Check.GetPositiveInt("Введите количество чисел в файле: ");
        Random rnd = new Random();
        using (BinaryWriter writer = new BinaryWriter(File.Open(file, FileMode.Create)))
        {
            for (int i = 0; i < n; i++)
            {
                int randomnum = rnd.Next(-100, 100);
                writer.Write(randomnum);


            }

        }
    }

    //Задание 5

    [Serializable]
    public struct BaggageItem
    {
        private string _name;
        private double _mass;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Mass
        {
            get { return _mass; }
            set { _mass = value; }

        }
    }

        //Сериализация объектов и запись в файл
        public static void SerializeBaggageToFile(string file, BaggageItem[] items)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BaggageItem[]));
            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                serializer.Serialize(fs, items);
            }
        }

        //Ввод
        public static BaggageItem[] FillBaggageArray()
        {
            
        int n = Check.GetPositiveInt("Введите количество элементов багажа: ");
            BaggageItem[] baggage = new BaggageItem[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введите название {i + 1}-й единицы багажа: ");
                string name = Console.ReadLine();
                double mass = Check.GetPositiveDouble($"Введите массу {i + 1}-й единицы багажа: ");

                baggage[i] = new BaggageItem { Name = name, Mass = mass };
            }

            return baggage;
        }

        //Десериализация и чтение массива объектов
        public static BaggageItem[] DeserializeBaggageFromFile(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BaggageItem[]));
            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                return (BaggageItem[])serializer.Deserialize(fs);
            }
        }

        //Вычисление разницы
        public static double Difference(BaggageItem[] items)
        {
            if (items == null || items.Length == 0)
            {
                throw new ArgumentException("Список багажа пуст или отсутствует");
            }

            double maxMass = items.Max(item => item.Mass);
            double minMass = items.Min(item => item.Mass);

            return maxMass - minMass;
        }



        //Задание 6
        public static void FillTheFile(string file)
        {
        int n = Check.GetPositiveInt("Введите количество чисел в файле: ");
            Random rnd = new Random();
            using (StreamWriter writer = new StreamWriter(File.Open(file, FileMode.Create)))
            {
                for (int i = 0; i < n; i++)
                {
                    int randomnum = rnd.Next(-10, 10);
                    writer.Write(randomnum);
                    writer.Write("\n");

                }

            }
        }

        public static bool ContainsZero(string file)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int num) && num == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //Задание 7
        public static void FillTheFileLine(string file)
        {
        int n = Check.GetPositiveInt("Введите количество строк в файле: ");    
        int str = Check.GetPositiveInt("Введите количество чисел в строке: ");

            Random rnd = new Random();
            using (StreamWriter writer = new StreamWriter(File.Open(file, FileMode.Create)))
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < str; j++)
                    {
                        int randomnum = rnd.Next(-100, 100);
                        writer.Write(randomnum);
                        writer.Write(" ");

                    }
                    writer.Write("\n");
                }

            }
        }


        public static int FindMax(string file)
        {
            int max = int.MinValue;
            string line;
            using (StreamReader reader = new StreamReader(file))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string[] numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    foreach (string numberStr in numbers)
                    {
                        if (int.TryParse(numberStr, out int num) && num > max)
                        {
                            max = num;
                        }
                    }
                }
            }
            return max;

        }


        //Задание 8
        public static void LinesWithChar(string fileinput, string fileoutput, char ending)
        {
            using (StreamReader reader = new StreamReader(fileinput))
            using (StreamWriter writer = new StreamWriter(fileoutput))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.EndsWith(ending))
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }








