namespace Solution;

public interface INodo
{
    /// <summary>
    /// Obtiene los hijos de este nodo junto con el costo de llegar dado a el
    /// según el personaje y si está conectado o no. Retorna null en caso de ser
    /// una hoja.
    /// </summary>
    /// <param name="personaje"> Personaje para el que se calcula el costo. </param>
    /// <returns> Retorna nodos hijos, costo, y si esta conectado. </returns>
    public (INodo, int, bool)[]? Hijos(int personaje);

    /// <summary>
    /// Obtiene los hijos de este nodo, junto con el índice global respecto a todos los
    /// nodos (conectados o no) y el costo de caminar hacia estos
    /// según el personaje. Retorna null en caso de ser una hoja.
    /// </summary>
    /// <param name="personaje"> Personaje para el que se calcula el costo. </param>
    /// <returns> Retorna nodos hijos conectados, los indices y su costo </returns>
    public (INodo, int, int)[]? HijosConectados(int personaje);

    /// <summary>
    /// Intercambia la conexión entre dos par de nodos.
    /// </summary>
    /// <param name="conectado"> El nodo que se encuentra conectado </param>
    /// <param name="desconectado"> El nodo que se encuentra desconectado </param>
    /// <exception cref="IndexOutOfRangeException"> Cuando los indices estan fuera de rango</exception>
    /// <exception cref="ArgumentException"> Cuando se intercambia la conexión entre dos nodos mutamente conectados o desconectados </exception>
    public void IntercambiarConexion(int conectado, int desconectado);
}
