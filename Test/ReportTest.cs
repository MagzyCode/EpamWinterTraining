using Epam_Task7.Enums;
using Epam_Task7.Reports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    /// <summary>
    /// Class for testing class Report.
    /// </summary>
    [TestClass]
    public class ReportTest
    {
        /// <summary>
        /// The method tests the method generation specialty result by session.
        /// </summary>
        [TestMethod]
        public void GenerateSessionReport_GenerationSpecialtyResultBySession_GenerationReport()
        {
            string path = @"..\..\..\..\..\Task7\Epam_Task7\Resources\Reports1.xlsx";
            string pathFileStream = @"..\..\..\..\Task7\Epam_Task7\Resources\Reports1.xlsx";
            int sortableSheet = 2;
            int sessionNumber = 2;
            GenerationReport generationReport = new GenerationReport();
            generationReport.GenerationSpecialtyResultBySession(sessionNumber, path, sortableSheet, SortOrder.Ascending);

            long result;
            using (var reader = new FileStream(pathFileStream, FileMode.OpenOrCreate))
            {
                result = reader.Length;
            }

            Assert.IsTrue(result != 0);
        }

        /// <summary>
        /// The method tests the method generation session result by examinator.
        /// </summary>
        [TestMethod]
        public void GenerateReport_GenerationSessionResultByExaminator_GenerationReport()
        {
            string path = @"..\..\..\..\..\Task7\Epam_Task7\Resources\Reports2.xlsx";
            string pathFileStream = @"..\..\..\..\Task7\Epam_Task7\Resources\Reports2.xlsx";
            int sortableSheet = 3;
            int sessionNumber = 1;
            GenerationReport generationReport = new GenerationReport();
            generationReport.GenerationSessionResultByExaminator(sessionNumber, path, sortableSheet, SortOrder.Ascending);

            long result;
            using (var reader = new FileStream(pathFileStream, FileMode.OpenOrCreate))
            {
                result = reader.Length;
            }

            Assert.IsTrue(result != 0);
        }

        /// <summary>
        /// The method tests the method generation average result student by year.
        /// </summary>
        [TestMethod]
        public void GenerateReport_GenerationAverageResultStudentByYear_GenerationReport()
        {
            string path = @"..\..\..\..\..\Task7\Epam_Task7\Resources\Reports3.xlsx";
            string pathFileStream = @"..\..\..\..\Task7\Epam_Task7\Resources\Reports3.xlsx";
            int sortableSheet = 2;
            GenerationReport generationReport = new GenerationReport();
            generationReport.GenerationAverageResultStudentByYear(path, sortableSheet, SortOrder.Ascending);

            long result;
            using (var reader = new FileStream(pathFileStream, FileMode.OpenOrCreate))
            {
                result = reader.Length;
            }

            Assert.IsTrue(result != 0);
        }
    }
}
