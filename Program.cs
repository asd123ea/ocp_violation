using System;
using System.Collections;
using System.Collections.Generic;

namespace OCP_Shape_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapes = new List<Shape>(){
                new Square(),
                new Circle(),
                new Triangle()
            };

            Program.DrawAllShapes(shapes);
        }

        public static void DrawAllShapes(List<Shape> shapes){
            IComparer comparer = new ShapeComparer();
            var arr = shapes.ToArray();
            Array.Sort(arr, comparer);
            foreach (var shape in arr)
                shape.Draw();
        }
    }

    public interface Shape {
        void Draw();
    }

    public class ShapeComparer : IComparer
    {
        Hashtable priorities = new Hashtable();

        public ShapeComparer()
        {
            priorities.Add(typeof(Triangle), 0);
            priorities.Add(typeof(Circle), 1);
            priorities.Add(typeof(Square), 2);
        }

        public int Compare(object x, object y)
        {
            var p1 = PriorityFor(x.GetType());
            var p2 = PriorityFor(y.GetType());
            return p1.CompareTo(p2);
        }

        public int PriorityFor(Type type){
            if (priorities.Contains(type))
                return (int)priorities[type];
            return 0;
        }
    }

    public class Square : Shape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing Square");
        }
    }

    public class Circle : Shape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing Circle");
        }
    }

    public class Triangle : Shape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing Triangle");
        }
    }
}
