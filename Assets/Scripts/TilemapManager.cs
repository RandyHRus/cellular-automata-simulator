using System.Collections;
using System.Collections.Generic;
using Canvas;
using Chemicals;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    [SerializeField] private TileBase tileBase = null;

    private static Tilemap _tilemap = null;

    private void Awake()
    {
        _tilemap = GameObject.FindWithTag("tilemap1").GetComponent<Tilemap>();

        CanvasManager.onLoadCanvas += OnLoadCanvasHandler;
        CanvasManager.onCellOverwritten += UpdateTile;
    }

    public void OnLoadCanvasHandler(CellsCanvas canvas)
    {
        _tilemap.ClearAllTiles();

        for (var i = 0; i < CanvasManager.currentCanvas.size; i++)
        {
            for (var j = 0; j < CanvasManager.currentCanvas.size; j++)
            {
                Vector3Int vec3Coodinate = new Vector3Int(i, j, 0);
                _tilemap.SetTile(vec3Coodinate, tileBase);
            }
        }
    }

    public void UpdateTile(Vector2Int coordinate)
    {
        Cell c = CanvasManager.currentCanvas.GetCell(coordinate);
        SetTileColor(coordinate, c.GetCellColor());
    }

    public static bool GetMouseTilePosition(out Vector2Int position)
    {
        Vector2 mouseToWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position = new Vector2Int(Mathf.RoundToInt(mouseToWorld.x), Mathf.RoundToInt(mouseToWorld.y));
        return (position.x >= 0 && position.x < CanvasManager.currentCanvas.size) && 
               (position.y >= 0 && position.y < CanvasManager.currentCanvas.size);
    }
    
    private static void SetTileColor(Vector2Int coodinate, Color color)
    {
        var vec3Coords = new Vector3Int(coodinate.x, coodinate.y, 0);
        _tilemap.SetTileFlags(vec3Coords, TileFlags.None);
        _tilemap.SetColor(vec3Coords, color);
    }
}