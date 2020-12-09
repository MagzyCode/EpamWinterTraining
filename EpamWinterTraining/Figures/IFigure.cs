using EpamWinterTraining.Figures.FigureBasis;
using System;

namespace EpamWinterTraining.Figures
{
    public interface IFigure
    {
        Point[] Points { get; set; }
        FigureColor ColorOfFigure { get; set; }
        StainAbility IsFigureСolorable { get; }
        bool IsFigureColored { get; }
        double GetPerimeter();
        double GetArea();
    }
}
