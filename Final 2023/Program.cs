using System.ComponentModel;
public class Program
{
    public static void Main()
    {
        var matrix = new int[,]
    {
    {0,1,5,69,44,47,74,23,59},
    {1,0,78,52,54,47,78,86,34},
    {5,78,0,43,9,9,37,16,65 },
    {69,52,43,0,50,90,8,3,93},
    {44,54,9,50,0,2,22,57,82},
    {47,47,9,90,2,0,1,31,69},
    {74,78,37,8,22,1,0,74,87},
    {23,86,16,3,57,31,74,0,30},
    {59,34,65,93,82,69,87,30,0}
    };

    var start = new int[] { 0, 38, 82, 30, 34, 40, 51, 52, 99 };
    var end = new int[] { 0, 108, 134, 116, 64, 125, 113, 113, 149 };
    var map = new Map(matrix, start, end);

    Console.WriteLine(Solution.GetRoutes(map, 16));
    }
}
