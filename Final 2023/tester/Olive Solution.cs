public static class Solution
{
    public static int GetRoutes(Map map, int n)
    {
        int LowerDistance = int.MaxValue;
        bool[] visitedLions = new bool[map.N - 1];

        GetBestRoute(map, visitedLions, 0, 0, n, 0, 0, ref LowerDistance);

        return LowerDistance;
    }

    private static void GetBestRoute(Map map, bool[] visitedLions, int actualPlace, int actualWorker, int n, int time, int distance, ref int LowerDistance)
    {
        if (distance >= LowerDistance)        //Poda
        {
            return;
        }


        //Caso Base, si ya definimos las rutas de todos los trabajadores
        if (actualWorker == n)
        {
            //Si visitamos a todos los leones la ruta es v'alida
            if (visitedLions.Cast<bool>().All(x => x == true))
            {
                LowerDistance = Math.Min(LowerDistance, distance);
            }
            return;
        }

        //Caso Recursivo, alimentando leones
        for (int i = 1; i < map.N; i++)
        {
            if (map.IsOnTime(i, time + map[actualPlace, i]) && !visitedLions[i - 1])
            {
                visitedLions[i - 1] = true;
                GetBestRoute(map, visitedLions, i, actualWorker, n, time + map[actualPlace, i], distance + map[actualPlace, i], ref LowerDistance);
                visitedLions[i - 1] = false;
            }
        }

        //Regresando al refugio
        GetBestRoute(map, visitedLions, 0, actualWorker + 1, n, 0, distance + map[actualPlace, 0], ref LowerDistance);

    }
}