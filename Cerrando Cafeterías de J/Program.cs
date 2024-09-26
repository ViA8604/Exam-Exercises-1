

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
        List<int>AvariablesCafeterias=new List<int>();
        for(int i=0;i<ClosedCafeterias.Length;i++)
        {
            if(i!=cafeteria && !ClosedCafeterias[i])
            {
                if(CanClose(i))
                {
                    AvariablesCafeterias.Add(i);
                }
            }
        }
        return AvariablesCafeterias.ToArray();
        bool CanClose(int i)
        {
            for(int r=0;r<capacidad.GetLength(0);r++)
            {
                    if(capacidad[i,r]+capacidad[cafeteria,r]>real[i,r])
                    {
                       return false;//hay q ver si pincha
                    }
            }
            return true;
        }
    }
    static void DesMerge(int[,] capacidad,int CloseCafeteria,int OpenCafeteria)
    {
        for(int i=0;i<capacidad.GetLength(0);i++)
        {
            capacidad[i,OpenCafeteria]-=capacidad[i,CloseCafeteria];
        }
    }
    static void MergeColumns(int[,] capacidad,int CloseCafeteria,int OpenCafeteria)
    {
        for(int i=0;i<capacidad.GetLength(0);i++)
        {
            capacidad[i,OpenCafeteria]+=capacidad[i,CloseCafeteria];
        }
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