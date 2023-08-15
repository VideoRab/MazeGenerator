using MazeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeGenerator;

public class Mouse : IMouse
{
    private Stack<Point> _memory;

    public Mouse(Point startPosition)
    {
        _memory = new Stack<Point>();
        _memory.Push(startPosition);
    }

    public Point GetCurrentPosition()
    {
        return _memory.Peek();
    }

    public IList<Point> LookAround()
    {
        IList<Point> directions = new List<Point>()
        {
            new Point(1),
            new Point(-1),
            new Point(y: 1),
            new Point(y: -1),
            new Point(z: 1),
            new Point(z: -1)
        };

        return directions;
    }

    public Point ChooseDirection(IList<Point> directions)
    {
        Random random = new Random();
        return directions[random.Next(0, directions.Count())];
    }

    public IList<Point> MakeSteps(Point direction)
    {
        IList<Point> route = new List<Point>();
        
        Point position = _memory.Peek();
        for (int i = 0; i < 2; i++)
        {
            position += direction;
            _memory.Push(position);
            
            route.Add(position);
        }

        return route;
    }

    public IList<Point> MakeStepsBack()
    {
        IList<Point> route = new List<Point>();

        if (_memory.Count() >= 2)
        {
            route.Add(_memory.Pop());
            route.Add(_memory.Pop());
        }
        
        return route;
    }

    public bool IsFinished()
    {
        return _memory.Count() <= 2;
    }
}