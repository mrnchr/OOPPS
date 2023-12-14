using System.IO;

namespace OOPPS.Persistence
{
    public static class PathHandlerExtensions 
    {
        public static void CreatePersistenceDirectory(this IPathHandler obj)
        {
            Directory.CreateDirectory(obj.GetDirectoryName());
        }
    }
}