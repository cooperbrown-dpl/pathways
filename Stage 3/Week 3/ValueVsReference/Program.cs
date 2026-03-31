using System;

Console.WriteLine("Value Types vs Reference Types Activity\n");

// TODO: Complete the 10 activities below

// 1. Value Type - int
// Create two int variables. Assign the first to the second, then change the second. Print both values. What do you observe?
System.Console.WriteLine("----- Activity 1 -----");
var n1 = 5;
var n2 = n1;
n2 = 10;
System.Console.WriteLine($"n1: {n1}, n2: {n2}");

// 2. Value Type - struct
// Create a simple struct Point with two int fields: X and Y. Create two instances, assign one to the other, modify the second, and print both.
System.Console.WriteLine("----- Activity 2 -----");

Point p1 = new Point { X = 5, Y = 10 };
Point p2 = p1;
p2.X = 15;
System.Console.WriteLine($"p1: {p1.X}, {p1.Y}");
System.Console.WriteLine($"p2: {p2.X}, {p2.Y}");

// 3. Reference Type - class
// Create a simple class Student with a string Name property. Create two instances, assign one to the other, change the name on the second, and print both names.
System.Console.WriteLine("----- Activity 3 -----");
var s1 = new Student { Name = "Bob" };
var s2 = new Student();
s2 = s1;
s2.Name = "Alice";
System.Console.WriteLine(s1.Name);
System.Console.WriteLine(s2.Name);

// 4. Reference Type - string
// Strings are reference types but behave specially (immutable). Create two string variables, assign one to the other, then reassign the second. Print both.
System.Console.WriteLine("----- Activity 4 -----");
var myString1 = "Hello";
var myString2 = myString1;
myString2 = "Hola";
System.Console.WriteLine(myString1);
System.Console.WriteLine(myString2);

// 5. Passing Value Type to Method
// Create a method that takes an int parameter and modifies it. Call the method and show that the original variable is unchanged.
System.Console.WriteLine("----- Activity 5 -----");
int modifyInput(int n)
{
    return n = n * 2;
}

int num = 2;
var result = modifyInput(num);
System.Console.WriteLine(num);
System.Console.WriteLine(result);

// 6. Passing Reference Type to Method
// Create a method that takes a Student parameter and changes its Name. Show that the original object is modified.
System.Console.WriteLine("----- Activity 6 -----");
void modifyStudent(Student student)
{
    System.Console.WriteLine(student.Name);
    student.Name = "Charlie";
    System.Console.WriteLine(student.Name);
}

var alex = new Student { Name = "Alex" };
modifyStudent(alex);
System.Console.WriteLine(alex.Name);

// 7. Array is a Reference Type
// Create an int[] array, assign it to another variable, modify an element in the second array, and show both arrays reflect the change.
System.Console.WriteLine("----- Activity 7 -----");
var myArr1 = new int[] { 1, 2, 3 };
var myArr2 = myArr1;
myArr2[1] = 9;
foreach (var n in myArr1)
{
    System.Console.WriteLine(n);
}

foreach (var n in myArr2)
{
    System.Console.WriteLine(n);
}

// 8. Create your own struct
// Create a struct called Rectangle with Width and Height. Demonstrate that assigning one to another creates a copy.
System.Console.WriteLine("----- Activity 8 -----");

Rectangle r1 = new Rectangle { Width = 10, Height = 5 };
Rectangle r2 = r1;
r2.Width = 25;
System.Console.WriteLine(r1.Width);
System.Console.WriteLine(r2.Width);

// 9. Create your own class
// Create a class called Car with a string Model property. Demonstrate reference behavior.
System.Console.WriteLine("----- Activity 9 -----");
var ford = new Car { Model = "Mustang" };
Car car2 = ford;
car2.Model = "Maverick";

System.Console.WriteLine(ford.Model);
System.Console.WriteLine(car2.Model);

// 10. Summary Question
// In your own words, explain why modifying a struct does not affect the original variable, but modifying a class does.
// Write your explanation as comments in the code.

/*
Modifying the struct does not affect the original variable because a struct is a value type, not a reference type. This is contrary to a class which is
a reference type as opposed to a value type. With a class as a reference type, any other variable that references it, can change it's value, because it's the
only copy that exists.
*/

class Car
{
    public string Model { get; set; }
}

struct Rectangle
{
    public int Width;
    public int Height;
}
class Student
{
    public string Name { get; set; }
}

struct Point
{
    public int X;
    public int Y;
}