using System;
using System.Collections.Generic;
using Chemicals;
using Saving;
using UnityEngine;

namespace Canvas
{
    public class CanvasManager: MonoBehaviour
    {
        public static CellsCanvas currentCanvas { get; private set; }

        public static Action<CellsCanvas> onLoadCanvas;
        public static Action<Vector2Int> onCellOverwritten;
        public static Action onCacheRefreshed;

        private static readonly Dictionary<string, CellsCanvas> NameToCanvasCache = new Dictionary<string, CellsCanvas>();
        public static readonly List<CellsCanvas> allCanvases = new List<CellsCanvas>();

        private void Awake()
        {
            CacheManager.onCacheRefresh += UpdateCache;
        }

        public static void LoadCanvas(CellsCanvas canvas)
        {
            currentCanvas = canvas;
            onLoadCanvas?.Invoke(canvas);
        }
        
        public static void LoadCanvas(string canvasName)
        {
            var canvas = NameToCanvasCache[canvasName];
            currentCanvas = canvas;
            onLoadCanvas?.Invoke(canvas);
            
        }

        public static void NextGenerationCells()
        {
            var newCells = new Cell[currentCanvas.size, currentCanvas.size];

            for (var i = 0; i < currentCanvas.size; i++)
            {
                for (var j = 0; j < currentCanvas.size; j++)
                {
                    var coordinate = new Vector2Int(i, j);
                    List<Vector2Int> neighbours = currentCanvas.GetNeighbours(coordinate);

                    HashSet<Chemical> chemicalsInNeighbours = new HashSet<Chemical>();
                    Dictionary<Chemical, float> chemicalSumInNeighbours = new Dictionary<Chemical, float>();

                    foreach (var neighbour in neighbours)
                    {
                        Cell neighbourCell = currentCanvas.GetCell(neighbour);
                        if (neighbourCell.chemical == null)
                            continue;

                        if (chemicalSumInNeighbours.TryGetValue(neighbourCell.chemical, out float value))
                        {
                            chemicalSumInNeighbours[neighbourCell.chemical] = value + neighbourCell.value;
                        }
                        else
                        {
                            chemicalSumInNeighbours.Add(neighbourCell.chemical, neighbourCell.value);
                            chemicalsInNeighbours.Add(neighbourCell.chemical);
                        }
                    }

                    List<Cell> cellCandidates = new List<Cell>();
                    foreach (var chemical in chemicalsInNeighbours)
                    {
                        var newValue =
                            chemical.rule.GetNextGenerationValue(chemicalSumInNeighbours[chemical] /
                                                                 (float) neighbours.Count);
                        if (newValue <= 0f)
                            continue;

                        var newCell = new Cell(chemical, newValue);
                        cellCandidates.Add(newCell);
                    }


                    //Choose winner
                    if (cellCandidates.Count < 1)
                    {
                        newCells[i, j] = new Cell(null, 0);
                    }
                    else
                    {
                        Cell winner = cellCandidates[UnityEngine.Random.Range(0, cellCandidates.Count)];
                        newCells[i, j] = winner;
                    }
                }
            }

            //Actual set cells part
            for (var i = 0; i < currentCanvas.size; i++)
            {
                for (var j = 0; j < currentCanvas.size; j++)
                {
                    var coordinate = new Vector2Int(i, j);
                    currentCanvas.SetCell(coordinate, newCells[i, j]);
                    onCellOverwritten?.Invoke(coordinate);
                }
            }
        }

        public static void OverwriteCell(Vector2Int coordinate, Chemical chemical, float value)
        {
            currentCanvas.SetCell(coordinate, new Cell(chemical, value));
            onCellOverwritten?.Invoke(coordinate);
        }

        private static void UpdateCache()
        {
            NameToCanvasCache.Clear();
            allCanvases.Clear();

            var allSaves = SaveManager.LoadAll<CellsCanvas>(SaveManager.canvasSubDir);
            foreach (var canvas in allSaves)
            {
                canvas.InitializeAfterLoad();
                for (var i = 0; i < canvas.size; i++)
                {
                    for (var j = 0; j < canvas.size; j++)
                    {
                        Cell c = canvas.GetCell(new Vector2Int(i, j));
                        c.InitializeFromGuid();
                    }
                }
                
                NameToCanvasCache.Add(canvas.m_CanvasName, canvas);
                allCanvases.Add(canvas);
            }

            onCacheRefreshed?.Invoke();
        }
    }
}