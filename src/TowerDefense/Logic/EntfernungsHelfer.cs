using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TowerDefense.Logic
{
    public class EntfernungsHelfer
    {
        public static double ErmittleEntfernung(Point pointA, Point pointB)
        {
            var xLength = Math.Max(pointA.X, pointB.X) - Math.Min(pointA.X, pointB.X);
            var yLength = Math.Max(pointA.Y, pointB.Y) - Math.Min(pointA.Y, pointB.Y);

            return Math.Sqrt(Math.Pow(xLength, 2) + Math.Pow(yLength, 2));
        }
    }
}
