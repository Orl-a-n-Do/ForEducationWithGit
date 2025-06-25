using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridExample : MonoBehaviour
{
    private void Awake()
    {
        Dictionary<Vector2Int, Cell> cells = new Dictionary<Vector2Int, Cell>() // Лист это ссылочный тип
        {
            {new Vector2Int(0, 0),new Cell()},
            {new Vector2Int(0, 0),new Cell()},
            {new Vector2Int(0, 0),new Cell()},
            {new Vector2Int(0, 0),new Cell()},
            {new Vector2Int(0, 0),new Cell()},
            {new Vector2Int(0, 0),new Cell()}
        };

        GridCells grid = new GridCells(cells);

    }





}
