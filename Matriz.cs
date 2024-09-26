public class Matriz
{
    private int[,] datos;

    public Matriz(int filas, int columnas)
    {
        datos = new int[filas, columnas];
    }

    public Matriz(int[,] valores)
    {
        datos = valores;
    }

    public int this[int fila, int columna]
    {
        get { return datos[fila, columna]; }
        set { datos[fila, columna] = value; }
    }

    public void Imprimir()
    {
        for (int f = 0; f < datos.GetLength(0); f++)
        {
            for (int c = 0; c < datos.GetLength(1); c++)
            {
                Console.Write(datos[f, c] + " | ");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', datos.GetLength(1) * 4 + 1));
        }
    }

    public Matriz SubMatriz(int filaInicial, int columnaInicial, int filas, int columnas)
    {
        if (filaInicial < 0 || columnaInicial < 0 || filas < 0 || columnas < 0)
        {
            throw new ArgumentException("Los parámetros deben ser no negativos");
        }

        if (filaInicial + filas > datos.GetLength(0) || columnaInicial + columnas > datos.GetLength(1))
        {
            throw new ArgumentException("La submatriz no cabe dentro de la matriz original");
        }

        int[,] subMatriz = new int[filas, columnas];

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                subMatriz[i, j] = datos[filaInicial + i, columnaInicial + j];
            }
        }

        return new Matriz(subMatriz);
    }

    public bool Iguales(Matriz otraMatriz)
    {
        if (datos.GetLength(0) != otraMatriz.datos.GetLength(0) || datos.GetLength(1) != otraMatriz.datos.GetLength(1))
        {
            return false;
        }

        for (int i = 0; i < datos.GetLength(0); i++)
        {
            for (int j = 0; j < datos.GetLength(1); j++)
            {
                if (datos[i, j] != otraMatriz.datos[i, j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    public Matriz InvierteHorizontal()
    {
        int[,] nuevaMatriz = new int[datos.GetLength(0), datos.GetLength(1)];

        for (int i = 0; i < datos.GetLength(0); i++)
        {
            for (int j = 0; j < datos.GetLength(1); j++)
            {
                nuevaMatriz[i, datos.GetLength(1) - 1 - j] = datos[i, j];
            }
        }

        return new Matriz(nuevaMatriz);
    }

    public Matriz InvierteVertical()
    {
        int[,] nuevaMatriz = new int[datos.GetLength(0), datos.GetLength(1)];

        for (int i = 0; i < datos.GetLength(0); i++)
        {
            for (int j = 0; j < datos.GetLength(1); j++)
            {
                nuevaMatriz[datos.GetLength(0) - 1 - i, j] = datos[i, j];
            }
        }

        return new Matriz(nuevaMatriz);
    }
}