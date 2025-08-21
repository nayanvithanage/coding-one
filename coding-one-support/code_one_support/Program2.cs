using code_one_support.Models;

namespace code_one_support.Program2
{
    public class Program2
    {
        void Run()
        {

            List<Teacher> listOfTeachers = new List<Teacher>();

            /* This syntax:

            List<Teacher> listOfTeachers = new List<Teacher>();

            **Explanation:**

            - `List<Teacher>`:  
            Declares a variable of type `List<Teacher>`, which is a generic collection that can store multiple `Teacher` objects.

            - `listOfTeachers`:  
            The name of the variable (the list you will use).

            - `new List<Teacher>()`:  
            Creates a new, empty list of `Teacher` objects using the `List<Teacher>` constructor.

            - The whole line:  
            Declares and initializes an empty list that you can add, remove, and access `Teacher` objects by index.

            **Syntax breakdown:**
            - `Type variableName = new Type();`
            - `List<T>` is a generic class, where `T` is the type of items stored (here, `Teacher`).

            **Usage example:**

            listOfTeachers.Add(new Teacher(1, "Dexter", "0778484554"));
            var firstTeacher = listOfTeachers[0];

            **Summary:**  
            This line creates an empty list to hold `Teacher` objects, ready for you to add, remove, or access teachers as needed.
            */

            //Adding items to the list
            listOfTeachers.Add(new Teacher(1, "Dexter", "012454545"));
            var firstTeacher = listOfTeachers[0];
            /*
            The error is likely because you are declaring and using `listOfTeachers` directly inside the class body, but not inside a method, property, or constructor.

            In C#, you cannot execute statements like `listOfTeachers.Add(...)` or `var firstTeacher = ...` directly in the class body.  
            These lines must be inside a method (like `Main`), a constructor, or a property.

            **How to fix:**
            Move the code into a method, for example:

            ```csharp
            public class Program2
            {
                public void Run()
                {
                    List<Teacher> listOfTeachers = new List<Teacher>();
                    listOfTeachers.Add(new Teacher(1, "Dexter", "012454545"));
                    var firstTeacher = listOfTeachers[0];
                }
            }
            ```

            Or, for a console app, use the `Main` method:

            ```csharp
            public class Program2
            {
                public static void Main(string[] args)
                {
                    List<Teacher> listOfTeachers = new List<Teacher>();
                    listOfTeachers.Add(new Teacher(1, "Dexter", "012454545"));
                    var firstTeacher = listOfTeachers[0];
                }
            }
            ```

            **Summary:**  
            You cannot execute statements directly in the class body; put them inside a method or constructor.
            */


        }
        
    }



}