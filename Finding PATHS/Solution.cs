using System.Reflection.PortableExecutable;

namespace Solution;

/*public static class Solution
{
    public static int CostoDeEscape(INodo root)
    {
        int best = int.MaxValue;
        int actualCost = 0;
        var rootNode = root;

        void MinCost(INodo root, int character)
        {
            if (actualCost > best)
                return;

            var children = root.Hijos(character);
            var connectedChildren = root.HijosConectados(character);

            // leaf node
            if (children is null)
            {
                // Javi reached a leaf node and is time for Frank now
                if (character is 0) { MinCost(rootNode, 1); }

                // Frank reached a leaf node so is time to compare journey results
                else { best = Math.Min(best, actualCost); }

                return;
            }


            for (int i = 0; i < children.Length; i++)
            {
                if (children[i].Item3)
                {
                    // explore all the connected islands
                    actualCost += children[i].Item2;
                    MinCost(children[i].Item1, character);
                    // backtrack
                    actualCost -= children[i].Item2;
                }

                // if this island is not connected to the actual one we can move a bridge so we can cross
                // (in case that bridge exists)

                else
                {
                    // explore all the connected islands
                    for (int j = 0; j < children.Length; j++)
                    {
                        if (children[j].Item3)
                        {
                            // change bridge with disconnected island
                            root.IntercambiarConexion(j, i);
                            actualCost += 2 * children[i].Item2;
                            MinCost(children[i].Item1, character);

                            // backtrack
                            actualCost -= 2 * children[i].Item2;
                            root.IntercambiarConexion(i, j);
                        }
                    }
                }
            }
        }
        MinCost(root, 0);

        return best;
    }
}*/