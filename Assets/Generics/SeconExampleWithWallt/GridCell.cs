using System.Collections.Generic;
using UnityEngine;

public class GridCells
{
    private Dictionary<Vector2Int, Cell> _cells;

    public GridCells(Dictionary<Vector2Int, Cell> cells)
    {
        _cells = new Dictionary<Vector2Int, Cell>(cells);      
    }

    public IEnumerable<IReadOnlyCell> Cells => _cells.Values;
   
   


}
