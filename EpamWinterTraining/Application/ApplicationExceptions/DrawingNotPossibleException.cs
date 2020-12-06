using System;

namespace EpamWinterTraining.Application.ApplicationExceptions
{
    class DrawingNotPossibleException : Exception
    {
        public DrawingNotPossibleException() : base("Невозможно вырезать фигуру.")
        { }
    }
}
