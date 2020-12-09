using EpamWinterTraining.Application.Painting;
using EpamWinterTraining.Figures;
using EpamWinterTraining.Figures.FigureBasis;
using EpamWinterTraining.Figures.SpecificFigures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestThirdTask
{
    public class TestFigurePainting
    {
        [TestCase(FigureMaterial.Paper, FigureColor.Black, ExpectedResult = true)]
        [TestCase(FigureMaterial.Paper, FigureColor.PaperDefaultColor, ExpectedResult = true)]
        [TestCase(FigureMaterial.Paper, FigureColor.PlasticDefaultColor, ExpectedResult = false)]
        [TestCase(FigureMaterial.Paper, FigureColor.Transparent, ExpectedResult = false)]
        [TestCase(FigureMaterial.Film, FigureColor.Green, ExpectedResult = false)]
        [TestCase(FigureMaterial.Film, FigureColor.Transparent, ExpectedResult = true)]
        [TestCase(FigureMaterial.Film, FigureColor.PaperDefaultColor, ExpectedResult = false)]
        [TestCase(FigureMaterial.Film, FigureColor.PlasticDefaultColor, ExpectedResult = false)]
        [TestCase(FigureMaterial.Plastic, FigureColor.Purple, ExpectedResult = true)]
        [TestCase(FigureMaterial.Plastic, FigureColor.PlasticDefaultColor, ExpectedResult = true)]
        [TestCase(FigureMaterial.Plastic, FigureColor.PaperDefaultColor, ExpectedResult = false)]
        [TestCase(FigureMaterial.Plastic, FigureColor.Transparent, ExpectedResult = false)]
        public bool TestPaint(FigureMaterial material, FigureColor color)
        {
            try
            {
                var points = new Point[]
                {
                    new Point(0, 0),
                    new Point(5, 5)
                };
                IFigure oval = new Oval(material, points);
                FigurePainting.Paint(ref oval, color);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
