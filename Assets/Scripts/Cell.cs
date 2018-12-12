using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Cell
{
    public int ID
    {
        get
        {
            return ID;
        }
        private set
        {
            ID = value;
        }
    }
    /// <summary>
    /// The row, column, and zplane of the cell.
    /// </summary>
    public Vector3 coords
    {
        get
        {
            return coords;
        }
        private set
        {
            coords = value;
        }
    }
    public Grid grid
    {
        get
        {
            return grid;
        }
        private set
        {
            grid = value;
        }
    }
    /// <summary>
    /// The worldspace position of the cell based on the grid specifications
    /// </summary>
    public Vector3 position
    {
        get
        {
            return position;
        }
        private set
        {
            position = value;
        }
    }


    public Cell(Grid parentGrid, Vector3 coordinations)
    {
        grid = parentGrid;
        coords = coordinations;
        ID = Mathf.RoundToInt(coords.y + (coords.x * grid.dimensions.y) + (coords.z * grid.dimensions.x * grid.dimensions.y));

        position = new Vector3(grid.originPoint.x + (grid.cellSize.x * coords.x) + grid.cellPadding.x,
                             grid.originPoint.y + (grid.cellSize.y * coords.y) + grid.cellPadding.y,
                             grid.originPoint.z + (grid.cellSize.z * coords.z) + grid.cellPadding.z);
    }

}
