using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square sqr = new Square("Red", 5);
        Rectangle rect = new Rectangle("Green", 3, 5);
        Circle circle = new Circle("Blue", 4);

        shapes.Add(sqr);
        shapes.Add(rect);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"---{shape.GetType()}---\nColor: {shape.GetColor()}\nArea: {shape.GetArea()}\n");
        }
    }
}