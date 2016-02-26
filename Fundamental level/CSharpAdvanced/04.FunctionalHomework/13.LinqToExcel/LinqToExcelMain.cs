namespace _13.LinqToExcel
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using ExcelLibrary.SpreadSheet;

    public class LinqToExcelMain
    {
        public static void Main(string[] args)
        {
            List<Student> studentsData = new List<Student>(1000);

            using (StreamReader streamReader = new StreamReader("Students-data.txt"))
            {
                while (true)
                {
                    string stringLine = streamReader.ReadLine();

                    if (string.IsNullOrEmpty(stringLine))
                    {
                        break;
                    }

                    string[] info = stringLine.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    if (info.Length != 12)
                    {
                        continue;
                    }

                    Student student = new Student(
                        int.Parse(info[0]),
                        info[1],
                        info[2],
                        info[3],
                        info[4],
                        info[5],
                        int.Parse(info[6]),
                        int.Parse(info[7]),
                        double.Parse(info[8]),
                        double.Parse(info[9]),
                        double.Parse(info[10]),
                        double.Parse(info[11]));

                    studentsData.Add(student);
                }
            }

            var sortedByTypeAndResult = studentsData.Where(s => s.StudentType == "Online").OrderByDescending(s => s.Result).ToList();

            Worksheet onlineStudentsSheet = new Worksheet("Online students");
            Workbook workbook = new Workbook();

            List<string> header = new List<string>()
                                      {
                                          "ID",
                                          "First name:",
                                          "Last name:",
                                          "Email:",
                                          "Gender:",
                                          "Student type:",
                                          "Exam result",
                                          "Homework sent",
                                          "Homework evaluated",
                                          "Teamwork",
                                          "Attendancies",
                                          "Bonus"
                                      };
            int colsCount = typeof(Student).GetProperties().Count();
            for (int row = 0; row < sortedByTypeAndResult.Count(); row++)
            {
                for (int col = 0; col < colsCount - 1; col++)
                {
                    if (row == 0)
                    {
                        onlineStudentsSheet.Cells[row, col] = new Cell(header[col]);
                    }
                    else
                    {
                        var studentProp = sortedByTypeAndResult[row].GetType().GetProperties();
                        List<object> propValues = studentProp.Select(propertyInfo => propertyInfo.GetValue(sortedByTypeAndResult[row])).ToList();
                        onlineStudentsSheet.Cells[row, col] = new Cell(propValues[col]);
                    }
                }
            }

            workbook.Worksheets.Add(onlineStudentsSheet);

            workbook.Save("..\\..\\Student.xls");
        }
    }
}
