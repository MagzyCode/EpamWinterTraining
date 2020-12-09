using EpamWinterTraining.Figures.FigureBasis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EpamWinterTraining.Figures.SpecificFigures
{
    public class Polygon : Figure, IFigure
    {
        /// <summary>
        /// Minimum number of points to create a polygon.
        /// </summary>
        public const int NUMBER_OF_MINIMUM_POINTS = 3;


        public Polygon(IFigure figure, Point[] points) : base(figure, points)
        {
            CheckNumberOfPoints(points);
        }

        /// <summary>
        /// Initializes an object of the Polygon type using the value of the n-gon vertices.
        /// </summary>
        /// <param name="points">Values of the vertices of the n-gon.</param>
        public Polygon(FigureMaterial material, Point[] points) : base(points, material)
        {
            CheckNumberOfPoints(points);
        }


        public override double GetArea()
        {
            List<double> xValues = _points.Select(i => i.X).
                Concat(new List<double>() { _points[0].X }).
                ToList();
            List<double> yValues = _points.Select(i => i.Y).
                Concat(new List<double>() { _points[0].Y }).
                ToList();
            var firstCalculation = xValues.
                Take(xValues.Count - 1).
                Select(i => i * yValues[xValues.IndexOf(i) + 1]).
                Sum();
            var secondCalculation = yValues.
                Take(yValues.Count - 1).
                Select(i => i * xValues[yValues.IndexOf(i) + 1]).
                Sum();
            var result = (firstCalculation - secondCalculation) / 2;
            result = Math.Abs(result);
            return result;
        }

        public override double GetPerimeter()
        {
            double perimeter = _sideSizes.Sum();
            return perimeter;
        }

        /// <summary>
        /// Method that checks whether a poly-Dom object can be created. If the object cannot be created, an Exception is thrown.
        /// </summary>
        /// <param name="points">Polygon points.</param>
        private void CheckNumberOfPoints(Point[] points)
        {
            if (points.Length < NUMBER_OF_MINIMUM_POINTS)
            {
                throw new Exception();
            }
        }
    }
}
