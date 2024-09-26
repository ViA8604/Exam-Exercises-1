

public class Program
{
    public static void Main()
    {

    }

    public static void CafeteriasACerrar(int[,] capacidad, int[,] real)
    {
        int[,] disponibilidad = GetDisponibilidad(capacidad, real);
        bool[] mascara = new bool[capacidad.GetLength(1)];

        int totalCaf = 0;

        CerrarCafeterias(0, capacidad, real, disponibilidad, mascara, ref totalCaf);
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