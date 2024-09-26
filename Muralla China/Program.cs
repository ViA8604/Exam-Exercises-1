public class Program
{
    public static void Main()
    {
        int [] secciones  = new int [] {10,20,30,40};
        int c = 2;
        Console.WriteLine("min: " + Solve(secciones , c).ToString());
    }

    public static int Solve(int [] array, int c)
    {
        int min = int.MaxValue;
        Solve(array, c, 0, 0, ref min);
        return min;
    }
    public static void Solve(int[] Arr, int c, int start, int currentTime, ref int min)
    {
        if(currentTime > min)   //Poda
            return;
            
        if (c == 1)             //Caso base
        {
            currentTime = Math.Max(currentTime, Suma(Arr , start - 1 , Arr.Length));
            min = Math.Min(currentTime , min);
            return;
        }

        for (int i = start + 1; i <= Arr.Length - c + 1; i++)
        {
            int sum = Suma(Arr, start, i);
            Solve(Arr, c - 1 , i+1 , Math.Max(sum, currentTime) , ref min); //Va picajdo
        }
    }

    public static int Suma(int[] arr, int start, int end)
    {
        int suma = 0;
        for (int i = start; i < end; i++)
        {
            suma += arr[i];
        }
        return suma;
    }
}