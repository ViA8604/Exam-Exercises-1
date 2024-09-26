

public class Program
{
    public static void Main()
    {
        int[,]capacity=new int[,]
        {
            {10,0,0,5,20},
            {10,10,0,5,20},
            {20,10,0,5,20},
            {20,10,30,10,20},
            {20,10,30,10,30},
            {20,10,30,5,20},
            {10,10,0,5,20},
            {10,0,0,5,20},
        }
        int[,]real=new int[,]
        {
            {5,0,0,1,20},
            {5,5,0,5,5},
            {5,5,0,4,8},
            {10,5,7,8,10},
            {10,5,8,10,10},
            {5,5,8,3,10},
            5,5,0,3,5},
            {5,0,0,1,2},
        }
        int result=CafeteriasACerrar(capacity,real);
        Console.WriteLine("Tu resultado: "+result);
        Console.WriteLine("Esperado 3");
    }

    public static int CafeteriasACerrar(int[,] capacidad, int[,] real)//aqui esto era entero lo tenias void
    {
        int[,] disponibilidad = GetDisponibilidad(capacidad, real);
        bool[] mascara = new bool[capacidad.GetLength(1)];

        int totalCaf = 0;

        CerrarCafeterias(0, capacidad, real, disponibilidad, mascara, ref totalCaf);
        return totalCaf;
    }

    private static void CerrarCafeterias(int columna, int[,] capacidad, int[,] real, int[,] disponibilidad, bool[] mascara, ref int totalCaf)
    {

    }

    private static bool IntentarCerrar(int cafeteria, int[,] real, int[,] disponibilidad)
    {
        for (int i = 0; i < real.GetLength(0); i++)
        {
            for (int j = 0; j < real.GetLength(1); j++)
            {
                if (j == cafeteria)
                {
                    continue;
                }
                else
                {

                }
            }
        }
        return true;
    }

    private static int[,] GetDisponibilidad(int[,] capacidad, int[,] real)
    {
        int[,] disponibilidad = new int[capacidad.GetLength(0), capacidad.GetLength(1)];

        for (int i = 0; i < capacidad.GetLength(0); i++)
        {
            for (int j = 0; j < capacidad.GetLength(1); j++)
            {
                disponibilidad[i, j] = capacidad[i, j] - real[i, j];
            }
        }
        return disponibilidad;
    }
}