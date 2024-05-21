namespace Employee_management_system.Entities
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public int ManagerID { get; set; }
    }
}
