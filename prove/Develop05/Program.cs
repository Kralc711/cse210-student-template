using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>();

        // Creating instances of Square, Rectangle, and Circle
        Square square = new Square("Red", 5);
        Rectangle rectangle = new Rectangle("Green", 4, 6);
        Circle circle = new Circle("Blue", 3);

        // Adding shapes to the list
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        // Iterating through the list and displaying color and area of each shape
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape color: {shape.Color}");
            Console.WriteLine($"Shape area: {shape.GetArea()}");
            Console.WriteLine();
        }
    }
}
