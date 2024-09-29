//     static int GetRoutes(Map map, int n)
//     {
//         int LowerDistance=int.MaxValue;
//         GetPath(ref LowerDistance,0,n,map);
//         return LowerDistance;
//     }
//     static void GetPath(ref int LowerDistance, int distance, int boats, Map map)
//     {
//         for (int i = 1; i < map.N; i++)//vemos cual es la maxima cantidad de islas que queremos visitar por cada barco
//         {
//             if(i*boats<map.N)//si hay mas islas que la maxima catidad de islas que visita cada barco no probar
//             {
//                 continue;
//             }
//             bool[]visitedLands=new bool[map.N-1];
//             SeachPath(visitedLands, ref LowerDistance, 0, 0,0, map,i,0,false);
//         }
//     }
//     static void SeachPath(bool[] visitedLands, ref int LowerDistance, int actualLand, int distance,int boatDistance, Map map,int amount,int visits,bool VisitedLandsB)
//     {
//         if (AllLandsVisited(visitedLands))//caso base si todas las islas fueron visitadas
//         {
//             distance += map[actualLand, 0];//regresar al puerto
//             if (distance < LowerDistance)
//             {
//                 LowerDistance = distance;
//             }
//             return;
//         }
//         if(visits==amount)//si se visitaron la maxima cantidad de islas permitidas
//         {
//             SeachPath(visitedLands, ref LowerDistance, 0, distance + map[actualLand, 0],0, map,amount,0,false);//ir al puerto
//             return;
//         }
//         for (int i = 1; i < map.N ; i++)
//         {
//             if (!visitedLands[i-1])//si no he visitado la isla
//             {
//                 if(map.IsTypeB(i))//si es una isla de B la visito
//                 {
//                     visitedLands[i-1] = true;
//                     SeachPath(visitedLands, ref LowerDistance, i, distance + map[actualLand, i],boatDistance+ map[actualLand, i], map,amount,visits+1,true);
//                     visitedLands[i-1] = false;
//                 }
//                 else if(map.IsTypeA(i) && !VisitedLandsB)//si es una isla de a y no he visitado ninguna de b
//                 {
//                     visitedLands[i-1] = true;
//                     SeachPath(visitedLands, ref LowerDistance, i, distance + map[actualLand, i],boatDistance+ map[actualLand, i], map,amount,visits+1,false);
//                     visitedLands[i-1] = false;
//                 }
//                 else//si es una de A y ya he visitado alguna de B la ruta no es valida
//                 {
//                    return;
//                 }
//             }
//         }
//     }
//     static bool AllLandsVisited(bool[] visitedLands)
//     {
//         foreach (bool IsVisited in visitedLands)
//         {
//             if (!IsVisited)
//             {
//                 return false;
//             }
//         }
//         return true;
//     }

// int[,] matrix = new int[,]{{0, 1, 1, 3},
//                            {1, 0, 3, 1},
//                            {1, 3, 0, 1},
//                            {3, 1, 1, 0}};

// int[] A = new int[]{1, 2};
// int[] B = new int[]{3};
// Map map = new Map(matrix, A, B);
// //Esto debe tener costo 7
// Console.WriteLine(GetRoutes(map, 2));