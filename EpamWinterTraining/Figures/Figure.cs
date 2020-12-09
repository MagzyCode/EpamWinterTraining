using EpamWinterTraining.Application.ApplicationExceptions;
using EpamWinterTraining.Figures.FigureBasis;
using EpamWinterTraining.Figures.FiguresException;
using System;
using System.Collections.Generic;
using Point = EpamWinterTraining.Figures.FigureBasis.Point;

namespace EpamWinterTraining.Figures
{
    public abstract class Figure : IFigure // , ICloneable
    {
        /// <summary>
        /// Minimum number of points to create a shape.
        /// </summary>
        public const int MIN_POINTS_COUNT_VALUE = 2;
        /// <summary>
        /// Coordinates of the vertices or center of the shape.
        /// </summary>
        private protected Point[] _points;
        /// <summary>
        /// Sides of the shape.
        /// </summary>
        private protected double[] _sideSizes;
        /// <summary>
        /// The color of the shape.
        /// </summary>
        private protected FigureColor _color;




        /// <summary>
        /// Initializing the original color for the shape.
        /// </summary>
        /// <param name="material">Material for the shape.</param>
        protected Figure(FigureMaterial material)
        {
            _color = GetStartColor(material);
            IsFigureСolorable = GetFigureColorable(material);
        }

        /// <summary>
        /// Initializes an object of the Figure type based on the material that the shape 
        /// will be made from and the points on this material.
        /// </summary>
        /// <param name="material">Material for the shape.</param>
        /// <param name="points">Points to cut.</param>
        public Figure(Point[] points, FigureMaterial material) : this(material)
        {
            Points = points;
            SideSizes = GetSideSizesFromPoints();
        }

        /// <summary>
        /// Initializes a Figure object using an existing shape and new points to cut.
        /// If the area of the new shape at the new points is larger than the area of the old shape, 
        /// a CuttingNotPossibleException is thrown.
        /// </summary>
        /// <param name="figure">The original shape.</param>
        /// <param name="newPoints">Points for cutting a new shape.</param>
        public Figure(IFigure figure, Point[] newPoints)
        {
            Points = newPoints;
            if (!AreaCheking(figure))
            {
                throw new Exception("The area of the cut shape cannot be larger than the original shape.");
            }
            SideSizes = GetSideSizesFromPoints();
            _color = figure.ColorOfFigure;
            IsFigureСolorable = figure.IsFigureСolorable;

        }

        /// <summary>
        /// Array of shape points.
        /// </summary>
        public Point[] Points
        {
            get
            {
                return _points;
            }
            set
            {
                if ((value == null) || (value.Length < MIN_POINTS_COUNT_VALUE))
                {
                    throw new Exception("Невозможно присвоить значение для Points");
                }
                _points = value;
            }
        }

        /// <summary>
        /// Array of lengths of the shape's sides.
        /// </summary>
        public double[] SideSizes
        {
            get
            {
                return _sideSizes;
            }
            set
            {
                if ((value == null) || (value.Length == 0))
                {
                    throw new Exception("Невозможно присвоить значение для SideSizes");
                }
                _sideSizes = value;
            }
        }

        /// <summary>
        /// Specifies the color of the shape. If you try to set a color for a film shape 
        /// or try to change the color in an already filled shape, a DrawingNotPossibleException is thrown.
        /// </summary>
        public FigureColor ColorOfFigure
        {
            get
            {
                return _color;
            }

            set
            {
                if (CanChangeColor(value))
                {
                    _color = value;
                    IsFigureColored = true;
                    IsFigureСolorable = IsFigureСolorable == StainAbility.CanDrawAlways
                        ? StainAbility.CanDrawAlways
                        : StainAbility.CanNotDraw;
                }
                else
                {
                    throw new DrawingNotPossibleException();
                }
            }
        }

        /// <summary>
        /// Indicates whether the shape was colored. If the shape cannot be colored, returns null.
        /// </summary>
        public StainAbility IsFigureСolorable { get; private set; }
        public bool IsFigureColored { get; private set; } = false;

