using EpamWinterTraining.Application.ApplicationExceptions;
using EpamWinterTraining.Figures.FigureBasis;
using EpamWinterTraining.Figures.FiguresException;
using System;
using System.Collections.Generic;
using Point = EpamWinterTraining.Figures.FigureBasis.Point;

namespace EpamWinterTraining.Figures
{
    public abstract class Figure : IFigure, ICloneable
    {

        public const int MIN_POINTS_COUNT_VALUE = 2;
        /// <summary>
        /// Координты вершин или центра фигуры.
        /// </summary>
        private protected Point[] _points;
        /// <summary>
        /// Стороны фигуры.
        /// </summary>
        private protected double[] _sideSizes;
        /// <summary>
        /// Цвет фигуры.
        /// </summary>
        private protected FigureColor _color;
        

        

        /// <summary>
        /// Инициализация первоначально цвета для фигуры.
        /// </summary>
        /// <param name="material">Материал для фигуры.</param>
        protected Figure(FigureMaterial material)
        {
            // инициализируем первоначальный цвет фигуры в обход свойства ColorOfFigure
            _color = GetStartColor(material);
            IsFigureСolorable = GetFigureColorable(material);
        }

        /// <summary>
        /// Инициализирует объект типа Figure, основываясь на материале,
        /// из которого будет сделана фигура и точкам на этом материале.
        /// </summary>
        /// <param name="material">Материал для фигуры.</param>
        /// <param name="points">Точки для вырезания</param>
        public Figure(Point[] points, FigureMaterial material) : this(material)
        {
            Points = points;
            SideSizes = GetSideSizesFromPoints();
            Perimeter = GetPerimeter();
            Area = GetArea();
        }

        /// <summary>
        /// Инициализирует объект типа Figure, используя 
        /// существующую фигуру и новые точки для вырезания.
        /// Если площадь новой фигиры по новым точкам будет
        /// больше площади старой фигуры, то будет вызвано
        /// исключение CuttingNotPossibleException.
        /// </summary>
        /// <param name="figure">Исходная фигура.</param>
        /// <param name="newPoints">Точки, для вырезания новой фигуры.</param>
        public Figure(IFigure figure, Point[] newPoints)
        {
            Points = newPoints;
            Area = AreaCheking(figure);
            Perimeter = figure.Perimeter;
            SideSizes = GetSideSizesFromPoints();
            _color = figure.ColorOfFigure; // вроде как должно всё это дело свойство присваиваться, но почему-то нет
            // ColorOfFigure = figure.ColorOfFigure;
            IsFigureСolorable = figure.IsFigureСolorable;

        }

        

       

        /// <summary>
        /// Массив точек фигуры.
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
        /// Массив длин сторон фигуры.
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
        /// Задаёт цвет фигуры. В случае, если попытаться
        /// установить плёночной фигуре цвет, то будет вызвано
        /// исключение DrawingNotPossibleException. Если
        /// попытаться изменить цвет в уже закрашенной 
        /// фигуре, то значение присвоено не будет.
        /// </summary>
        public FigureColor ColorOfFigure
        {
            get
            {
                return _color;
            }

            set
            {
                // зачем здесь стоит (value != FigureColor.Transparent) && (value != FigureColor.PaperDefaultColor) ????
                // Ведь цвета фигур могут быть первоначальными

                // if ((value == default) || ())
                if (value != default && CanChangeColor(value))
                {
                    _color = value;
                    IsFigureСolorable = true;
                }
                else
                {
                    throw new DrawingNotPossibleException();
                }
                //if ((value != default) && (value != FigureColor.Transparent) && (value != FigureColor.PaperDefaultColor) &&
                //    IsFigureСolorable == false)
                //{
                //    switch (_color)
                //    {
                //        case FigureColor.PaperDefaultColor:
                //            {
                //                _color = value;
                //                IsFigureСolorable = true;
                //                break;
                //            }
                //        default: throw new DrawingNotPossibleException();
                //    }
                //}
            }
        }

        /// <summary>
        /// Указывает, окрашивали ли фигуру. Если фигуру невозможно
        /// окрасить, возвращает null;
        /// </summary>
        public bool? IsFigureСolorable { get; set; }
        // public bool? IsFigureDyed { get; set; } = null;

        /// <summary>
        /// Площадь фигуры.
        /// </summary>
        public double Area { get; private set; }
        /// <summary>
        /// Периметр фигуры.
        /// </summary>
        public double Perimeter { get; private set; }

        

        /// <summary>
        /// Получает площадь фигуры.
        /// </summary>
        /// <returns>Возвращает площадь фигуры.</returns>
        public abstract double GetArea();

        /// <summary>
        /// Получает периметр фигуры.
        /// </summary>
        /// <returns>Возвращает периметр фигуры.</returns>
        public abstract double GetPerimeter(); 

        /// <summary>
        /// Получает массив значений сторон фигуры, 
        /// последовательно обходя все вершины фигуры.
        /// </summary>
        /// <returns>Возвращает массив значений сторон фигуры.</returns>
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

        public object Clone() => Clone();

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
        /// Сравнивает две фигуры основываяcь на их типе и цвете.
        /// </summary>
        /// <param name="obj">Фигура для сравнения.</param>
        /// <returns>Возвращает true в случае равенства 
        /// типов и цветов у двух фигур.</returns>
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
        /// Метод задания первоначального цвета для фигуры, 
        /// используя материал для аппликации.
        /// </summary>
        /// <param name="material">Материал фигуры.</param>
        /// <returns>Возвращает цвет по умолчанию
        /// для каждого материала.</returns>
        private FigureColor GetStartColor(FigureMaterial material) => material switch
        {
            FigureMaterial.Film => FigureColor.Transparent,
            FigureMaterial.Paper => FigureColor.PaperDefaultColor,
            FigureMaterial.Plastic => FigureColor.PlasticDefaultColor,
            _ => throw new Exception()
        };

        private protected double AreaCheking(IFigure figure)
        {
            var result = GetArea() < figure.GetArea()
                    ? figure.Area
                    : throw new CuttingNotPossibleException();
            return result;
        }

        private protected bool? GetFigureColorable(FigureMaterial material) => material switch
        {
            FigureMaterial.Film => null,
            _ => false
        };

        private protected bool CanChangeColor(FigureColor color)
        {
            bool isPaintPossible = false;

            // Если мы пытаемся из дефолтного начального цвета покрасить в такой же,
            // то у нас это получится. Если фигура н окрашена,

            switch (color)
            {
                case FigureColor.Transparent:
                case FigureColor.PaperDefaultColor:
                case FigureColor.PlasticDefaultColor:
                    {
                        isPaintPossible = (_color == color);
                        break;
                    }
                default:
                    {
                        if (IsFigureСolorable == false)
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
