using Microsoft.AspNetCore.Mvc;
using coding_one.Models;

namespace coding_one
{
    /// <summary>
    /// Manage Students.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    /*is an attribute that sets the base route for all actions in the StudentController class.

        It means all endpoints in this controller will start with api/student (since [controller] is replaced by the controller's name minus "Controller").
        For example, the Get method will be accessible at api/student.
        In short:
        It defines the URL pattern for accessing the controller’s API endpoints.*/
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>();
        /*does the following:
            Declares a private static field named students that holds a list of Student objects.
            
            private means it can only be accessed within the StudentController class.
            static means the list is shared across all instances of the controller (not per request).
            Initializes the list as empty using new List<Student>().
            
            In short:
            It creates a shared, in-memory list to store student data for the API.
        */

        /*
        We use List<Student> instead of IEnumerable<Student> when we need to:

        Add, remove, or update items in the collection.
        Access items by index (e.g., students[0]).
        Use methods like Add(), Remove(), Clear(), etc.
        IEnumerable<Student> is only for reading and iterating; it does not support modifying the collection or accessing by index.

        Summary:

        Use List<Student> for storing and managing data.
        Use IEnumerable<Student> for exposing or returning data, especially when you only need to read or loop through it.
        */

        /// <summary>
        /// Gets all students.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get() => students;
        /*
        What it does:

        Declares a public method named Get that handles HTTP GET requests.
        Returns the list of all students.
        The return type ActionResult<IEnumerable<Student>> allows returning either the list or an HTTP error response if needed.
        
        Syntaxes and conventions used:

        Method Declaration
        public makes the method accessible outside the class.
        The method name Get follows RESTful naming conventions for retrieving resources.
        
        Return Type
        ActionResult<IEnumerable<Student>> is a generic type that can return a collection of Student objects or an HTTP response.
        
        Expression-bodied Member (=>)
        Uses the => syntax for concise method implementation, returning students directly.
        
        Generic Collection (IEnumerable<Student>)
        Uses IEnumerable<Student> to represent a collection of students.
        
        Camel Case Naming
        Variable and property names use camel case (students, Student).
        */

        /// <summary>
        /// Gets student by Id.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id); //?
            /*does the following:
            Searches the students list for the first student whose StudentId matches the given id.
            If a matching student is found, it assigns that student to the student variable.
            If no match is found, student will be null.
            It uses a LINQ method (FirstOrDefault) with a lambda expression to filter the list.*/
            if (student == null) return NotFound();
            return student;
        }

        /// <summary>
        /// Add new student.
        /// </summary>
        [HttpPost]
        public ActionResult<Student> Post(Student student)
        {
            student.StudentId = students.Count > 0 ? students.Max(s => s.StudentId) + 1 : 1; //? what this line does
            /*This line assigns a unique ID to a new student when adding them to the list:
                If there are already students in the list (students.Count > 0), it finds the highest existing StudentId (students.Max(s => s.StudentId)) and sets the new student's ID to that value plus one.
                If the list is empty, it sets the new student's ID to 1.
            In short: it auto-generates a new, incremented StudentId for each new student.

            Ternary Operator (? :)
                Syntax: condition ? value_if_true : value_if_false
                Example: students.Count > 0 ? ... : ...
                It checks if there are any students. If true, it does one thing; if false, another.
            
            Lambda Expression (s => s.StudentId)
                Syntax: (parameter) => expression
                Example: students.Max(s => s.StudentId)
                Used to select the StudentId property from each student in the list.
                
            Method Call (Max)
                Syntax: collection.Method(lambda)
                Example: students.Max(s => s.StudentId)
                Finds the maximum StudentId in the list.
            
            Assignment (=)

                Syntax: variable = value
                Example: student.StudentId = ...
                Assigns the calculated value to StudentId.
            
            Arithmetic (+ 1)
                Adds 1 to the maximum ID to generate the next ID.
            
            Property Access (students.Count, student.StudentId)
                Accesses properties of objects.

            */
            students.Add(student);
            return CreatedAtAction(nameof(Get), new { id = student.StudentId }, student); //?
            /*
            does the following:

            Returns an HTTP 201 Created response, which is standard for successful resource creation.
            Sets the Location header to the URL of the newly created student (using the Get action and the new student's ID).
            Includes the newly created student object in the response body.
            In short:
            It tells the client that a new student was created, where to find it, and returns the student data.
            */
            /*
            Return Statement
            return ...; sends a response from the method.

            Method Call
            CreatedAtAction(...) is a method that creates a 201 Created HTTP response.
            
            nameof Operator
            nameof(Get) gets the string name "Get" of the method, making code refactoring-safe.
            
            Anonymous Object
            new { id = student.StudentId } creates an object with a property id for route values.
            
            Object Property Access
            student.StudentId accesses the StudentId property of the student object.
            
            Passing Multiple Arguments
            The method takes three arguments: the action name, route values, and the response body.
            
            Camel Case Naming
            Properties and variables use camel case (student.StudentId, id).

            */
        }
        /*
        public ActionResult<Student> Post(Student student) : 
        what this method does, what is going on under the hood?

        This method:

        What it does:

        Handles HTTP POST requests to add a new student.
        Receives a Student object from the request body.
        Assigns a unique StudentId to the new student.
        Adds the student to the in-memory students list.
        Returns a 201 Created response with the new student's details and a location header pointing to the GET endpoint for that student.
        Under the hood:

        The framework binds the incoming JSON data to the Student parameter.
        The method calculates the next available StudentId.
        The student is added to the static list, which acts as a temporary database.
        The method returns a response using CreatedAtAction, which:
        Sets the HTTP status code to 201 (Created).
        Includes the new student data in the response body.
        Sets the Location header to the URL where the new student can be retrieved.
        Summary:
        This method creates and stores a new student, then responds with all the details and a link to access that student via the API.
        */

