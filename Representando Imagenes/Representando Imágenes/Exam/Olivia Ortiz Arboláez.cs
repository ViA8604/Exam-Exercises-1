using System.Drawing;
using System.Net.Security;

namespace Exam;

public static class QuadTreeFactory
{
    public static IQuadtree Create(int size)
    {
        return new Quadtree(size);
    }
}


public class Quadtree : IQuadtree
{

    int size;
    int slot = 0;
    bool parent = true;
    QuadNodeColor[,] quadMatrix;
    QuadNodeColor color;
    Quadtree TL;
    Quadtree TR;
    Quadtree BL;
    Quadtree BR;

    List<Quadtree> Children;
    public Quadtree(int size, QuadNodeColor Color = QuadNodeColor.White)
    {
        this.size = size;
        quadMatrix = new QuadNodeColor[size, size];
        color = Color;
        Children = new List<Quadtree>();
    }

    private void AddChildren()
    {
        if (size / 2 != 0)
        {
            TL = new Quadtree(size / 2);
            TR = new Quadtree(size / 2);
            BL = new Quadtree(size / 2);
            BR = new Quadtree(size / 2);

            Children = new List<Quadtree>() { TL, TR, BL, BR };

            for (int i = 0; i < 5; i++)
            {
                Children[i].parent = false;
                this.parent = true;
            }


        }
        color = QuadNodeColor.Gray;
    }

    QuadNodeColor[,] QuadMatrix => quadMatrix;
    QuadNodeColor IQuadtree.Color => color;

    IQuadtree IQuadtree.TopLeft => TL;

    IQuadtree IQuadtree.TopRight => TR;

    IQuadtree IQuadtree.BottomLeft => BL;

    IQuadtree IQuadtree.BottomRight => BR;

    public static int Size { get; private set; }

    public void DrawPixel(int x, int y, bool isBlack)
    {
        QuadNodeColor colorToPaint = (isBlack) ? QuadNodeColor.Black : QuadNodeColor.White;
        quadMatrix[x, y] = colorToPaint;

        if (Children.Count == 0)
        {
            AddChildren();
        }

    }


    public int CountPixels()
    {
        int counter = 0;
        foreach (var pixel in quadMatrix)
        {
            if (pixel == QuadNodeColor.Black)
            {
                counter = counter + 1;
            }
        }
        return counter;
    }

    public void ImprimirMatrizArbol()
    {
        Dictionary<Quadtree, string> bosque = new Dictionary<Quadtree, string>() { { this, "Matriz del Arbol" } };
        if (Children.Count != 0)
        {
            bosque.Add(TL, "TL");
            bosque.Add(TR, "TR");
            bosque.Add(BL, "BL");
            bosque.Add(BR, "BR");
            //   { TL, "TL" }, { TR, "TR" }, { BL, "BL" }, { BR, "BR" } 
        }
        foreach (var arbol in bosque.Keys)
        {
            Console.WriteLine(bosque[arbol]);
            for (int i = 0; i < arbol.QuadMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < arbol.QuadMatrix.GetLength(1); j++)
                {
                    if (arbol.QuadMatrix[i, j] == QuadNodeColor.White)
                    {
                        Console.Write(string.Format("{0,2}", "◻"));
                    }
                    else if (arbol.QuadMatrix[i, j] == QuadNodeColor.Black)
                    {
                        Console.Write(string.Format("{0,2}", "◼"));
                    }
                    else
                    {
                        Console.Write(string.Format("{0,2}", "⊡"));
                    }
                }
                Console.WriteLine();
            }
        }
    }


    /* public int[,] SubMatriz(int filaInicial, int columnaInicial, int filas, int columnas)
     {
         List<int> ints = new List<int>();
         for(int i = 0; i < quadMatrix.GetLength(0); i ++)
         {
             ints.Add(i);
         }

         if (filaInicial < 0 || columnaInicial < 0 || filas < 0 || columnas < 0)
         {
             throw new ArgumentException("Los parámetros deben ser no negativos");
         }

         if (filaInicial + filas > quadMatrix.GetLength(0) || columnaInicial + columnas > quadMatrix.GetLength(1))
         {
             throw new ArgumentException("La submatriz no cabe dentro de la matriz original");
         }

         int[,] subMatriz = new int[filas, columnas];

         for (int i = 0; i < filas; i++)
         {
             for (int j = 0; j < columnas; j++)
             {
                 subMatriz[i, j] = quadMatrix[filaInicial + i, columnaInicial + j];
             }
         }

         return subMatriz;
     }
     */
}
