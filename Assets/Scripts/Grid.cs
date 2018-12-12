using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public List<Cell> cells; public Vector3 originPoint;

    public Vector3 dimensions;
    public Vector3 cellSize;
    public Vector3 cellPadding;
    public Vector3 offsetFromOrigin;

    public bool is3D = false;


    public Grid(Vector3 startingPoint, Vector3 numberOfCells, Vector3 sizeOfCells, bool threeDimensional)
    {
        originPoint = startingPoint;
        dimensions = numberOfCells;
        cellSize = sizeOfCells;
        is3D = threeDimensional;
        cellPadding = Vector3.zero;
        offsetFromOrigin = Vector3.zero;

        for (var r = 0; r < numberOfCells.x; r++)
        {
            for (var c = 0; c < numberOfCells.y; c++)
            {
                for (var p = 0; p < numberOfCells.z; p++)
                {
                    Cell cell = new Cell(this, new Vector3(r, c, p));
                    cells.Add(cell);
                }
            }
        }
    }
    public Grid(Vector3 startingPoint, Vector3 numberOfCells, Vector3 sizeOfCells, bool threeDimensional,
                Vector3 padding, Vector3 paddingfromOrigin)
    {
        originPoint = startingPoint;
        dimensions = numberOfCells;
        cellSize = sizeOfCells;
        is3D = threeDimensional;
        cellPadding = padding;
        offsetFromOrigin = paddingfromOrigin;

        for (var r = 0; r < dimensions.x; r++)
        {
            for (var c = 0; c < dimensions.y; c++)
            {
                for (var p = 0; p < dimensions.z; p++)
                {
                    Cell cell = new Cell(this, new Vector3(r, c, p));
                    cells.Add(cell);
                }
            }
        }
    }
    public Grid(Grid grid)
    {
        originPoint = grid.originPoint;
        dimensions = grid.dimensions;
        cellSize = grid.cellSize;
        is3D = grid.is3D;
        cellPadding = grid.cellPadding;
        offsetFromOrigin = grid.offsetFromOrigin;

        for (var r = 0; r < dimensions.x; r++)
        {
            for (var c = 0; c < dimensions.y; c++)
            {
                for (var p = 0; p < dimensions.z; p++)
                {
                    Cell cell = new Cell(this, new Vector3(r, c, p));
                    cells.Add(cell);
                }
            }
        }
    }
}
