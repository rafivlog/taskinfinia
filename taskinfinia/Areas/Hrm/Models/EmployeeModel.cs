namespace taskinfinia.Areas.Hrm.Models
{
    public class EmployeeModel
    {
        public string empname { get; set; }
        public DateTime dtjoin { get; set; }
        public DateTime dtbirth { get; set; }
        public int dept_id { get; set; }
        public int desig_id { get; set; }
        public int salary { get; set; }
        public bool emp_status { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public string deptname { get; set; }

        public string designame { get; set;}
    }
}
