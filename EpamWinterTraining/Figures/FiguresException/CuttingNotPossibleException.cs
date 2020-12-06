using System;

namespace EpamWinterTraining.Figures.FiguresException
{
    public class CuttingNotPossibleException : Exception
    {
        public CuttingNotPossibleException() : base("Невозможно вырезать фигуру")
        { }
    }
}
