using System.Diagnostics;

namespace Weboo.Examen;

public class Program
{
    public static void Main()
    {
        int[,] map1 =
        {
            { 0, 1, 1, 1 },
            { 1, 0, 1, 1 },
            { 1, 1, 0, 1 },
            { 1, 1, 1, 0 }
        };
        
       int result = Solution.Solve(map1, 1, 0);
        Debug.Assert(result == -1);
        
        int result1 = Solution.Solve(map1, 2, 0);
        Debug.Assert(result1 == 6);
        
        int result2 = Solution.Solve(map1, 3, 0);
        Debug.Assert(result2 == 5);
        
        int result3 = Solution.Solve(map1, 4, 0);
        Debug.Assert(result3 == 4);
        
        int[,] map2 =
        {
            { 0, 2, 4, 6 },
            { 7, 0, 2, 4 },
            { 9, 9, 0, 5 },
            { 7, 4, 6, 0 }
        };
        int result4 = Solution.Solve(map2, 14, 1);
        Debug.Assert(result4 == 20);
        

        int[,] map3 =
        {
            { 0, 4, 4, 3, 8 },
            { 2, 0, 2, 5, 9 },
            { 7, 5, 0, 4, 7 },
            { 3, 1, 3, 0, 5 },
            { 6, 4, 6, 8, 0 }
        };

        int result5 = Solution.Solve(map3, 17, 0);
        Debug.Assert(result5 == 23);

        int result6 = Solution.Solve(map3, 15, 0);
        Debug.Assert(result6 == 25);

        int result7 = Solution.Solve(map3, 13, 0);
        Debug.Assert(result7 == -1);

        Console.WriteLine("All tests passed!!!");
    }
}