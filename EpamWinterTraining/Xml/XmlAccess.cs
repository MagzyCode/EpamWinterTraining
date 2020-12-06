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
        public const string myPath = "figuresXml.xml";

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

        public static void Save(IFigure[] figures, FigureMaterial material, string path = myPath)
        {
            using var xmlWriter = XmlWriter.Create(path);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("figures");

            foreach (IFigure item in figures)
            {
                if ((material == FigureMaterial.Film) && (item.ColorOfFigure == FigureColor.Transparent))
                {
                    WriteElement(item, xmlWriter);
                }
                else if ((material == FigureMaterial.Paper) && (item.ColorOfFigure != FigureColor.Transparent))
                {
                    WriteElement(item, xmlWriter);
                }
            }

            xmlWriter.WriteEndDocument();
        }

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
                        var figureType = xmlReader.GetAttribute("type");
                        var figurePoints = xmlReader.GetAttribute("points");
                        var figureColor = xmlReader.GetAttribute("color");
                        IFigure figure = XmlParser.FigureParse(figureType, figurePoints, figureColor);
                        figures[counter++] = figure;
                    }
                }
            }
            return figures;
        }

        private static void WriteElement(IFigure figure, XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("figure");
            var type = figure.GetType().Name;
            xmlWriter.WriteAttributeString("type", type);
            var stringOfPoints = string.Join(',', figure.Points);
            xmlWriter.WriteAttributeString("points", stringOfPoints);
            var color = figure.ColorOfFigure.ToString();
            xmlWriter.WriteAttributeString("color", color);
            xmlWriter.WriteEndElement();
        }
    }
}
