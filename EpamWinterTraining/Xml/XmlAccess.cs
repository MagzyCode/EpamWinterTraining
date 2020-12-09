using EpamWinterTraining.Figures;
using EpamWinterTraining.Figures.FigureBasis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Point = EpamWinterTraining.Figures.FigureBasis.Point;

namespace EpamWinterTraining.Xml
{
    public static class XmlAccess
    {
        /// <summary>
        /// File path.
        /// </summary>
        public const string myPath = "figuresXml.xml";

        /// <summary>
        /// Saving figures to an xml file.
        /// </summary>
        /// <param name="figures">Save the figures.</param>
        /// <param name="path">File path.</param>
        public static void Save(IFigure[] figures, string path = myPath)
        {
            using var xmlWriter = XmlWriter.Create(path);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("figures");

            foreach (IFigure item in figures)
            {
                WriteElement(item, xmlWriter);
            }

            xmlWriter.WriteEndDocument();
        }

        /// <summary>
        /// Saving figures to an xml file.
        /// </summary>
        /// <param name="figures">Save the figures.</param>
        /// <param name="material">Figure material.</param>
        /// <param name="path">File path.</param>
        public static void Save(IFigure[] figures, FigureMaterial material, string path = myPath)
        {
            using var xmlWriter = XmlWriter.Create(path);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("figures");

            foreach (IFigure item in figures)
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
                                    WriteElement(item, xmlWriter);
                                }
                                break;
                            }
                        case FigureMaterial.Film:
                            {
                                if (item.ColorOfFigure == FigureColor.Transparent)
                                {
                                    WriteElement(item, xmlWriter);
                                }
                                break;
                            }
                        case FigureMaterial.Plastic:
                            {
                                if (item.IsFigureСolorable == StainAbility.CanDrawAlways)
                                {
                                    WriteElement(item, xmlWriter);
                                }
                                break;
                            }

                    }
                }
            }

            xmlWriter.WriteEndDocument();
        }

        /// <summary>
        /// Unloads shapes from an xml file to an array of shapes.
        /// </summary>
        /// <param name="path">File path.</param>
        /// <returns>Figures array.</returns>
        public static IFigure[] LoadFile(string path = myPath)
        {
            using var stream = new FileStream(path, FileMode.OpenOrCreate);
            XmlReader xmlReader = XmlReader.Create(stream);
            var figures = new IFigure[XmlParser.MAX_ELEMENTS_IN_BLOCK];
            var counter = 0;

            while (xmlReader.Read())
            {
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "figure"))
                {
                    if (xmlReader.HasAttributes)
                    {
                        var properties = new string[]
                        {
                            xmlReader.GetAttribute("type"),
                            xmlReader.GetAttribute("points"),
                            xmlReader.GetAttribute("color"),
                            xmlReader.GetAttribute("figureColorable"),
                            xmlReader.GetAttribute("figureColored")
                        };
                        IFigure figure = XmlParser.FigureParse(properties);
                        figures[counter++] = figure;
                    }
                }
            }
            return figures;
        }

        /// <summary>
        /// Converts the shape to xml format.
        /// </summary>
        /// <param name="figure">Convertable figure.</param>
        /// <param name="document"></param>
        private static void WriteElement(IFigure figure, XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("figure");
            var type = figure.GetType().Name;
            xmlWriter.WriteAttributeString("type", type);
            var stringOfPoints = string.Join(',', figure.Points);
            xmlWriter.WriteAttributeString("points", stringOfPoints);
            var color = figure.ColorOfFigure.ToString();
            xmlWriter.WriteAttributeString("color", color);
            var colorable = figure.IsFigureСolorable.ToString();
            xmlWriter.WriteAttributeString("figureColorable", colorable);
            var isColored = figure.IsFigureColored ? "true" : "false";
            xmlWriter.WriteAttributeString("figureColored", isColored);
            xmlWriter.WriteEndElement();
        }
    }
}
