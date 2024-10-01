using System.Net.Security;

namespace MatCom.Examen;

public class CityNode{
    private List<(int, CityNode)> roads;
    private CityNode? teleport;
    
    public CityNode(CityNode? teleport = null, List<(int, CityNode)>? roads = null){
        this.roads = (roads is null) ? new() : roads;
        this.teleport = teleport;
    }

    public (int, CityNode)[] Roads(){
        return roads.ToArray();
    }

    public (bool, CityNode?) HasTeleport(){
        return (teleport != null, teleport);
    }
}