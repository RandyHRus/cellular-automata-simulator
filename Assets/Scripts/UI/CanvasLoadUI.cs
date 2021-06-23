using System.Collections.Generic;
using System.IO;
using Canvas;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CanvasLoadUI: MonoBehaviour
    {
        [SerializeField] private Dropdown loadCanvasDropdown = null;
        
        public void OnPanelOpenerPressed()
        {
            UpdateLoadCanvasList();
        }
        
        public void OnLoadSubmitButtonPressed()
        {
            if (loadCanvasDropdown.options.Count < 1)
                return;
            
            var selectedFileName = loadCanvasDropdown.options[loadCanvasDropdown.value].text;
            CanvasSaveManager.LoadCanvas(selectedFileName);
        }
        
        private void UpdateLoadCanvasList()
        {
            loadCanvasDropdown.options.Clear();

            var saveFiles = CanvasSaveManager.GetAllSaveFiles();

            foreach (var saveFilePath in saveFiles)
            {
                var fileName = Path.GetFileName(saveFilePath);
                var optionData = new Dropdown.OptionData(fileName);
                loadCanvasDropdown.options.Add(optionData);
            }
        }
    }
}