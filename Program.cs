using System;
using System.Collections.Generic;

namespace PointInPolygon
{
    public class PointInPolygon
    {
        public static void Main()
        {
            var triangle = new Polygon
            {
                Vertices = new List<Vertex>
                {
                    new Vertex {X = 0, Y = 0},
                    new Vertex {X = 0, Y = 1},
                    new Vertex {X = 1, Y = 0},
                }
            };

            var square = new Polygon
            {
                Vertices = new List<Vertex>
                {
                    new Vertex {X = 0, Y = 0},
                    new Vertex {X = 0, Y = 1},
                    new Vertex {X = 1, Y = 1},
                    new Vertex {X = 1, Y = 0}
                }
            };

            var trisquare = new Polygon
            {
                Vertices = new List<Vertex>
                {
                    new Vertex {X = 0, Y = 0},
                    new Vertex {X = 0, Y = 1},
                    new Vertex {X = 1, Y = 0},
                    new Vertex {X = 1, Y = 1},
                    new Vertex {X = 0, Y = 1},
                    new Vertex {X = 1, Y = 0},
                }
            };

            var insideAll = new Vertex { X = 0.3f, Y = 0.3f };
            var outsideTriangle = new Vertex { X = 0.9f, Y = 0.9f };

            Console.WriteLine(InPolygon(insideAll, triangle)
                ? "X of 0.3 and Y of 0.3 is inside of vertex triangle"
                : "X of 0.3 and Y of 0.3 is not inside of vertex triangle");

            Console.WriteLine(InPolygon(insideAll, square)
                ? "X of 0.3 and Y of 0.3 is inside of vertex square"
                : "X of 0.3 and Y of 0.3 is not inside of vertex square");

            Console.WriteLine(InPolygon(insideAll, trisquare)
                ? "X of 0.3 and Y of 0.3 is inside of vertex square of two triangles"
                : "X of 0.3 and Y of 0.3 is not inside of vertex square of two triangles");

            Console.WriteLine(InPolygon(outsideTriangle, triangle)
                ? "X of 0.3 and Y of 0.3 is inside of vertex triangle"
                : "X of 0.3 and Y of 0.3 is not inside of vertex triangle");

            Console.WriteLine(InPolygon(outsideTriangle, square)
                ? "X of 0.3 and Y of 0.3 is inside of vertex square"
                : "X of 0.3 and Y of 0.3 is not inside of vertex square");

            Console.WriteLine(InPolygon(outsideTriangle, trisquare)
                ? "X of 0.3 and Y of 0.3 is inside of vertex square of two triangles"
                : "X of 0.3 and Y of 0.3 is not inside of vertex square of two triangles");
        }

        public static bool InPolygon(Vertex vertex, Polygon polygon)
        {
            int numPolygons = polygon.Vertices.Count;
            bool isInsidePolygon = false;

            var i = 0;
            int j = numPolygons - 1;

            for (; i < numPolygons; j = i++)
            {
                if (((polygon.Vertices[i].Y > vertex.Y) !=
                    (polygon.Vertices[j].Y > vertex.Y)) &&
                    (vertex.X < (polygon.Vertices[j].X - polygon.Vertices[i].X) *
                    (vertex.Y - polygon.Vertices[i].Y) / (polygon.Vertices[j].Y - polygon.Vertices[i].Y) +
                    polygon.Vertices[i].X))
                {
                    isInsidePolygon = !isInsidePolygon;  
                }
            }

            return isInsidePolygon;
        }
    }

    public class Vertex
    {
        public float X { get; set; }
        public float Y { get; set; }
    }

    public class Polygon
    {
        public List<Vertex> Vertices { get; set; }
    }
}
