using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMO.ADO.NET.Lab7.LinqStudent
{
    class Program
    {
        static List<Student> students = new List<Student>
        {
            new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
            new Student {First="Claire", Last="O’Donnell", ID=112, Scores= new List<int> {75, 98, 91, 39}},
            new Student {First="Marina", Last="Garcia", ID=113, Scores= new List<int> {94, 93, 86, 65}},
            new Student {First="Alex", Last="Alexandrov", ID=114, Scores= new List<int> {78, 88, 89, 65}},
            new Student {First="Petr", Last="Vasin", ID=115, Scores= new List<int> {94, 92, 98, 76}},
            new Student {First="Ivan", Last="Vagin", ID=116, Scores= new List<int> {72, 76, 86, 39}},
            new Student {First="Alesha", Last="Aleshin", ID=117, Scores= new List<int> {93, 35, 81, 60}},
            new Student {First="Sergei", Last="Sidorov", ID=118, Scores= new List<int> {78, 87, 91, 39}},
            new Student {First="Anton", Last="Petrov", ID=119, Scores= new List<int> {95, 56, 81, 60}},
            new Student {First="Kostik", Last="Ivanov", ID=120, Scores= new List<int> {77, 76, 91, 39}},
        };

        static void Main(string[] args)
        {
            IEnumerable<Student> studentQuery =
                from student in students
                where student.Scores[0] > 90 && student.Scores[3] < 80
                orderby student.Scores[0] descending
                select student;
            foreach (Student student in studentQuery)
            {
                Console.WriteLine("{0}, {1} {2}", student.Last, student.First, student.Scores[0]);
            }
            Console.WriteLine("\n");    
            var studentQuery2 =
                from student in students
                group student by student.Last[0];                
            foreach (var studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (Student student in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}",
                              student.Last, student.First);
                }
            }
            Console.WriteLine("\n");
            var studentQuery3 =
                from student in students
                group student by student.Last[0];

            foreach (var groupOfStudents in studentQuery3)
            {
                Console.WriteLine(groupOfStudents.Key);
                foreach (var student in groupOfStudents)
                {
                    Console.WriteLine("   {0}, {1}",
                        student.Last, student.First);
                }
            }
            Console.WriteLine("\n");
            var studentQuery4 =
                from student in students
                group student by student.Last[0] into studentGroup
                orderby studentGroup.Key
                select studentGroup;

            foreach (var groupOfStudents in studentQuery4)
            {
                Console.WriteLine(groupOfStudents.Key);
                foreach (var student in groupOfStudents)
                {
                    Console.WriteLine("   {0}, {1}",
                        student.Last, student.First);
                }
            }
            Console.WriteLine("\n");
            var studentQuery5 =
                from student in students
                let totalScore = student.Scores[0] + student.Scores[1] +
                    student.Scores[2] + student.Scores[3]
                where totalScore / 4 < student.Scores[0]
                select student.Last + " " + student.First;

            foreach (string s in studentQuery5)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("\n");
            var studentQuery6 =
                from student in students
                let totalScore = student.Scores[0] + student.Scores[1] +
                    student.Scores[2] + student.Scores[3]
                select totalScore;
            double averageScore = studentQuery6.Average();
            Console.WriteLine("Class average score = {0}", averageScore);

            Console.WriteLine("\n");
            IEnumerable<string> studentQuery7 =
                from student in students
                where student.Last == "Garcia"
                select student.First;
            Console.WriteLine("The Garcias in the class are:");
            foreach (string s in studentQuery7)
            {
                Console.WriteLine(s);
            }
            var studentQuery8 =
                from student in students
                let x = student.Scores[0] + student.Scores[1] +
                    student.Scores[2] + student.Scores[3]
                where x > averageScore
                select new { id = student.ID, score = x };

            foreach (var item in studentQuery8)
            {
                Console.WriteLine("Student ID: {0}, Score: {1}", item.id, item.score);
            }

        }
    }
}
