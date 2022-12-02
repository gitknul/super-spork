using System.Drawing;

namespace UdemyCourse.Tests.Models;

public class Fruit
{
    public KnownColor Color { get; init; }
    public Hardness Hardness { get; init; }
    public Shape Shape { get; init; }
}

public enum Hardness
{
    Hard,
    Soft
}

public enum Shape
{
    Round,
    Square,
    Rectangle
}