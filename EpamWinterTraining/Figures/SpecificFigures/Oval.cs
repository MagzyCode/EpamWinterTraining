

using EpamWinterTraining.Figures.FigureBasis;
using System;

namespace EpamWinterTraining.Figures.SpecificFigures
{
    public class Oval : Figure, IFigure
    {
        private readonly double _smallDiameter;
        private readonly double _bigDiameter;

        public Oval(IFigure figure, Point[] points) : base(figure, points)
        { }

        /// <summary>
        /// Конструктор создания фигуры "Овал", использую массив точек и материал.
        /// </summary>
        /// <param name="material">Материал фигуры.</param>
        /// <param name="points">Точки прямоугольника, в который вписывается овал.</param>
        public Oval(FigureMaterial material, Point[] points) : base(points, material)
        {
            _bigDiameter = SideSizes[0];
            _smallDiameter = SideSizes[1];
        }

        /// <summary>
        /// Конструктор создания овала, использующий центральную 
        /// точку, значения перпендикулярных радиусов и материал.
        /// </summary>
        /// <param name="material">Материал фигуры./param>
        /// <param name="centerPoint">Точка-центр овала.</param>
        /// <param name="smallRadius">Малый радиус овала.</param>
        /// <param name="bigRadius">Большой радиус овала.</param>
        public Oval(FigureMaterial material, Point centerPoint, double smallRadius, double bigRadius)
                : base(material)
        {
            Points = new Point[] { centerPoint };
            _smallDiameter = smallRadius;
            _bigDiameter = bigRadius;
            _sideSizes = new double[] { _smallDiameter, _bigDiameter };
        }

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
        /// Преобразует значения точек в свойстве Points в малый и большой радиусы овала.
        /// </summary>
        /// <returns>Возвращает массив сторон(диаметров) овала.</returns>
        public override double[] GetSideSizesFromPoints()
        {
            var (xDifferenct, yDifference) = (_bigDiameter, _smallDiameter);
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
