
int GetRoutes(Map map, int n)
{
    int min = int.MaxValue;
    bool[] visitedIslands = new bool[map.N];

    Navigate(map, visitedIslands, 0, 0, n, 0, ref min);

    return min;
}

void Navigate(Map map, bool[] visitedIslands, int actualIsland, int actualShip, int Ships, int cost, ref int min)
{
    if (cost > min) return;  //Poda, si la ruta tiene un costo mayor que la mejor ruta hasta ahora, no la continuamos

    if (actualShip == Ships)       //Caso base ya trazamos las rutas de todos los barcos
    {
        if (visitedIslands.Cast<bool>().All(x => x == true))
        {
            //Si todas las islas estan visitadas, la ruta cuenta
            min = Math.Min(min, cost);
        }
        return;
    }

    for (int i = 0; i < map.N; i++)                         //Visitemos las islas
    {
        if (!visitedIslands[i])
        {
            if (map.IsTypeA(i) && map.IsTypeB(actualIsland))  //Si pasa esto ignoramos el viaje
            {
                continue;
            }
            visitedIslands[i] = true;
            Navigate(map, visitedIslands, i, actualShip, Ships, cost + map[actualIsland, i], ref min);
            visitedIslands[i] = false;
        }
    }

    //No visitamos nada más así que regresamos a puerto y mandamos otro barco
    Navigate(map, visitedIslands, 0, actualShip + 1, Ships, cost + map[actualIsland, 0], ref min);
}



int[,] matrix = new int[,]{{0, 1, 1, 3},
                           {1, 0, 3, 1},
                           {1, 3, 0, 1},
                           {3, 1, 1, 0}};

int[] A = new int[] { 1, 2 };
int[] B = new int[] { 3 };
Map map = new Map(matrix, A, B);
//Esto debe tener costo 7
Console.WriteLine(GetRoutes(map, 2));