using EpamWinterTraining.Figures.FigureBasis;
using NUnit.Framework;

namespace TestThirdTask
{
    public class TestPoint
    {
        [TestCase(new double[] { 1, 2, 3, 4}, ExpectedResult = 2)]
        [TestCase(new double[] { -1, -2, -3, -4 }, ExpectedResult = 2)]
        [TestCase(new double[] { 1, 2, 3, 4, -5, -6}, ExpectedResult = 3)]
        [TestCase(new double[] { 1, 2, 3, 4, -5 }, ExpectedResult = 0)]
        public int TestGetPointsFromArray(double[] values)
        {
            try
            {
                int result = Point.GetPointsFromArray(values).Length;
                return result;
            }
            catch
            {
                return 0;
            }
            
        }

        [TestCase(new double[] { 1, 2, 3, 4 }, 2, 2, ExpectedResult = true)]
        [TestCase(new double[] { 11, -2, 358.98, 25.4 }, 347.98, 27.4, ExpectedResult = true)]
        public bool TestGetDifferenceOfAxis(double[] values, double xAxis, double yAxis)
        {
            var points = Point.GetPointsFromArray(values);
            var (xDifference, yDifference) = Point.GetDifferenceOfAxis(points[0], points[1]);
            var result = (xDifference == xAxis) && (yDifference == yAxis);
            return result;
        }

        [TestCase(new double[] { 1, 2, 3, 4 }, ExpectedResult = 2.8284271247461903)]
        [TestCase(new double[] { 11, -2, 358.98, 25.4 }, ExpectedResult = 349.0570732702605)]
        public double TestGetLengthBetweenPoints(double[] values)
        {
            var points = Point.GetPointsFromArray(values);
            var result = Point.GetLengthBetweenPoints(points[0], points[1]);
            return result;
        }

        [TestCase(new double[] { 1, 2, 3, 4 }, ExpectedResult = false)]
        [TestCase(new double[] { 11, -2, 358.98, 25.4 }, ExpectedResult = false)]
        [TestCase(new double[] { 4, 4, 4, 4 }, ExpectedResult = true)]
        [TestCase(new double[] { -1, 1, -1, 1 }, ExpectedResult = true)]
        public bool TestEqualityOperator(double[] values)
        {
            var points = Point.GetPointsFromArray(values);
            var result = points[0] == points[1];
            return result;
        }
    }
}
