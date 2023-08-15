using System.Collections.Generic;

namespace MazeGenerator.Interfaces;

public interface IMouse
{
    Point GetCurrentPosition();
    IList<Point> LookAround();
    Point ChooseDirection(IList<Point> directions);
    IList<Point> MakeSteps(Point direction);
    IList<Point> MakeStepsBack();
    bool IsFinished();
}