using System;
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
            bool[] iluminatedRegions = new bool[mapa.GetLength(0)];

            foreach (var region in AsignaAntorchas(mapa, new List<int>(), iluminatedRegions))
            {
                yield return region;
            }
        }

        private static IEnumerable<int> AsignaAntorchas(bool[,] mapa, List<int> torchedRegions, List<int> regionsEncendidas, bool[] iluminatedRegions)
        {
            throw new NotImplementedException();
        }



    }
}
