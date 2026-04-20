# C# 

## 1. Program Structure

```csharp
// Namespace + class + Main (classic style)
namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
        }
    }
}

// Top-level statements (modern style)
Console.WriteLine("Hello, Top-level statements");
```

---

## 2. Variables & Data Types

### Value Types

```csharp
bool isActive = true;
char letter = 'A';

byte b = 255;
short s = 32000;
int age = 20;
long big = 12345678900L;

float numF = 3.14f;
double numD = 3.1415926;
decimal money = 99.99m;
```

### Reference Types

```csharp
string name = "Alice";
object obj = 123;
dynamic dyn = "test";
```

### Nullable Types

```csharp
int? a = null;
bool? isOK = null;
```

### Constant

```csharp
const double PI = 3.1415926;
```

---

## 3. Type Conversion

### Implicit

```csharp
int a = 100;
double b = a;
```

### Explicit

```csharp
double x = 3.99;
int y = (int)x; // 3
```

### String to Number

```csharp
string str = "123";
int a = int.Parse(str);
int b = Convert.ToInt32(str);

bool success = int.TryParse("456", out int result);
```

---

## 4. Operators

### Arithmetic

```csharp
+ - * / %
++ --
```

### Comparison

```csharp
> < >= <= == !=
```

### Logical

```csharp
&&
||
!
```

### Ternary

```csharp
string res = score >= 60 ? "Pass" : "Fail";
```

### Assignment

```csharp
= += -= *= /= %=
```

---

## 5. Console I/O

```csharp
Console.WriteLine("Hello");      // with newline
Console.Write("Hi");             // without newline

string name = Console.ReadLine();// read line
ConsoleKeyInfo key = Console.ReadKey(); // read key

Console.WriteLine($"Name: {name}, Age: {age}");
```

---

## 6. Conditional Statements

### if / else if / else

```csharp
if (score >= 90)
{
    Console.WriteLine("Excellent");
}
else if (score >= 60)
{
    Console.WriteLine("Pass");
}
else
{
    Console.WriteLine("Fail");
}
```

### switch

```csharp
switch (day)
{
    case 1: Console.WriteLine("Monday"); break;
    case 2: Console.WriteLine("Tuesday"); break;
    default: Console.WriteLine("Unknown"); break;
}
```

---

## 7. Loops

### for

```csharp
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}
```

### while

```csharp
int i = 0;
while (i < 5)
{
    i++;
}
```

### do while

```csharp
int i = 0;
do
{
    Console.WriteLine(i);
    i++;
} while (i < 5);
```

### foreach

```csharp
int[] arr = { 1, 2, 3 };
foreach (int item in arr)
{
    Console.WriteLine(item);
}
```

### break / continue

```csharp
break;
continue;
```

---

## 8. Arrays

```csharp
int[] arr1 = new int[5];
int[] arr2 = { 1, 2, 3, 4, 5 };

arr1[0] = 10;
int len = arr2.Length;
```

---

## 9. String Methods

```csharp
s.Length;
s.ToUpper();
s.ToLower();
s.Trim();
s.Contains("abc");
s.Replace("a", "b");
s.Substring(2);
s.Split(',');
s.IndexOf("b");
string.Join("-", arr);
```

---

## 10. Methods

### Basic Method

```csharp
static void SayHello()
{
    Console.WriteLine("Hi");
}

static int Add(int a, int b)
{
    return a + b;
}

int sum = Add(2, 3);
```

### Optional Parameters

```csharp
static void Print(string msg, int count = 1)
{
}
```

### out Parameters

```csharp
static void Calc(int a, int b, out int sum, out int product)
{
    sum = a + b;
    product = a * b;
}
```

### Overload

```csharp
static int Add(int a, int b) { return a + b; }
static double Add(double a, double b) { return a + b; }
```

### Recursion

```csharp
static int Fact(int n)
{
    return n == 0 ? 1 : n * Fact(n - 1);
}
```

---

## 11. Generic Collections

### List<T>

```csharp
List<int> list = new List<int>();
list.Add(1);
list.AddRange(new int[] { 2, 3 });
list.Remove(1);
list.RemoveAt(0);
int count = list.Count;
```

### Dictionary<TKey, TValue>

```csharp
Dictionary<string, int> dict = new Dictionary<string, int>();
dict["Tom"] = 20;
dict["Jerry"] = 18;
int age = dict["Tom"];
```

---

## 12. Enum & Struct

### Enum

```csharp
enum Gender
{
    Male,
    Female
}

Gender g = Gender.Male;
```

### Struct

```csharp
struct Point
{
    public int X;
    public int Y;
}

Point p;
p.X = 10;
p.Y = 20;
```

---

## 13. Class & Object

```csharp
class Person
{
    private string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void SayHi()
    {
        Console.WriteLine(Name);
    }
}

Person p = new Person("Alice", 20);
p.SayHi();
```

---

## 14. Access Modifiers

```csharp
public      // accessible everywhere
private     // inside class only
protected   // class + derived classes
internal    // same assembly
```

---

## 15. Inheritance & Polymorphism

```csharp
class Animal
{
    public virtual void Shout()
    {
        Console.WriteLine("Shout");
    }
}

class Dog : Animal
{
    public override void Shout()
    {
        Console.WriteLine("Woof");
    }
}
```

---

## 16. Interface

```csharp
interface IRunnable
{
    void Run();
}

class Car : IRunnable
{
    public void Run()
    {
        Console.WriteLine("Running");
    }
}
```

---

## 17. Abstract Class

```csharp
abstract class Shape
{
    public abstract double GetArea();
}

class Circle : Shape
{
    public override double GetArea()
    {
        return 0;
    }
}
```

---

## 18. Exception Handling

```csharp
try
{
    int n = int.Parse("abc");
}
catch (FormatException ex)
{
    Console.WriteLine("Format error");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Always executed");
}
```

---

## 19. Generics

```csharp
static T Max<T>(T a, T b) where T : IComparable
{
    return a.CompareTo(b) > 0 ? a : b;
}

int max = Max<int>(10, 20);
```

---

## 20. Common Utility Classes

### Math

```csharp
Math.Abs(-5);
Math.Round(3.55);
Math.Sqrt(16);
Math.Pow(2, 3);
```

### DateTime

```csharp
DateTime now = DateTime.Now;
Console.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss"));
```

### Random

```csharp
Random rnd = new Random();
int num = rnd.Next(1, 101);
```

---

## 21. Basic LINQ Query

```csharp
List<int> list = new List<int> { 1, 2, 3, 4, 5, 6 };
var result = from n in list
             where n > 3
             orderby n descending
             select n;
```
