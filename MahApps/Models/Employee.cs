namespace MahApps.Models
{
    public class Employee
    {
        public Employee(string name, string dept, int code, string email)
        {
            Name = name;
            Dept = dept;
            Code = code;
            Email = email;
        }

        public string Name { get; set; }
        public string Dept { get; set; }
        public int Code { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Name} / {Dept}";
        }
    }
}