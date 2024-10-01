namespace MatCom.Examen;

public static class Solution
{
    public static double MinDanger(CityNode RootCity)
    {
        int MinDanger=int.MaxValue;
        SeachPath(RootCity,ref MinDanger,0,0,false);
        return MinDanger;
    }
    static void SeachPath(CityNode actualCity,ref int MinDanger,int Danger,int acummulateRoads,bool ComeToTeport)
    {
        if(Danger>MinDanger)//poda
        {
            return;
        }
        if(actualCity.HasTeleport().Item1 && !ComeToTeport)
        {
            SeachPath(actualCity.HasTeleport().Item2,ref MinDanger,Danger,acummulateRoads,true);
            return;
        }
        (int,CityNode)[]Roads=actualCity.Roads();
        if(Roads.Length==0)
        {
            if(Danger<MinDanger)
            {
                MinDanger=Danger;
            }
            return;
        }
        for(int i=0;i<Roads.Length;i++)
        {
            SeachPath(Roads[i].Item2,ref MinDanger,Danger+Roads[i].Item1*(acummulateRoads+1),acummulateRoads+1,false);
        }
    }
}