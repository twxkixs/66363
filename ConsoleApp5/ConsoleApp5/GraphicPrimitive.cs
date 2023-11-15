using System;
using System.Collections.Generic;

public abstract class GraphicPrimitive
{
    public int X { get; set; }
    public int Y { get; set; }

    public abstract void Draw();
    public abstract void Move(int x, int y);
    public abstract void Scale(float factor);
}

public class Circle : GraphicPrimitive
{
    public int Radius { get; set; }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Circle at ({X}, {Y}) with radius {Radius}");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public override void Scale(float factor)
    {
        Radius = (int)(Radius * factor);
    }
}

public class Rectangle : GraphicPrimitive
{
    public int Width { get; set; }
    public int Height { get; set; }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Rectangle at ({X}, {Y}) with width {Width} and height {Height}");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public override void Scale(float factor)
    {
        Width = (int)(Width * factor);
        Height = (int)(Height * factor);
    }
}

public class Triangle : GraphicPrimitive
{
    public override void Draw()
    {
        Console.WriteLine($"Drawing Triangle at ({X}, {Y})");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public override void Scale(float factor)
    {
        
    }
}


public class Group : GraphicPrimitive
{
    private List<GraphicPrimitive> primitives;

    public Group()
    {
        primitives = new List<GraphicPrimitive>();
    }

    public void AddPrimitive(GraphicPrimitive primitive)
    {
        primitives.Add(primitive);
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Group at ({X}, {Y})");
        foreach (var primitive in primitives)
        {
            primitive.Draw();
        }
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
        foreach (var primitive in primitives)
        {
            primitive.Move(x, y);
        }
    }

    public override void Scale(float factor)
    {
        foreach (var primitive in primitives)
        {
            primitive.Scale(factor);
        }
    }
}

public class GraphicsEditor
{
    private List<GraphicPrimitive> primitives;

    public GraphicsEditor()
    {
        primitives = new List<GraphicPrimitive>();
    }

    public void AddPrimitive(GraphicPrimitive primitive)
    {
        primitives.Add(primitive);
    }

    public void DrawAllPrimitives()
    {
        foreach (var primitive in primitives)
        {
            primitive.Draw();
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        GraphicsEditor editor = new GraphicsEditor();

        Circle circle = new Circle { X = 10, Y = 20, Radius = 5 };
        Rectangle rectangle = new Rectangle { X = 30, Y = 40, Width = 10, Height = 15 };
        Triangle triangle = new Triangle { X = 50, Y = 60 };

        Group group = new Group();
        group.AddPrimitive(circle);
        group.AddPrimitive(rectangle);

        editor.AddPrimitive(circle);
        editor.AddPrimitive(rectangle);
        editor.AddPrimitive(triangle);
        editor.AddPrimitive(group);

        editor.DrawAllPrimitives();

        
    }
}
