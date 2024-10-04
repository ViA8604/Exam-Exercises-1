
using filesystem;

public class Exam
{
    public static IFileSystem CreateFileSystem()
    {

        // Devuelva aquí su instancia de IFileSystem
        throw new NotImplementedException();
    }

    // Borre esta excepción y ponga su nombre como string, e.j.
    // Nombre => "Fulano Pérez Pérez";
    public static string Nombre => throw new NotImplementedException();

    // Borre esta excepción y ponga su grupo como string, e.j.
    // Grupo => "C2XX";
    public static string Grupo => throw new NotImplementedException();
}

public class File : IFile
{
    string _name;
    int _size;

     public File(string name, int size)
    {
        _name = name;
        _size = size;
    }

    public int Size => _size;
    public string Name => _name;
}

public class Folder : IFolder
{
    private string _name;
    private List<IFile> _files;
    private List<IFolder> _folders;

    public Folder(string name)
    {
        _name = name;
        _files = new List<IFile>();
        _folders = new List<IFolder>();
    }

    public string Name => _name;

    public IFile CreateFile(string name, int size)
    {
        var file = new File(name, size);
        _files.Add(file);
        return file;
    }

    public IFolder CreateFolder(string name)
    {
        var folder = new Folder(name);
        _folders.Add(folder);
        return folder;
    }

    public IEnumerable<IFile> GetFiles()
    {
        return _files;
    }

    public IEnumerable<IFolder> GetFolders()
    {
        return _folders;
    }

    public int TotalSize()
    {
        int totalSize = 0;
        foreach (File file in _files)
        {
            totalSize += file.Size;
        }
        foreach (Folder folder in _folders)
        {
            totalSize += folder.TotalSize();
        }
        return totalSize;
    }

    
}