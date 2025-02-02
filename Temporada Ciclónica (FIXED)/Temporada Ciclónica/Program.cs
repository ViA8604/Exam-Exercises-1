bool[,] Amigos =
{
    { false, true,  true,  false, false, false, false, false, false, },
    { true,  false, false, true,  false, true,  false, true,  false, },
    { true,  false, false, false, true,  false, true,  false, true, },
    { false, true,  false, false, false, false, false, false, false, },
    { false, false, true,  false, false, false, false, false, false, },
    { false, true,  false, false, false, false, false, false, false, },
    { false, false, true,  false, false, false, false, false, false, },
    { false, true,  false, false, false, false, false, false, false, },
    { false, false, true,  false, false, false, false, false, false, },
};

int[] Expected = { 9, 2, 1, 1, 1, 1, 1, 1, 1, 1 };

for(int k = 0; k < 10; k++)
{
    var result = Examen.MinEstudiantesAvisar(Amigos, k);
    if (result != Expected[k]) Console.WriteLine($"Test #{k + 1}: Se esperaba {Expected[k]}, se obtuvo {result}");
    else Console.WriteLine($"Test #{k + 1}: S={result}. Correcto!");
}
