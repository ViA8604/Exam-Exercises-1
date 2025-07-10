
namespace Molecules
{
    public static class Exam
    {
        public static bool EstaInfectado(
            string[] muestraAtomos, bool[,] muestraEnlances,
            string[] sentinelaAtomos, bool[,] sentinelaEnlaces)
        {
            string[] toFoundMolecule = new string[sentinelaAtomos.Length];
            bool solution = false;

            if (sentinelaAtomos.Length == 0)
            {
                return true;
            }
            if (muestraAtomos.Length == 0 || sentinelaEnlaces.GetLength(0) == 0 || sentinelaEnlaces.GetLength(1) == 0)
            {
                return false;
            }

            InfectedBacktrack(muestraAtomos, muestraEnlances, new int[muestraAtomos.Length], sentinelaAtomos, sentinelaEnlaces, toFoundMolecule, ref solution, new bool[toFoundMolecule.Length]);
            return solution;
        }

        private static void InfectedBacktrack(string[] muestraAtomos, bool[,] muestraEnlances,
            int[] atomsPosition, string[] sentinel, bool[,] sentinelLinks,
            string[] toProccessMolecule, ref bool solution, bool[] alreadyWritten)
        {
            if (Coincidence(muestraEnlances, atomsPosition, sentinelLinks)) //si coinciden el sentinela con una una de las submoleculas que revisamos se devuelve true
            {
                solution = true;
                return;
            }

            for (int i = 0; i < sentinel.Length; i++)
            {
                if (alreadyWritten[i] == true)
                {
                    continue;
                }
                for (int atom = 0; atom < muestraAtomos.Length; atom++)
                    {
                        if (muestraAtomos[atom] == sentinel[i])
                        {
                            toProccessMolecule[i] = sentinel[i];
                            atomsPosition[i] = atom;
                            alreadyWritten[i] = true;
                            InfectedBacktrack(muestraAtomos, muestraEnlances, atomsPosition, sentinel, sentinelLinks, toProccessMolecule, ref solution, alreadyWritten);
                            alreadyWritten[i] = false;
                        }
                    }
            }
        }

        public static bool Coincidence(bool[,] muestraEnlances, int[] atomsPosition, bool[,] sentinelLinks)
        {
            //armo la matriz de enlaces de la molecula que estamos analizando
            bool[,] proccessedLinks = new bool[atomsPosition.Length, atomsPosition.Length];
            for (int i = 0; i < atomsPosition.Length; i++)
            {
                for (int j = 0; j < atomsPosition.Length; j++)
                {
                    proccessedLinks[i, j] = muestraEnlances[atomsPosition[i], atomsPosition[j]];
                }
            }
            
            //Reviso si el sentinela es igual a la molecula que estamos analizando
            for (int i = 0; i < sentinelLinks.GetLength(0); i++)
            {
                for (int j = 0; j < sentinelLinks.GetLength(1); j++)
                {
                    if (sentinelLinks[i, j] != proccessedLinks[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}