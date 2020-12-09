using System;

namespace EpamWinterTraining.Application.ApplicationExceptions
{
    /// <summary>
    /// An exception that is thrown when trying to paint a shape incorrectly.
    /// </summary>
    public class DrawingNotPossibleException : Exception
    {
        public DrawingNotPossibleException() : base("Невозможно вырезать фигуру.")
        { }
    }
}
