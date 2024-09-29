

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

    public static int CafeteriasACerrar(int[,] capacidad, int[,] real)
    {
        int maxClose=0;
        CloseCafeterias(capacidad,real,ref maxClose,0,FalseArray(new bool[capacidad.GetLength(1)]),FalseArray(new bool[capacidad.GetLength(1)]));
        return maxClose;
        
    }
    public static void CloseCafeterias(int[,] capacidad, int[,] real,ref int maxClose,int closes,bool[]TryClose,bool[]ClosedCafeterias)
    {
        if(AllVisitsCafeterias(TryClose))
        {
            if(closes>maxClose)
            {
                maxClose=closes;
            }
            return;
        }
        for(int c=0;c<TryClose.Length;c++)
        {
            if(!TryClose[c])
            {
                TryClose[c]=true;
                if(Close(capacidad,real,ClosedCafeterias,c))
                {
                    ClosedCafeterias[c]=true;
                    CloseCafeterias(capacidad,real,ref maxClose,closes+1,TryClose,ClosedCafeterias);
                    ClosedCafeterias[c]=false;
                }
                else
                {
                    CloseCafeterias(capacidad,real,ref maxClose,closes,TryClose,ClosedCafeterias);
                }
                TryClose[c]=false;
            }
        }
    }
    static bool[] FalseArray(bool[] array)
    {
        for(int i=0;i<array.Length;i++)
        {
            array[i]=false;
        }
        return array;
    }
    static bool Close(int[,] capacidad, int[,] real,bool[] ClosedCafeterias,int cafeteria)
    {
        for(int i=0;i<real.GetLength(0);i++)
        {
            int SumRow=0;
            for(int a=0;a<real.GetLength(1);a++)
            {
                if(a!=cafeteria)
                {
                    if(ClosedCafeterias[a])
                    {
                        SumRow-=real[i,a];
                    }
                    else
                    {
                        SumRow+=(capacidad[i,a]-real[i,a]);
                    }
                }
            }
            if(SumRow<real[i,cafeteria]) return false;
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