public static class Examen
{
    public static int MinEstudiantesAvisar(bool[,] amigos, int k)
    {
        int minAvisos = int.MaxValue;
        bool[] estudiantesAvisados = new bool[amigos.GetLength(0)];

        AvisarEstudiantes(amigos, k, estudiantesAvisados, 0, 0, ref minAvisos);
        return minAvisos;
        // Implementación del algoritmo de búsqueda exhaustiva
    }

    private static void AvisarEstudiantes(bool[,] amigos, int llamadasDeAviso, bool[] estudiantesAvisados, int estudianteActual, int cantAvisosDados, ref int minAvisos)
    {

        if (cantAvisosDados >= minAvisos)    //Poda
        {
            return;
        }

        if (estudiantesAvisados.All(x => x == true))     //Caso Base 2, todos fueron avisados
        {
            minAvisos = Math.Min(cantAvisosDados, minAvisos);
            return;
        }


        //Caso Recursivo, mandando a avisar
        if (llamadasDeAviso == 0)
        {
            int cant = 0;

            for (int i = 0; i < estudiantesAvisados.Length; i++)
            {
                if (!estudiantesAvisados[i])
                {
                    estudiantesAvisados[i] = true;
                    cant = cant + 1;
                }
            }

            AvisarEstudiantes(amigos, llamadasDeAviso, estudiantesAvisados, estudiantesAvisados.Length, cantAvisosDados + cant, ref minAvisos);
        }

        else
        {

            for (int i = 0; i < estudiantesAvisados.Length; i++)
            {
                estudiantesAvisados[estudianteActual] = true;
                if (amigos[estudianteActual, i])    //Si encuentras un amigo, lo mandas a avisar
                {
                    AvisarEstudiantes(amigos, llamadasDeAviso, estudiantesAvisados, i, cantAvisosDados + 1, ref minAvisos);
                }
                estudiantesAvisados[estudianteActual] = false;
                AvisarEstudiantes(amigos, llamadasDeAviso - 1, estudiantesAvisados, i, cantAvisosDados, ref minAvisos);

            }
        }

    }


}
