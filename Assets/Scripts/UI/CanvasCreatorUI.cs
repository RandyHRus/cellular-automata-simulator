using System.Collections.Generic;
using Canvas;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace UI
{
    public class CanvasCreatorUI : MonoBehaviour
    {
        public static readonly int minPaletteSize = 10;
        public static readonly int maxPaletteSize = 200;
        
        [SerializeField] private InputField inputField;
        [SerializeField] private TilemapManager tilemapManager;

        public void OnCreateButtonPressed()
        {
            var size = (int.TryParse(inputField.text, out var result)) ? result : 10;
            if (size < minPaletteSize) size = minPaletteSize;
            else if (size > maxPaletteSize) size = maxPaletteSize;

            var neighbours = new List<Vector2Int>()
            {
                new Vector2Int(-1,0),
                new Vector2Int(1,0),
                new Vector2Int(0,-1),
                new Vector2Int(0,1),
                new Vector2Int(-1,1),
                new Vector2Int(1,1),
                new Vector2Int(1,-1),
                new Vector2Int(-1,-1),
                new Vector2Int(0,0),
            };
            var newCanvas = new CellsCanvas(size, neighbours);
            CanvasManager.LoadCanvas(newCanvas);
        }
    }
}
