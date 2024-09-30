
namespace Solution;

public static class Solution
{
    public static int CostoDeEscape(INodo root)
    {
        int min = int.MaxValue;
        GetBestPath(root, root, 0, 0, ref min);

        return min;
    }

    private static void GetBestPath(INodo root, INodo actualNode, int character, int cost, ref int min)
    {
        //Caso Base
        if (actualNode.Hijos(character) == null)  //LLegaste a una hoja, vira patr'as
        {
            if (character == 1)
            {
                min = Math.Min(cost, min);
                return;
            }
            else
            {
                GetBestPath(root, root, character + 1, cost, ref min);
            }
        }

        (INodo, int, bool)[]? Children = actualNode.Hijos(character);
        (INodo, int, int)[]? ConnectedChildren = actualNode.HijosConectados(character);

        //Recursivo, vamos a movernos por el arbol
        if (Children != null)
        {
            for (int i = 0; i < Children.Length; i++)
            {
                if (Children[i].Item3)   //Si el hijo está conectado al nodo actual
                {
                    GetBestPath(root, Children[i].Item1, character, cost + Children[i].Item2, ref min);
                }
                else
                {
                    //Si no lo está lo conecta y llama a la recursividad
                    if (ConnectedChildren != null)
                    {
                        for (int j = 0; j < ConnectedChildren.Length; j++)
                        {
                            actualNode.IntercambiarConexion(j, i);
                            GetBestPath(root, Children[i].Item1, character, cost + 2 * Children[i].Item2, ref min);
                            actualNode.IntercambiarConexion(i, j);
                        }
                    }
                }
            }
        }

    }
}
