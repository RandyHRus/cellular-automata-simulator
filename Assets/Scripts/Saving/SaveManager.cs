using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using Object = System.Object;

namespace Saving
{
    public static class SaveManager
    {
        private static readonly string FileExtension = "data";
        private static readonly string FilePattern = "*." + FileExtension;
        private static readonly string SavePath = Path.Combine(Application.dataPath, "save");

        public static readonly string chemicalSubDir = "chemical";
        public static readonly string canvasSubDir = "canvas";
        
        public static void Save(Object obj, string subDirectory, string fileName)
        {
            var fullFileName = fileName + "." + FileExtension;
            var directoryPath = Path.Combine(SavePath, subDirectory);
            Directory.CreateDirectory(directoryPath);

            var fullFilePath = Path.Combine(directoryPath, fullFileName);
            var data = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.WriteAllText(fullFilePath, data);
            
            CacheManager.RefreshCache();
        }
        /*
        public static T Load<T>(string subDirectory, string fileName)
        {
            var fullFileName = fileName + "." + FileExtension;
            var loadPath = Path.Combine(SavePath, subDirectory, fullFileName);
            var content = File.ReadAllText(loadPath);
            T obj = JsonConvert.DeserializeObject<T>(content);
            return obj;
        }
        */
        public static List<T> LoadAll<T>(string subDirectory)
        {
            var pathToDir = Path.Combine(SavePath, subDirectory);
            
            List<T> objectsList = new List<T>();

            if (!Directory.Exists(pathToDir))
            {
                return objectsList;
            }
            
            var filesList = Directory.GetFiles(pathToDir, FilePattern);

            foreach (var file in filesList)
            {
                string pathToFile = Path.Combine(pathToDir, file);
                var content = File.ReadAllText(pathToFile);
                T obj = JsonConvert.DeserializeObject<T>(content);
                objectsList.Add(obj);
            }

            return objectsList;
        }
    }
}