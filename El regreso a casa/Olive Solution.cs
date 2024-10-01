namespace MatCom.Examen;

/*public static class Solution
{
    public static double MinDanger(CityNode RootCity)
    {
        double MinDanger = double.MaxValue;
        Travel(RootCity, 0, false, 0, ref MinDanger);

        return MinDanger;
    }


    public static void Travel(CityNode CurrentCity, int totalRoads, bool teleport, int CurrentDanger, ref double MinDanger)
    {
        if (CurrentDanger > MinDanger)
        {
            return;
        }

        if (CurrentCity.Roads().Length == 0)  //Caso base, se llega a una hoja
        {
            MinDanger = Math.Min(MinDanger, CurrentDanger);
            return;
        }

        if (CurrentCity.HasTeleport().Item1 && !teleport)
        {
            Travel(CurrentCity.HasTeleport().Item2, totalRoads, true, CurrentDanger, ref MinDanger);
        }

        for (int i = 0; i < CurrentCity.Roads().Length; i++)
        {
            Travel(CurrentCity.Roads()[i].Item2,totalRoads + 1, false, CurrentDanger + CurrentCity.Roads()[i].Item1 * (totalRoads + 1), ref MinDanger);
        }

    }
} */