using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// namespace Weboo.Examen
// {
//     public static class ProblemaAntorchas
//     {
//         public static IEnumerable<int> AsignaAntorchas(bool[,] mapa)
//         {
//             int LowerLamps=int.MaxValue;
//             int[]Lamps=Array.Empty<int>();
//             DistributeLamp(new bool[mapa.GetLength(0)],ref LowerLamps,0,mapa,new Stack<int>(),ref Lamps);
//             Array.Sort(Lamps);
//             return Lamps;
//         }
//         static void DistributeLamp(bool[] regionsLighted, ref int LowerLamps, int Lamps,bool[,]map,Stack<int>RegionLamps,ref int[]BestRegionLamps)
//         {
//             if (AllRegionsLigthted(regionsLighted))
//             {
//                 if(Lamps<LowerLamps)
//                 {
//                     LowerLamps=Lamps;
//                     BestRegionLamps=RegionLamps.ToArray();
//                 }
//                 return;
//             }
//             if(Lamps>LowerLamps)
//             {
//                 return;
//             }
//             for(int i=0;i<regionsLighted.Length;i++)
//             {
//                 if(regionsLighted[i])
//                 {
//                     continue;
//                 }
//                 LigthRegion(regionsLighted,map,i);
//                 RegionLamps.Push(i);
//                 DistributeLamp(regionsLighted,ref LowerLamps,Lamps+1,map,RegionLamps,ref BestRegionLamps);
//                 RegionLamps.Pop();
//                 DarknessRegion(regionsLighted,map,i);
//             }
//         }
//     static void LigthRegion(bool[] regionsLighted,bool[,]map,int region)
//     {
//         regionsLighted[region]=true;
//         for(int i=0;i<regionsLighted.GetLength(0);i++)
//         {
//             if(map[i,region])
//             {
//                 regionsLighted[i]=true;
//             }
//         }
//         return;
//     }
//     static void DarknessRegion(bool[] regionsLighted,bool[,]map,int region)
//     {
//         regionsLighted[region]=false;
//         for(int i=0;i<regionsLighted.GetLength(0);i++)
//         {
//             if(map[i,region])
//             {
//                 regionsLighted[i]=false;
//             }
//         }
//         return;
//     }
//     static bool AllRegionsLigthted(bool[] regionsLighted)
//     {
//         foreach (bool IsLigthted in regionsLighted)
//         {
//             if (!IsLigthted)
//             {
//                 return false;
//             }
//         }
//         return true;
//     }
//     }
// }
