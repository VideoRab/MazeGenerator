using MazeGenerator.Enums;
using MazeGenerator.Interfaces;
using System;
using System.Collections.Generic;

namespace MazeGenerator;

public class Map : IMap
{
    private CellType[][][] _map;
    
    public int Width { get; set; }
    public int Height { get; set; }
    public int Depth { get; set; }
    
    public Map(int width, int height, int depth)
    {
        Width = width;
        Height = height;
        Depth = depth;

        _map = new CellType[depth][][];
    }

    public void FillMap(CellType cellType)
    {
        for (int z = 0; z < Depth; z++)
        {
            CellType[][] layer = new CellType[Height][];
            for (int y = 0; y < Height; y++)
            {
                CellType[] row = new CellType[Width];
                Array.Fill(row, cellType);

                layer[y] = row;
            }

            _map[z] = layer;
        }
    }

    public void SetCellType(Point point, CellType cellType)
    {
        this[point] = cellType;
    }
    
    public void SetCellType(IList<Point> points, CellType cellType)
    {
        foreach (var point in points)
        {
            this[point] = cellType;
        }
    }

    public CellType GetCellType(Point point)
    {
        return this[point];
    }

    public CellType[][] GetLayer(int index)
    {
        if (index >= Depth)
        {
            throw new IndexOutOfRangeException("Layer does not exist!");
        }
        
        return _map[index];
    }

    public bool OnMap(Point point)
    {
        return point.X >= 0
               && point.X < Width
               && point.Y >= 0
               && point.Y < Height
               && point.Z >= 0
               && point.Z < Depth; 
    }

    private CellType this[Point point]
    {
        get => _map[point.Z][point.Y][point.X];
        set => _map[point.Z][point.Y][point.X] = value;
    }
}