/* Access Modifiers
    1. public
    2. private
    3. protected
    4. internal
    5. protected internal
    6. private protected

*/

// 1. public
public class ThisIsAPublicClass
{
    public int PublicClassValue;

    // 3. private - Accessible only within the same class.
    private class MyPrivateClass
    {
        private int thisIsPrivateInt;
        /*
        In C#, you cannot declare a top-level class as `private`.  
        Only nested classes (classes declared inside another class) can be `private`.

        **Access for a private nested class:**
        - The private class is accessible only within the containing (outer) class.
        - It cannot be accessed from outside the outer class, not even from other classes in the same namespace or assembly.

        **Example:**
        ```csharp
        public class Outer
        {
            private class Inner
            {
                // Only accessible inside Outer
            }

            void Method()
            {
                Inner inner = new Inner(); // OK
            }
        }

        class Other
        {
            // Inner is NOT accessible here
        }
        ```

        **Summary:**  
        A `private` class can only be used inside its containing class.  
        You cannot declare a top-level class as `private` in C#.
        */
    }
}

// 2. Internal (By default)
class TestClass
{
    /* **internal** by default
        The selected class: 

        ```csharp
        class TestClass
        {
            
        }
        ```

        has the **internal** access modifier by default.

        **Explanation:**  
        If no access modifier is specified for a top-level class in C#, it is `internal` by default, meaning it is accessible only within the same assembly/project.
    */
    /***assembly**
     In C#, an **assembly** is a compiled code library used for deployment, versioning, and security.

        - It is usually a `.dll` (class library) or `.exe` (application) file.
        - An assembly contains one or more namespaces, classes, and resources.
        - Assemblies are the building blocks of .NET applications; they are what you run or reference.

        **Summary:**  
        An assembly is the output file (DLL or EXE) created when you build your project.  
        Access modifiers like `internal` restrict access to code within the same assembly (project output file).
    */
    ThisIsAPublicClass _thisIsPublicClass = new ThisIsAPublicClass();


}

// 3. protected - Accessible within the class and dericed classes
public class BaseClass
{
    protected int myProtected; //Accessible in Base class and sub classes
}

public class DerivedClass : BaseClass
{
    void Example()
    {
        myProtected = 5;
    }
}
