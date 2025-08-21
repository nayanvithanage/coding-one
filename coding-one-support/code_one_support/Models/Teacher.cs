namespace code_one_support.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        /*
        This concept is called **constructor overloading**.

        It means your class (`Teacher`) has multiple constructors with different parameter lists:
        - A parameterless constructor (`Teacher()`)
        - A constructor with parameters (`Teacher(int id, string name, string contactNumber)`)

        This allows you to create objects in different ways, depending on your needs.
        */
        public Teacher()
        { 
            
        }

        public Teacher(int id, string name, string contactNumber)
        {
            TeacherId = id;
            Name = name;
            ContactNumber = contactNumber;

        }
    }
}
