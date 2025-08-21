namespace coding_one.Models
{
    public class Teacher
    {
        //lets give teacher a name, contact first. then in other cases, if we want, we can assign a class to a teacher
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
    }
}