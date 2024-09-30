/*public static class Solution
{
    public static int GetRoutes(Map map, int n)
    {
        int LowerDistance=int.MaxValue;
        GetPath(ref LowerDistance,0,n,map);
        return LowerDistance;
    }
    static void GetPath(ref int LowerDistance, int distance, int workers, Map map)
    {
        for (int i = 1; i < map.N; i++)
        {
            if(i*workers<map.N)
            {
                continue;
            }
            bool[]visitedLions=new bool[map.N-1];
            for(int a=0;a<map.N-1;a++)
            {
                visitedLions[a]=false;
            }
            SeachPath(visitedLions, ref LowerDistance, 0, 0,0, map,i,0);
        }
    }
    static void SeachPath(bool[] visitedLions, ref int LowerDistance, int actualLion, int distance,int workDistance, Map map,int amount,int visits)
    {
        if (AllLionsVisited(visitedLions))
        {
            distance += map[actualLion, 0];
            if (distance < LowerDistance)
            {
                LowerDistance = distance;
            }
            return;
        }
        if(visits==amount)
        {
            SeachPath(visitedLions, ref LowerDistance, 0, distance + map[actualLion, 0],0, map,amount,0);
        }
        for (int i = 1; i < map.N ; i++)
        {
            if (!visitedLions[i-1] && map.IsOnTime(i,workDistance+map[actualLion,i]))
            {
                visitedLions[i-1] = true;
                SeachPath(visitedLions, ref LowerDistance, i, distance + map[actualLion, i],workDistance+ map[actualLion, i], map,amount,visits+1);
                visitedLions[i-1] = false;
            }
            else
            {
                continue;
            }
        }
    }
    static void VisitLions(bool[] VisitedLions, ref int distance, int amount, int visits, Map map, int actualLion)
    {
        if (visits == amount)
        {
            return;
        }
    }
    static bool AllLionsVisited(bool[] visitedLions)
    {
        foreach (bool IsVisited in visitedLions)
        {
            if (!IsVisited)
            {
                return false;
            }
        }
        return true;
    }
}
*/