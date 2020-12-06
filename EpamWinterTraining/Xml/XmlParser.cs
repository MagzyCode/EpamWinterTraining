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
        public static IFigure FigureParse(string type, string points, string color)
        {
            var figurePoints = points.Split(',');
            List<Point> listOfPoints = new List<Point>();

            for (int counter = 0; counter < figurePoints.Length; counter += 2)
            {
                var firstNumber = Convert.ToDouble(figurePoints[counter]);
                var secondNumber = Convert.ToDouble(figurePoints[counter + 1]);
                listOfPoints.Add(new Point(firstNumber, secondNumber));
            }
            var arrayOfPoints = listOfPoints.ToArray();

            var figureColor = (FigureColor)Enum.Parse(typeof(FigureColor), color);
            var material = XmlParser.GetMaterialFromColor(figureColor);

            var result = GetSpecificFigure(arrayOfPoints, figureColor, type, material);
            return result;
        }

        public static FigureMaterial GetMaterialFromColor(FigureColor color) => color switch
        {
            FigureColor.Transparent => FigureMaterial.Film,
            _ => FigureMaterial.Paper
        };

        public static IFigure GetSpecificFigure(Point[] points, FigureColor color,
                string type, FigureMaterial material) => type switch
                {
                    // "Circle" => new Circle(material, points) { ColorOfFigure = color },
                    "Oval" => new Oval(material, points) { ColorOfFigure = color },
                    "Polygon" => new Polygon(material, points) { ColorOfFigure = color },
                    _ => throw new Exception()
                };
    }
}
