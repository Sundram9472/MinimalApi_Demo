using System.ComponentModel.DataAnnotations;

namespace MinimalApi_Demo.Entities
{
    public class EmployeeAttendancSheet
    {
        [Key]
        public int EmployeeId { get; set; }

        public string? EmployeeName { get; set; } 
        
        public string? EmployeeTeam { get; set; }

        public string? EmployeeEmailId { get; set; }

        public int EmployeePresent { get; set; }

        public int EmployeeAbsent { get; set; }

        public int EmployeeTakeLeave { get; set; }
    }
}
