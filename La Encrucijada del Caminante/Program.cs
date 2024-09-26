public class Program
{
    //How many combinations?
    static void Main()
    {
        int [] cajas = new int[] {5,7,3,5};
        int H = 2;
        Console.WriteLine("> " + Solve(cajas, H).ToString());
    }

    public static int Solve(int[] cajas, int H)
    {
        int total = 0;
        List<int> river = new List<int>();
        Solve(cajas, H, river, 0, ref total);
        return total;
    }

    public static void Solve(int[] cajas, int H, List<int> river, int start, ref int total)
    {
        System.Console.Write("(");
        foreach (var item in river)
        {
            System.Console.Write(item.ToString() + ", ");
        }
        System.Console.WriteLine(")");

        if(start == cajas.Length) return; //No hay cajas por poner, caso base.
        // Ponerla
        if (river.Count() == 0 || Math.Abs(cajas[start] - river[river.Count() - 1]) <= H)  //Para comprobar que  la distancia entre las cajas sea v'alida
        {
            river.Add(cajas[start]);
            if (river.Count() >= 2)
            {
                total += 1;     //Hay una combinaci'on
            }
            Solve(cajas, H, river, start + 1, ref total);   //Seguimos
            river.RemoveAt(river.Count() - 1);
        }
        // No ponerla
        Solve(cajas, H, river, start + 1, ref total);
        
    }
}