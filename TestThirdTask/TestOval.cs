using EpamWinterTraining.Figures.FigureBasis;
using EpamWinterTraining.Figures.SpecificFigures;
using NUnit.Framework;

namespace TestThirdTask
{
    public class TestOval
    {
        [TestCase(new double[] { 0, 0, 5, 5 }, ExpectedResult = true)]
        [TestCase(new double[] { -5, -5, 5, 5 }, ExpectedResult = true)]
        [TestCase(new double[] { 0, 0, 0, 0 }, ExpectedResult = true)]
        [TestCase(new double[] { 0, 0, 4, 5 }, ExpectedResult = false)]
        public bool TestIsFigureCircle(double[] values)
        {
            var points = Point.GetPointsFromArray(values);
            var oval = new Oval(FigureMaterial.Paper, points);
            return oval.IsFigureCircle();
        }

        [TestCase(new double[] { 0, 0, 5, 5 }, ExpectedResult = 78.539816339744831)]
        [TestCase(new double[] { -5, -5, 5, 5 }, ExpectedResult = 314.15926535897933)]
        [TestCase(new double[] { 0, 0, 0, 0 }, ExpectedResult = 0)]
        [TestCase(new double[] { 0, 0, 4, 5 }, ExpectedResult = 62.831853071795862)]
        public double TestGetArea(double[] values)
        {
            var points = Point.GetPointsFromArray(values);
            var oval = new Oval(FigureMaterial.Paper, points);
            return oval.GetArea();
        }

        [TestCase(new double[] { 0, 0, 5, 5 }, ExpectedResult = 15.707963267948966)]
        [TestCase(new double[] { -5, -5, 5, 5 }, ExpectedResult = 31.415926535897931)]
        [TestCase(new double[] { 0, 0, 0, 0 }, ExpectedResult = 0)]
        [TestCase(new double[] { 0, 0, 4, 5 }, ExpectedResult = 14.224165712699351)]
        public double TestGetPerimeter(double[] values)
        {
            var points = Point.GetPointsFromArray(values);
            var oval = new Oval(FigureMaterial.Paper, points);
            return oval.GetPerimeter();
        }

       
    }
}
