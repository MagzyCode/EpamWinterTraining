using Microsoft.Office.Interop.Excel;
using Students.Enums;
using Students.Objects;
using Students.WorkWithOrm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Students.Reports
{
    /// <summary>
    /// Class generation reports.
    /// </summary>
    public class GenerationReport
    {
        /// <summary>
        /// The constructor initializes the GenerationReport.
        /// </summary>
        /// <param name="name">Group name.</param>
        public GenerationReport(string connectionString)
        {
            StudentDbContext = new StudentDbContext(connectionString);
        }

        /// <summary>
        /// The property stores information about StudentDbContext.
        /// </summary>
        public StudentDbContext StudentDbContext { get; set; }

        /// <summary>
        /// Method saving in xlsx format file of session results for session group in the form of a table.
        /// </summary>
        /// <param name="pathToFile">Path to file.</param>
        /// <param name="sortableSheet">Sorted table number.</param>
        /// <param name="sortOrder">Sort order.</param>
        public void GenerationSessionResultReportByGroup(int sessionNumber, string pathToFile, int sortableSheet, SortOrder sortOrder)
        {
            Application application = new Application();
            Workbook workBook = application.Workbooks.Add();
            Worksheet workSheet = (Worksheet)workBook.ActiveSheet;

            workSheet.Cells[1, "A"] = "Session";
            workSheet.Cells[1, "B"] = "Group";
            workSheet.Cells[1, "C"] = "Student";
            workSheet.Cells[1, "D"] = "EducationSubject";
            workSheet.Cells[1, "E"] = "Type";
            workSheet.Cells[1, "F"] = "Mark";

            int i = 2;

            foreach (StudentResult item in StudentDbContext.StudentResult.Collection)
            {
                if (item.SessionEducationalSubject.Session.SessionNumber == sessionNumber)
                {
                    workSheet.Cells[i, "A"] = item.SessionEducationalSubject.Session.SessionNumber;
                    workSheet.Cells[i, "B"] = item.SessionEducationalSubject.Session.Group.Name;
                    workSheet.Cells[i, "C"] = item.Student.FullName;
                    workSheet.Cells[i, "D"] = item.SessionEducationalSubject.EducationalSubject.SubjectName;
                    workSheet.Cells[i, "E"] = item.SessionEducationalSubject.EducationalSubject.SubjectType;
                    workSheet.Cells[i, "F"] = item.Mark;
                    i++;
                }
            }

            SortSheet(workSheet, i, sortableSheet, (XlSortOrder)sortOrder);

            try
            {
                workBook.Close(true, $"{Environment.CurrentDirectory}" + pathToFile);
                application.Quit();
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid path to file.");
            }
        }

        /// <summary>
        /// Method for each session, display the xlsx pivot table with average / minimum / maximum score for each group.
        /// </summary>
        /// <param name="pathToFile">Path to file.</param>
        /// <param name="sortableSheet">Sorted table number.</param>
        /// <param name="sortOrder">Sort order.</param>
        public void GenerationResultSummaryTableByGroup(string pathToFile, int sortableSheet, SortOrder sortOrder)
        {
            Application application = new Application();
            Workbook workBook = application.Workbooks.Add();
            Worksheet workSheet = (Worksheet)workBook.ActiveSheet;

            workSheet.Cells[1, "A"] = "Session";
            workSheet.Cells[1, "B"] = "Group";
            workSheet.Cells[1, "C"] = "Average Mark";
            workSheet.Cells[1, "D"] = "Min Mark";
            workSheet.Cells[1, "E"] = "Max Mark";

            int i = 2;

            List<int> countId = StudentDbContext.StudentResult.Collection.Select(item => item.SessionEducationalSubject.SessionId).Distinct().ToList();

            foreach (StudentResult item in StudentDbContext.StudentResult.Collection)
            {
                if (countId.Where(obj => obj == item?.SessionEducationalSubject?.SessionId).Select(obj => obj).Count() == 1)
                {
                    var examList = StudentDbContext.StudentResult.Collection
                        .Where(item => item.SessionEducationalSubject?
                        .EducationalSubject.SubjectType == "Exam")
                        .Select(item => item).ToList();

                    List<double> markForGroup = GetStudentMarkForGroup(examList,
                        item.SessionEducationalSubject.SessionId,
                        item.SessionEducationalSubject.Session.GroupId);

                    workSheet.Cells[i, "A"] = item?.SessionEducationalSubject?.Session?.SessionNumber;
                    workSheet.Cells[i, "B"] = item?.SessionEducationalSubject?.Session?.Group.Name;

                    workSheet.Cells[i, "C"] = markForGroup.Average();

                    workSheet.Cells[i, "D"] = markForGroup.Min();

                    workSheet.Cells[i, "E"] = markForGroup.Max();
                    i++;
                    countId.Add(item.SessionEducationalSubject.SessionId);
                }
            }

            SortSheet(workSheet, i, sortableSheet, (XlSortOrder)sortOrder);

            try
            {
                workBook.Close(true, $"{Environment.CurrentDirectory}" + pathToFile);
                application.Quit();
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid path to file.");
            }
        }

        /// <summary>
        /// Method generation bad student by group.
        /// </summary>
        /// <param name="pathToFile">Path to file.</param>
        /// <param name="sortableSheet">Sorted table number.</param>
        /// <param name="sortOrder">Sort order.</param>
        public void GenerationBadStudentByGroup(string pathToFile, int sortableSheet, SortOrder sortOrder)
        {
            Application application = new Application();
            Workbook workBook = application.Workbooks.Add();
            Worksheet workSheet = (Worksheet)workBook.ActiveSheet;

            workSheet.Cells[1, "A"] = "Group";
            workSheet.Cells[1, "B"] = "Student";

            int i = 2;
            int tempMark = 4;
            int idCount = 0;
            string creditResultIsNotPassed = "Not Passed";
            List<int> countStudentId = StudentDbContext.StudentResult.Collection.Select(item => item.StudentId).Distinct().ToList();

            foreach (StudentResult item in StudentDbContext.StudentResult.Collection)
            {
                int.TryParse(item.Mark, out tempMark);
                idCount = countStudentId.Where(obj => obj == item.StudentId).Count();
                if (idCount == 1 && ((tempMark < 4 && tempMark != 0) || item.Mark == creditResultIsNotPassed))
                {
                    workSheet.Cells[i, "A"] = item.SessionEducationalSubject.Session.Group.Name;
                    workSheet.Cells[i, "B"] = item.Student.FullName;
                    countStudentId.Add(item.StudentId);
                    i++;
                }

            }

            SortSheet(workSheet, i, sortableSheet, (XlSortOrder)sortOrder);

            try
            {
                workBook.Close(true, $"{Environment.CurrentDirectory}" + pathToFile);
                application.Quit();
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid path to file.");
            }
        }

        /// <summary>
        /// Method sort sheet.
        /// </summary>
        /// <param name="workSheet">Work Sheet.</param>
        /// <param name="maxLine">Max Line.</param>
        /// <param name="sortableSheet">Sortable Sheet.</param>
        /// <param name="xlSortOrder">Sort Order.</param>
        private static void SortSheet(Worksheet workSheet, int maxLine, int sortableSheet, XlSortOrder xlSortOrder)
        {
            var rngSort = workSheet.get_Range("A1", $"F{maxLine}");
            rngSort.Sort(rngSort.Columns[sortableSheet, Type.Missing], xlSortOrder,
            null, Type.Missing, XlSortOrder.xlAscending,
            Type.Missing, XlSortOrder.xlAscending,
            XlYesNoGuess.xlYes, Type.Missing, Type.Missing,
            XlSortOrientation.xlSortColumns);
        }

        /// <summary>
        /// Method get student mark for group.
        /// </summary>
        /// <param name="listStudentResults">List student results.</param>
        /// <param name="sessionId">Session id.</param>
        /// <param name="groupId">Group id.</param>
        /// <returns>List sessionEducationalSubject objects.</returns>
        private static List<double> GetStudentMarkForGroup(List<StudentResult> listStudentResults, int sessionId, int groupId)
        {
            return listStudentResults.Where(item => item.SessionEducationalSubject.SessionId == sessionId
            && item.SessionEducationalSubject.Session.GroupId == groupId)
                .Select(item => double.Parse(item.Mark)).ToList();
        }
    }
}
