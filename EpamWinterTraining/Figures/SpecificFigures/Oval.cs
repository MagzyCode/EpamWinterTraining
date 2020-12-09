

using EpamWinterTraining.Figures.FigureBasis;
using System;

namespace EpamWinterTraining.Figures.SpecificFigures
{
    public class Oval : Figure, IFigure
    {
        /// <summary>
        /// Represents the minor diameter of the oval.
        /// </summary>
        private readonly double _smallDiameter;
        /// <summary>
        /// Is a larger diameter of the oval.
        /// </summary>
        private readonly double _bigDiameter;

        public Oval(IFigure figure, Point[] points) : base(figure, points)
        { }

        /// <summary>
        /// Constructor for creating an "Oval" shape, using an array of points and a material.
        /// </summary>
        /// <param name="material">Shape material.</param>
        /// <param name="points">Points of the rectangle that the oval fits into.</param>
        public Oval(FigureMaterial material, Point[] points) : base(points, material)
        {
            _bigDiameter = SideSizes[0];
            _smallDiameter = SideSizes[1];
        }

        /// <summary>
        /// Indicates whether the oval is a circle.
        /// </summary>
        /// <returns></returns>
        public bool IsFigureCircle()
        {
            var result = _bigDiameter == _smallDiameter;
            return result;
        }

        public override double GetArea()
        {
            var area = Math.PI * _smallDiameter * _bigDiameter;
            return area;
        }

        public override double GetPerimeter()
        {
            var rootPartOfFormula = (_bigDiameter * _bigDiameter +
                    _smallDiameter * _smallDiameter) / 8;
            var perimeter = 2 * Math.PI * Math.Pow(rootPartOfFormula, 0.5);
            return perimeter;
        }

        /// <summary>
        /// Converts the values of points in the Points property to the small and large radii of the oval.
        /// </summary>
        /// <returns>Returns an array of sides(diameters) of the oval.</returns>
        public override double[] GetSideSizesFromPoints()
        {
            var (xDifferenct, yDifference) = Point.GetDifferenceOfAxis(Points[0], Points[1]);
            if (xDifferenct > yDifference)
            {
                return new double[] { xDifferenct, yDifference };
            }
            else
            {
                return new double[] { yDifference, xDifferenct };
            }
        }

    }
}
