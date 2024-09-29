
public class Program
{
    public static void Main()
    {
        bool[,] test1 = new bool[8, 8];
        foreach (var coo in new List<(int, int)> { (1, 2), (1, 4), (3, 2), (4, 0), (4, 5), (4, 7), (6, 2), (7, 4) })
        {
            test1[coo.Item1, coo.Item2] = true;
        }

        bool[,] test2 = new bool[8, 8];         //EL PARTIDOR
        foreach (var coo in new List<(int, int)> { (5, 0), (5, 1), (5, 2), (5, 3), (5, 4), (5, 5),  (5, 6), (5, 7) })
        {
            test2[coo.Item1, coo.Item2] = true;
        }

        bool[,] test3 = new bool[8, 8];
        foreach (var coo in new List<(int, int)> { (3, 0), (3, 1), (3, 2), (3, 3), (3, 4), (3, 5), (4, 7), (6, 7) })
        {
            test3[coo.Item1, coo.Item2] = true;
        }


        ImprimirMatrizBool(test3);
        Console.WriteLine(LongitudMinimaSegura(test3));
        Console.WriteLine(LongitudMinimaSegura(test1));
        Console.WriteLine(LongitudMinimaSegura(test2));
    }

    public static int LongitudMinimaSegura(bool[,] tablero)
    {
        int min = int.MaxValue;
        bool[,] posBloqueada = GetValidArray(tablero);
        bool[,] mascara = new bool[tablero.GetLength(0), tablero.GetLength(1)];
        if(!HaySalida(posBloqueada))
        {
            return 0;
        }
        Solve(tablero, posBloqueada, mascara, 7, 0, 1, ref min);
        return min;
    }

    private static void Solve(bool[,] tablero, bool[,] posBloqueada, bool[,] mascara, int fila, int columna, int movimientos, ref int minimo)
    {
        if (movimientos >= minimo)           //Poda
        {
            return;
        }
        if (fila == 0 && columna == tablero.GetLength(1) - 1)       // Caso base
        {
            minimo = Math.Min(movimientos, minimo);
            return;
        }
        else
        {
            bool peonExistente = false;
            foreach (var coo in new List<(int, int)> { (0, 1), (0, -1), (-1, 0), (-1, -1), (-1, 1), (1, 0), (1, 1), (1, -1) })
            {
                int nextFila = coo.Item1 + fila;
                int nextColumna = coo.Item2 + columna;
                if (MoveValidation(posBloqueada, mascara, nextFila, nextColumna))
                {
                    if (tablero[nextFila, nextColumna])
                    {
                        EliminarPeon(tablero, posBloqueada, nextFila, nextColumna);    //Este actualiza posBloqueada
                        peonExistente = true;
                    }

                    mascara[nextFila, nextColumna] = true;

                    Solve(tablero, posBloqueada, mascara, nextFila, nextColumna, movimientos + 1, ref minimo);

                    if (peonExistente)
                    {
                        PonerPeon(tablero, posBloqueada, nextFila, nextColumna);
                        peonExistente = false;
                    }
                    mascara[nextFila, nextColumna] = false;
                }
            }

        }
    }
    static bool HaySalida(bool[,] posiciones_bloqueadas)
    {
        for (int i = 1; i < posiciones_bloqueadas.GetLength(0)-1; i++)
        {
            for (int j = 0; j < posiciones_bloqueadas.GetLength(1); j++)
            {
               if(!posiciones_bloqueadas[i,j])
               {
                    break;
               }
               if(j==posiciones_bloqueadas.GetLength(1)-1)
               {
                    return false;
               }
            }
        }
        for (int j = 1; j < posiciones_bloqueadas.GetLength(1)-1; j++)
        {
            for (int i = 0; i < posiciones_bloqueadas.GetLength(0); i++)
            {
               if(!posiciones_bloqueadas[i,j])
               {
                    break;
               }
               if(j==posiciones_bloqueadas.GetLength(1)-1)
               {
                    return false;
               }
            }
        }
        return true;
    }

    private static void PonerPeon(bool[,] tablero, bool[,] posBloqueada, int fila, int columna)
    {
        tablero[fila, columna] = true;
        foreach (var coo in new List<(int, int)> { (1, 1), (-1, 1), (-1, -1), (1, -1) })
        {
            int nextFila = fila + coo.Item1;
            int nextColumna = columna + coo.Item2;
            if (nextFila < posBloqueada.GetLength(0) && nextColumna < posBloqueada.GetLength(1) && nextFila >= 0 && nextColumna >= 0)
            {
                posBloqueada[nextFila, nextColumna] = true;
            }
        }
    }

    private static void EliminarPeon(bool[,] tablero, bool[,] posBloqueada, int fila, int columna)
    {
        tablero[fila, columna] = false;
        foreach (var coo in new List<(int, int)> { (1, 1), (-1, 1), (-1, -1), (1, -1) })
        {
            int nextFila = fila + coo.Item1;
            int nextColumna = columna + coo.Item2;
            if (nextFila < posBloqueada.GetLength(0) && nextColumna < posBloqueada.GetLength(1) && nextFila >= 0 && nextColumna >= 0)
            {
                posBloqueada[nextFila, nextColumna] = false;
            }
        }
    }

    private static bool MoveValidation(bool[,] posBloqueada, bool[,] mascara, int fila, int columna)
    {
        if (fila < posBloqueada.GetLength(0) && columna < posBloqueada.GetLength(1) && fila >= 0 && columna >= 0)
        {
            if (!posBloqueada[fila, columna] && !mascara[fila, columna])
            {
                return true;
            }
            return false;
        }
        return false;
    }

    private static bool[,] GetValidArray(bool[,] tablero)
    {
        bool[,] bloqueados = new bool[tablero.GetLength(0), tablero.GetLength(1)];
        for (int i = 0; i < tablero.GetLength(0); i++)
        {
            for (int j = 0; j < tablero.GetLength(1); j++)
            {
                if (tablero[i, j])
                {
                    foreach (var coo in new List<(int, int)> { (1, 1), (-1, 1), (-1, -1), (1, -1) })
                    {
                        int nextFila = i + coo.Item1;
                        int nextColumna = j + coo.Item2;
                        if (nextFila < bloqueados.GetLength(0) && nextColumna < bloqueados.GetLength(1) && nextFila >= 0 && nextColumna >= 0)
                        {
                            bloqueados[nextFila, nextColumna] = true;
                        }
                    }
                }
            }
        }
        return bloqueados;
    }

    private static void ImprimirMatrizBool(bool[,] matriz)
    {
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                if (matriz[i, j])
                {
                    Console.Write(string.Format("{0,2}", "♙"));
                }
                else
                {
                    Console.Write(string.Format("{0,2}", "-"));
                }
            }
            Console.WriteLine();
        }
    }
}