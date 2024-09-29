

using System.Reflection.Metadata;

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
                TryClose[c]=false;
            }
        }
        return true;
    }
    static bool AllVisitsCafeterias(bool[]VisitCafeterias)
    {
        foreach(bool visited in VisitCafeterias)
        {
            if(!visited)
            {
                return false;
            }
        }
        return true;
    }
}