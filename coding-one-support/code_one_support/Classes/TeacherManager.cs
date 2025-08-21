namespace code_one_support.Classes
{
    public class TeacherManager
    {
        private readonly List<Teacher> teachers = new List<Teacher>();

        public void AddTeacher(Teacher teacher)
        {
            teachers.Add(teacher);
        }

        public List<Teacher> GetTeachers()
        {
            return teachers;
        }
    }
}

/*
    do we need any constructor for these classes? i cant see any. why?

    You do not need to add constructors for these classes unless you want to set default values or require certain properties at object creation.
    In C#, if you do not define any constructor, the compiler automatically provides a default parameterless constructor. This allows you to create objects like new Teacher() or new TeacherManager() without any arguments.
    You only need to add a constructor if you want to initialize properties when creating the object, for example:
    
    public Teacher(int teacherId, string name, string contactNumber)
    {
        TeacherId = teacherId;
        Name = name;
        ContactNumber = contactNumber;
    }

    But for simple data classes, the default constructor is enough. That’s why you don’t see any explicit constructors.
*/