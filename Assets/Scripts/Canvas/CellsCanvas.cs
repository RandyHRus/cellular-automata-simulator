using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Canvas
{
    public class CellsCanvas
    {
        [JsonProperty] public readonly int size;
        [JsonProperty] private readonly Cell[,] m_Cells;
        [JsonProperty] private readonly List<Vector2Int> m_NeighbourOffsets;
        [JsonProperty] public readonly string m_CanvasName;
        
        [JsonIgnore] private List<Vector2Int>[,] m_NeighbourLists;

        [JsonConstructor]
        public CellsCanvas()
        {
        }

        public CellsCanvas(int size, List<Vector2Int> neighbourOffsets, string canvasName)
        {
            this.size = size;
            this.m_NeighbourOffsets = neighbourOffsets;
            m_Cells = new Cell[size, size];
            this.m_CanvasName = canvasName;

            //Set cells;
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    m_Cells[i, j] = new Cell(null, 0);
                }
            }
            
            SetNeighbours();
        }

        public void InitializeAfterLoad()
        {
            SetNeighbours();
        }

        private void SetNeighbours()
        {
            m_NeighbourLists = new List<Vector2Int>[size, size];

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    Vector2Int coordinate = new Vector2Int(i, j);
                        
                    List<Vector2Int> neighbours = new List<Vector2Int>();
                    foreach (var offset in m_NeighbourOffsets)
                    {
                        neighbours.Add(Helpers.GetWrappedCoordinate(coordinate + offset, size));
                    }

                    m_NeighbourLists[i, j] = neighbours;
                }
            }
        }

        public Cell GetCell(Vector2Int coordinate)
        {
            return m_Cells[coordinate.x, coordinate.y];
        }
    
        public void SetCell(Vector2Int coordinate, Cell cell)
        {
            m_Cells[coordinate.x, coordinate.y] = cell;
        }

        public List<Vector2Int> GetNeighbours(Vector2Int coordinate)
        {
            return m_NeighbourLists[coordinate.x, coordinate.y];
        }
    }
}
