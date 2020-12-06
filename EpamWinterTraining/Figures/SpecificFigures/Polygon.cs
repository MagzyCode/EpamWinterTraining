using EpamWinterTraining.Figures.FigureBasis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EpamWinterTraining.Figures.SpecificFigures
{
    public class Polygon : Figure, IFigure
    {
        public const int NUMBER_OF_MINIMUM_POINTS = 3;


        public Polygon(IFigure figure, Point[] points) : base(figure, points)
        {
            CheckNumberOfPoints(points);
        }

        /// <summary>
        /// Инициализирует объект типа Polygon, использую значение вершин n-угольника.
        /// </summary>
        /// <param name="points">Значения вершин n-угольника.</param>
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
            return result;
        }

        public override double GetPerimeter()
        {
            double perimeter = _sideSizes.Sum();
            return perimeter;
        }

        /// <summary>
        /// Метод, проверяющий можно ли создать объект
        /// типа Polynom. В случае невозможности создания 
        /// объкта вызывается исключение Exception.
        /// </summary>
        /// <param name="points">Точки многоугольник.</param>
        private void CheckNumberOfPoints(Point[] points)
        {
            if (points.Length < NUMBER_OF_MINIMUM_POINTS)
            {
                throw new Exception();
            }
        }
    }
}
