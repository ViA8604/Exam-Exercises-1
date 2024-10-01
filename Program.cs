using System.Linq.Expressions;

namespace MatCom.Examen;

public class Program
{
    public static void Main()
    {
        //Descomente solo un caso a la vez para evitar colisiones entre los nombres de las variables
        //
        //--------------------------------------Caso 1---------------------------------------------------------------------------------

        //hojas
         CityNode city3 = new CityNode();
         CityNode city6 = new CityNode();
         CityNode city7 = new CityNode();
        CityNode city8 = new CityNode();

        // //nivel2
         List<(int, CityNode)> city4Roads = new List<(int, CityNode)>();
         city4Roads.Add((5, city6));
         city4Roads.Add((11, city7));

        CityNode city4 = new CityNode(null, city4Roads);

         List<(int, CityNode)> city5Roads = new List<(int, CityNode)>();
        city5Roads.Add((4, city8));

        CityNode city5 = new CityNode(null, city5Roads);

        //nivel1
        List<(int, CityNode)> city1Roads = new List<(int, CityNode)>();
        city1Roads.Add((2, city3));
        city1Roads.Add((6, city4));

        CityNode city1 = new CityNode(null, city1Roads);

        List<(int, CityNode)> city2Roads = new List<(int, CityNode)>();
        city2Roads.Add((9, city5));

        CityNode city2 = new CityNode(null, city2Roads);
        List<(int, CityNode)> rootRoads = new List<(int, CityNode)>();
        rootRoads.Add((7, city1));
        rootRoads.Add((5, city2));

        CityNode root = new CityNode(null, rootRoads);

        System.Console.WriteLine("esperado: 11");


        //-------------------------------------Caso 2---------------------------------------------------------------------------------

        //hojas
        // CityNode city3 = new CityNode();
        // CityNode city6 = new CityNode();
        // CityNode city7 = new CityNode();
        // CityNode city8 = new CityNode();

        // //nivel2
        // List<(int, CityNode)> city4Roads = new List<(int, CityNode)>();
        // city4Roads.Add((5, city6));
        // city4Roads.Add((11, city7));

        // CityNode city4 = new CityNode(null, city4Roads);

        // List<(int, CityNode)> city5Roads = new List<(int, CityNode)>();
        // city5Roads.Add((4, city8));

        // CityNode city5 = new CityNode(null, city5Roads);

        // //nivel1
        // List<(int, CityNode)> city1Roads = new List<(int, CityNode)>();
        // city1Roads.Add((2, city3));
        // city1Roads.Add((6, city4));

        // CityNode city1 = new CityNode(city8, city1Roads);

        // List<(int, CityNode)> city2Roads = new List<(int, CityNode)>();
        // city2Roads.Add((9, city5));

        // CityNode city2 = new CityNode(city4, city2Roads);
        // List<(int, CityNode)> rootRoads = new List<(int, CityNode)>();
        // rootRoads.Add((7, city1));
        // rootRoads.Add((5, city2));

        // CityNode root = new CityNode(null, rootRoads);

        // System.Console.WriteLine("esperado: 7");

        // -----------------------------------Caso 3---------------------------------------------------------------------------------
        // leafs
        // CityNode city4 = new CityNode();
        // CityNode city8 = new CityNode();
        // CityNode city7 = new CityNode();

        // nivel 3
        // List<(int, CityNode)> city5Roads = new List<(int, CityNode)>()
        // {
        //     (11,city8),
        // };

        // List<(int, CityNode)> city6Roads = new List<(int, CityNode)>()
        // {
        //     (20,city8)
        // };

        // CityNode city5 = new CityNode(null, city5Roads);
        // CityNode city6 = new CityNode(null, city6Roads);


        // nivel 2
        // List<(int, CityNode)> city1Roads = new List<(int, CityNode)>()
        // {
        //     (3,city4),
        //     (10,city5)
        // };


        // CityNode city1 = new CityNode(null, city1Roads);

        // List<(int, CityNode)> city2Roads = new List<(int, CityNode)>()
        // {
        //     (5,city6)
        // };


        // CityNode city2 = new CityNode(null, city2Roads);

        // List<(int, CityNode)> city3Roads = new List<(int, CityNode)>()
        // {
        //     (1,city7)
        // };

        // CityNode city3 = new CityNode(null, city3Roads);

        // Root
        // List<(int, CityNode)> rootRoads = new List<(int, CityNode)>()
        // {
        //     (2,city1),
        //     (4,city2),
        //     (13,city3)
        // };

        // CityNode root = new CityNode(null, rootRoads);
        // System.Console.WriteLine("Esperado: 8");

        // ----------------------------------------Caso 4---------------------------------------------------------------------------------

        // leafs
       /* CityNode city8 = new CityNode();
        CityNode city7 = new CityNode();
        CityNode city4 = new CityNode();

        // nivel 3
        List<(int, CityNode)> city5Roads = new List<(int, CityNode)>()
        {
            (11,city8),
        };

        List<(int, CityNode)> city6Roads = new List<(int, CityNode)>()
        {
            (20,city8)
        };

        CityNode city5 = new CityNode(null, city5Roads);
        CityNode city6 = new CityNode(null, city6Roads);


        // nivel 2
        List<(int, CityNode)> city1Roads = new List<(int, CityNode)>()
        {
            (3,city4),
            (10,city5),

        };

        // nivel 1
        CityNode city1 = new CityNode(null, city1Roads);

        List<(int, CityNode)> city2Roads = new List<(int, CityNode)>()
        {
            (5,city6)
        };


        CityNode city2 = new CityNode(null, city2Roads);

        List<(int, CityNode)> city3Roads = new List<(int, CityNode)>()
        {
            (1,city7)
        };

        CityNode city3 = new CityNode(null, city3Roads);

        // Root
        List<(int, CityNode)> rootRoads = new List<(int, CityNode)>()
        {
            (2,city1),
            (4,city2),
            (3,city3),
            // (4,city9)
        };

        CityNode root = new CityNode(null, rootRoads);

        System.Console.WriteLine("Esperado: 5");*/

        //----------------------------------------Caso 5---------------------------------------------------------------------------------        
        // leafs
        // CityNode city3 = new CityNode();
        // CityNode city16 = new CityNode();
        // CityNode city13 = new CityNode();
        // CityNode city14 = new CityNode();
        // CityNode city11 = new CityNode();
        // CityNode city8 = new CityNode();
        // CityNode city9 = new CityNode();
        // CityNode city19 = new CityNode();
        // CityNode city20 = new CityNode();
        // CityNode city21 = new CityNode();
        // CityNode city5 = new CityNode();

        // CityNode city15 = new CityNode();
        // CityNode city2 = new CityNode();
        // CityNode city6 = new CityNode();
        // CityNode city17 = new CityNode();
        // // level 2
        // List<(int, CityNode)> city1Roads = new List<(int, CityNode)>()
        // {
        //     (2,city15),
        // };
        // List<(int, CityNode)> city2Roads = new List<(int, CityNode)>()
        // {
        //     (4,city5),
        //     (2,city6),
        // };
        // List<(int, CityNode)> city4Roads = new List<(int, CityNode)>()
        // {
        //     (3,city17)
        // };
        // CityNode city1 = new CityNode(null, city1Roads);
        // CityNode city4 = new CityNode(null, city4Roads);
        // CityNode city10 = new CityNode();

        // List<(int, CityNode)> city5Roads = new List<(int, CityNode)>()
        // {
        //     (5,city10),
        //     (7,city11)
        // };

        // CityNode city7 = new CityNode();
        // List<(int, CityNode)> city6Roads = new List<(int, CityNode)>()
        // {
        //     (5,city7)
        // };
        // List<(int, CityNode)> city18Roads = new List<(int, CityNode)>()
        // {
        //     (5,city19),
        //     (1,city20),
        //     (10,city21)

        // };
        // CityNode city18 = new CityNode(null,city18Roads);
        // List<(int, CityNode)> city17Roads = new List<(int, CityNode)>()
        // {
        //     (2,city18)
        // };

        // List<(int, CityNode)> city12Roads = new List<(int, CityNode)>()
        // {
        //     (2,city13),
        //     (1,city14)
        // };

        // List<(int, CityNode)> city7Roads = new List<(int, CityNode)>()
        // {
        //     (2,city8),
        //     (1,city9)
        // };

        // CityNode city12 = new CityNode(null, city12Roads);



        // // root city
        // List<(int, CityNode)> rootRoads = new List<(int, CityNode)>()
        // {
        //     (1,city1),
        //     (3,city2),
        //     (20,city3),
        //     (2,city4)
        // };
        // CityNode root = new CityNode(null,rootRoads);

        System.Console.WriteLine(Solution.MinDanger(root));
    }
}