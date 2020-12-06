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
        public const string myPath = "figuresStream.xml";
        public static readonly string documentStart = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
        public static readonly (string start, string end) elementsBlock = ("<figures>", "</figures>");

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

        public static void Save(IFigure[] figures, FigureMaterial material, string path = myPath)
        {
            var document = documentStart;
            document += elementsBlock.start;

            foreach (var item in figures)
            {
                if (item != null)
                {
                    if ((material == FigureMaterial.Film) && (item.ColorOfFigure == FigureColor.Transparent))
                    {
                        WriteElement(item, ref document);
                    }
                    else if ((material == FigureMaterial.Paper) && (item.ColorOfFigure != FigureColor.Transparent))
                    {
                        WriteElement(item, ref document);
                    }
                }
            }
            document += elementsBlock.end;

            using var stream = new StreamWriter(path);
            stream.Write(document);
        }

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
                    string type = xnode.Attributes.GetNamedItem("type").Value;
                    string points = xnode.Attributes.GetNamedItem("points").Value;
                    string color = xnode.Attributes.GetNamedItem("color").Value;
                    var figure = XmlParser.FigureParse(type, points, color);
                    arrayOfFigures[counter++] = figure;
                }
            }
            return arrayOfFigures;
        }

        private static void WriteElement(IFigure figure, ref string document)
        {
            var type = figure.GetType().Name;
            var stringOfPoints = string.Join<Point>(',', figure.Points);
            var color = figure.ColorOfFigure.ToString();
            document += $"<figure type=\"{type}\" points=\"{stringOfPoints}\" color = \"{color}\" />";
        }
    }
}
