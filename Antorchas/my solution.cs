using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weboo.Examen
{
    public static class ProblemaAntorchas
    {
        public static IEnumerable<int> AsignaAntorchas(bool[,] mapa)
        {
            int LowerLamps=int.MaxValue;
            int[]Lamps=Array.Empty<int>();//creamos un array para guardar las regiones donde pusimos la menor cantidad de antorchas
            DistributeLamp(new bool[mapa.GetLength(0)],ref LowerLamps,0,mapa,new Stack<int>(),ref Lamps);
            Array.Sort(Lamps);
            return Lamps;
        }
        static void DistributeLamp(bool[] regionsLighted, ref int LowerLamps, int Lamps,bool[,]map,Stack<int>RegionLamps,ref int[]ActivateLamps)
        {
            if (AllRegionsLigthted(regionsLighted))//caso base
            {
                if(Lamps<LowerLamps)
                {
                    LowerLamps=Lamps;
                    ActivateLamps=RegionLamps.ToArray();
                }
                return;
            }
            if(Lamps>LowerLamps)//poda
            {
                return;
            }
            for(int i=0;i<regionsLighted.Length;i++)
            {
                if(regionsLighted[i])//si esta iluminada la zona vemos si podemos iluminar otra
                {
                    continue;
                }
                LigthRegion(regionsLighted,map,i);//llamamos a la funcion para iluminarla y las otras zonas que se iluminan con ella
                ActivateLamps.Push(i);//agregamos la antorcha a las antorchas prendidas
                DistributeLamp(regionsLighted,ref LowerLamps,Lamps+1,map,RegionLamps,ref ActivateLamps);
                ActivateLamps.Pop();//sacamos la antorcha del recorrido
                DarknessRegion(regionsLighted,map,i);//apagamos las regiones que se iluminaban con esa antorcha
            }
        }
    static void LigthRegion(bool[] regionsLighted,bool[,]map,int region)
    {
        regionsLighted[region]=true;//iluminamos la region
        for(int i=0;i<regionsLighted.GetLength(0);i++)//iteramos para ver que otras regiones se iluminan
        {
            if(map[i,region])
            {
                regionsLighted[i]=true;
            }
        }
        return;
    }
    static void DarknessRegion(bool[] regionsLighted,bool[,]map,int region)
    {
        regionsLighted[region]=false;
        for(int i=0;i<regionsLighted.GetLength(0);i++)
        {
            if(map[i,region])
            {
                regionsLighted[i]=false;
            }
        }
        return;
    }
    static bool AllRegionsLigthted(bool[] regionsLighted)
    {
        foreach (bool IsLigthted in regionsLighted)
        {
            if (!IsLigthted)
            {
                return false;
            }
        }
        return true;
    }
    }
}
