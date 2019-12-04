using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun With Shapes!");
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");

            List<IShape> shapes = new List<IShape>()
            {
                new Circle(4),
                new Rectangle(3.2, 5.9),
                new Square(3),
                new Square(10),
                new Rectangle(2,3),
                new Circle(2),
                new Rectangle(10,10),
                new Circle(8)
            };

            foreach(IShape shape in shapes)
            {
                Console.WriteLine($"Shape with area {shape.Area}");
            }
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");

            IEnumerable<IShape> filteredShapes = shapes.Where(shape => shape.Area > 50);
            Console.WriteLine("Shape with area > 50: ");

            foreach (IShape shape in filteredShapes)
            {
                Console.WriteLine($"Shape with area {shape.Area}");
            }
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");

            IEnumerable<Circle> circles = shapes.OfType<Circle>();
            foreach (Circle circle in circles)
            {
                Console.WriteLine($"Shape with radius {circle.Radius} and area {circle.Area}");
            }
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");

            IEnumerable<Circle> filteredCircles = circles.Where(circle => circle.Area < 70);
            Console.WriteLine("Shape with area < 70: ");
            foreach (Circle circle in filteredCircles)
            {
                Console.WriteLine($"Shape with radius {circle.Radius} and area {circle.Area}");
            }
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");

            Console.WriteLine("combined example:");

            foreach (Circle circle in shapes.OfType<Circle>().Where(c => c.Radius > 3.5))
            {
                Console.WriteLine($"Shape with radius {circle.Radius} and area {circle.Area}");
            }
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");

            Console.WriteLine("Group by Type:");

            var groupedShapes = shapes.GroupBy(shape => shape.GetType());
            foreach(var group in groupedShapes)
            {
                Console.WriteLine($"Shapes of type {group.Key}");
                foreach(IShape shape in group)
                {
                    Console.WriteLine($"Shape of area {shape.Area}");
                }
            }
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");

            var groupedByArea = shapes.GroupBy(shape => shape.Area % 2 == 0);
            foreach(var group in groupedByArea)
            {
                Console.WriteLine(group.Key ? "Even area" : "Odd area");
                foreach(IShape shape in group)
                {
                    Console.WriteLine($"Shape with area {shape.Area}");
                }
            }
            Console.WriteLine("B===D~~~~B===D~~~~B===D~~~~B===D~~~~B===D~~~~B===D~~~~B===D~~~~B===D~~~~"); 

            var maxArea = shapes.Max(shape => shape.Area);
            Console.WriteLine($"Maximum Area is {maxArea}");

            Console.WriteLine("B===D~~~~B===D~~~~B===D~~~~B===D~~~~B===D~~~~B===D~~~~B===D~~~~B===D~~~~");
            var totalArea = shapes.Sum(shape => shape.Area);
            Console.WriteLine($"Total Area is {totalArea}");

            Console.ReadKey();
        }
    }
}
