using EpamWinterTraining.Application.ApplicationExceptions;
using EpamWinterTraining.Figures;
using EpamWinterTraining.Figures.FigureBasis;

namespace EpamWinterTraining.Application.Painting
{
    /// <summary>
    /// A class designed for painting shapes.
    /// </summary>
    public static class FigurePainting
    {
        /// <summary>
        /// Applies paint to the shape.
        /// </summary>
        /// <param name="figure">The shape to be colored.</param>
        /// <param name="color">The color to be painted.</param>
        public static void Paint(ref IFigure figure, FigureColor color) => figure.ColorOfFigure = color;
    }
}
