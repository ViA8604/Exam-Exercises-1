namespace Weboo.Examen;

public static class Solution
{
    public static int Solve(int[,] map, int capacity, int origin)
    {
        int minCombustible = int.MaxValue;
        bool[] visitedCities = new bool[map.GetLength(0)];
        visitedCities[origin] = true; //maarca la ciudad de origen como visitada

        AgenciaNoel(map, visitedCities, capacity, origin, origin, capacity, 0, ref minCombustible);
        if(minCombustible == int.MaxValue)  //si no se pudo llegar a todas las ciudades
        {
            return -1;
        }
        return minCombustible;
    }

    public static void AgenciaNoel(int[,] map, bool[] visitedCities, int capacity, int origin, int actualCity, int combustibleActual, int cantCombustibleUsado, ref int MinTotal)
    {
        if (cantCombustibleUsado >= MinTotal)   //poda
        {
            return;
        }
        if(actualCity == origin) //rellenar el tanke
        {
            combustibleActual = capacity;
        }

        //Caso Base
        if (AllVisited(origin, visitedCities) && actualCity == origin) //si ya se visitaron todas las ciudades
        {
            MinTotal = Math.Min(cantCombustibleUsado, MinTotal);
            return;
        }

        //Caso Recursivo
        for (int i = 0; i < visitedCities.Length; i++)
        {
            if (!visitedCities[i] && map[actualCity, i] <= combustibleActual)
            {
                //visitar la ciudad i
                visitedCities[i] = true;
                AgenciaNoel(map, visitedCities, capacity, origin, i, combustibleActual - map[actualCity, i], cantCombustibleUsado + map[actualCity, i], ref MinTotal);
                visitedCities[i] = false;
            }
        }

        if (actualCity != origin && map[actualCity, origin] <= combustibleActual)
        {
            //volver a la ciudad de origen
            AgenciaNoel(map, visitedCities, capacity, origin, origin, capacity, cantCombustibleUsado + map[actualCity, origin], ref MinTotal);
        }
    }

    static bool AllVisited (int origin, bool [] visitedCities)
    {
        for(int i = 0; i < visitedCities.Length; i++)
        {
            if(i != origin && !visitedCities[i])
            {
                return false;
            }
        }
        return true;
    }
}