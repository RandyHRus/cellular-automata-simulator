using System.IO;
using Canvas;
using Saving;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CanvasSaveUI: MonoBehaviour
    {
        public void OnSaveSubmitButtonPressed()
        {
            SaveManager.Save(CanvasManager.currentCanvas, SaveManager.canvasSubDir, CanvasManager.currentCanvas.m_CanvasName);
        }
    }
}