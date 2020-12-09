using System;
using System.Collections.Generic;

namespace EpamWinterTraining.Figures.FigureBasis
{
    /// <summary>
    /// Represents a point in the plane of the sheet from which the shapes are cut.
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// Constructor for creating a "point" in the plane with the specified x and y values, respectively.
        /// </summary>
        /// <param name="xPoint">The value of the point relative to the OX axis.</param>
        /// <param name="yPoint">The value of the point relative to the OY axis.</param>
        public Point(double xPoint, double yPoint)
        {
            X = xPoint;
            Y = yPoint;
        }

        // <summary>
        /// Value of the point on the OX axis.
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Value of the point on the OY axis.
        /// </summary>
        public double Y { get; set; }

        public override int GetHashCode()
        {
            return HashCode.Combine(this);
        }

        public override bool Equals(object obj)
        {
            if (obj is Point point && this == point)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{X},{Y}";
        }

        /// <summary>
        /// Static method for creating an array of points from an array of x and y values. 
        /// If the array contains an odd or zero number of coordinates, an Exception will be 
        /// thrown with the corresponding message.
        /// </summary>
        /// <param name="values">Array of coordinates of points, each pair of values is a point.</param>
        /// <returns>Returns an array of points.</returns>
        public static Point[] GetPointsFromArray(double[] values)
        {
            if ((values.Length == 0) || (values.Length % 2 == 1))
            {
                throw new Exception("Невозможно преобразовать данные в массив точек.");
            }

            var list = new List<Point>(values.Length / 2);
            for (int counter = 0; counter < values.Length; counter += 2)
            {
                list.Add(new Point(values[counter], values[counter + 1]));
            }
            var points = list.ToArray();
            return points;
        }

        /// <summary>
        /// Method for obtaining the modulus of the difference between the ox and OY axes between points.
        /// </summary>
        /// <param name="first">The first point.</param>
        /// <param name="second">Second point.</param>
        /// <returns>Returns the value of the difference between the axes of two points.</returns>
        public static (double xDifference, double yDifference) GetDifferenceOfAxis(Point first, Point second)
        {
            var yDifference = Math.Abs(first.Y - second.Y);
            var xDifference = Math.Abs(first.X - second.X);
            return (xDifference, yDifference);
        }


        /// <summary>
        /// Gets the distance between two points in space.
        /// </summary>
        /// <param name="startPoint">The starting point of the segment.</param>
        /// <param name="finishPoint">The end point of the segment.</param>
        /// <returns>Returns the distance between points.</returns>
        public static double GetLengthBetweenPoints(Point startPoint, Point finishPoint)
        {
            var (xDifferenct, yDifference) = GetDifferenceOfAxis(startPoint, finishPoint);
            var side = Math.Pow(xDifferenct * xDifferenct + yDifference * yDifference, 0.5);
            return side;
        }

        /// <summary>
        /// Operator for comparing two points. The comparison is based on the values on the ox and OY axes.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Returns true if the values on the ox and OY axes are equal. In this case, false is returned.</returns>
        public static bool operator ==(Point left, Point right)
        {
            if ((left.X == right.X) && (left.Y == right.Y))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }
    }
}
