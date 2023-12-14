using System.IO;
using UnityEngine;

namespace OOPPS.Persistence
{
    public class PathHandler : IPathHandler
    {
        private readonly PersistenceDataConfig _config;

        public PathHandler(PersistenceDataConfig config)
        {
            _config = config;
        }

        public string GetDirectoryName()
        {
            return Path.Combine(Application.persistentDataPath, _config.DirectoryName);
        }

        public string GetFileName()
        {
            return Path.Combine(GetDirectoryName(), _config.FileName);
        }
    }

    public interface IPathHandler
    {
        public string GetDirectoryName();
        public string GetFileName();
    }
}