namespace MatCom.Exam;

using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Mail;
using zoologico;

public class Exam
{
    public static IRecord CreateRecord()
    {
        // Devuelva aquí su instancia de IRecord
        return new Record(new Area("Zoologico"));
    }

    // Borre esta excepción y ponga su nombre como string, e.j.
    // Nombre => "Fulano Pérez Pérez";
    public static string Nombre => "Anthony Cruz Garcia";

    // Borre esta excepción y ponga su grupo como string, e.j.
    // Grupo => "C2XX";
    public static string Grupo => "C121";

}
public class Animal(int age, string name, string specie, Area parent) : IAnimal
{
    public int Age => age;

    public string Name => name;

    public string Specie => specie;
    public Area Parent = parent;

}
public class Area(string name, Area? parent = null) : IArea
{
    public string Name => name;
    public List<Animal> Animals = new List<Animal>();
    public List<Area> Areas = new List<Area>();
    public Area? Parent = parent;

    public IAnimal CreateAnimal(string name, int size, string specie)
    {
        Animal animal = new Animal(size, name, specie, this);
        Animals.Add(animal);
        return animal;
    }

    public IArea CreateArea(string name)
    {
        Area area = new Area(name, this);
        Areas.Add(area);
        return area;
    }

    public IEnumerable<IAnimal> GetAnimals()
    {
        List<Animal> AnimalsInArea = new List<Animal>();
        foreach (Animal animal in Animals)
        {
            AnimalsInArea.Add(animal);
        }
        foreach (Area area in Areas)
        {
            AnimalsInArea.Concat(area.GetAnimals());
        }
        AnimalsInArea.OrderByDescending(x => x.Name);
        return AnimalsInArea;
    }

    public IEnumerable<IArea> GetAreas()
    {
        List<Area> AreasInArea = new List<Area>();
        foreach (Area area in Areas)
        {
            AreasInArea.Add(area);
            AreasInArea.Concat(area.GetAreas());
        }
        AreasInArea.OrderByDescending(x => x.Name);
        return AreasInArea;
    }
    public Area GetArea(string name)
    {
        foreach (Area area in Areas)
        {
            if (area.Name == name)
            {
                return area;
            }
        }
        throw new InvalidOperationException();
    }
    public Animal GetAnimal(string name)
    {
        foreach (Animal animal in Animals)
        {
            if (animal.Name == name)
            {
                return animal;
            }
        }
        throw new InvalidOperationException();
    }

    public int MeanAge()
    {
        return (int)GetAnimals().Average(x => x.Age);
    }

}
public class Record(Area root) : IRecord
{
    public Area Root => root;

    public IEnumerable<IAnimal> Find(Func<IAnimal, bool> predicate)
    {
        return FindAnimal(Root);
        List<Animal> FindAnimal(Area area)
        {
            List<Animal> animals = new List<Animal>();
            area.Animals.OrderBy(x => x.Name);
            foreach (Animal animal in area.Animals)
            {
                if (predicate(animal))
                {
                    animals.Add(animal);
                }
            }
            area.Areas.OrderBy(x => x.Name);
            foreach (Area area1 in area.Areas)
            {
                animals.AddRange(FindAnimal(area1));
            }
            return animals;
        }
    }

    public IAnimal GetAnimal(string description)
    {
        int last_position = -1;
        for (int i = 0; i < description.Length; i++)
        {
            if (description[i] == '/')
            {
                last_position = i;
            }
        }
        if (last_position == -1)
        {
            throw new InvalidOperationException();
        }
        Area area = (Area)GetArea(description.Substring(0, last_position ));
        return area.GetAnimal(description.Substring(last_position + 1));
    }

    public IArea GetArea(string description)
    {
        return ReadArea(description);
    }

    public IRecord GetRoot(string description)
    {
        return new Record(ReadArea(description));
    }

    public void Move(string origin, string destination)
    {
        Area destiny = ReadArea(destination);
        try
        {
            Area Source = ReadArea(origin);
            if (Source.Parent == null)
            {
                throw new InvalidOperationException();
            }
            Source.Parent.Areas.Remove(Source);
            Source.Parent = destiny;
            List<Area> AreasInDestiny = destiny.Areas;
            for (int i = 0; i < AreasInDestiny.Count; i++)
            {
                if (AreasInDestiny[i].Name == Source.Name)
                {
                    AreasInDestiny[i] = MergeAreas(AreasInDestiny[i], Source);
                    return;
                }
            }
            destiny.Areas.Add(Source);
        }
        catch
        {
            Animal Source = (Animal)GetAnimal(origin);
            Source.Parent.Animals.Remove(Source);
            Source.Parent = destiny;
            List<Animal> AnimalsInDestiny = destiny.Animals;
            for (int i = 0; i < AnimalsInDestiny.Count; i++)
            {
                if (AnimalsInDestiny[i].Name == Source.Name)
                {
                    AnimalsInDestiny[i] = Source;
                    return;
                }
            }
            AnimalsInDestiny.Add(Source);
        }
    }

    public void Remove(string description)
    {
        try
        {
            Area Source = ReadArea(description);
            if (Source.Parent == null)
            {
                throw new InvalidOperationException();
            }
            Source.Parent.Areas.Remove(Source);
        }
        catch
        {
            Animal Source = (Animal)GetAnimal(description);
            Source.Parent.Animals.Remove(Source);
        }
    }
    static Area MergeAreas(Area area1, Area source)
    {
        List<Animal> AnimalsInDestiny = area1.Animals;
        List<Animal> AnimalsInSource = source.Animals;
        for (int i = 0; i < AnimalsInDestiny.Count; i++)
        {
            foreach (Animal animal in AnimalsInSource)
            {
                if (animal.Name == AnimalsInDestiny[i].Name)
                {
                    continue;
                }
            }
            AnimalsInSource.Add(AnimalsInDestiny[i]);
        }
        List<Area> AreasInDestiny = area1.Areas;
        List<Area> AreasInSource = source.Areas;
        for (int i = 0; i < AreasInDestiny.Count; i++)
        {
            bool Merged = false;
            for (int a = 0; a < AreasInSource.Count; a++)
            {
                if (AreasInDestiny[i].Name == AreasInSource[a].Name)
                {
                    Merged = true;
                    AreasInSource[a] = MergeAreas(AreasInDestiny[i], AreasInSource[a]);
                }
            }
            if (!Merged) AreasInSource.Add(AreasInDestiny[i]);
        }
        return source;
    }
    Area ReadArea(string path)
    {
        Area? area = null;
        string name_area = "";
        int count = 0;
        while (count < path.Length)
        {
            if (path[count] == '/')
            {
                if (area == null)
                {
                    if (Root.Name != name_area)
                    {
                        throw new InvalidOperationException();
                    }
                    else
                    {
                        area = root;
                    }
                }
                else
                {
                    area = area.GetArea(name_area);
                }
                name_area = "";
            }
            else
            {
                name_area += path[count];
            }
            count++;
        }
        if (area == null)
        {
            if (Root.Name != name_area)
            {
                throw new InvalidOperationException();
            }
            else
            {
                area = root;
            }
        }
        else
        {
            area = area.GetArea(name_area);
        }
        return area;
    }
}