        /// <summary>
        /// Update existing student by Id.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Student updatedStudent) //?
        /*does the following:

        Declares a public method named Put that handles HTTP PUT requests.
        The method takes two parameters:
            int id: the ID of the student to update.
            Student updatedStudent: the new data for the student.
        The return type is IActionResult, which allows the method to return different HTTP responses (like 404 Not Found or 204 No Content).
        */
        {
            var student = students.FirstOrDefault(s => s.StudentId == id); //?
            /*
                does the following:
                Searches the students list for the first student whose StudentId matches the given id.
                If a matching student is found, it assigns that student to the student variable.
                If no match is found, student will be null.
                It uses a LINQ method (FirstOrDefault) with a lambda expression to filter the list.
            */
            /*
            Implicit Typing (var)
            var lets the compiler infer the variable type from the right-hand side.
            
            LINQ Method (FirstOrDefault)
            FirstOrDefault is a LINQ extension method that returns the first matching element or null if none is found.
            
            Lambda Expression (s => s.StudentId == id)
            (s => s.StudentId == id) is a concise way to define a function that checks if a student's ID matches the given id.
            
            Object Property Access
            s.StudentId accesses the StudentId property of each Student object.
            
            Equality Comparison (==)
            Checks if two values are equal.
            
            Camel Case Naming
            Variable and property names use camel case (student, students, StudentId, id).
            */
            if (student == null) return NotFound();
            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            return NoContent();
        }

        /// <summary>
        /// Delete existing student by Id.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id);
            if (student == null) return NotFound();
            students.Remove(student);
            return NoContent();
        }


    }
}

/*
Difference between ActionResult and IActionResult:

IActionResult
An interface representing any possible HTTP response (e.g., Ok, NotFound, BadRequest).
Use when you want to return only status codes or responses, not strongly-typed data.
Example:
public IActionResult Delete(int id)
{
    // returns NoContent(), NotFound(), etc.
}

ActionResult<T>
A generic class that can return either a strongly-typed object (T) or any IActionResult response.
Use when you want to return data (like a model) or an error/status response.
Example:
public ActionResult<Student> Get(int id)
{
    // returns a Student object or NotFound()
}

Syntax/Conventions:
Use IActionResult for actions that only return status codes (no data).
Use ActionResult<T> for actions that may return data or status codes.
Both are commonly used in ASP.NET Core controllers for flexibility and clarity.

Summary:
IActionResult: for any response.
ActionResult<T>: for data or any response.
Choose based on whether your endpoint returns data or just status.
*/