using System;
using System.Collections.Generic;
using System.Linq;

var students = new List<Student>
{
    new Student { Id = 1, Name = "Alice Smith", Age = 20, Grade = "A" },
    new Student { Id = 2, Name = "Bob Johnson", Age = 19, Grade = "B" },
    new Student { Id = 3, Name = "Charlie Brown", Age = 21, Grade = "C" },
    new Student { Id = 4, Name = "Diana Prince", Age = 20, Grade = "A" },
    new Student { Id = 5, Name = "Ethan Hunt", Age = 22, Grade = "B" }
};

// TODO: Complete the 5 activities below

// Activity 1: List all students
// Print the name and grade of every student.
foreach (var s in students)
{
    System.Console.WriteLine($"{s.Name}, Grade: {s.Grade}");
}

// Activity 2: Show students with grade "A"
// Display only the names of students who have grade "A".
var aStudents = students.Where(s => s.Grade == "A").ToList();
System.Console.WriteLine("Students with a grade of A:");
foreach (var s in aStudents)
{
    System.Console.WriteLine($"- {s.Name}");
}

// Activity 3: Add a new student
// Add a new student: Name = "Fiona Green", Age = 19, Grade = "B".
var fiona = new Student
{
    Name = "Fiona Green",
    Age = 19,
    Grade = "B"
};
students.Add(fiona);
foreach (var s in students)
{
    System.Console.WriteLine($"{s.Name}, Grade: {s.Grade}, Age: {s.Age}");
}

// Activity 4: Update a student's age
// Change Bob Johnson's age to 20.
var bob = students.FirstOrDefault(s => s.Name == "Bob Johnson");
bob.Age = 20;

foreach (var s in students)
{
    System.Console.WriteLine($"{s.Name}, Age: {s.Age}");
}

// Activity 5: Count students older than 20
// Print how many students are older than 20 years old.
var olderThan20 = students.Where(s => s.Age > 20).ToList().Count();

System.Console.WriteLine($"Student older than 20: {olderThan20}");

class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Grade { get; set; } = string.Empty;
}