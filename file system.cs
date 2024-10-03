using filesystem;

public class Exam
{
    public static IFileSystem CreateFileSystem()
    {
        return new FileSystem();
    }

    // Borre esta excepción y ponga su nombre como string, e.j.
    // Nombre => "Fulano Pérez Pérez";
    public static string Nombre =>"Anthony Cruz Garcia";

    // Borre esta excepción y ponga su grupo como string, e.j.
    // Grupo => "C2XX";
    public static string Grupo =>"C121";
}
class File : IFile
{
    public int Size {get;}

    public string Name {get;}
    public File(string name,int size)
    {
        Size=size;
        Name=name;
    }
}
class Folder : IFolder
{
    public string Name {get;}
    public Dictionary<string,IFolder>Folders;
    public Dictionary<string,IFile>Files;
    public Folder(string name)
    {
        Folders=new Dictionary<string, IFolder>();
        Files=new Dictionary<string, IFile>();
        Name=name;
    }
    public IFile CreateFile(string name, int size)
    {
        if(Files.ContainsKey(name))
        {
            throw new Exception("ya hay una carpeta con este nombre");
        }
        else
        {
            File file=new File(name,size);
            Files.Add(file.Name,file);
            Files.OrderByDescending(s=>s);
            return file;
        }
        
    }

    public IFolder CreateFolder(string name)
    {
        if(Folders.ContainsKey(name))
        {
            throw new Exception("ya hay una carpeta con este nombre");
        }
        else
        {
            Folder folder=new Folder(name);
            Folders.Add(folder.Name,folder);
            Files.OrderByDescending(s=>s);
            return folder;
        }
        
    }

    public IEnumerable<IFile> GetFiles()
    {
        List<IFile> files=new List<IFile>();
        foreach(IFile file in Files.Values)
        {
            files.Add(file);
        }
        return files;
    }

    public IEnumerable<IFolder> GetFolders()
    {
        List<IFolder> folders=new List<IFolder>();
        foreach(IFolder folder in Folders.Values)
        {
            folders.Add(folder);
        }
        return folders;
    }

    public int TotalSize()
    {
        int size=0;
        foreach(IFile file in Files.Values)
        {
            size+=file.Size;
        }
        foreach(IFolder folder in Folders.Values)
        {
            size+=folder.TotalSize();
        }
        return size;
    }
}
class FileSystem : IFileSystem
{
    IFolder root{get;}
    public FileSystem()
    {
        root=new Folder("");
    }
    public FileSystem(IFolder root)
    {
        this.root=root;
    }
    public void Copy(string origin, string destination)
    {
        Folder Destination=(Folder)GetFolder(destination);
        try
        {
            IFolder Origin=GetFolder(origin);
            Destination.Folders.Add(Origin.Name,Origin);
        }
        catch
        {
            IFile Origin=GetFile(origin);
            Destination.Files.Add(Origin.Name,Origin);
        }
    }

    public void Delete(string path)
    {
        try
        {
            IFolder Origin=GetFolder(path);
            IFolder parent=GetFolderParent(path);
            ((Folder)parent).Folders.Remove(Origin.Name);
        }
        catch
        {
            IFile Origin=GetFile(path);
            IFolder parent=GetFolderParent(path);
            ((Folder)parent).Files.Remove(Origin.Name);
        } 
    }

    public IEnumerable<IFile> Find(FileFilter filter)
    {
        return Find(filter,(Folder)root);
        IEnumerable<IFile> Find(FileFilter filter,Folder folder)
        {
            List<IFile> files=new List<IFile>();
            foreach(File file in folder.Files.Values)
            {
                if(filter(file))
                {
                    files.Add(file);
                }
            }
            foreach(Folder folder1 in folder.Folders.Values)
            {
                files.Concat(Find(filter,folder1));
            }
            return files;
        }
        
    }

    public IFile GetFile(string path)
    {
        IFolder folder=root;
        return GetFile(path,0,folder);
        IFile GetFile(string path, int start,IFolder parent)
        {
            if(path[start++]!='/')  throw new NotImplementedException();
            string name="";
            while(start<path.Length)
            {
                if(path[start]=='/') return GetFile(path,start,GetFolderByName(name,parent));
                name+=path[start];
                start++;
            }
            return GetFileByName(name,parent);
        }
        IFile GetFileByName(string name,IFolder parent)
        {
            IEnumerable<IFile> parent_files=parent.GetFiles();
            foreach(IFile file in parent_files)
            {
                if(file.Name==name)
                {
                    return file;
                }
            }
            throw new NotImplementedException();
        }
        IFolder GetFolderByName(string name,IFolder parent)
        {
            IEnumerable<IFolder> parent_folders=parent.GetFolders();
            foreach(IFolder folder in parent_folders)
            {
                if(folder.Name==name)
                {
                    return folder;
                }
            }
            throw new NotImplementedException();
        }
    }
    public IFolder GetFolderParent(string path)
    {
        IFolder folder=root;
        GetFolder(path,0,folder);
        return folder;
        void GetFolder(string path, int start,IFolder parent)
        {
            if(path[start++]!='/')  throw new NotImplementedException();
            string name="";
            while(start<path.Length)
            {
                if(path[start]=='/') break;
                name+=path[start];
                start++;
            }
            if(start==path.Length)
            {
                return;
            }
            parent=GetFolderByName(name,parent);
            GetFolder(path,start,parent);
        }
        IFolder GetFolderByName(string name,IFolder parent)
        {
            IEnumerable<IFolder> parent_folders=parent.GetFolders();
            foreach(IFolder folder in parent_folders)
            {
                if(folder.Name==name)
                {
                    return folder;
                }
            }
            throw new NotImplementedException();
        }
    }
    public IFolder GetFolder(string path)
    {
        IFolder folder=root;
        if(path[0]!='/')  throw new Exception();
        GetFolder(path,1,ref folder);
        return folder;
        void GetFolder(string path, int start,ref IFolder parent)
        {
            if(start==path.Length)
            {
                return;
            }
            string name="";
            while(start<path.Length)
            {
                if(path[start]=='/'){start++; break;}
                name+=path[start];
                start++;
            }
            parent=GetFolderByName(name,parent);
            GetFolder(path,start,ref parent);
        }
        IFolder GetFolderByName(string name,IFolder parent)
        {
            IEnumerable<IFolder> parent_folders=parent.GetFolders();
            foreach(IFolder folder in parent_folders)
            {
                if(folder.Name==name)
                {
                    return folder;
                }
            }
            throw new Exception();
        }
    }

    public IFileSystem GetRoot(string path)
    {
        return new FileSystem(GetFolder(path));
    }

    public void Move(string origin, string destination)
    {
        Copy(origin,destination);
        Delete(origin);
    }
}