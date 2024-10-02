namespace Weboo.Examen
{
    public static class ProblemaAntorchas
    {
        public static IEnumerable<int> AsignaAntorchas(bool[,] mapa)
        {
            bool[] iluminatedRegions = new bool[mapa.GetLength(0)];
            List<int> minTorches = new List<int>();


            for (int i = 0; i < mapa.GetLength(0); i++) //Aquí llenamos la lista(aumentar el length), porque si no la poda no funciona
            {
                minTorches.Add(i);
            }

            IluminarZonas(mapa, 0, iluminatedRegions, new List<int>(), ref minTorches);

            return minTorches;
        }

        private static void IluminarZonas(bool[,] mapa, int regionActual, bool[] regionesIluminadas, List<int> regionesConAntorchas, ref List<int> minimaDistribucion)
        {
            /*
            Importante, si sobreescribes una lista por completo, aunque se pasa por referencia,
            aquí cambiarías la lista local del método, por eso hay que ponerle ref al parámetro.
            */

            if (regionesConAntorchas.Count >= minimaDistribucion.Count) return; //Poda

            if (regionActual >= mapa.GetLength(0))   //Caso Base 1: ya no hay regiones por encender
            {
                return;
            }

            if (regionesIluminadas.All(x => x == true)) //Caso Base 2: todas las regiones están iluminadas
            {
                if (minimaDistribucion.Count > regionesConAntorchas.Count)
                {
                    minimaDistribucion = new List<int>(regionesConAntorchas);
                }
                return;
            }

            //Encendiendo Regiones
            regionesIluminadas[regionActual] = true;    //Prendiendo la antorcha
            regionesConAntorchas.Add(regionActual);     //Añadiéndola a la lista de regiones puestas

            for (int i = 0; i < mapa.GetLength(1); i++)
            {
                if (mapa[regionActual, i])              //Viendo si esta antorcha enciende otras regiones
                {
                    regionesIluminadas[i] = true;
                }
            }
            //Llamando a la siguiente región con la antorcha puesta
            IluminarZonas(mapa, regionActual + 1, regionesIluminadas, regionesConAntorchas, ref minimaDistribucion);
            regionesIluminadas[regionActual] = false;   //Apagando la antorcha
            regionesConAntorchas.Remove(regionActual);

            //Apagando Regiones'
            for (int i = 0; i < mapa.GetLength(1); i++)
            {
                if (mapa[regionActual, i])      //Volviendo todo a como estaba y llamado recursivo
                {
                    regionesIluminadas[i] = false;
                }
            }
            IluminarZonas(mapa, regionActual + 1, regionesIluminadas, regionesConAntorchas, ref minimaDistribucion);
        }

    }
}