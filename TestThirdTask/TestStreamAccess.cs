using EpamWinterTraining.Figures;
using EpamWinterTraining.Figures.FigureBasis;
using EpamWinterTraining.Figures.SpecificFigures;
using EpamWinterTraining.Xml;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TestThirdTask
{
    public class TestStreamAccess
    {
        private static Point[] points = new Point[]
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
            new Point(6, -8)
        };

        private static readonly IFigure[] figures = new IFigure[]
        {
            new Oval (FigureMaterial.Film, new Point[] { points[0], points[7]}),
            new Oval (FigureMaterial.Paper, new Point[] { points[0], points[8]}),
            new Oval (FigureMaterial.Plastic, new Point[] { points[6], points[9] }),
            new Oval (FigureMaterial.Plastic, new Point[] { points[10], points[2] }),
            new Polygon (FigureMaterial.Film, new Point[] {points[0], points[3], points[4]}),
            new Polygon (FigureMaterial.Paper, new Point[] {points[2], points[3], points[5], points[6], points[10]}),
            new Polygon (FigureMaterial.Plastic, new Point[] { points[0], points[8], points[9] }),
            new Polygon (FigureMaterial.Film, new Point[] {points[0], points[1], points[2], points[10], points[11]}),
        };

        [TestCase(ExpectedResult = 8)]
        public int TestSaveAll()
        {
            StreamAccess.Save(figures);
            var data = File.ReadAllText(StreamAccess.myPath);
            var figuresCount = Regex.Matches(data, "points").Count;
            return figuresCount;
        }

        [TestCase(FigureMaterial.Film, ExpectedResult = 3)]
        [TestCase(FigureMaterial.Paper, ExpectedResult = 2)]
        [TestCase(FigureMaterial.Plastic, ExpectedResult = 3)]
        public int TestSaveMaterial(FigureMaterial material)
        {
            StreamAccess.Save(figures, material);
            var data = File.ReadAllText(StreamAccess.myPath);
            var figuresCount = Regex.Matches(data, "points").Count;
            return figuresCount;
        }

        [TestCase(ExpectedResult = 8)]
        public int LoadFile()
        {
            StreamAccess.Save(figures);
            var result = StreamAccess.LoadFile();
            return result.Where(i => i != null).Count();
        }
    }
}
