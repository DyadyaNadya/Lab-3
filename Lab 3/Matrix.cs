public class Matrix
{
    private double[,] matrix;

    public double [,] Arr
    {
        get { return matrix; }
        set { matrix = value; }
    }


    //Конструктор для первого массива
    public Matrix(int n, int m, bool inputRequired = false)
    {
        matrix = new double[n, m];
        if (inputRequired)
        {
            Console.WriteLine($"Введите элементы двумерного массива: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Введите элемент с индексом [{i},{j}]: ");
                    matrix[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }
        }
        this.Arr = matrix;
    }


    //Конструктор для второго массива

    public Matrix(int n)
    {
        matrix = new double[n, n];
        Random rand = new Random();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (j < n - i - 1)
                {
                    matrix[i, j] = rand.NextDouble() * (120 - (-65)) + (-65);
                }
                else
                {
                    matrix[i, j] = rand.NextDouble() * (10.75 - (3.5)) + (-3.5);
                }
            }
        }
        this.Arr = matrix;
    }

    //Конструктор для третьего массива
    public Matrix(int n, bool fill)
    {
        matrix = new double[n, n];
        int value = 1;

        // Заполнение начинается с верхнего правого угла
        for (int startCol = n - 1; startCol >= 0; startCol--)
        {
            int i = 0;
            int j = startCol;
            while (j < n && i < n)
            {
                matrix[i, j] = value++;
                i++;
                j++;
            }
        }

        // Заполнение нулями
        for (int startRow = 1; startRow < n; startRow++)
        {
            int i = startRow;
            int j = 0;
            while (i < n && j < n)
            {
                matrix[i, j] = 0;
                i++;
                j++;
            }
        }
        this.Arr = matrix;
    }

    public void display()
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"{matrix[i, j],8:F2} ");
            }
            Console.WriteLine();
        }
      
    }

    public Matrix()
    {
        this.Arr = new double[0, 0];
    }

    //Задание 2
    public void debt()
    {
        int banks = matrix.GetLength(0);

        // Заменяем элементы на главной диагонали на ноль
        for (int i = 0; i < banks; i++)
        {
            matrix[i, i] = 0;
        }

        int bankWithMaxDebt = 0;
        int debtorToBank = 0;
        double maxDebt = 0; // Начальное значение минимальное, чтобы найти максимум

        // Поиск максимальной задолженности среди всех банков
        for (int i = 0; i < banks; i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > maxDebt)
                {
                    maxDebt = matrix[i, j];
                    bankWithMaxDebt = i;
                    debtorToBank = j;
                }
            }
        }

        Console.WriteLine($"\nБанк {bankWithMaxDebt + 1} имеет максимальную задолженность {maxDebt} перед банком {debtorToBank + 1}");
    }

    //Перегрузка оператора для умножения матрицы на число
    public static Matrix operator *(double num, Matrix mat)
    {
        int rows = mat.matrix.GetLength(0);
        int cols = mat.matrix.GetLength(1);
        Matrix result = new Matrix(rows, cols);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result.matrix[i, j] = num * mat.matrix[i, j];
            }
        }
        return result;

    }

    //Перегрузка вычитания матриц
    public static Matrix operator -(Matrix mat1, Matrix mat2)
    {
        int rows = mat1.matrix.GetLength(0);
        int cols = mat1.matrix.GetLength(1);

        if (rows != mat2.matrix.GetLength(0) || cols != mat2.matrix.GetLength(1))
        {
            throw new ArgumentException("Матрицы имеют разные размеры");
        }

        Matrix result = new Matrix(rows, cols);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result.matrix[i, j] = mat1.matrix[i, j] - mat2.matrix[i, j];
            }
        }
        return result;
    }


    //Перегрпзка оператора умножения матриц
    public static Matrix operator *(Matrix mat1, Matrix mat2)
    {
        int mat1Rows = mat1.matrix.GetLength(0);
        int mat1Cols = mat1.matrix.GetLength(1);
        int mat2Rows = mat2.matrix.GetLength(0);
        int mat2Cols = mat2.matrix.GetLength(1);
        if (mat1Cols != mat2Rows)
        {
            throw new ArgumentException("Матрицы имеют недопустимые размеры для умножения");
        }

        Matrix result = new Matrix(mat1Rows, mat2Cols);

        for (int i = 0; i < mat1Rows; i++)
        {
            for (int j = 0; j < mat2Cols; j++)
            {
                for (int k = 0; k < mat1Cols; k++)
                {
                    result.matrix[i, j] += mat1.matrix[i, k] * mat2.matrix[k, j];
                }
            }
        }

        return result;
    }

    public Matrix Transponse()
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        Matrix result = new Matrix(rows, cols);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0;j < cols; j++)
            {
                result.matrix[j, i] = matrix[i, j];
            }
        }
        return result;
    }

    //Перегрузка метода ToString для вывода
    public override string ToString()
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        string result = "";

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result += $"{matrix[i, j],8:F2} ";
            }
            result += "\n";
        }
        return result;

    }
}