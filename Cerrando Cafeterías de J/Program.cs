

using System.Reflection.Metadata;

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
        };
        int[,]real=new int[,]
        {
            {5,0,0,1,0},
            {5,5,0,5,5},
            {5,5,0,4,8},
            {10,5,7,8,10},
            {10,5,8,10,10},
            {5,5,8,3,10},
            {5,5,0,3,5},
            {5,0,0,1,2},
        };
        int result=CafeteriasACerrar(capacity,real);
        Console.WriteLine("Tu resultado: "+result);
        Console.WriteLine("Esperado 3");

    }

    public static void CafeteriasACerrar(int[,] capacidad, int[,] real)
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