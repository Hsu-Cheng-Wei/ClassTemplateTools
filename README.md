# Class程式碼產生器

## 用途
**單元測試mock資料from已存在資料庫做驗證**

## Demo

    public class Department
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }

    public class Employee
    {
        public Guid EmployeeId { get; set; }

        public string Name { get; set; }
    }

    public class App
    {
        static int main()
        {
            HashSet<Department> sut = new HashSet<Department>()
            {
                new Department()
                {
                    DepartmentId = 1,
                    DepartmentName = "左A",
                    Employees = new []
                    {
                        new Employee
                        {
                            EmployeeId = Guid.Parse("becc484a-d8f7-4569-ad35-720fe7a454fb"),
                            Name = "Jason",
                        }
                    }
                }
            };

            Console.WriteLine(sut.DumpToString());
        }
    }

## Result

    "new HashSet<Department>()\r\n{\r\n\tnew Department()\r\n\t{\r\n\t\tDepartmentId = 1,\r\n\t\tDepartmentName = \"左A\",\r\n\t\tEmployees = new[]\r\n\t\t{\r\n\t\t\tnew Employee()\r\n\t\t\t{\r\n\t\t\t\tEmployeeId = Guid.Parse(\"becc484a-d8f7-4569-ad35-720fe7a454fb\"),\r\n\t\t\t\tName = \"Jason\",\r\n\t\t\t},\r\n\t\t},\r\n\t},\r\n}"