using System;
using System.IO;
using UnityEngine;

namespace OOPPS.Persistence
{
    public class FileDataHandler : IFileDataHandler
    {
        private readonly string _fileName;

        public FileDataHandler(string fileName)
        {
            _fileName = fileName;
        }

        public bool Load(ref GameData data)
        {
            if (File.Exists(_fileName))
            {
                try
                {
                    string rawData = File.ReadAllText(_fileName);
                    data = JsonUtility.FromJson<GameData>(rawData);
                    return true;
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                    return false;
                }
            }

            return false;
        }

        public void Save(GameData data)
        {
            string rawData = JsonUtility.ToJson(data);
            File.WriteAllTextAsync(_fileName, rawData);
        }
    }

    public interface IFileDataHandler
    {
        public bool Load(ref GameData data);
        public void Save(GameData data);
    }
}