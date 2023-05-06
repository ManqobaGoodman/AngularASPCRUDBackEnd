using System.ComponentModel.DataAnnotations;

namespace AngularCRUD.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string Course { get; set; }
    }
}
