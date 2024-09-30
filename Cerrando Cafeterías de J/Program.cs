

using System.Reflection.Metadata;

 public class Program
{
     public static void Main()
    {
        int[,]capacity1=new int[,]
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
        int[,]real1=new int[,]
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
        int result1=CafeteriasACerrar(capacity1,real1);
        Console.WriteLine("Tu resultado: "+result1);
        Console.WriteLine("Esperado 3");
        int[,]capacity2=new int[,]
        {
            {10,0,20},
            {10,10,20},
            {20,15,20},
            {20,15,20},
            {20,15,30},
            {20,10,20},
            {10,10,20},
            {10,0,20},
        };
        int[,]real2=new int[,]
        {
            {5,0,0},
            {5,5,5},
            {5,5,8},
            {10,15,18},
            {10,5,10},
            {5,5,10},
            {5,5,5},
            {5,0,2},
        };
        int result2=CafeteriasACerrar(capacity2,real2);
        Console.WriteLine("Tu resultado: "+result2);
        Console.WriteLine("Esperado 0");
        int[,]capacity3=new int[,]
        {
            {10,0},
            {10,10},
            {20,15},
            {20,15},
            {20,15},
            {20,10},
            {10,10},
            {10,0},
        };
        int[,]real3=new int[,]
        {
            {5,0},
            {5,5},
            {5,12},
            {10,10},
            {10,5},
            {5,5},
            {5,5},
            {5,0},
        };
        int result3=CafeteriasACerrar(capacity3,real3);
        Console.WriteLine("Tu resultado: "+result3);
        Console.WriteLine("Esperado 1");
         int[,]capacity4=new int[,]
        {
            {10,0,20},
            {10,10,20},
            {20,15,20},
            {20,15,20},
            {20,15,30},
            {20,10,20},
            {10,10,20},
            {10,0,20},
        };
        int[,]real4=new int[,]
        {
            {0,0,0},
            {0,0,0},
            {0,0,0},
            {0,0,0},
            {0,0,0},
            {0,0,0},
            {0,0,0},
            {0,0,0},
        };
        int result4=CafeteriasACerrar(capacity4,real4);
        Console.WriteLine("Tu resultado: "+result4);
        Console.WriteLine("Esperado 3");
        int[,]capacity5=new int[,]
        {
            {10,8},
            {10,10},
            {20,15},
            {20,15},
            {20,15},
            {20,10},
            {10,10},
            {10,8},
        };
        int[,]real5=new int[,]
        {
            {5,2},
            {5,5},
            {5,7},
            {5,8},
            {9,5},
            {5,5},
            {5,5},
            {5,3},
        };
        int result5=CafeteriasACerrar(capacity5,real5);
        Console.WriteLine("Tu resultado: "+result5);
        Console.WriteLine("Esperado 1");
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