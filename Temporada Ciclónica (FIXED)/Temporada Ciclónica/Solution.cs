public static class Examen
{
    public static int MinEstudiantesAvisar(bool[,] amigos, int k)
    {
        bool[] estudiantesAvisados = new bool[amigos.GetLength(0)];
        int minEstudiantesAvisar = int.MaxValue;

        WorkingDecano(amigos, estudiantesAvisados, k, 0, 0, ref minEstudiantesAvisar);

        return minEstudiantesAvisar;
    }


    public static void WorkingDecano(bool[,] amigos, bool[] estudiantesAvisados, int k, int estudianteActual, int cantidadAvisados, ref int minEstudiantesAvisar)
    {
        //Poda
        if (cantidadAvisados >= minEstudiantesAvisar) 
        {
            return;
        }

        //Caso base 1, todos los estudiantes han sido avisados
        if (estudiantesAvisados.All(x => x == true))
        {
            minEstudiantesAvisar = Math.Min(cantidadAvisados, minEstudiantesAvisar);

            return;
        }

        //Caso base 2, ya el decano ha solicitado para el aviso a todos los estudiantes
        if (estudianteActual == estudiantesAvisados.Length)
        {
            return;
        }

        //Caso RECURSIVO CANDELA
        Avisar(amigos, estudiantesAvisados, k, estudianteActual);
        WorkingDecano(amigos, estudiantesAvisados, k, estudianteActual + 1, cantidadAvisados + 1, ref minEstudiantesAvisar);

        //N0 avisar
        DesAvisar(amigos, estudiantesAvisados, k, estudianteActual);
        WorkingDecano(amigos, estudiantesAvisados, k, estudianteActual + 1, cantidadAvisados, ref minEstudiantesAvisar);

    }

    private static void Avisar(bool[,] amigos, bool[] estudiantesAvisados, int k, int estudianteActual)
    {
        estudiantesAvisados[estudianteActual] = true;
        if (k > 0)
        {
            for (int i = 0; i < estudiantesAvisados.Length; i++)
            {
                if (amigos[estudianteActual, i])
                {
                    Avisar(amigos, estudiantesAvisados, k - 1, i);
                }
            }
        }
    }

    private static void DesAvisar(bool[,] amigos, bool[] estudiantesAvisados, int k, int estudianteActual)
    {
        estudiantesAvisados[estudianteActual] = false;
        if (k > 0)
        {
            for (int i = 0; i < estudiantesAvisados.Length; i++)
            {
                if (amigos[estudianteActual, i])
                {
                    DesAvisar(amigos, estudiantesAvisados, k - 1, i);
                }
            }
        }
    }
}