        /// <summary>
        /// Gets the area of the shape.
        /// </summary>
        /// <returns>Gets the area of the shape.</returns>
        public abstract double GetArea();

        /// <summary>
        /// Gets the perimeter of the shape.
        /// </summary>
        /// <returns>Возвращает периметр фигуры.</returns>
        public abstract double GetPerimeter();

        /// <summary>
        /// Gets an array of values for the sides of the shape, sequentially traversing all the vertices of the shape.
        /// </summary>
        /// <returns>Returns an array of values for the shape's sides.</returns>
        public virtual double[] GetSideSizesFromPoints()
        {
            // Соединяем первую и последнюю точку
            var indexOfLastPoint = Points.Length - 1;
            double side = Point.GetLengthBetweenPoints(Points[indexOfLastPoint], Points[0]);
            var listOfSides = new List<double> { side };
            if (Points.Length >= 2)
            {
                for (int counter = 0; counter < Points.Length - 1; counter++)
                {
                    side = Point.GetLengthBetweenPoints(Points[counter], Points[counter + 1]);
                    listOfSides.Add(side);
                }
            }
            var arrayOfSides = listOfSides.ToArray();
            return arrayOfSides;
        }

        public override string ToString()
        {
            string stringOfPoints = string.Join<Point>(' ', Points);
            return $" Type: {GetType().Name} \n Points: {stringOfPoints}\n";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this);
        }

        /// <summary>
        /// Compares two shapes based on their type and color.
        /// </summary>
        /// <param name="obj">Figure for comparison.</param>
        /// <returns>Returns true if the types and colors of the two shapes are equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Figure figure)
            {
                if ((GetType() == figure.GetType()) &&
                        (ColorOfFigure == figure.ColorOfFigure))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Method for setting the original color for the shape using the material for the application.
        /// </summary>
        /// <param name="material">Shape material.</param>
        /// <returns>Returns the default color for each material.</returns>
        private FigureColor GetStartColor(FigureMaterial material) => material switch
        {
            FigureMaterial.Film => FigureColor.Transparent,
            FigureMaterial.Paper => FigureColor.PaperDefaultColor,
            FigureMaterial.Plastic => FigureColor.PlasticDefaultColor,
            _ => throw new Exception()
        };

        /// <summary>
        /// Checks whether the area of the cut shape is larger than that of the original shape.
        /// </summary>
        /// <param name="figure">The original shape.</param>
        /// <returns></returns>
        private protected bool AreaCheking(IFigure figure)
        {
            var result = GetArea() < figure.GetArea();
            return result;
        }

        /// <summary>
        /// Gets the ability to color based on the shape material.
        /// </summary>
        /// <param name="material">Shape material.</param>
        /// <returns></returns>
        private protected StainAbility GetFigureColorable(FigureMaterial material) => material switch
        {
            FigureMaterial.Film => StainAbility.CanNotDraw,
            FigureMaterial.Plastic => StainAbility.CanDrawAlways,
            FigureMaterial.Paper => StainAbility.CanDrawOnce,
            _ => throw new DrawingNotPossibleException()
        };
        /// <summary>
        /// Checks, whether the shape can change color.
        /// </summary>
        /// <param name="color">The color to be painted.</param>
        /// <returns></returns>
        private protected bool CanChangeColor(FigureColor color)
        {
            bool isPaintPossible = false;

            switch (color)
            {
                case FigureColor.Transparent:
                case FigureColor.PaperDefaultColor:
                case FigureColor.PlasticDefaultColor:
                    {
                        isPaintPossible = _color == color;
                        break;
                    }
                default:
                    {
                        if ((IsFigureСolorable == StainAbility.CanDrawAlways) || (IsFigureСolorable == StainAbility.CanDrawOnce))
                        {
                            isPaintPossible = true;
                        }
                        break;
                    }
            }
            return isPaintPossible;
        }

    }
}
