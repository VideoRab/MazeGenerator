using MazeGenerator.Enums;
using System.Collections.Generic;

namespace MazeGenerator.Interfaces;

public interface IMap
{
    void FillMap(CellType cellType);
    void SetCellType(Point point, CellType cellType);
    void SetCellType(IList<Point> points, CellType cellType);
    CellType GetCellType(Point point);
    CellType[][] GetLayer(int index);    
    bool OnMap(Point point);
}