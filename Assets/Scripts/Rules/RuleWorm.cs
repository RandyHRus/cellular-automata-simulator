using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Chemicals;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

/*
public class RuleWorm
{
    private Chemical trailingChemical;
    private int viewRadius;
    
    public RuleWorm(Chemical trailingChemical, int viewRadius)
    {
        this.trailingChemical = trailingChemical;
        this.viewRadius = viewRadius;
    }
    
    public List<Tuple<Vector2Int, Cell>> GetNextGenerationCells(CellsCanvas canvas, Vector2Int coordinate, Cell cell)
    {
        List<Vector2> scaledDirectionsToObstacles = new List<Vector2>();
        
        for (var x = coordinate.x - viewRadius; x <= (coordinate.x + viewRadius); x++)
        {
            for (var y = coordinate.y - viewRadius; y <= (coordinate.y + viewRadius); y++)
            {
                var checkCoordinate = new Vector2Int(x, y);
                var distance = Vector2.Distance(coordinate, checkCoordinate);
                if (distance <= viewRadius)
                {
                    Vector2 vectorToObstacle = coordinate + checkCoordinate;
                    Vector2 normalizedVector = Vector3.Normalize(vectorToObstacle);
                    Vector2 scaledVector = normalizedVector / distance;
                    scaledDirectionsToObstacles.Add(scaledVector);
                }
            }
        }

        Vector2 averageDirection = Vector2.zero;
        for (var i = 0; i < scaledDirectionsToObstacles.Count; i++)
        {
            averageDirection += scaledDirectionsToObstacles[i];
        }

        averageDirection = -averageDirection;
        throw new NotImplementedException("Rule worm is not implemented");
    }
}
*/
