using System.Diagnostics;
using Solution;

namespace Main
{
    public class Program
    {
        static void Main(string[]args)
        {
            MejorCamino1();
            MejorCamino2();
            MejorCamino3();
            MejorCamino4();
            MejorCamino5();



void MejorCamino1()
{
    Nodo raiz = new Nodo(
        new (INodo, (int, int), bool)[]
        {
            (
                new Nodo(
                    new (INodo, (int, int), bool)[]
                    {
                        (new Nodo(), (5, 8), true),
                        (new Nodo(new Nodo(), (9, 4), true), (5, 3), true),
                    }
                ),
                (10, 3),
                true
            ),
            (
                new Nodo(
                    new Nodo(new Nodo(new Nodo(), (8, 10), true), (1, 10), true),
                    (2, 10),
                    true
                ),
                (3, 1),
                true
            ),
        }
    );

    var res = Solution.Solution.CostoDeEscape(raiz);
    Debug.Assert(res == 24, $"Costo esperado: 24, costo obtenido: {res}");
    Console.WriteLine("Correcto!");
}

void MejorCamino2()
{
    Nodo raiz = new Nodo(
        new (INodo, (int, int), bool)[]
        {
            (new Nodo(), (10, 1), true),
            (new Nodo(), (1, 10), false)
        }
    );
    var res = Solution.Solution.CostoDeEscape(raiz);
    Debug.Assert(res == 4, $"Costo esperado: 4, costo obtenido: {res}");
    Console.WriteLine("Correcto!");
}

void MejorCamino3()
{
    Nodo raiz = new Nodo(
        new (INodo, (int, int), bool)[]
        {
            (
                new Nodo(
                    new (INodo, (int, int), bool)[]
                    {
                        (new Nodo(), (7, 7), true),
                        (new Nodo(), (5, 3), false),
                    }
                ),
                (10, 3),
                true
            ),
            (
                new Nodo(
                    new (INodo, (int, int), bool)[]
                    {
                        (new Nodo(), (2, 6), false),
                        (new Nodo(), (5, 6), true),
                    }
                ),
                (2, 7),
                true
            ),
        }
    );
    var res = Solution.Solution.CostoDeEscape(raiz);
    Debug.Assert(res == 15, $"Costo esperado: 15, costo obtenido: {res}");
    Console.WriteLine("Correcto!");
}

void MejorCamino4()
{
    Nodo raiz = new Nodo(
        new (INodo, (int, int), bool)[]
        {
            (
                new Nodo(
                    new (INodo, (int, int), bool)[]
                    {
                        (new Nodo(), (7, 7), true),
                        (new Nodo(), (5, 3), false),
                    }
                ),
                (10, 3),
                true
            ),
            (
                new Nodo(
                    new (INodo, (int, int), bool)[]
                    {
                        (new Nodo(), (2, 2), false),
                        (new Nodo(), (5, 6), true),
                    }
                ),
                (2, 6),
                true
            ),
        }
    );
    var res = Solution.Solution.CostoDeEscape(raiz);
    Debug.Assert(res == 14, $"Costo esperado: 14, costo obtenido: {res}");
    Console.WriteLine("Correcto!");
}
void MejorCamino5()
{
    Nodo raiz = new Nodo(
        new (INodo, (int, int), bool)[]
        {
            (
                new Nodo(
                    new (INodo, (int, int), bool)[]
                    {
                        (new Nodo(), (7, 7), true),
                        (new Nodo(), (3, 5), false),
                    }
                ),
                (3, 10),
                true
            ),
            (
                new Nodo(
                    new (INodo, (int, int), bool)[]
                    {
                        (new Nodo(), (2, 2), false),
                        (new Nodo(), (6, 5), true),
                    }
                ),
                (6, 2),
                true
            ),
        }
    );
    var res = Solution.Solution.CostoDeEscape(raiz);
    Debug.Assert(res == 14, $"Costo esperado: 14, costo obtenido: {res}");
    Console.WriteLine("Correcto!");
}
        }
    }
}
    

class Nodo : INodo
{
    Hijo[]? hijos;

    public Nodo() { }

    public Nodo(INodo nodo, (int, int) costo, bool conectado)
    {
        this.hijos = new Hijo[]
        {
            new Hijo
            {
                Nodo = nodo,
                Costo = new int[] { costo.Item1, costo.Item2 },
                Conectado = conectado
            }
        };
    }

    public Nodo((INodo nodo, (int, int) costo, bool conectado)[] hijos)
    {
        this.hijos = (
            from val in hijos
            select new Hijo
            {
                Nodo = val.nodo,
                Costo = new int[] { val.costo.Item1, val.costo.Item2 },
                Conectado = val.conectado
            }
        ).ToArray();
    }

    public (INodo, int, bool)[]? Hijos(int personaje)
    {
        return this.hijos is null
            ? null
            : (
                from hijo in hijos
                select (hijo.Nodo, hijo.Costo[personaje], hijo.Conectado)
            ).ToArray();
    }

    public (INodo, int, int)[]? HijosConectados(int personaje)
    {
        return this.hijos is null
            ? null
            : (
                from data in hijos.Select((hijo, index) => (hijo, index))
                where data.hijo.Conectado
                select (data.hijo.Nodo, data.index, data.hijo.Costo[personaje])
            ).ToArray();
    }

    public void IntercambiarConexion(int conectado, int desconectado)
    {
        hijos?[conectado].Desconectar();
        hijos?[desconectado].Conectar();
    }
}

struct Hijo
{
    public INodo Nodo;
    public bool Conectado;
    public int[] Costo;

    public void Conectar()
    {
        if (this.Conectado)
            throw new ArgumentException("Reconectando nodo ya conectado");
        this.Conectado = true;
    }

    public void Desconectar()
    {
        if (!this.Conectado)
            throw new ArgumentException("Desconectando nodo ya desconectado");
        this.Conectado = false;
    }

    public override string ToString()
    {
        return $"Nodo{{{this.Conectado},  ({this.Costo[0]}, {this.Costo[1]})}}";
    }
}
