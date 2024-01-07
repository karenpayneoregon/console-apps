using System.Text.Json;
using MenuConsoleStudentWorkApp.Models;

namespace MenuConsoleStudentWorkApp.Classes;
internal class FileOperations
{
    public static readonly string FileName = "data.json";
    public static List<Student> GetStudents()
    {
        List<Student> studentList;
        if (File.Exists(FileName))
        {
            studentList = JsonSerializer.Deserialize<List<Student>>(File.ReadAllText(FileName))!;
            studentList.Add(new Student() { Id = -1, FirstName = "Exit" });
        }
        else
        {
            studentList = BogusOperations.GenerateStudents();
            Save(studentList);
        }

        return studentList;
    }

    public static void Save(List<Student> studentList)
    {
        
        var student = studentList.FirstOrDefault(x => x.Id == -1);

        if (student is not null)
        {
            studentList.Remove(student);
        }

        File.WriteAllText(FileName, 
            JsonSerializer.Serialize(studentList, 
                new JsonSerializerOptions { WriteIndented = true }));
    }
}

