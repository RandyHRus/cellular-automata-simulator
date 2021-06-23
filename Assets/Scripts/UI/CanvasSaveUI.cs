using System.IO;
using Canvas;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CanvasSaveUI: MonoBehaviour
    {
        [SerializeField] private InputField nameInput = null;
        
        public void OnSaveSubmitButtonPressed()
        {
            string canvasName = nameInput.text;
            
            CanvasSaveManager.SaveCanvas(CanvasManager.currentCanvas, canvasName);
        }
    }
}