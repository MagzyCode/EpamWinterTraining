using EpamWinterTraining.Figures;
using EpamWinterTraining.Figures.FigureBasis;
using EpamWinterTraining.Figures.SpecificFigures;
using System;
using System.Collections.Generic;
using System.Text;

namespace EpamWinterTraining.Xml
{
    public static class XmlParser
    {
        public const int MAX_ELEMENTS_IN_BLOCK = 20;

        /// <summary>
        /// Converts a list of properties in text format to a shape object.
        /// </summary>
        /// <param name="properies">Shape properties.</param>
        /// <returns>Parsed figure.</returns>
        public static IFigure FigureParse(string[] properies)
        {
            Point[] points = GetPoints(properies[1]);
            var figureColor = (FigureColor)Enum.Parse(typeof(FigureColor), properies[2]);
            var colorable = (StainAbility)Enum.Parse(typeof(StainAbility), properies[3]);
            var material = GetMaterialFromColor(figureColor, colorable);

            var result = GetSpecificFigure(points, figureColor, properies[0], material);
            return result;
        }

        /// <summary>
        /// Gets the original shape material based on the shape's color and coloring ability.
        /// </summary>
        /// <param name="color">Figure color.</param>
        /// <param name="colorable">Ability to stain.</param>
        /// <returns></returns>
        public static FigureMaterial GetMaterialFromColor(FigureColor color, StainAbility colorable)
        {
            if (color == FigureColor.Transparent)
            {
                return FigureMaterial.Film;
            }
            else if(colorable == StainAbility.CanDrawAlways)
            {
                return FigureMaterial.Plastic;
            }
            else
            {
                return FigureMaterial.Paper;
            }

        }

        public static IFigure GetSpecificFigure(Point[] points, FigureColor color,
                string type, FigureMaterial material) => type switch
        {
            "Oval" => new Oval(material, points) { ColorOfFigure = color },
            "Polygon" => new Polygon(material, points) { ColorOfFigure = color },
            _ => throw new Exception()
        };

        private static Point[] GetPoints(string points)
        {
            string[] figurePoints = points.Split(',');
            List<Point> listOfPoints = new List<Point>();

            for (int counter = 0; counter < figurePoints.Length; counter += 2)
            {
                var firstNumber = Convert.ToDouble(figurePoints[counter]);
                var secondNumber = Convert.ToDouble(figurePoints[counter + 1]);
                listOfPoints.Add(new Point(firstNumber, secondNumber));
            }
            Point[] arrayOfPoints = listOfPoints.ToArray();
            return arrayOfPoints;
        }
    }
}
