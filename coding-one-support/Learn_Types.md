In C#, a **type** defines what kind of data a variable can hold and what operations can be performed on it. Here’s an overview from the basics:

---

### 1. Value Types

- Store data directly.
- Examples: `int`, `double`, `char`, `bool`, `struct`, `enum`
- Allocated on the stack.
- Cannot be `null` (except for nullable types).

**Examples:**
```csharp
int age = 25;
double price = 19.99;
bool isActive = true;
char letter = 'A';
```

---

### 2. Reference Types

- Store a reference (address) to the data.
- Examples: `string`, `class`, `interface`, `array`, `delegate`
- Allocated on the heap.
- Can be `null`.

**Examples:**
```csharp
string name = "Dexter";
Teacher teacher = new Teacher();
int[] numbers = { 1, 2, 3 };
```

---

### 3. Built-in Types

- **Numeric:** `int`, `float`, `double`, `decimal`, `byte`, `short`, `long`
- **Text:** `char`, `string`
- **Boolean:** `bool`
- **Object:** `object` (base type for all types)

---

### 4. User-defined Types

- **Class:** Blueprint for objects.
- **Struct:** Similar to class, but value type.
- **Enum:** Set of named constants.
- **Interface:** Contract for classes.

**Examples:**
```csharp
public class Teacher { ... }
public struct Point { ... }
public enum Day { Monday, Tuesday }
public interface IPrintable { void Print(); }
```

---

### 5. Nullable Types

- Allow value types to be `null`.
- Syntax: `int?`, `double?`, etc.

**Example:**
```csharp
int? age = null;
```

---

### 6. Generic Types

- Allow types to be specified as parameters.
- Example: `List<T>`, `Dictionary<TKey, TValue>`

**Example:**
```csharp
List<int> numbers = new List<int>();
Dictionary<int, string> map = new Dictionary<int, string>();
```

---

### 7. Array Types

- Fixed-size collection of elements of the same type.

**Example:**
```csharp
int[] scores = new int[5];
```

---

### 8. Type Aliases

- Some C# types are aliases for .NET types:
  - `int` = `System.Int32`
  - `string` = `System.String`
  - `bool` = `System.Boolean`

---

### 9. Dynamic Type

- Type checked at runtime.
- Use `dynamic` keyword.

**Example:**
```csharp
dynamic value = 10;
value = "Hello";
```

---

**Summary:**  
Types in C# define the kind of data and its behavior.  
They include value types, reference types, built-in types, user-defined types, generics, arrays, and more.  
Understanding types is fundamental to writing safe and efficient C# code.

Let me know if you want to dive deeper into any specific type!