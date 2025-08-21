using code_one_support;
using code_one_support.Classes;


//object create type 1
Teacher teacher1 = new Teacher();

teacher1.TeacherId = 1;
teacher1.Name = "Dexter";
teacher1.ContactNumber = "0778484554";

Console.WriteLine(teacher1.Name);
//---------------

TeacherManager manager = new TeacherManager();

//object create type 2 >> Object initializer syntax
Teacher teacher_2 = new Teacher
{
    TeacherId = 2,
    Name = "Tres",
    ContactNumber = "011454556"
};

/*
This code creates a new Teacher object using object initializer syntax:
Teacher teacher_2 = new Teacher
{
    TeacherId = 2,
    Name = "Tres",
    ContactNumber = "011454556"
};

What it does:

Instantiates a new Teacher object.
Sets its properties (TeacherId, Name, ContactNumber) in one block.
Syntax usage:

The curly braces { ... } after new Teacher let you set property values directly.
This is called an object initializer and is a concise way to assign values when creating an object.

It’s equivalent to:
Teacher teacher_2 = new Teacher();
teacher_2.TeacherId = 2;
teacher_2.Name = "Tres";
teacher_2.ContactNumber = "011454556";

But shorter and more readable.
*/

manager.AddTeacher(teacher_2);

foreach (var t in manager.GetTeachers())
{
    Console.WriteLine($"TeacherId:\t{t.TeacherId}\nTeacher Name:\t{t.Name}\nContact Number:\t{t.ContactNumber}");
}

//object create type 3
/* Insight
Your `Teacher` class in `Teacher.cs` only has a default (parameterless) constructor. It does not define any constructor that takes arguments.

So, if you try to create a `Teacher` object like this:

```csharp
var teacher = new Teacher(arg1, arg2, arg3);
```

it will fail, because there is no constructor matching those parameters.

**Solution:**  
Add a constructor to your class:

```csharp
public Teacher(int teacherId, string name, string contactNumber)
{
    TeacherId = teacherId;
    Name = name;
    ContactNumber = contactNumber;
}
```

Or, use the default constructor and set properties individually:

```csharp
var teacher = new Teacher();
teacher.TeacherId = ...;
teacher.Name = ...;
teacher.ContactNumber = ...;
```

**Summary:**  
The error occurs because your class does not have a constructor that takes three arguments.
*/
//Teacher teacher3 = new Teacher(3, "Sandy", "03333333");
//Console.WriteLine("Id = {0} && Name = {1}", teacher3.TeacherId, teacher3.Name);

Teacher teacher3 = new Teacher(3, "Sandy", "03333333");
Console.WriteLine("Id : {0} && Name = {1}", teacher3.TeacherId, teacher3.Name);
/* **composite format string**
The selected syntax:

```csharp
"Id : {0} && Name = {1}"
```

is a **composite format string** used in C# for string formatting.

**What it does:**
- `{0}` and `{1}` are placeholders for values that will be inserted when the string is used with methods like `Console.WriteLine` or `string.Format`.
- Example usage:
  ```csharp
  Console.WriteLine("Id : {0} && Name = {1}", teacher3.TeacherId, teacher3.Name);
  ```
  This will print:  
  `Id : 3 && Name = Sandy`

**Summary:**  
It’s a template for formatting output, allowing you to insert variable values into a string.
*/
/*This is **composite formatting**, not string interpolation.

- **Composite formatting:**  
  Uses placeholders like `{0}`, `{1}` in a format string, and values are supplied as arguments:
  ```csharp
  Console.WriteLine("Id : {0} && Name = {1}", teacher3.TeacherId, teacher3.Name);
  ```

- **String interpolation:**  
  Uses `$` and curly braces to embed variables directly:
  ```csharp
  Console.WriteLine($"Id : {teacher3.TeacherId} && Name = {teacher3.Name}");
  ```

**Summary:**  
Your example uses composite formatting, not string interpolation.
*/