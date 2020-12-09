using EpamWinterTraining.Figures;
using EpamWinterTraining.Figures.FigureBasis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace EpamWinterTraining.Xml
{
    public static class StreamAccess
    {
        /// <summary>
        /// File path.
        /// </summary>
        public const string myPath = "figuresStream.xml";
        /// <summary>
        /// Start of the xml document.
        /// </summary>
        public static readonly string documentStart = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
        /// <summary>
        /// Designations for blocks of shapes.
        /// </summary>
        public static readonly (string start, string end) elementsBlock = ("<figures>", "</figures>");

        /// <summary>
        /// Saving figures to an xml file.
        /// </summary>
        /// <param name="figures">Save the figures.</param>
        /// <param name="path">File path.</param>
        public static void Save(IFigure[] figures, string path = myPath)
        {
            var document = documentStart;
            document += elementsBlock.start;
            foreach (var item in figures)
            {
                if (item != null)
                {
                    WriteElement(item, ref document);
                }
            }
            document += elementsBlock.end;

            using var stream = new StreamWriter(path);
            stream.Write(document);
        }

        /// <summary>
        /// Saving figures to an xml file.
        /// </summary>
        /// <param name="figures">Save the figures.</param>
        /// <param name="material">Figure material.</param>
        /// <param name="path">File path.</param>
        public static void Save(IFigure[] figures, FigureMaterial material, string path = myPath)
        {
            var document = documentStart;
            document += elementsBlock.start;

            foreach (var item in figures)
            {
                if (item != null)
                {
                    switch (material)
                    {
                        case FigureMaterial.Paper:
                            {
                                if ((item.ColorOfFigure != FigureColor.Transparent) && (item.ColorOfFigure != FigureColor.PlasticDefaultColor) &&
                                    (item.IsFigureСolorable != StainAbility.CanDrawAlways))
                                {
                                    WriteElement(item, ref document);
                                }
                                break;
                            }
                        case FigureMaterial.Film:
                            {
                                if (item.ColorOfFigure == FigureColor.Transparent)
                                {
                                    WriteElement(item, ref document);
                                }
                                break;
                            }
                        case FigureMaterial.Plastic:
                            {
                                if (item.IsFigureСolorable == StainAbility.CanDrawAlways)
                                {
                                    WriteElement(item, ref document);
                                }
                                break;
                            }

                    }

                    // здесь нужно как-то разграничить какой и когда материал сохраняется
                    // 
                    // плёнка -> (цвет фигуры Transparent)
                    // пластик -> (состояние окращиваемости CanDrawAlways)
                    //бумага -> (цвет фигуры установлен в DefaultPaperColor) || (состояние окрашиваемости фигуры CanNotDraw && значение были ли окрашена фигура true)
                    // или просто бумага в остальных случаях является бумагой
                    //
                    //if ((material == FigureMaterial.Film) && (item.ColorOfFigure == FigureColor.Transparent))
                    //{
                    //    WriteElement(item, ref document);
                    //}
                    //else if ((material == FigureMaterial.Paper) && (item.ColorOfFigure != FigureColor.Transparent))
                    //{
                    //    WriteElement(item, ref document);
                    //}
                }
            }
            document += elementsBlock.end;

            using var stream = new StreamWriter(path);
            stream.Write(document);
        }


        /// <summary>
        /// Unloads shapes from an xml file to an array of shapes.
        /// </summary>
        /// <param name="path">File path.</param>
        /// <returns>Figures array.</returns>
        public static IFigure[] LoadFile(string path = myPath)
        {
            using var stream = new StreamReader(path);
            var arrayOfFigures = new IFigure[XmlParser.MAX_ELEMENTS_IN_BLOCK];
            var counter = 0;
            var document = new XmlDocument();
            document.Load(stream);
            var root = document.DocumentElement;

            foreach (XmlNode xnode in root.ChildNodes)
            {
                if (xnode.Attributes.Count > 0)
                {  
                    var properies = new string[]
                    {
                        xnode.Attributes.GetNamedItem("type").Value,
                        xnode.Attributes.GetNamedItem("points").Value,
                        xnode.Attributes.GetNamedItem("color").Value,
                        xnode.Attributes.GetNamedItem("figureСolorable").Value,
                        xnode.Attributes.GetNamedItem("figureColored").Value
                    };
                    var figure = XmlParser.FigureParse(properies);
                    arrayOfFigures[counter++] = figure;
                }
            }
            return arrayOfFigures;
        }

        /// <summary>
        /// Converts the shape to xml format.
        /// </summary>
        /// <param name="figure">Convertable figure.</param>
        /// <param name="document"></param>
        private static void WriteElement(IFigure figure, ref string document)
        {
            var type = figure.GetType().Name;
            var stringOfPoints = string.Join<Point>(',', figure.Points);
            var color = figure.ColorOfFigure.ToString();
            var figureСolorable = figure.IsFigureСolorable.ToString();
            var figureColored = figure.IsFigureColored ? "true" : "false";

            document += $"<figure type=\"{type}\" points=\"{stringOfPoints}\" color = \"{color}\" " +
                $"figureСolorable=\"{figureСolorable}\" figureColored=\"{figureColored}\"/>";
        }
    }
}
