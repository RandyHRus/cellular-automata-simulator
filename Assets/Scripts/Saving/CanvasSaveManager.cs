using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

namespace Canvas
{
    public class CanvasSaveManager: MonoBehaviour
    {
        private static readonly string SavePath = Path.Combine(Application.dataPath, "save", "canvas");
        private static readonly string FileExtension = "data";
        private static readonly string FilePattern = "*." + FileExtension;
        
        public static void SaveCanvas(CellsCanvas canvas, string canvasName)
        {
            Directory.CreateDirectory(SavePath);

            var data = JsonConvert.SerializeObject(canvas, Formatting.Indented);

            string fileName = canvasName + "." + FileExtension;
            var filePath = Path.Combine(SavePath, fileName);
            File.WriteAllText(filePath, data);
        }

        public static void LoadCanvas(string fileName)
        {
            var loadPath = Path.Combine(SavePath, fileName);
            var fileContent = File.ReadAllText(loadPath);
            CellsCanvas canvas = JsonConvert.DeserializeObject<CellsCanvas>(fileContent);
            CanvasManager.LoadCanvas(canvas);
        }

        public static string[] GetAllSaveFiles()
        {
            return Directory.GetFiles(SavePath, FilePattern);
        }
    }
}
