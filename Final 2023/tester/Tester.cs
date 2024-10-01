namespace MatCom.Tester;

public class Tester : TesterBase<int, Tuple<int[][], int[], int[], int>, int, int>
{
    public override Tuple<int[][], int[], int[], int> InputGenerator(int seed, int arg)
    {
        Random random = new Random(seed);
        int N = random.Next(1, arg);
        int M = random.Next(1, arg);
        int[][] matrix = new int[M][];
        int[] start = new int[M];
        int[] end = new int[M];
        for (int i = 0; i < M; i++)
        {
            matrix[i] = new int[M];
        }
        for (int i = 0; i < M; i++)
        {
            start[i] = random.Next(0, 100);
            end[i] = random.Next(start[i] + 20, 150);
            
            for (int j = i; j < M; j++)
            {
                matrix[i][j] = matrix[j][i] = i == j? 0: random.Next(0, 100);
            }   
        }
        start[0] = 0;
        end[0] = 0;
        return new Tuple<int[][], int[], int[], int>(matrix, start, end, N);
    }

    public override bool OutputChecker(Tuple<int[][], int[], int[], int> input, int output, int expectedOutput)
    {
        return output == expectedOutput;
    }

    public override int OutputGenerator(Tuple<int[][], int[], int[], int> input)
    {
        return GetRoutes(new Map(MakeMatrix(input.Item1), input.Item2, input.Item3), input.Item4);
    }

    static int GetRoutes(Map map, int n)
    {
        throw new NotImplementedException();
    }

    public static int[,] MakeMatrix(int[][] input)
    {
        int[,] matrix = new int[input[0].Length, input[0].Length];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i; j < matrix.GetLength(1); j++)
            {
                matrix[i,j] = matrix[j,i] = input[i][j];
            }
        }
        return matrix;
    }

}
