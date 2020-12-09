using System;

namespace EpamWinterTraining.Figures.FiguresException
{
    /// <summary>
    /// An exception caused by the inability to cut one shape from another.
    /// </summary>
    public class CuttingNotPossibleException : Exception
    {
        public CuttingNotPossibleException() : base("Невозможно вырезать фигуру")
        { }
    }
}
