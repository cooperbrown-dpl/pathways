void Swap<T>(ref T a, ref T b)
{
    T temp = a;
    a = b;
    b = temp;
}
int x = 1, y = 2;
Swap(ref x, ref y);
Console.WriteLine($"{x}, {y}"); // 2, 1
string s1 = "hello", s2 = "world";
Swap(ref s1, ref s2);
Console.WriteLine($"{s1}, {s2}"); // world, hello


/*
C# Teaching Outline:

- Hello World
- Syntax and Structure
- Variables
- Data Types
- Loops
- Conditional Statements
- Arrays and Collections
- Methods
- Classes and Objects
- Inheritance and Polymorphism
- Interfaces and Abstract Classes
- Testing and Debugging
*/