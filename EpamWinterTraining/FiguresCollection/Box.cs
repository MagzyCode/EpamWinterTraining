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
        #region Fields
        /// <summary>
        /// Максимальное количество фигур в коробке.
        /// </summary>
        public const int MAX_COUNT_OF_FIGURES = 20;
        /// <summary>
        /// Фигуры в коробке.
        /// </summary>
        private readonly IFigure[] _figures = new IFigure[MAX_COUNT_OF_FIGURES];

        #endregion

        #region Constructors

        #endregion

        #region Indexer
        /// <summary>
        /// Индексатор, по обращению к фигурам в коробке
        /// по номеру, без изъятие из неё.
        /// </summary>
        /// <param name="index">Индекс фигуры.</param>
        /// <returns>Возвращает фигуру по индексу.</returns>
        public IFigure this[int index]
        {
            get
            {
                return Figures[index].Clone() as IFigure;
            }
        }

        #endregion

        #region Properties
        /// <summary>
        /// Возвращает все фигуры из коробки.
        /// В случае присвоения коробке определённого
        /// количества фигур, будет занесено только 
        /// 20 первых фигур.
        /// </summary>
        public IFigure[] Figures
        {
            get
            {
                return _figures;
            }

            set
            {
                var lenght = value.Length <= MAX_COUNT_OF_FIGURES ? value.Length : MAX_COUNT_OF_FIGURES;
                Array.Copy(value, 0, _figures, 0, lenght);
            }

        }

        /// <summary>
        /// Возвращает количество фигур, 
        /// которое находится в коробке сейчас.
        /// </summary>
        public int Count
        {
            get
            {
                // int index = Figures.Where(i => i != null).Count();
                var index = 0;
                foreach (var item in Figures)
                {
                    if (item != null)
                    {
                        index++;
                    }
                }
                return index;
            }
        }

        public double TotalPerimeter
        {
            get
            {
                return GetTotalPerimeter();
            }
        }

        public double TotalArea
        {
            get
            {
                return GetTotalArea();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод по изъятию все кругов из коробки.
        /// При этом круги в коробке удаляются.
        /// </summary>
        /// <returns>Возвращает все круги из коробки.</returns>
        /// 
        /// Нужно переделать под овалы, которые являются кругами
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
        /// Метод по изъятию всех плёночный фигур.
        /// </summary>
        /// <returns>Возвращает все плёночные фигуры из коробки</returns>
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
        /// Добавление уникальной по цвету и типу фигуры.
        /// </summary>
        /// <param name="figure">Фигура для добавления.</param>
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
        /// Удаление фигуры из коробки по заданному индексу.
        /// </summary>
        /// <param name="index">Индекс удаляемой фигуры.</param>
        public void RemoveFigure(int index)
        {
            if ((index >= MAX_COUNT_OF_FIGURES) || (index < 0))
            {
                throw new IndexOutOfRangeException();
            }
            Array.Copy(Figures, index + 1, Figures, index, Count - index);
        }

        /// <summary>
        /// Замена фигур.
        /// </summary>
        /// <param name="index">Индекс заменяемой фигуры.</param>
        /// <param name="figure">Новая фигура.</param>
        public void ReplaceFigure(int index, IFigure figure)
        {
            Figures[index] = figure ?? throw new NullReferenceException();
        }

        /// <summary>
        /// Нахождение фигуры по характеристикам.
        /// </summary>
        /// <param name="figureType">Тип фигуры.</param>
        /// <param name="color">Цвет фигуры.</param>
        /// <returns></returns>
        public IFigure Find(Type figureType, FigureColor color)
        {
            foreach (IFigure item in Figures)
            {
                if ((item.GetType() == figureType) && (item.ColorOfFigure == color))
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Метод сохранения фигур из коробки в файл,
        /// используя StreamWriter.
        /// </summary>
        /// <param name="path">Путь к файлу сохранения.</param>
        public void SaveFiguresUsingStreamWriter(string path = StreamAccess.myPath)
        {
            StreamAccess.Save(Figures, path);
        }

        /// <summary>
        /// Метод сохранения фигур, учитывая их материал,
        /// из коробки в файл, используя StreamWriter.
        /// </summary>
        /// <param name="material">Материал для сохранения.</param>
        /// <param name="path">Путь к файлу.</param>
        public void SaveFiguresUsingStreamWriter(FigureMaterial material, string path = StreamAccess.myPath)
        {
            StreamAccess.Save(Figures, material, path);
        }

        /// <summary>
        /// Метод загрузки фигур из файла
        /// в фигуру, используя StreamReader.
        /// </summary>
        /// <param name="path">Путь к файлу изъятия.</param>
        public void LoadFiguresUsingStreamReader(string path = StreamAccess.myPath)
        {
            Figures = StreamAccess.LoadFile(path);
        }

        /// <summary>
        /// Метод сохранения фигур из коробки в файл,
        /// используя XmlWriter.
        /// </summary>
        /// <param name="path">Путь к файлу сохранения.</param>
        public void SaveFiguresUsingXmlWriter(string path = XmlAccess.myPath)
        {
            XmlAccess.Save(Figures, path);
        }

        /// <summary>
        /// Метод сохранения фигур, учитывая их материал,
        /// из коробки в файл, используя XmlWriter.
        /// </summary>
        /// <param name="material">Материал для сохранения.</param>
        /// <param name="path">Путь к файлу.</param>
        public void SaveFiguresUsingXmlWriter(FigureMaterial material, string path = XmlAccess.myPath)
        {
            XmlAccess.Save(Figures, material, path);
        }

        /// <summary>
        /// Метод загрузки фигур из файла
        /// в фигуру, используя XmlReader.
        /// </summary>
        /// <param name="path">Путь к файлу изъятия.</param>
        public void LoadFiguresUsingXmlReader(string path = XmlAccess.myPath)
        {
            Figures = XmlAccess.LoadFile(path);
        }

        /// <summary>
        /// Метод получения суммы всех
        /// периметров фигур в коробке.
        /// </summary>
        /// <returns>Общий периметр.</returns>
        private double GetTotalPerimeter()
        {
            var total = 0.0;
            foreach (IFigure item in Figures)
            {
                if (item == null)
                {
                    break;
                }
                total += item.GetPerimeter();
            }
            return total;
        }

        /// <summary>
        /// Метод получения суммы всех
        /// площадей фигур в коробке.
        /// </summary>
        /// <returns>Общую площадь.</returns>
        private double GetTotalArea()
        {
            double total = 0.0;
            foreach (IFigure item in Figures)
            {
                if (item == null)
                {
                    break;
                }
                total += item.GetArea();
            }
            return total;
        }

        #endregion
    }
}
