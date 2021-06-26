using Canvas;
using Saving;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CanvasLoadPanelUI: MonoBehaviour
    {
        [SerializeField] private Dropdown loadCanvasDropdown = null;
        
        private void Awake()
        {
            CanvasManager.onCacheRefreshed += UpdateLoadCanvasList;
        }

        private void UpdateLoadCanvasList()
        {
            loadCanvasDropdown.options.Clear();

            var canvases = CanvasManager.allCanvases;

            foreach (var canvas in canvases)
            {
                var optionData = new Dropdown.OptionData(canvas.m_CanvasName);
                loadCanvasDropdown.options.Add(optionData);
            }
        }
        
        public void OnLoadSubmitButtonPressed()
        {
            if (loadCanvasDropdown.options.Count < 1)
                return;
            
            var selectedFileName = loadCanvasDropdown.options[loadCanvasDropdown.value].text;
            CacheManager.RefreshCache();
            CanvasManager.LoadCanvas(selectedFileName);
        }
    }
}