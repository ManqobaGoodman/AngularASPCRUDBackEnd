using AngularCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDBContext _studentDBContext;

        public StudentController(StudentDBContext studentDBContext)
        {
            _studentDBContext = studentDBContext;
        }

        [HttpGet]
        [Route("GetStudent")]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentDBContext.Student.ToArrayAsync();
        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<Student> AddStudent(Student objStudent)
        {
            _studentDBContext.Student.Add(objStudent);
            await _studentDBContext.SaveChangesAsync();
            return objStudent;
        }

        [HttpPatch]
        [Route("UpdateStudent/{id}")]
        public async Task<Student> UpdateStudent(Student objStudent)
        {
            _studentDBContext.Entry(objStudent).State = EntityState.Modified;
            await _studentDBContext.SaveChangesAsync();
            return objStudent;
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public bool DeleteStudent(int id)
        {
            bool isDeleted = false;

            var student = _studentDBContext.Student.Find(id);
            if (student != null)
            {
                isDeleted = true;
                _studentDBContext.Entry(student).State = EntityState.Deleted;
                _studentDBContext.SaveChanges();
            }
            return isDeleted;
        }
    }
}
