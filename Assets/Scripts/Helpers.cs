using UnityEngine;

public static class Helpers
{
    public static Vector2Int GetWrappedCoordinate(Vector2Int coordinate, int canvasSize)
    {
        return new Vector2Int(
            Mod(coordinate.x, canvasSize),
            Mod(coordinate.y, canvasSize)
        );
    }
    
    public static int Mod(int x, int m) {
        return (x%m + m)%m;
    }
}