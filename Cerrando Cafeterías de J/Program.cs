

using System.Reflection.Metadata;

 public class Program
{
    public static void Main()
    {

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
                int[]AvariablesCaferias=Close(capacidad,real,ClosedCafeterias,c);
                if(AvariablesCaferias.Length!=0)
                {
                    ClosedCafeterias[c]=true;
                    closes++;
                    for(int i=0;i<AvariablesCaferias.Length;i++)
                    {
                        MergeColumns(capacidad,c,AvariablesCaferias[i]);
                        CloseCafeterias(capacidad,real,ref maxClose,closes,TryClose,ClosedCafeterias);
                        DesMerge(capacidad,c,AvariablesCaferias[i]);
                    }
                    closes--;
                    ClosedCafeterias[c]=false;
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
    static int[] Close(int[,] capacidad, int[,] real,bool[] ClosedCafeterias,int cafeteria)
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