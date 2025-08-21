using Microsoft.AspNetCore.Mvc;
using coding_one.Models;

namespace coding_one
{
    /// <summary>
    /// Manage Teachers.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private static List<Teacher> teachers = new List<Teacher>();

        /// <summary>
        /// Gets all teachers.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Teacher>> Get()
        {
            return teachers;
        }

        /// <summary>
        /// Get teahcer by TeacherId.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Teacher> Get(int id)
        {
            var teacher = teachers.FirstOrDefault(t => t.TeacherId == id);
            if (teacher == null) return NotFound();
            return teacher;
        }

        /// <summary>
        /// Add a new teacher.
        /// </summary>
        [HttpPost]
        public ActionResult<Teacher> Post(Teacher teacher)
        {
            //increment the studentId if > 0 ? +1 : 1
            teacher.TeacherId = teachers.Count > 0 ? teachers.Max(t => t.TeacherId) + 1 : 1;
            //add the newly crated teacher to teachers list
            teachers.Add(teacher);
            //return status with student object
            return CreatedAtAction(nameof(Get), new { id = teacher.TeacherId }, teacher);
        }

        /// <summary>
        /// Update existing teacher.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Teacher updatedTeacher)
        {
            //filter the teacher by id with lambda expression and LINQ method
            var teacher = teachers.FirstOrDefault(t => t.TeacherId == id);
            if (teacher == null) return NotFound();
            teacher.Name = updatedTeacher.Name;
            teacher.ContactNumber = updatedTeacher.ContactNumber;

            return NoContent();
        }

        ///<summary>
        /// Delete existing teacher by id.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teacher = teachers.FirstOrDefault(t => t.TeacherId == id);
            if (teacher == null) return NotFound();
            teachers.Remove(teacher);
            return NoContent();
        }
    }
}