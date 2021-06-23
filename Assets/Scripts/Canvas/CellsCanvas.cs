using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Canvas
{
    public class CellsCanvas
    {
        [JsonProperty] public readonly int size;
        [JsonProperty] private readonly Cell[,] m_Cells;
        [JsonIgnore] private readonly List<Vector2Int>[,] m_NeighbourLists;

        public CellsCanvas(int size, List<Vector2Int> neighbourOffsets)
        {
            this.size = size;
            m_Cells = new Cell[size, size];
            m_NeighbourLists = new List<Vector2Int>[size, size];
        
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    Vector2Int coordinate = new Vector2Int(i, j);
                
                    //Set cells;
                    m_Cells[i, j] = new Cell(null, 0);

                    //Set neighbours;
                    {
                        List<Vector2Int> neighbours = new List<Vector2Int>();
                        foreach (var offset in neighbourOffsets)
                        {
                            neighbours.Add(Helpers.GetWrappedCoordinate(coordinate + offset, size));
                        }
                        m_NeighbourLists[i, j] = neighbours;
                    }
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
