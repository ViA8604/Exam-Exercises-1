using System.Collections.Immutable;

namespace repasoFinal;

public class Antorchas
{
    public static IEnumerable<int> AsignaAntorchas(bool[,] mapa)
    {
        List<int> regionesConAntorchas = [];
        bool[] regionesEncendidas = new bool[mapa.GetLength(0)];

        for (int i = 0; i < mapa.GetLength(0); i++)
            regionesConAntorchas.Add(i);

        foreach (var region in AsignaAntorchas(mapa, regionesConAntorchas, [], regionesEncendidas))
            yield return region;
    }

    private static List<int> AsignaAntorchas(
        bool[,] mapa, List<int> regionesConAntorchas, List<int> acumuladas, 
        bool[] regionesEncendidas, int cantEncendidas = 0, int region = 0
    )
    {      
        if (acumuladas.Count >= regionesConAntorchas.Count || region >= mapa.GetLength(0))
            return [..regionesConAntorchas];

        if (cantEncendidas == mapa.GetLength(0))
            return [..acumuladas];

        acumuladas.Add(region);
        var temp = EncenderRegiones(mapa, region, regionesEncendidas, out int count);

        var taken = AsignaAntorchas(
            mapa, regionesConAntorchas, acumuladas, 
            temp, cantEncendidas + count, region + 1
        );

        acumuladas.Remove(region);

        var notTaken = AsignaAntorchas(
            mapa, regionesConAntorchas, acumuladas,
            regionesEncendidas, cantEncendidas, region + 1
        );

        regionesConAntorchas = (taken.Count < notTaken.Count) ? taken : notTaken;

        return regionesConAntorchas;
    }

    private static bool[] EncenderRegiones(bool[,] mapa, int columna, bool[] regionesEncendidas, out int count)
    {
        count = 0;
        bool[] result = new bool[regionesEncendidas.Length];

        if (!regionesEncendidas[columna]) 
        {
            count++;
            result[columna] = true;
        }

        for (int i = 0; i < mapa.GetLength(1); i++)
        {
            if (mapa[i, columna] || regionesEncendidas[i])
            {
                result[i] = true;
                if (!regionesEncendidas[i])
                    count++;
            }
        }

        return result;
    }
}