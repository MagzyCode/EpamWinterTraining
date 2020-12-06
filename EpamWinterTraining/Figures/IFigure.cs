using EpamWinterTraining.Figures.FigureBasis;
using System;

namespace EpamWinterTraining.Figures
{
    public interface IFigure : ICloneable
    {
        Point[] Points { get; set; }
        FigureColor ColorOfFigure { get; set; }
        bool? IsFigureСolorable { get; set; }
        double Area { get; }
        double Perimeter { get; }
        double GetPerimeter();
        double GetArea();
    }
}
