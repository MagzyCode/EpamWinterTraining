using EpamWinterTraining.Figures;
using EpamWinterTraining.Figures.FigureBasis;
using EpamWinterTraining.Figures.SpecificFigures;
using EpamWinterTraining.FiguresCollection;
using NUnit.Framework;
using System;

namespace TestThirdTask
{
    public class TestBox
    {
        private Box _box;

        [SetUp]
        public void Setup()
        {
            Point[] points = new Point[]
            {
                new Point(-9, -8),
                new Point(-6, -5),
                new Point(-3, -2),
                new Point(-6, 3),
                new Point(-10, 6),
                new Point(-3, 8),
                new Point(3, 3),
                new Point(6, 9),
                new Point(12, 6),
                new Point(7, -1),
                new Point(3, -4),
                new Point(6, -8),
                new Point(0, 0)
            };

            IFigure[] figures = new IFigure[]
            {
                new Oval (FigureMaterial.Film, new Point[] { points[6], points[12]}),
                new Oval (FigureMaterial.Paper, new Point[] { points[0], points[8]}),
                new Oval (FigureMaterial.Plastic, new Point[] { points[6], points[9] }) { ColorOfFigure = FigureColor.Orange},
                new Oval (FigureMaterial.Plastic, new Point[] { points[10], points[2] }),
                new Polygon (FigureMaterial.Film, new Point[] {points[0], points[3], points[4]}),
                new Polygon (FigureMaterial.Paper, new Point[] {points[2], points[3], points[5], points[6], points[10]}),
                new Polygon (FigureMaterial.Plastic, new Point[] { points[0], points[8], points[9] }),
                new Polygon (FigureMaterial.Film, new Point[] {points[0], points[1], points[2], points[10], points[11]}),
            };

            _box = new Box(figures);
        }

        [TestCase(ExpectedResult = 8)]
        public int TestCount()
        {
            return _box.Count;
        }

        [TestCase(ExpectedResult = 2)]
        public int TestGetAllCircles()
        {
            return _box.GetAllCircles().Length;
        }

        [TestCase(ExpectedResult = 3)]
        public int TestGetAllFilmFigures()
        {
            return _box.GetAllFilmFigures().Length;
        }

        [TestCase(ExpectedResult = 2)]
        public int TestGetNotColoredPlasticFigures()
        {
            return _box.GetNotColoredPlasticFigures().Length;
        }

        [TestCase(ExpectedResult = 9)]
        public int TestAddFigure()
        {
            _box.AddFigure(new Oval(FigureMaterial.Film, new Point[]
            {
                new Point(0, 0),
                new Point(1, 1),
            }));
            var result = _box.Count;
            _box.RemoveFigure(result - 1);
            return result;
        }

        [TestCase(7, ExpectedResult = 7)]
        public int TestRemoveFigure(int index)
        {
            var saveElement = _box[index];
            _box.RemoveFigure(index);
            var result = _box.Count;
            _box.AddFigure(saveElement);
            return result;
        }

        [TestCase(typeof(Oval), FigureColor.Black, ExpectedResult = false)]
        [TestCase(typeof(Oval), FigureColor.Orange, ExpectedResult = true)]
        [TestCase(typeof(Oval), FigureColor.PaperDefaultColor, ExpectedResult = true)]
        [TestCase(typeof(Polygon), FigureColor.Black, ExpectedResult = false)]
        [TestCase(typeof(Polygon), FigureColor.Transparent, ExpectedResult = true)]
        [TestCase(typeof(Polygon), FigureColor.PlasticDefaultColor, ExpectedResult = true)]
        public bool TestFind(Type figureType, FigureColor color)
        {
            var figure = _box.Find(figureType, color);
            var result = figure == null ? false : true;
            return result;

        }

        [TestCase(ExpectedResult = 1206.8671683382217)]
        public double TestGetTotalArea()
        {
            return _box.GetTotalArea();
        }

        [TestCase(ExpectedResult = 241.45682786364176)]
        public double TestGetPerimeter()
        {
            return _box.GetTotalPerimeter();
        }


    }
}
