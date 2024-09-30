// using System.Reflection.PortableExecutable;

// namespace Solution;

// public static class Solution
// {
//     public static int CostoDeEscape(INodo root)
//     {
//         int BestCost=int.MaxValue;
//         BestPath(root,root,ref BestCost,0,0);
//         return BestCost;
//     }
//     static void BestPath(INodo root,INodo ActualNode,ref int BestCost,int cost,int person)
//     {
//         if(cost>BestCost)
//         {
//             return;
//         }
//         if(ActualNode.Hijos(person)==null)
//         {
//             if(person==1)
//             {
//                 if(cost<BestCost)
//                 {
//                     BestCost=cost;
//                 }
//             }
//             else
//             {
//                 BestPath(root,root,ref BestCost,cost,person+1);
//             }
//             return;
//         }
//         (INodo,int,bool)[]Hijos=ActualNode.Hijos(person);
//         (INodo,int,int)[]HijosConectados=ActualNode.HijosConectados(person);
//         for(int i=0;i<Hijos.Length;i++)
//         {
//             if(Hijos[i].Item3)
//             {
//                 BestPath(root,Hijos[i].Item1,ref BestCost,cost+Hijos[i].Item2,person);
//             }
//             else
//             {
//                 for(int a=0;a<HijosConectados.Length;a++)
//                 {
//                     ActualNode.IntercambiarConexion(HijosConectados[a].Item2,i);
//                     BestPath(root,Hijos[i].Item1,ref BestCost,cost+2*Hijos[i].Item2,person);
//                     ActualNode.IntercambiarConexion(i,HijosConectados[a].Item2);
//                 }
//             }
//         }
//     }
// }