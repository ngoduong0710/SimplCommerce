using SimplCommerce.Infrastructure.Models;

namespace FIT.Module.Students.Models
{
    public class Student : EntityBase
    {
        public string StudentID { get; set; }
        public string FullName { get; set; }
        public bool isMale { get; set; }
        public int Age { get; set; }
    }
}
