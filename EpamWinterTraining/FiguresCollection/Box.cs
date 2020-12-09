using EpamWinterTraining.Figures;
using EpamWinterTraining.Figures.FigureBasis;
using EpamWinterTraining.Figures.SpecificFigures;
using EpamWinterTraining.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EpamWinterTraining.FiguresCollection
{
    public class Box
    {

        /// <summary>
        /// Maximum number of shapes in a box.
        /// </summary>
        public const int MAX_COUNT_OF_FIGURES = 20;
        /// <summary>
        /// Shapes in a box.
        /// </summary>
        private readonly IFigure[] _figures = new IFigure[MAX_COUNT_OF_FIGURES];

        public Box()
        { }

        public Box(IFigure[] figures)
        {
            Figures = figures;
        }

        /// <summary>
        /// The indexer, at the request of the shapes in the box according to the room, without taking out of it.
        /// </summary>
        /// <param name="index">Shape index.</param>
        /// <returns>Returns the shape by index.</returns>
        public IFigure this[int index]
        {
            get
            {
                return Figures[index];
            }
        }

        /// <summary>
        /// Returns all shapes from the box. If you assign a certain number of shapes 
        /// to a box, only the first 20 shapes will be entered.
        /// </summary>
        public IFigure[] Figures
        {
            get
            {
                return _figures;
            }

            set
            {
                bool isSequenceCorrect = value.All(i => i != null);
                if (isSequenceCorrect)
                {
                    var lenght = value.Length <= MAX_COUNT_OF_FIGURES ? value.Length : MAX_COUNT_OF_FIGURES;
                    Array.Copy(value, 0, _figures, 0, lenght);
                }
                else
                {
                    throw new Exception();
                }
               
            }

        }

        /// <summary>
        /// Returns the number of shapes that are currently in the box.
        /// </summary>
        public int Count
        {
            get
            {
                return Figures.Where(i => i != null).Count();
            }
        }

        /// <summary>
        /// Method for removing all circles from the box. This removes the circles in the box.
        /// </summary>
        /// <returns>Returns all the circles out of the box.</returns>
        public Oval[] GetAllCircles()
        {
            var circles = new Oval[MAX_COUNT_OF_FIGURES];
            var counter = 0;
            for (int i = 0; i < Count; i++)
            {
                if (Figures[i] is Oval circle && circle.IsFigureCircle())
                {
                    circles[counter++] = circle;
                    RemoveFigure(i);
                }
            }

            var numberOfElements = circles.Where(i => i != null).Count();
            Array.Resize(ref circles, numberOfElements);
            return circles;
        }

        /// <summary>
        /// Method for the removal of all film shapes.
        /// </summary>
        /// <returns>Returns all film shapes from the box.</returns>
        public IFigure[] GetAllFilmFigures()
        {
            var figures = new IFigure[MAX_COUNT_OF_FIGURES];
            var counter = 0;
            for (int i = 0; i < Count; i++)
            {
                if (Figures[i].ColorOfFigure == FigureColor.Transparent)
                {
                    figures[counter++] = Figures[i];
                    RemoveFigure(i);
                }
            }

            var numberOfElements = figures.Where(i => i != null).Count();
            Array.Resize(ref figures, numberOfElements);
            return figures;
        }

        /// <summary>
        /// Returns all non-painted plastic figure from the box.
        /// </summary>
        /// <returns></returns>
        public IFigure[] GetNotColoredPlasticFigures()
        {
            var figures = new IFigure[MAX_COUNT_OF_FIGURES];
            var counter = 0;
            for (int i = 0; i < Count; i++)
            {
                if (Figures[i].IsFigureСolorable == StainAbility.CanDrawAlways && Figures[i].IsFigureColored == false)
                {
                    figures[counter++] = Figures[i];
                    RemoveFigure(i);
                }
            }

            var numberOfElements = figures.Where(i => i != null).Count();
            Array.Resize(ref figures, numberOfElements);
            return figures;
        }

        /// <summary>
        /// Adding a shape that is unique in color and type.
        /// </summary>
        /// <param name="figure">Shape to add.</param>
        public void AddFigure(IFigure figure)
        {
            if (figure == null)
            {
                throw new Exception("Невозможно добавить фигуру");
            }

            foreach (IFigure item in Figures)
            {
                if (item == figure)
                {
                    throw new Exception("Невозможно добавлять аналогичные фигуры в коробку");
                }
            }

            Figures[Count] = figure;
        }

        /// <summary>
        /// Deleting a shape from the box by the specified index.
        /// </summary>
        /// <param name="index">Index of the shape to delete.</param>
        public void RemoveFigure(int index)
        {
            if ((index >= MAX_COUNT_OF_FIGURES) || (index < 0))
            {
                throw new IndexOutOfRangeException();
            }
            Array.Copy(Figures, index + 1, Figures, index, Count - index);
        }

        /// <summary>
        /// Replacement pieces.
        /// </summary>
        /// <param name="index">Index of the shape being replaced.</param>
        /// <param name="figure">New figure.</param>
        public void ReplaceFigure(int index, IFigure figure)
        {
            if ((index >= MAX_COUNT_OF_FIGURES) || (index < 0))
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                Figures[index] = figure ?? throw new NullReferenceException();
            }
        }

        /// <summary>
        /// Finding a shape by characteristics.
        /// </summary>
        /// <param name="figureType">Type of shape.</param>
        /// <param name="color">The color of the shape.</param>
        /// <returns></returns>
        public IFigure Find(Type figureType, FigureColor color)
        {
            foreach (IFigure item in Figures)
            {
                if ((item != null) &&(item.GetType() == figureType) && (item.ColorOfFigure == color))
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Method for saving shapes from a box to a file using StreamWriter.
        /// </summary>
        /// <param name="path">Path to the save file.</param>
        public void SaveFiguresUsingStreamWriter(string path = StreamAccess.myPath)
        {
            StreamAccess.Save(Figures, path);
        }

        /// <summary>
        /// A method for saving shapes, given their material, from a box to a file using StreamWriter.
        /// </summary>
        /// <param name="material">Material to be stored.</param>
        /// <param name="path">File path.</param>
        public void SaveFiguresUsingStreamWriter(FigureMaterial material, string path = StreamAccess.myPath)
        {
            StreamAccess.Save(Figures, material, path);
        }

        /// <summary>
        /// Method for loading shapes from a file to a shape using StreamReader.
        /// </summary>
        /// <param name="path">Path to the withdrawal file.</param>
        public void LoadFiguresUsingStreamReader(string path = StreamAccess.myPath)
        {
            Figures = StreamAccess.LoadFile(path);
        }

        /// <summary>
        /// Method for saving shapes from a box to a file using XmlWriter.
        /// </summary>
        /// <param name="path">Path to the save file.</param>
        public void SaveFiguresUsingXmlWriter(string path = XmlAccess.myPath)
        {
            XmlAccess.Save(Figures, path);
        }

        /// <summary>
        /// Method for saving shapes, taking into account their material, from the box to a file using XmlWriter.
        /// </summary>
        /// <param name="material">Material to be stored.</param>
        /// <param name="path">File path.</param>
        public void SaveFiguresUsingXmlWriter(FigureMaterial material, string path = XmlAccess.myPath)
        {
            XmlAccess.Save(Figures, material, path);
        }

        /// <summary>
        /// Method for loading shapes from a file to a shape using XmlReader.
        /// </summary>
        /// <param name="path">Path to the withdrawal file.</param>
        public void LoadFiguresUsingXmlReader(string path = XmlAccess.myPath)
        {
            Figures = XmlAccess.LoadFile(path);
        }

        /// <summary>
        /// Method for getting the sum of all the perimeters of shapes in a box.
        /// </summary>
        /// <returns>The total perimeter.</returns>
        public double GetTotalPerimeter()
        {
            var total = Figures.Select(i => i?.GetPerimeter()).Sum().Value;
            return total;
        }

        /// <summary>
        /// Method for getting the sum of all the squares of shapes in a box.
        /// </summary>
        /// <returns>Total area.</returns>
        public double GetTotalArea()
        {
            var total = Figures.Select(i => i?.GetArea()).Sum().Value;
            return total;
        }

        
    }
}
