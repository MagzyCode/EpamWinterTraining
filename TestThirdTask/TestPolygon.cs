using EpamWinterTraining.Figures.FigureBasis;
using EpamWinterTraining.Figures.SpecificFigures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestThirdTask
{
    public class TestPolygon
    {
        [TestCase(new double[] { 0, 0, 5, 5, 5, 0 }, ExpectedResult = 12.5)]
        [TestCase(new double[] { 0, 0, 5, 5, 0, 5 }, ExpectedResult = 12.5)]
        [TestCase(new double[] { -8.7, -4, 0, 93, 3, -1 }, ExpectedResult = 554.39999999999998)]
        [TestCase(new double[] { 0, 0, 0, 5, 5, 5, 5, 0 }, ExpectedResult = 25)]
        [TestCase(new double[] {3, 3, 4, 1, 3, -2, -2, -2, -5, 0, -2, 4 }, ExpectedResult = 28.5)]
        public double TestGetArea(double[] values)
        {
            var points = Point.GetPointsFromArray(values);
            var polygon = new Polygon(FigureMaterial.Paper, points);
            return polygon.GetArea();
        }

        [TestCase(new double[] { 0, 0, 5, 5, 5, 0 }, ExpectedResult = 17.071067811865476)]
        [TestCase(new double[] { 0, 0, 5, 5, 0, 5 }, ExpectedResult = 17.071067811865476)]
        [TestCase(new double[] { -8.7, -4, 0, 93, 3, -1 }, ExpectedResult = 203.51572657683883)]
        [TestCase(new double[] { 0, 0, 0, 5, 5, 5, 5, 0 }, ExpectedResult = 20)]
        [TestCase(new double[] { 3, 3, 4, 1, 3, -2, -2, -2, -5, 0, -2, 4 }, ExpectedResult = 24.102916426724942)]
        public double TestGetPerimeter(double[] values)
        {
            var points = Point.GetPointsFromArray(values);
            var polygon = new Polygon(FigureMaterial.Paper, points);
            return polygon.GetPerimeter();
        }
    }
}
