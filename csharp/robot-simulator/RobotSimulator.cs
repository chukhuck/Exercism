using System;

public enum Direction : int
{
    North = 0,
    East,
    South,
    West
}

public class RobotSimulator
{
    Direction direction;
    int x;
    int y;
    public RobotSimulator(Direction direction, int x, int y)
    {
        this.direction = direction;
        this.x = x;
        this.y = y;
    }

    public Direction Direction => direction;

    public int X => x;

    public int Y => y;

    public void Move(string instructions)
    {
        foreach (var movement in instructions)
            DoMovement(movement);
    }

    private void DoMovement(char movement)
    {
        switch (movement)
        {
            case 'R':
                direction = (Direction)(((int)direction + 1) % 4);
                break;
            case 'L':
                direction = (Direction)(((int)direction - 1) % 4);
                direction = direction < 0 ? direction + 4 : direction;
                break;
            case 'A':
                DoStep(direction);
                break;
            default:
                throw new FormatException("Incorrect command.");
        }
    }

    private void DoStep(Direction direction)
    {
        switch (direction)
        {
            case Direction.East:
                x += 1;
                break;
            case Direction.West:
                x -=1;
                break;
            case Direction.North:
                y += 1;
                break;
            case Direction.South:
                y -= 1;
                break;
            default:
                throw new FormatException("Incorrect direction.");
        }
    }
}