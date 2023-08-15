using MazeGenerator.Enums;
using MazeGenerator.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MazeGenerator;

public class Generator : IGenerator
{
    private Map _map;
    private readonly IMouse _mouse;

    public Generator(Map map, IMouse mouse)
    {
        _map = map;
        _mouse = mouse;
    }

    public Generator(int width, int height, int depth, Point startPosition)
    {
        _map = new Map(width, height, depth);
        _mouse = new Mouse(startPosition);
    }

    public void BuildMaze()
    {
        _map.FillMap(CellType.Wall);
        _map.SetCellType(_mouse.GetCurrentPosition(), CellType.Empty);

        do
        {
            var directions = _mouse.LookAround();
            var validDirections = GetValidDirections(directions);
            if (validDirections.Count() == 0)
            {
                _mouse.MakeStepsBack();
                continue;
            }

            var chosenDirection = _mouse.ChooseDirection(validDirections);
            var steps = _mouse.MakeSteps(chosenDirection);
            _map.SetCellType(steps, CellType.Empty);
        } while (!_mouse.IsFinished());
    }

    public Map GetMap()
    {
        return _map;
    }

    private IList<Point> GetValidDirections(IList<Point> directions)
    {
        IList<Point> result = new List<Point>();
        
        Point pos = _mouse.GetCurrentPosition();
        foreach (Point dir in directions)
        {
            Point possibleStep = pos + dir * 2;
            if (_map.OnMap(possibleStep)
                && _map.GetCellType(possibleStep) != CellType.Empty)
            {
                result.Add(dir);
            }
        }

        return result;
    }
}