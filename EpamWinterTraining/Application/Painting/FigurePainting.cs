using EpamWinterTraining.Application.ApplicationExceptions;
using EpamWinterTraining.Figures;
using EpamWinterTraining.Figures.FigureBasis;

namespace EpamWinterTraining.Application.Painting
{
    public static class FigurePainting
    {
        public static void Paint(ref IFigure figure, FigureColor color)
        {
            if (figure.IsFigureСolorable == false)
            {
                figure.ColorOfFigure = color;
                figure.IsFigureСolorable = true;
            }
            else
            {
                throw new DrawingNotPossibleException();
            }
        }
    }
}
